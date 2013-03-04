using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.OrmLite;
using System.Data;
using System.IO;

namespace SmsIO
{
	public enum OutputFormat
	{
		RichTextFormat = 0,
		Html = 1
	}
}