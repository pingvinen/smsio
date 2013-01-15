using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace transformer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			this.InitializeComponent();
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

			List<Sms> sorted =	(
									from y in list
									orderby y.Address ascending, y.Date ascending
									select y
								).ToList();

			RtfWriter writer = new RtfWriter();
			writer.Output(sorted, filename);
		}
	}
}