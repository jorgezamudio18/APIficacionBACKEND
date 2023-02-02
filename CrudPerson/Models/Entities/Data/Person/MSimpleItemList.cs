using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.Models.Entities.Data.Person {
    public class MSimpleItemList {
        public int? id { get; set; }
        public string name { get; set; }

        public string lastname { get; set; }

        public DateTime? datetime { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public int? age { get; set; }
    }
}
