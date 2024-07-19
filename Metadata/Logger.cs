using System;
using System.IO;

namespace Metadata
{
   static class Logger
	{
		public static void Log(object message)
		{
			File.AppendAllText(@".\Metadata.log", DateTime.Now + ":" + message + Environment.NewLine);
		}
	}
}
