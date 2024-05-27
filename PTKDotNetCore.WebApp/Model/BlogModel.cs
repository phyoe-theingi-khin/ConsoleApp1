using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTKDotNetCore.WebApp.Model;

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