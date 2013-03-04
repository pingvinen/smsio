using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace SmsIO
{
	public class HtmlWriter
	{
		private static string GeneratedTimestamp = "${GeneratedTimestamp}";
		private static string MessageTemplateBegin = "${MessageTemplateBegin}";
		private static string MessageTemplateEnd = "${MessageTemplateEnd}";
		private static string MessageToFrom = "${Message.ToFrom}";
		private static string MessageToFromNumber = "${Message.ToFromNumber}";
		private static string MessageTimestamp = "${Message.Timestamp}";
		private static string MessageBody = "${Message.Body}";

		public HtmlWriter()
		{
			this.TemplateFile = "htmltemplate.html";
		}

		public string TemplateFile { get; set; }

		public void Output(List<Sms> list, string outputfilename)
		{
			StringBuilder sb = new StringBuilder();

			string templatehtml = File.ReadAllText(this.TemplateFile, Encoding.UTF8);

			string[] parts = templatehtml.Split(new string[]{MessageTemplateBegin, MessageTemplateEnd}, StringSplitOptions.RemoveEmptyEntries);
			string header = parts[0];
			string msgtemplate = parts[1];
			string footer = parts[2];

			//
			// file header
			//
			sb.Append(header.Replace(GeneratedTimestamp, DateTime.Now.ToString()));

			//
			// the messages
			//
			foreach (Sms cur in list)
			{
				sb.Append(this.SmsToHtml(cur, msgtemplate));
			}

			//
			// close up
			//
			sb.Append(footer);

			File.WriteAllText(outputfilename, sb.ToString(), Encoding.UTF8);
		}

		private string SmsToHtml(Sms sms, string template)
		{
			string res = template;
			string tmp;

			//
			// to/from
			//
			tmp = "From";
			if (sms.Type.Equals(XmlConstants.TypeSent))
			{
				tmp = "To";
			}
			res = res.Replace(MessageToFrom, tmp);

			//
			// number
			//
			tmp = sms.Address;
			if (!sms.ContactName.Equals(XmlConstants.UnknownContact))
			{
				tmp = String.Format("{0} ({1})", tmp, HttpUtility.HtmlEncode(sms.ContactName));
			}
			res = res.Replace(MessageToFromNumber, tmp);

			//
			// timestamp
			//
			res = res.Replace(MessageTimestamp, HttpUtility.HtmlEncode(sms.Date.ToString()));

			//
			// body
			//
			res = res.Replace(MessageBody, HttpUtility.HtmlEncode(sms.Body));

			return res;
		}
	}
}