using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTKDotNetCore.PractiseWebApp.Models
{
    [Table("Tbl_Product")]
    public class ProductModels
    {
        [Key]
        //[Column("ProductId")]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }


    }
}
