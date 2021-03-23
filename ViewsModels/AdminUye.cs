using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFinal.Models;

namespace WebFinal.ViewsModels
{
    public class AdminUye
    {
        public List<Adminler> Adminler{ get; set; }
        public List<Uyeler> Uyeler { get; set; }
    }
}