namespace PTKDotNetCore.MvcApp.Models;

public class DonutChartHomeworkResponseModel
{
    public List<string> Browsers { get; set; }
    public List<string> Versions { get; set; }
    public List<decimal> Usages { get; set; }
}