using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenisKortProjesi.Models;
namespace TenisKortProjesi.Models
{
    public class ViewModel
    {
        public Users users { get; set; }
        public List<Hours> hours { get; set; }
        public List<Fields> fields { get; set; }

        public List<Rezervation> rezervation { get; set; }

        public List<BillModel> BillLister { get; set; }
    }
}