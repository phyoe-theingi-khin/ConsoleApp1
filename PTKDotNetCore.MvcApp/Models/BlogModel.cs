using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTKDotNetCore.MvcApp.Models;

[Table("Tbl_Blog")]
public class BlogModel
{
    [Key]
    //[Column("BlogId")]
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}
public class BlogMessageResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
[Table("Tbl_PageStatistics")]
public class PageStatisticsModel
{
    [Key]
    public int PageStatisticsId { get; set; }
    public int SessionDuration { get; set; }
    public int PageViews { get; set; }
    public int TotalVisits { get; set; }
    public string CreatedDate { get; set; }
}
[Table("Tbl_RadarChart")]
public class RadarModel
{
    [Key]
    public int Id { get; set;}
    public int Series { get; set;}
    public string Month { get; set;} 

}
public class ApexChartRadarResponseModel
{
    public List<int> Series { get; set; }   
    public List<string> Month { get; set; } 
}
[Table("Tbl_BarChart")]
public class BarChartModel
{
    [Key]
    public int Id { get; set;}  
    public string Color { get; set;}  
    public int Votes { get; set;}

}
public class ChartJsBarChartResponseModel
{
    public List<int> Votes { get; set;}  
    public List<string> Color { get; set;}  
}
[Table("Tbl_DonutChart")]
public class DonutChartHomeworkModel
{
    [Key]
    public int Id { get; set; }
    public string Browsers { get; set; }
    public string Versions { get; set; }
    public float Usages { get; set; }
}
public class DonutChartHomeworkResponseModel
{
    public List<string> Browsers { get; set; }
    public List<string> Versions { get; set; }
    public List<float> Usages { get; set; }

}