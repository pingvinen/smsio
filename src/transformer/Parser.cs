using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace transformer
{
	public class Parser
	{
		public Parser()
		{
		}

		public List<Sms> Parse(string filename)
		{
			var res = new List<Sms>();

			XDocument doc = XDocument.Load(filename);

			foreach (XElement elm in doc.Descendants("sms"))
			{
				res.Add(this.SmsFromXelement(elm));
			}

			return res;
		}

		private Sms SmsFromXelement(XElement elm)
		{
			Sms res = new Sms();

			res.Address = elm.Attribute("address").Value;
			res.Body = elm.Attribute("body").Value;
			res.ContactName = elm.Attribute("contact_name").Value;
			res.Date = this.DateTimeFromString(elm.Attribute("date").Value);
			res.DateSent = this.DateTimeFromString(elm.Attribute("date_sent").Value);
			res.Locked = elm.Attribute("locked").Value;
			res.Protocol = elm.Attribute("protocol").Value;
			res.Read = elm.Attribute("read").Value;
			res.ReadableDate = elm.Attribute("readable_date").Value;
			res.ScToa = elm.Attribute("sc_toa").Value;
			res.ServiceCenter = elm.Attribute("service_center").Value;
			res.Status = elm.Attribute("status").Value;
			res.Subject = elm.Attribute("subject").Value;
			res.Toa = elm.Attribute("toa").Value;
			res.Type = elm.Attribute("type").Value;

			return res;
		}

		private DateTime DateTimeFromString(string input)
		{
			if (String.IsNullOrEmpty(input) || input.Equals("null"))
			{
				return DateTime.MinValue;
			}

			DateTime res = DateTime.MinValue;

			try
			{
				var asint = Int64.Parse(input);

				res = this.FromUnixTime(asint);
			}

			catch (Exception ex)
			{
				int i = 1;
			}

			return res;
		}

		public DateTime FromUnixTime(long unixTime)
		{
			// from http://stackoverflow.com/questions/2883576/how-do-you-convert-epoch-time-in-c
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			epoch = epoch.AddMilliseconds(unixTime);
			epoch = epoch.AddHours(2);

			return epoch;
		}
	}
}