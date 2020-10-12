using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class userModel
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string name{ get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string cellPhone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string email{ get; set; }

        public int age { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string bloodGroup { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string password { get; set; }

        public virtual addressModel addressModel { get; set; }

    }
}
