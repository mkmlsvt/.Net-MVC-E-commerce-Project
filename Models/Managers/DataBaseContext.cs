using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebFinal.Models.Managers
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Urunler> Urunler { get; set; } 
        public DbSet<Uyeler> Uyeler { get; set; }
        public DbSet<Adminler> Adminler { get; set; }
        public DataBaseContext()
        {
            Database.SetInitializer(new VeriTabanıOlusturucu());
        }
    }
    public class VeriTabanıOlusturucu : CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            Adminler Admin = new Adminler();
            Admin.AdminAdi = "Mehmet";
            Admin.Sifre = "123";
            context.Adminler.Add(Admin);
            Urunler Urun = new Urunler();
            Urun.Ad = "Hoodie";
            Urun.Fiyat = 100;
            Urun.Erkekmi = true;
            Urun.Indirim = false;
            Urun.Resim = "~/images/Hoodie1.jpg";
            context.Urunler.Add(Urun);
            for (int i = 0; i < 3; i++)
            {
                Uyeler Uye = new Uyeler();
                Uye.KullaniciAdi = FakeData.NameData.GetFirstName();
                Uye.Parola = FakeData.NameData.GetSurname();                  
                context.Uyeler.Add(Uye);
            }
            context.SaveChanges();
            List<Uyeler> TumUyeler = context.Uyeler.ToList();
            context.SaveChanges();
        }
        
    }
}