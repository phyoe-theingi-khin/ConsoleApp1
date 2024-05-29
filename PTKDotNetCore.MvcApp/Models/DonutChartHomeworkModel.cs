using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTKDotNetCore.MvcApp.Models;

[Table("Tbl_DonutChart")]
public class DonutChartHomeworkModel
{
    [Key]
    public int Id { get; set; }
    public string Browsers { get; set; }
    public string Versions { get; set; }
    public decimal Usages { get; set; }
}
