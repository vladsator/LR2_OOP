using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_code_Cch.Controller
{
    class StudentsDB
    {
        List<Student> StudentList = new List<Student>();
        Model.StudentManipulation StudentDataManipulator = new Model.StudentManipulation();

        public StudentsDB()
        {
            StudentList = StudentDataManipulator.ReadFile();
        }

        public int NullStringToIntParser(string str)
        {
            int Out;
            int.TryParse(str, out Out);
            return Out;
        }

        public void SetFilePath(string filepath)
        {
            StudentDataManipulator.FilePathGetSet = filepath;
            StudentList.Clear();
            StudentList = StudentDataManipulator.ReadFile();
        }

        public string GetFilePath()
        {
            return StudentDataManipulator.FilePathGetSet;
        }

        public void WriteFile()
        {
            StudentDataManipulator.WriteFile(StudentList);
        }

        public void AddStudent(Student student)
        {
            StudentList.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            StudentList.Remove(student);

        }

        public string GetStudentsList()
        {
            string std = "";
            foreach (Student student in StudentList)
            {
                std += String.Format("{0}\n",student);
            }
            return std;
        }

        
        public List<Student> FindStudentUsingPharameters(string subname, string subsurname, string sex, string subid, int cource, string mark_param)
        {
            var q = (from row in StudentList select row as Student);
            if (subname != "")
                q = q.Where(row => row.StudentName.ToUpper().Contains(subname.ToUpper()));
            if (subsurname != "")
                q = q.Where(row => row.StudentSurname.ToUpper().Contains(subsurname.ToUpper()));
            if (sex != "")
                q = q.Where(row => row.StudentSex.ToUpper() == sex.ToUpper());
            if (subid != "")
                q = q.Where(row => row.StudentID.ToUpper().Contains(subid.ToUpper()));
            if (cource != 0)
                q = q.Where(row=> row.StudentCource == cource);

            if (mark_param != "")
            {
                string inequalitySign = "";
                string num = "";
                foreach (char ch in mark_param)
                {
                    if ((ch == '<') || (ch == '>') || (ch == '='))
                    {
                        inequalitySign += ch;
                    }
                    else
                        if (Char.IsDigit(ch) || (ch == '.'))
                    {
                        num += ch;
                    }
                }
                switch (inequalitySign)
                {
                    case "<":
                        q = q.Where(row => row.StudentGPA < double.Parse(num));
                        break;
                    case ">":
                        q = q.Where(row => row.StudentGPA > double.Parse(num));
                        break;
                    case "=":
                        q = q.Where(row => row.StudentGPA == double.Parse(num));
                        break;
                    case "<>":
                        q = q.Where(row => row.StudentGPA != double.Parse(num));
                        break;
                }
            }
            
            return q.ToList<Student>();        
        }


    }
}
