
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using SAB.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class PageRequest
	{
		public string OrgCode { get; set; }

		[Required]
		public string PageCode { get; set; }

		public Page Page { get; set; }

		public ResponseContentType ContentType { get; set; }

		public XDocument PageDocument { get; set; }

		public string Template { get; set; }
		
	}
}
