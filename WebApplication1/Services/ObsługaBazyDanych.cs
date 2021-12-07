using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Contexts;
using WebApplication1.DAL.Models;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class ObslugaBazyDanych : IObslugaBazyDanych
    {
        private readonly DziekanatContext bazaDanychDziekanatu;

        public ObslugaBazyDanych(DziekanatContext bazaDanychDziekanatu)
        {
            this.bazaDanychDziekanatu = bazaDanychDziekanatu;
        }

        public Zajecia DodajZajeciaDoPlanu(string podanaNazwa, string podanyTermin)
        {
            using var transaction = bazaDanychDziekanatu.Database.BeginTransaction();

            try
            {
                Zajecia zajecia = new Zajecia(podanaNazwa, DateTime.Now);
                Debug.WriteLine($"Id: {zajecia.ID}");

                bazaDanychDziekanatu.Zajecia.Add(zajecia);
                bazaDanychDziekanatu.SaveChanges();
                Debug.WriteLine($"Id: {zajecia.ID}");

                DateTime data = Convert.ToDateTime(podanyTermin);
                if (data.Date <= DateTime.Now.Date)
                    throw new Exception("Data nie może być wcześniejsza niż dzisiaj");
                Debug.WriteLine($"TerminZajec: {zajecia.TerminZajec}");

                bazaDanychDziekanatu.Zajecia.Where(z => z.ID == zajecia.ID).First().TerminZajec = data;
                bazaDanychDziekanatu.SaveChanges();
                Debug.WriteLine($"TerminZajec: {zajecia.TerminZajec}");

                transaction.Commit();

                return zajecia;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);

                transaction.Rollback();

                return null;
            }
        }

        public List<Zajecia> PobierzPlanZajec()
        {
            return bazaDanychDziekanatu.Zajecia.ToList();
        }
    }
}
