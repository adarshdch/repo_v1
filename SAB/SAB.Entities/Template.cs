using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using SAB.Framework.DbRepository.Infra;
using SAB.Infra.Config;

namespace SAB.Entities
{
	public class Template : Entity 
	{

		[Key]
		public string TemplateCode { get; set; }
		
		public string RelativePath { get; set; }

		public virtual ICollection<Page> Pages { get; set; }


		[NotMapped]
		public string FullFilePath
		{
			get { return Path.Combine(WebConfig.AppSetting.TemplateBasePath, RelativePath); }
		}

	}
}
