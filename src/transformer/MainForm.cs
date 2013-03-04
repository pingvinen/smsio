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

		public MainForm()
		{
			this.InitializeComponent();

			string dbfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SMS-to-RTF.db");

			this.dbFactory = new OrmLiteConnectionFactory(String.Format("Data Source={0};Version=3;", dbfile), false, SqliteDialect.Provider);
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonSelectFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dia = new OpenFileDialog();
			dia.CheckFileExists = true;
			dia.CheckPathExists = true;
			dia.Filter = "XML files|*.xml";
			dia.Title = "Select the SMS backup xml file";

			DialogResult res = dia.ShowDialog();

			if (res == DialogResult.OK)
			{
				this.RunTransformation(dia.FileName);

				MessageBox.Show("All done");
			}
		}

		private void RunTransformation(string filename)
		{
			Parser parser = new Parser();
			List<Sms> list = parser.Parse(filename);

			this.SaveEntries(list);

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

			RtfWriter writer = new RtfWriter();
			writer.Output(sorted, filename);
		}

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
	}
}