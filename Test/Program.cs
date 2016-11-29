using CTL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CTLDbContext dm = new CTLDbContext("DatabaseConnection"))
            {
                Console.WriteLine(dm.Database.Connection.ConnectionString);

                Console.WriteLine(dm.Faculties.Count());
                var a = dm.Cathedras.ToList();

                foreach (var cathedra in a)
                {
                    Console.WriteLine(cathedra.Faculty.Name);
                }
            }
        }
    }
}
