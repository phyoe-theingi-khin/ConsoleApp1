namespace PTKDotNetCore.WebApp.Models
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
}
