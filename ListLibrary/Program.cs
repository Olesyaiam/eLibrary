using System;
using ClassesDll;

namespace ListLibrary
{
    // сделали наследование от ArrayLibrary.Program
    class Program : ArrayLibrary.Program
    {
        new static void Main(string[] args)
        {
            Console.Title = "«Электронная библиотека» версия 1.1, разработала Жигалова О.А., студентка группы ИСП 19-1";

            LibraryBase library = new ListLibrary();
            Functions.AddDummyBooks(library);
            MainMenu(library);
        }
    }
}