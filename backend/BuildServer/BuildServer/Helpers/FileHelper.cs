using System.IO;

namespace BuildServer.Helpers
{
    public class FileHelper
    {
        public static void WriteToFile(string path, string data)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.Write(data);
            }
        }
    }
}