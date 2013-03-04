using System;
using System.Collections.Generic;
using System.IO;
using DW.RtfWriter;

namespace SmsIO
{
	public class RtfWriter
	{
		public RtfWriter()
		{
		}

		public void Output(List<Sms> list, string outputFilename)
		{
			RtfDocument doc = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.English);

			FontDescriptor fontBody = doc.createFont("Courier New");
			int fontSizeBody = 12;
			int fontSizeSmall = 10;

			RtfParagraph par;
			RtfCharFormat format;

			//
			// file header
			//
			par = doc.addParagraph();
			par.DefaultCharFormat.Font = fontBody;
			par.DefaultCharFormat.FontSize = fontSizeSmall;
			par.Text = String.Format("Generated\nOn {0}", DateTime.Now);

			this.AddEmptyLine(doc);


			string fromto = String.Empty;

			//
			// the smses
			//
			foreach (Sms sms in list)
			{
				//
				// from / to
				//
				fromto = "From";
				if (sms.Type.Equals(XmlConstants.TypeSent))
				{
					fromto = "To";
				}
				par = doc.addParagraph();
				par.DefaultCharFormat.Font = fontBody;
				par.DefaultCharFormat.FontSize = fontSizeBody;
				par.Text = String.Format("{0}: {1}", fromto, sms.Address);
				format = par.addCharFormat(0, fromto.Length);
				format.FontStyle.addStyle(FontStyleFlag.Bold);

				if (!sms.ContactName.Equals(XmlConstants.UnknownContact))
				{
					par.Text = String.Format("{0} ({1})", par.Text, sms.ContactName);
				}

				//
				// date
				//
				par = doc.addParagraph();
				par.DefaultCharFormat.Font = fontBody;
				par.DefaultCharFormat.FontSize = fontSizeBody;
				par.Text = sms.Date.ToString();

				this.AddEmptyLine(doc);

				//
				// body
				//
				par = doc.addParagraph();
				par.DefaultCharFormat.Font = fontBody;
				par.DefaultCharFormat.FontSize = fontSizeBody;
				par.Text = sms.Body;

				this.AddEmptyLine(doc);

				//
				// separator
				//
				par = doc.addParagraph();
				par.DefaultCharFormat.Font = fontBody;
				par.DefaultCharFormat.FontSize = fontSizeBody;
				par.Text = "---";

				this.AddEmptyLine(doc);
			}

			doc.save(outputFilename);
		}

		private void AddEmptyLine(RtfDocument doc)
		{
			doc.addParagraph();
		}
	}
}