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
        public string StudentSex; // {Male/Female}
        public string StudentID;   // {AA123456 (2 serial and 6 digit)}
        public double StudentGPA;

        public Student()
        {

        }

        public Student(string name, string surname, string sex, string id, double gpa)
        {
            StudentName = name;
            StudentSurname = surname;
            StudentSex = sex;
            StudentID = id;
            StudentGPA = gpa;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return "ID - " + this.StudentID + " Name - " + this.StudentName + " Surname - " + this.StudentSurname + " Sex - " + this.StudentSex + " GPA - " + this.StudentGPA;
                case "O":
                    return this.StudentName + " " + this.StudentSurname + " " + this.StudentSex + " " + this.StudentID + " " + this.StudentGPA;
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
