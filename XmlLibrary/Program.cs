using System;
using System.IO;
using ClassesDll;

namespace XmlLibrary
{
    class Program : ArrayLibrary.Program
    {
        static void Main()
        {
            Console.Title = "«Электронная библиотека» версия 1.2, разработала Жигалова О.А., студентка группы ИСП 19-1";

            ClassesDll.XmlLibrary library = new ClassesDll.XmlLibrary();

            if (!File.Exists(library.GetFilePath()))
            {
                Functions.AddDummyBooks(library);
            }

            Console.WriteLine("Добро пожаловать в XmlLibrary");
            Console.WriteLine("Ваша библиотека сохраняется в файле:");
            Console.WriteLine(library.GetFilePath());
            Functions.PressAnyKey();

            MainMenu(library);
        }
    }
}