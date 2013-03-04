using System;
using ServiceStack.DataAnnotations;

namespace SmsIO
{
	public class Sms
	{
		public Sms()
		{
			this.Date = DateTime.MinValue;
			this.DateSent = DateTime.MinValue;
		}

		[AutoIncrement]
		public int Id { get; set; }

		[Index]
		public int Checksum { get; set; }

		public string Protocol { get; set; }
		public string Address { get; set; }
		public DateTime Date { get; set; }
		public string Type { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public string Toa { get; set; }
		public string ScToa { get; set; }
		public string ServiceCenter { get; set; }
		public string Read { get; set; }
		public string Status { get; set; }
		public string Locked { get; set; }
		public DateTime DateSent { get; set; }
		public string ReadableDate { get; set; }
		public string ContactName { get; set; }
	}
}