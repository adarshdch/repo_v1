
using System.ComponentModel.DataAnnotations;
using SAB.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class PageRequest
	{
		[Required]
		public string PageCode { get; set; }

		public Page Page { get; set; }

		public ResponseContentType ContentType { get; set; }

		

	}
}
