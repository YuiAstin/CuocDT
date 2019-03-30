using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Helper
{
	public static class FileHelper
	{
		private static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LogFile.txt";

		public static void WriteToFile(FileLine line)
		{
			FileStream fs = new FileStream(filePath,FileMode.Append,FileAccess.Write,FileShare.Read);
			StreamWriter sw = new StreamWriter(fs);
			sw.WriteLine(line.ToString());
			sw.Close();
			fs.Close();
		}

		public static IList<FileLine> ReadFromFile()
		{
			var lines = new List<FileLine>();
			FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
			StreamReader sr = new StreamReader(fs);
			string s;
			while ((s = sr.ReadLine()) != null)
			{
				string[] strArr = s.Split('\t');
				FileLine line = new FileLine
				{
					SIMId = int.Parse(strArr[0]),
					StartingTime = DateTime.Parse(strArr[1]),
					EndingTime = DateTime.Parse(strArr[2])
				};
				lines.Add(line);
			}
            fs.Close();
            sr.Close();
			return lines;
		}       

		public static void EraseFile()
		{
			File.Create(filePath);
		}
	}

	public class FileLine
	{
		public int SIMId { get; set; }

		public DateTime StartingTime { get; set; }

		public DateTime EndingTime { get; set; }

		public override string ToString()
		{
			return SIMId + "\t" + StartingTime + "\t" + EndingTime;
		}
	}
}
