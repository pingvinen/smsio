using System;
using System.Text;

namespace transformer
{
	public static class ChecksumCalculator
	{
		public static int ForSms(Sms sms)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(sms.Address);
			sb.Append(sms.Body);
			sb.Append(sms.ContactName);
			sb.Append(sms.Date.ToString());
			sb.Append(sms.DateSent.ToString());
			sb.Append(sms.Locked);
			sb.Append(sms.Protocol);
			sb.Append(sms.Read);
			sb.Append(sms.ReadableDate);
			sb.Append(sms.ScToa);
			sb.Append(sms.ServiceCenter);
			sb.Append(sms.Status);
			sb.Append(sms.Subject);
			sb.Append(sms.Toa);
			sb.Append(sms.Type);

			return sb.ToString().GetHashCode();
		}
	}
}