using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaderCommenter
{
    public class Comment
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Program { get; set; }
        public string Filename { get; set; }

        public Comment() : this(" ", " ", " ", " ", " ")
        {

        }

        public Comment(string name, string email, string date, string program, string filename)
        {
            Name = name;
            Email = email;
            Date = date;
            Program = program;
            Filename = filename;
        }

        public override string ToString()
        {
            const int padding = -40;
            string comment = "/*************************************************\n";
            comment += $" * Name:\t\t{Name, padding}\n";
            comment += $" * Email:\t\t{Email, padding}\n";
            comment += $" * Program:\t\t{Program, padding}\n";
            comment += $" * Filename:\t{Filename, padding}\n";
            comment += $" * Date:\t\t{Date, padding}\n";
            comment += "*************************************************/";

            return comment;
        }
    }
}
