using System;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	class MainClass
	{
		public static XmlWriterSettings XWSettings = new XmlWriterSettings()
		{
			CheckCharacters = false,
			CloseOutput = false,
//			ConformanceLevel = ConformanceLevel.Fragment,
			Encoding = ASCIIEncoding.ASCII,
			Indent = true,
			IndentChars = "  ",
			NamespaceHandling = NamespaceHandling.OmitDuplicates,
			NewLineChars = "\n",
			NewLineHandling = NewLineHandling.None,
			NewLineOnAttributes = false,
			OmitXmlDeclaration = false
		};
		
		public static void Main(string[] args)
		{
			try
			{
				string assName = args [0];
				string outFile = Path.GetDirectoryName (Assembly.GetEntryAssembly ().CodeBase).Substring (5) + "/" + Path.GetFileName (args [0]) + ".xml";
				string htmlFile = outFile.Replace (".xml", ".html");
				
				XmlSerializer xs = new XmlSerializer (typeof(ReflectedContainer));
				ReflectedAssembly ass = new ReflectedAssembly (assName);
				
				Console.Write (string.Format ("Output XML reflection for {0} (to console and to {1})\n [Y/n] ?", assName, outFile));
				ConsoleKey input = Console.ReadKey ().Key;
				if (input != ConsoleKey.N)
				{
					Console.WriteLine ("\n");
					using (MemoryStream ms = new MemoryStream())
					{
						using (XmlWriter xw = XmlWriter.Create (ms, XWSettings))
						{
							xs.Serialize (xw, new ReflectedContainer () { Assembly = ass });
						}
						
						if (File.Exists (outFile))
							File.Delete (outFile);
						using (Stream fs = File.OpenWrite (outFile), cs = Console.OpenStandardOutput ())
						{
							ms.WriteTo (fs);
							ms.WriteTo (cs);
						}

//						if (File.Exists (htmlFile))
//							File.Delete (htmlFile);
//						using (Stream hs = File.OpenWrite (htmlFile))
//						{
//							using (XmlWriter xw = XmlWriter.Create(hs, XWSettings))
//							{
//								foreach (ReflectedType rt in ass.Types)
//									rt.WriteHtml(xw);
//							}
//						}
					}
				}
				else
					Console.WriteLine ("Cancelled, exiting..");
			}
			catch (Exception ex)
			{
				Console.WriteLine ("! Exception : " + ex.ToString () + " : " + ex.Message);
			}
			finally
			{
				
			}
		}
	}
}
