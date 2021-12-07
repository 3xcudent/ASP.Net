using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Models;

namespace WebApplication1.DAL.Contexts
{
    public class DziekanatDatabaseInitializer
    {
        public static void Initialize(DziekanatContext context)
        {
            context.Database.EnsureCreated();

           
            var zajecia = new Zajecia[]
            {
                new Zajecia{NazwaZajec = "Programowanie .NET",      TerminZajec = DateTime.Now.AddDays(2)},
                new Zajecia{NazwaZajec = "Programowanie C#",        TerminZajec = DateTime.Now.AddDays(2).AddHours(4)},
                new Zajecia{NazwaZajec = "Programowanie Java",      TerminZajec = DateTime.Now.AddDays(1).AddHours(2)},
                new Zajecia{NazwaZajec = "Bazy danych",             TerminZajec = DateTime.Now.AddDays(3).AddHours(1)},
                new Zajecia{NazwaZajec = "Wzorce projektowe",       TerminZajec = DateTime.Now.AddDays(5).AddHours(6)},
                new Zajecia{NazwaZajec = "Zarządzanie projektem",   TerminZajec = DateTime.Now.AddDays(7).AddHours(3)},
                new Zajecia{NazwaZajec = "UX",                      TerminZajec = DateTime.Now.AddDays(4).AddHours(3)},
                new Zajecia{NazwaZajec = "Microsoft",               TerminZajec = DateTime.Now.AddDays(1).AddHours(2)}
            };

            context.Database.EnsureCreated();
            if (context.Student.Any())
            {
                return;
            }
            var studenci = new Student[] 
            { 
                new Student { NumerIndeksu = "111", Imie = "Adam", Nazwisko = "Nowak" },
                new Student { NumerIndeksu = "222", Imie = "Andrzej", Nazwisko = "Duda" },
                new Student { NumerIndeksu = "333", Imie = "Anna", Nazwisko = "Rożek" },
                new Student { NumerIndeksu = "444", Imie = "Justyna", Nazwisko = "Dzik" },
                new Student { NumerIndeksu = "555", Imie = "Micha  ł", Nazwisko = "Lis" },
                new Student { NumerIndeksu = "666", Imie = "Daria", Nazwisko = "Nowak" },
                new Student { NumerIndeksu = "777", Imie = "Mateusz", Nazwisko = "Mostowiak" } 
            };
            foreach (Zajecia Z in zajecia)
            {
                context.Zajecia.Add(Z);
            }
            foreach (Student S in studenci)
            {
                context.Student.Add(S);
            }

            context.SaveChanges();
        }
    }
}
