using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.OrmLite;
using System.Data;
using System.IO;

namespace transformer
{
	public partial class MainForm : Form
	{
		private OrmLiteConnectionFactory dbFactory;
		private string appFolder;
		private string dbFile;

		public MainForm()
		{
			this.InitializeComponent();

			this.appFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SmsIO");
			this.dbFile = Path.Combine(this.appFolder, "SmsIO.db");

			// make sure app folder exists
			if (!Directory.Exists(this.appFolder))
			{
				Directory.CreateDirectory(this.appFolder);
			}

			this.dbFactory = new OrmLiteConnectionFactory(String.Format("Data Source={0};Version=3;", this.dbFile), false, SqliteDialect.Provider);
		}

		#region Button close
		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion Button close

		#region Button load file
		private void buttonLoadFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dia = new OpenFileDialog();
			dia.CheckFileExists = true;
			dia.CheckPathExists = true;
			dia.Filter = "XML files|*.xml";
			dia.Title = "Select the SMS backup xml file";
			dia.InitialDirectory = Environment.CurrentDirectory;

			DialogResult res = dia.ShowDialog();

			if (res == DialogResult.OK)
			{
				Parser parser = new Parser();
				List<Sms> list = parser.Parse(dia.FileName);

				this.SaveEntries(list);

				MessageBox.Show("All done");
			}
		}
		#endregion Button load file

		#region Button open db folder
		private void buttonOpenDbFolder_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(this.appFolder);
		}
		#endregion Button open db folder

		#region Button output as rtf
		private void buttonOutputAsRtf_Click(object sender, EventArgs e)
		{
			this.Output(OutputFormat.RichTextFormat);
		}
		#endregion Button output as rtf

		#region Output
		private string Output(OutputFormat format)
		{
			switch (format)
			{
				case OutputFormat.RichTextFormat:
				{
					string filename = Path.Combine(this.appFolder, String.Format("{0}.rtf", this.GetTimestamp()));

					RtfWriter writer = new RtfWriter();
					writer.Output(this.GetSortedEntries(), filename);
					return filename;
				}

				default:
				{
					throw new ArgumentException(String.Format("The output format '{0}' is not supported", format));
				}
			}
		}

		private string GetTimestamp()
		{
			return DateTime.Now.ToString("yyyy_MM_dd__hh_mm");
		}
		#endregion Output

		#region Get sorted entries
		private List<Sms> GetSortedEntries()
		{
			List<Sms> fromDb = new List<Sms>();

			using (IDbConnection db = this.dbFactory.OpenDbConnection())
			{
				fromDb = db.Select<Sms>();
			}

			List<Sms> sorted =	(
									from y in fromDb
									orderby y.Address ascending, y.Date ascending
									select y
								).ToList();

			return sorted;
		}
		#endregion Get sorted entries

		#region Save
		private void SaveEntries(List<Sms> list)
		{
			using (IDbConnection db = this.dbFactory.OpenDbConnection())
			{
				db.CreateTableIfNotExists<Sms>();

				foreach (Sms cur in list)
				{
					cur.Checksum = ChecksumCalculator.ForSms(cur);

					if (db.Select<Sms>(s => s.Checksum == cur.Checksum).Count > 0)
					{
						//
						// this sms is already in the database,
						// so skip it
						//
						continue;
					}

					db.Insert<Sms>(cur);
				}
			}
		}
		#endregion Save
	}
}