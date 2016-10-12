using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LR_2_code_Cch.Controller 
{
    class Student : IFormattable
    {
        public string StudentName;
        public string StudentSurname;
        public string StudentSex;  // {Male/Female}
        public string StudentID;   // {AA123456 (2 serial and 6 digit)}
        public int StudentCource;
        public double StudentGPA;

        public Student()
        {

        }

        public Student(string name, string surname, string sex, string id, int cource, double gpa)
        {
            StudentName = name;
            StudentSurname = surname;
            StudentSex = sex;
            StudentID = id;
            StudentCource = cource;
            StudentGPA = gpa;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                    //return "ID - " + this.StudentID + " Cource - " + this.StudentCource + " Name - " + this.StudentName + " Surname - " + this.StudentSurname + " Sex - " + this.StudentSex + " GPA - " + this.StudentGPA;
                    return String.Format("ID - {0,-9} Cource - {1,-2} Name - {2,-10}  Surname - {3,-10} Sex - {4,-6} GPA - {5}", this.StudentID, this.StudentCource, this.StudentName, this.StudentSurname, this.StudentSex, this.StudentGPA);
                case "O":
                    return this.StudentName + " " + this.StudentSurname + " " + this.StudentSex + " " + this.StudentID + " " + this.StudentCource + " " + this.StudentGPA;
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
