using System;
using System.Diagnostics;
using OldEF6Library;
namespace ConsoleAppTestCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var oldClass = new  OldEF6Class();

            var userCount = oldClass.GetUserCount();

            Console.WriteLine($"User Count read from DB via EF: {userCount}");

            Console.ReadLine();
        }
    }
}
