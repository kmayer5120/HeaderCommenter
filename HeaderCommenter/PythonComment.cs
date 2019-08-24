using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaderCommenter
{
    class PythonComment : Comment
    {
        public PythonComment() : this("", "", "", "", "") { }

        public PythonComment(string name, string email, string date, string program, string filename) : base(name, email, date, program, filename) { }

        public override string ToString()
        {
            const int padding = -40;
            string comment = "'''\n";
            comment += $" * Name:\t\t{Name, padding}\n";
            comment += $" * Email:\t\t{Email, padding}\n";
            comment += $" * Program:\t\t{Program, padding}\n";
            comment += $" * Filename:\t{Filename, padding}\n";
            comment += $" * Date:\t\t{Date, padding}\n";
            comment += "'''";
            return comment;
        }

    }
}
