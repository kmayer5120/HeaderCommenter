using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaderCommenter
{
    class SourceFile
    {
        public string Filename { get; set; }
        public List<string> fileContents { get; set; }
        public Comment Comment { get; set; }

        public SourceFile() : this("", new Comment()) { }

        public SourceFile(string filename, Comment comment)
        {
            Filename = filename;
            Comment = comment;
        }

        public bool ReadFile()
        {
            if (Filename == null) return false;

            fileContents = File.ReadLines(Filename).ToList();
            foreach (string line  in fileContents)
            {
                Console.WriteLine(line); 
            }

            return true;
        }

        public bool WriteFile()
        {
            if (fileContents == null) return false;

            //File.WriteAllText(Filename, Comment.ToString()); 
            fileContents.Insert(0, Comment.ToString());
            File.WriteAllLines(Filename, fileContents);
            return true;

        }
    }
}
