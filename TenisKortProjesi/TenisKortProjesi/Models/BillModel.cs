using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TenisKortProjesi.Models
{
    public class BillModel
    {
        public int Id { get; set; }
        public int? FieldId { get; set; }
        public double? Amounth { get; set; }
        public string Hour { get; set; }
        public DateTime Date { get; set; }
    }
}