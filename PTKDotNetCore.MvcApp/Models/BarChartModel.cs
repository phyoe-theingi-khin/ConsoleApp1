using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTKDotNetCore.MvcApp.Models;

[Table("Tbl_BarChart")]
public class BarChartModel
{
    [Key]
    public int Id { get; set;}  
    public string Color { get; set;}  
    public int Votes { get; set;}

}
