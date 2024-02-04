using System;

namespace Metadata
{
   static class Logger
	{
		public static void Log(object message)
		{
			System.IO.File.AppendAllText(@".\Metadata.log", DateTime.Now + ":" + message + Environment.NewLine);
		}
	}
}
