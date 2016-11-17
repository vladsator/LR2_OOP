using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace LR_2_code_Cch.View
{
    class Menu
    {
        Controller.StudentsDB StdDB = new Controller.StudentsDB();
        public void UI_Starter()
        {
            UIMainMenu();
            string reg = @"[1-6]";
            string Question = ">>";
            Console.Write(Question);
            int choose = int.Parse(InputDataRegCheck(Console.ReadLine(), reg, Question));
            switch (choose)
            {
                case 1:
                    UIAddStudent();
                    break;
                case 2:
                    FindStudent();
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

        public string InputDataRegCheck(string InputA, string RegFormat, string OutputQ)
        {
            Regex reg = new Regex(RegFormat);
            while (!reg.IsMatch(InputA)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Not in accordance with the rules, please try again.");
                Console.Write(OutputQ);
                InputA = Console.ReadLine();
            }
            return InputA;
        }

        void UIAddStudent()
        {
            Console.Clear();
            Controller.Student AddingStudent = new Controller.Student();
            string reg = @"^[А-ЯA-Z]{1}[а-яa-z]";
            string Question = "Enter student name >>";
            Console.Write(Question);
            AddingStudent.StudentName = InputDataRegCheck(Console.ReadLine(), reg, Question);
            /////////////////////////////////////////////////////////////////////////////
            Question = "Enter student surname >>";
            Console.Write(Question);
            AddingStudent.StudentSurname = InputDataRegCheck(Console.ReadLine(), reg, Question);
            /////////////////////////////////////////////////////////////////////////////
            List<string> MaleVariatnsLib = new List<string>();
            MaleVariatnsLib.Add("MALE");
            MaleVariatnsLib.Add("M");
            List<string> FemaleVariatnsLib = new List<string>();
            MaleVariatnsLib.Add("FEMALE");
            MaleVariatnsLib.Add("W");
            reg = @"(^[Mm]{1}(ale){1}$)|(^[Ff]{1}(emale){1}$)|(^[Mm]$)|(^[Ww]$)";
            Question = "Enter student sex >>";
            Console.Write(Question);
            if (MaleVariatnsLib.Contains(InputDataRegCheck(Console.ReadLine(), reg, Question).ToUpperInvariant()))
                AddingStudent.StudentSex = "Male";
            else
                if (FemaleVariatnsLib.Contains(InputDataRegCheck(Console.ReadLine(), reg, Question).ToUpperInvariant()))
                AddingStudent.StudentSex = "Female";
            ////////////////////////////////////////////////////////////////////////////
            reg = @"^[A-Za-zА-Яа-я]{2}[0-9]{6}$";
            Question = "Enter student ID >>";
            Console.Write(Question);
            AddingStudent.StudentID = InputDataRegCheck(Console.ReadLine(), reg, Question).ToUpperInvariant();
            ///////////////////////////////////////////////////////////////////////////
            reg = @"[0-9]{1}";
            Question = "Enter student Cource >>";
            Console.Write(Question);
            AddingStudent.StudentCource = int.Parse(InputDataRegCheck(Console.ReadLine(), reg, Question).ToUpperInvariant());
            ///////////////////////////////////////////////////////////////////////////
            reg = @"^[0-9]{0,1}[.]{0,1}[0-9]*";
            Question = "Enter student GPA >>";/////////////////
            Console.Write(Question);
            AddingStudent.StudentGPA = double.Parse(InputDataRegCheck(Console.ReadLine(), reg, Question).ToUpperInvariant());
            //////////////////////////////////////////////////////////////////////////
            Console.WriteLine(AddingStudent);
            Console.ReadKey();
            StdDB.AddStudent(AddingStudent);
            Console.Clear();
            UI_Starter();
        }

        void FindStudent()
        {
            Console.Clear();
            List<string> ParamList = new List<string>();
            //////////////////////////////////////////////////////////////////////////
            string reg = @"(^[А-Яа-яA-Za-z])||()";
            string Question = "Enter student name or subname >>";
            Console.Write(Question);
            ParamList.Add(InputDataRegCheck(Console.ReadLine(), reg, Question));
            //////////////////////////////////////////////////////////////////////////
            Question = "Enter student surname or subsurname >>";
            Console.Write(Question);
            ParamList.Add(InputDataRegCheck(Console.ReadLine(), reg, Question));
            //////////////////////////////////////////////////////////////////////////
            reg = @"^[А-Яа-яA-Za-z] || ()";
            Question = "Enter student sex (Male/Female) >>";
            Console.Write(Question);
            ParamList.Add(InputDataRegCheck(Console.ReadLine(), reg, Question));
            //////////////////////////////////////////////////////////////////////////
            reg = @"^[А-Яа-яA-Za-z0-9] || ()";
            Question = "Enter student subid >>";
            Console.Write(Question);
            ParamList.Add(InputDataRegCheck(Console.ReadLine(), reg, Question));
            //////////////////////////////////////////////////////////////////////////
            reg = @"^[0-9]{1} || () ";
            Question = "Enter student Cource >>";
            Console.Write(Question);
            ParamList.Add(InputDataRegCheck(Console.ReadLine(), reg, Question));
            //////////////////////////////////////////////////////////////////////////
            reg = @"^[<>=]{0,2}[0-9][.]{0,1}[0-9]* || ()";
            Question = "Enter sign and student GPA >>";
            Console.Write(Question);
            ParamList.Add(InputDataRegCheck(Console.ReadLine(), reg, Question));
            //////////////////////////////////////////////////////////////////////////
            foreach (Controller.Student student in StdDB.FindStudentUsingPharameters(ParamList[0], ParamList[1], ParamList[2], ParamList[3], StdDB.NullStringToIntParser(ParamList[4]), ParamList[5]))
            {
                Console.WriteLine("{0}", student);
            }
            Console.ReadKey();
            Console.Clear();
            UI_Starter();
        }

        void GetStudentsList()
        {
            Console.WriteLine("{0}\n\n", StdDB.GetStudentsList());
            UI_Starter();
        }

        void SetDBFile()
        {
            Console.WriteLine("Would u like to save previous file?(Y\\N)");
            string RegChecker = Console.ReadLine().ToUpper();
            Regex reg = new Regex("[YyNn]");
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Not in accordance with the rules, please try again.");
                Console.Write("Enter filepath >>");
                RegChecker = Console.ReadLine().ToUpper();
            }
            if (RegChecker == "Y")
            {
                StdDB.WriteFile();
                Console.WriteLine("File {0} successfully saved!", StdDB.GetFilePath());
                Console.ReadKey();
            }
            Console.Clear();
            reg = new Regex(@"([A-Za-zА-Яа-я_0-9:\])([A-Za-zА-Яа-я_0-9][.](txt))$");
            Console.Write("Enter filepath >>");
            RegChecker = Console.ReadLine().ToLower();
            while (!reg.IsMatch(RegChecker)) // цикл если условие не выполняется.
            {
                Console.WriteLine("Not in accordance with the rules, please try again.");
                Console.Write("Enter filepath >>");
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
