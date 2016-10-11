using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_code_Cch.Model
{
    class StudentManipulation
    {
        string FilePath;

        public StudentManipulation()
        {
            FilePath = "Students_DB.txt";
        }

        public string FilePathGetSet
        {
            get
            {
                return FilePath;
            }

            set
            {
                FilePath = value;
            }
        }

        public List<Controller.Student> ReadFile()
        {
            string line;
            List<Controller.Student> StudentList = new List<Controller.Student>();
            try
            {
                Encoding win1251 = Encoding.GetEncoding(1251);
                StreamReader file = new StreamReader(FilePath, win1251);               
                while ((line = file.ReadLine()) != null)
                {
                    string[] TempSubStrings = line.Split(' ');
                    StudentList.Add(new Controller.Student(TempSubStrings[0], TempSubStrings[1], TempSubStrings[2], TempSubStrings[3], double.Parse(TempSubStrings[4])));
                }
                file.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка при работе с файлом.");
                return null; ////////////////////////////////////////////
            }
            return StudentList;
        }

        public bool WriteFile(List<Controller.Student> StudentList)
        {
            Encoding win1251 = Encoding.GetEncoding(1251);
            File.WriteAllLines(FilePath, (from item in StudentList select item.ToString("O", null) as string).ToArray(), win1251);
            return true;
        }
    }
}
