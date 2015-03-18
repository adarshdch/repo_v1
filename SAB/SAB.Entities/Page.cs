using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using SAB.Framework.DbRepository.Infra;
using SAB.Infra.Config;

namespace SAB.Entities
{
	public class Page : Entity
	{
		[Key]
		public string PageCode { get; set; }

		public string TemplateCode { get; set; }

		[ForeignKey("TemplateCode")]
		public Template Template { get; set; }
		
		public PageType PageType { get; set; }
		public string RelativePath { get; set; }

		[NotMapped]
		public string FullFilePath
		{
			get { return Path.Combine(WebConfig.AppSetting.PageBasePath, RelativePath); }
		}
	
	}
}
