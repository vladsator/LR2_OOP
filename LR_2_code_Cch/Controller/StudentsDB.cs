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

        public List<Student> FindStudentUsingPharameters(string subname, string subsurname)
        {
            return (from item in StudentList
                    where item.StudentName.Contains(subname) && item.StudentSurname.Contains(subsurname)
                    select item as Student).ToList<Student>();
        }


    }
}
