using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFinal.Models;

namespace WebFinal.ViewsModels
{
    public class HomePageViewModel
    {
        public List<Urunler> Urunler { get; set; }
        public List<Uyeler> Uyeler { get; set; }
    }
}