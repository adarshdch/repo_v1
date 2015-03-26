
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using SAB.Entities;
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class PageRequest
	{

		public PageRequest()
		{
			OrgCode = "Master";
		}

		public DbOperation Operation { get; set; }

		public string OrgCode { get; set; }

		[Required]
		public string PageCode { get; set; }

		public Page Page { get; set; }

		public ResponseContentType ContentType { get; set; }

		public XDocument PageDocument { get; set; }

		public string Template { get; set; }
		
	}
}
