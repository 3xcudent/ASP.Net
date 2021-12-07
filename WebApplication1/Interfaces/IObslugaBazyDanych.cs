using System.Collections.Generic;
using WebApplication1.DAL.Models;

namespace WebApplication1.Interfaces
{
    public interface IObslugaBazyDanych
    {
        Zajecia DodajZajeciaDoPlanu(string podanaNazwa, string podanyTermin);
        List<Zajecia> PobierzPlanZajec();
    }
}