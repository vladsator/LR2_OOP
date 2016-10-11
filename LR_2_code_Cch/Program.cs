using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2_code_Cch
{
    class Program
    {
        static void Main(string[] args)
        {
            //MENUTEST
            View.Menu mnu = new View.Menu();
            mnu.UI_Starter();
            //mnu.UIMainMenu();
            //mnu.UIAddStudent();
            //mnu.SetDBFile();
            //mnu.GetStudentsList();


            //MODEL TEST
            //Model.StudentManipulation test = new Model.StudentManipulation("Students_DB.txt");
            //List<Controller.Student> STDLST = test.ReadFile();
            //foreach (Controller.Student std in STDLST)
            //{
            //    Console.WriteLine("{0}", std);
            //}
            //test.FilePath = "Students_DB1.txt";
            //Console.WriteLine(test.WriteFile(STDLST));


            Console.ReadLine();

        }
    }
}
