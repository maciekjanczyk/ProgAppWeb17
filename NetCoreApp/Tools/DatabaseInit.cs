using NetCoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Tools
{
    public class DatabaseInit
    {
        public static void Initialize(OsobyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Osoba.Any())
            {
                return;
            }

            context.Add(new Osoba { Imie = "Maciej", Nazwisko = "Janczyk" });
            context.Add(new Osoba { Imie = "Jan", Nazwisko = "Kowalski" });
            context.Add(new Osoba { Imie = "Barack", Nazwisko = "Obama" });
            context.Add(new Osoba { Imie = "Walter", Nazwisko = "White" });

            context.SaveChanges();
        }
    }
}
