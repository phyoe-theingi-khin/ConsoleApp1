using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTKDotNetCore.MvcApp.Models;

[Table("Tbl_RadarChart")]
public class RadarModel
{
    [Key]
    public int Id { get; set;}
    public int Series { get; set;}
    public string Month { get; set;} 

}
