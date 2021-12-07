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

            if (context.Zajecia.Any())
            {
                return;
            }
            else
            {
                var zajecia = new Zajecia[]
                {
                    new Zajecia("Programowanie .NET", DateTime.Now.AddDays(2)),
                    new Zajecia("Programowanie C#", DateTime.Now.AddDays(2).AddHours(4)),
                    new Zajecia("Programowanie Java", DateTime.Now.AddDays(1).AddHours(2)),
                    new Zajecia("Bazy danych", DateTime.Now.AddDays(3).AddHours(1)),
                    new Zajecia("Wzorce projektowe", DateTime.Now.AddDays(5).AddHours(6)),
                    new Zajecia("Zarządzanie projektem", DateTime.Now.AddDays(7).AddHours(3)),
                    new Zajecia("UX", DateTime.Now.AddDays(4).AddHours(3)),
                    new Zajecia("Microsoft", DateTime.Now.AddDays(1).AddHours(2))
                };
                foreach (Zajecia Z in zajecia)
                {
                    context.Zajecia.Add(Z);
                }
            }

            

            if (context.Student.Any())
            {
                return;
            }
            else
            {
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
                foreach (Student S in studenci)
                {
                    context.Student.Add(S);
                }
            }
            
            context.SaveChanges();
        }
    }
}
