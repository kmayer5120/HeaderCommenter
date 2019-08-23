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

            return true;
        }

        public bool WriteFile()
        {
            if (fileContents == null) return false;

            fileContents.Insert(0, Comment.ToString());
            File.WriteAllLines(Filename, fileContents);
            return true;

        }
    }
}
