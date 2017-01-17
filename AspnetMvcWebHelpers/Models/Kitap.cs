using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetMvcWebHelpers.Models
{
    public class Kitap
    {
        public static List<Kitap> Kitaplar { get; set; }

        public Guid Id { get; set; }
        public string Adi { get; set; }
        public string Yazar { get; set; }
        public DateTime YayinTarihi { get; set; }
        public decimal Fiyat { get; set; }

        protected Kitap()
        {

        }

        public static void GenerateFakeData(int count)
        {
            if (Kitaplar == null)
            {
                Kitaplar = GetFakeData(count);
            }
        }

        private static List<Kitap> GetFakeData(int count)
        {
            List<Kitap> kitaplar = new List<Models.Kitap>();

            for (int i = 0; i < count; i++)
            {
                kitaplar.Add(new Kitap()
                {
                    Id = Guid.NewGuid(),
                    Adi = FakeData.NameData.GetCompanyName(),
                    Yazar = FakeData.NameData.GetFullName(),
                    Fiyat = FakeData.NumberData.GetNumber(10, 75),
                    YayinTarihi = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(2), DateTime.Now)
                });
            }

            return kitaplar;
        }
    }
}