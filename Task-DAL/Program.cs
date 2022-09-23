using System;
using Task_DAL.IntalioDbModel;

namespace Task_DAL
{
    class Program
    {
        IntalioDbContext db = new IntalioDbContext();
        static void Main(string[] args)
        {
            var dbCl = new dbClass();
            var person = new TblEmployee();
            person.EName = "Mohammad";
            person.EPosition = "Engineer";
            var test = dbCl.addEmployees(person);
        }
    }
}
