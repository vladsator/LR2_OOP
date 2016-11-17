using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LR_2_code_Cch.Model
{
    class StudentManipulation
    {
        string FilePath;

        Encoding win1251 = Encoding.GetEncoding(1251);

        public StudentManipulation()
        {
            SetDefaultFilePath();
        }

        public void SetDefaultFilePath()
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

                using (StreamReader file = new StreamReader(FilePath, win1251))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] TempSubStrings = line.Split(' ');
                        try
                        {
                            StudentList.Add(new Controller.Student(TempSubStrings[0], TempSubStrings[1], TempSubStrings[2], TempSubStrings[3], int.Parse(TempSubStrings[4]), double.Parse(TempSubStrings[5])));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong table format (Name, Surname, Sex, ID, Cource GPA)");
                            Console.ReadKey();
                            SetDefaultFilePath();
                            StudentList = ReadFile();
                            return StudentList;
                        }
                    }
                }      
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка при работе с файлом.");
                SetDefaultFilePath();
                StudentList = ReadFile();
                return StudentList;
            }
            return StudentList;
        }

        //public bool wWriteFile(List<Controller.Student> StudentList)
        //{
        //    Encoding win1251 = Encoding.GetEncoding(1251);
        //    File.WriteAllLines(FilePath, (from item in StudentList select item.ToString("O", null) as string).ToArray(), win1251);
        //    return true;
        //}

        public bool WriteFile(List<Controller.Student> StudentList)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, false, win1251))
            {
                foreach (string str in (from item in StudentList select item.ToString("O", null) as string).ToArray())
                {
                    sw.WriteLine(str);
                }
                return true;
            }
        }
    }
}
