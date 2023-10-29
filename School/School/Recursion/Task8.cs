using System.Collections.Generic;
using System.IO;

namespace School.Recursion
{
    public class Task8
    {
        public static List<string> GetAllFiles(string folderPath) 
        {
            var files = new List<string>();

            files.AddRange(Directory.GetFiles(folderPath));

            var subdirectories = Directory.GetDirectories(folderPath);

            foreach (string subdirectory in subdirectories)
            {
                files.AddRange(GetAllFiles(subdirectory));
            }

            return files;
        }
    }
}
