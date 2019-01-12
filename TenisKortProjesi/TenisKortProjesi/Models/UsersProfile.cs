using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TenisKortProjesi.Models
{
    public class UsersProfile
    {
        public int id { get; set; }
        public Nullable<int> UsersId { get; set; }
        public Nullable<int> FieldsId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Hour { get; set; }
        public Nullable<bool> IsComplated { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
    }
}