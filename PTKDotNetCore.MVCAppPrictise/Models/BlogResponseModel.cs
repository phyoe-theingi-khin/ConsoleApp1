using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTKDotNetCore.MVCAppPrictise.Models
{
    public class BlogResponseModel
    {
        public int pageNo { get; set; }

        public int pageSize { get; set; }
        public int pageCount { get; set; }
        //public bool isEndOfPage { get; set; }
        public bool isEndOfPage => pageNo >= pageCount;
        public List<BlogModel> Data { get; set; }
    }
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
}
