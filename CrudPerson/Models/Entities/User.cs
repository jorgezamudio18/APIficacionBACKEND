using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CrudPerson.Models.Entities
{
    [Table("User")]
    public partial class User
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string lastname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? datetime { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        [StringLength(50)]
        public string gender { get; set; }
        public int? age { get; set; }
    }
}
