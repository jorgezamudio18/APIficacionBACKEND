using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.Models.Entities.Data.Person {
    public class MPerson {
        public int? id { get; set; }
        public string name { get; set; }
  
        public string lastname { get; set; }
    
        public DateTime? datetime { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public int? age { get; set; }
    }
}
