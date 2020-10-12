using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class addressModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(8)")]
        public string cep { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string state { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string city { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string street { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string neighborhood { get; set; }
    }
}
