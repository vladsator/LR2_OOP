using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_code_Cch.View
{
    class Menu
    {
        Controller.StudentsDB StdDB = new Controller.StudentsDB();
        public void UI_Starter()
        {
            UIMainMenu();
            Regex reg = new Regex("[123456]");
            string RegChecker = null;
            Console.Write(">>");
            RegChecker = Console.ReadLine();
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {    
                Console.WriteLine("Не соответствует правилам, нажмите Enter и повторите попытку.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(">>");
                RegChecker = Console.ReadLine();
            }
            int choose = int.Parse(RegChecker);
            switch (choose)
            {
                case 1:
                    UIAddStudent();
                    break;
                case 2:
                    break;
                case 3:
                    GetStudentsList();
                    break;
                case 4:
                    SetDBFile();
                    break;
                case 5:
                    SaveANDExit();
                    break;
                case 6:
                    Exit();
                    break;
            }
        }
        void UIMainMenu()
        {
            string str = String.Format("Hello {0}, Welcome to the student management system.\n", Environment.UserName.ToUpperInvariant());
            str += String.Format("Now open the file:{0}\n\n", StdDB.GetFilePath());
            str += String.Format("1: Add student\n");
            str += String.Format("2: Find students\n");
            str += String.Format("3: Get students list\n");
            str += String.Format("4: Select the database file (Default - \"StudentsDB.txt\")\n");
            str += String.Format("5: Save & Exit\n");
            str += String.Format("6: Exit\n");
            Console.WriteLine(str);
        }

        void UIAddStudent()
        {
            Console.Clear();
            Controller.Student AddingStudent = new Controller.Student();
            Regex reg = new Regex("^[А-ЯA-Z]{1}[а-яa-z]");
            string RegChecker = null;
            Console.Write("Enter student name >> ");
            RegChecker = Console.ReadLine();
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Не соответствует правилам, повторите попытку.");
                Console.Write("Enter student name >> ");
                RegChecker = Console.ReadLine();

            }
            AddingStudent.StudentName = RegChecker;

            /////////////////////////////////////////////////////////////////////////////
            Console.Write("Enter student surname >> ");
            RegChecker = Console.ReadLine();
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Не соответствует правилам, повторите попытку.");
                Console.Write("Enter student surname >> ");
                RegChecker = Console.ReadLine();

            }
            AddingStudent.StudentSurname = RegChecker;

            /////////////////////////////////////////////////////////////////////////////
            List<string> MaleVariatnsLib = new List<string>();
            MaleVariatnsLib.Add("MALE");
            MaleVariatnsLib.Add("M");

            List<string> FemaleVariatnsLib = new List<string>();
            MaleVariatnsLib.Add("FEMALE");
            MaleVariatnsLib.Add("W");

            reg = new Regex("(^[Mm]{1}(ale){1}$)|(^[Ff]{1}(emale){1}$)|(^[Mm]$)|(^[Ww]$)");
            Console.Write("Enter student sex >> ");
            RegChecker = Console.ReadLine();
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Не соответствует правилам, повторите попытку.");
                Console.Write("Enter student sex >> ");
                RegChecker = Console.ReadLine();

            }
            if (MaleVariatnsLib.Contains(RegChecker.ToUpperInvariant()))
                AddingStudent.StudentSex = "Male";
            else
                if (FemaleVariatnsLib.Contains(RegChecker.ToUpperInvariant()))
                    AddingStudent.StudentSex = "Female";

            ////////////////////////////////////////////////////////////////////////////
            reg = new Regex("^[A-Za-zА-Яа-я]{2}[0-9]{6}$");
            Console.Write("Enter student ID >> ");
            RegChecker = Console.ReadLine();
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Не соответствует правилам, повторите попытку.");
                Console.Write("Enter student ID >> ");
                RegChecker = Console.ReadLine();

            }
            AddingStudent.StudentID = RegChecker.ToUpperInvariant();

            ///////////////////////////////////////////////////////////////////////////
            reg = new Regex("^[0-9][.]*[0-9]*");
            Console.Write("Enter student GPA >> ");
            RegChecker = Console.ReadLine();
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Не соответствует правилам, повторите попытку.");
                Console.Write("Enter student GPA >> ");
                RegChecker = Console.ReadLine();

            }
            AddingStudent.StudentGPA = double.Parse(RegChecker);

            //////////////////////////////////////////////////////////////////////////
            Console.WriteLine(AddingStudent);
            StdDB.AddStudent(AddingStudent);
            Console.Clear();
            UI_Starter();
        }

        void GetStudentsList()
        {
            Console.WriteLine("{0}\n\n",StdDB.GetStudentsList());
            UI_Starter();
        }

        void SetDBFile()
        {
            Console.WriteLine("Would u like to save previous file?(Y\\N)");
            if (Console.ReadLine() == "Y" || Console.ReadLine() == "y")
            {
                StdDB.WriteFile();
                Console.WriteLine("File {0} successfully saved!", StdDB.GetFilePath());
                Console.ReadKey();
            }
            Console.Clear();
            Regex reg = new Regex(@"([A-Za-zА-Яа-я_0-9:\])([A-Za-zА-Яа-я_0-9][.](txt))$");
            Console.Write("Enter filepath >> ");
            string RegChecker = Console.ReadLine().ToLower();
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Не соответствует правилам, повторите попытку.");
                Console.Write("Enter filepath >> ");
                RegChecker = Console.ReadLine().ToLower();
            }
            StdDB.SetFilePath(RegChecker);
            Console.Clear();
            UI_Starter();
        }

        void SaveANDExit()
        {
            StdDB.WriteFile();
            Exit();
        }

        void Exit()
        {
            Environment.Exit(0);
        }
    }
}
