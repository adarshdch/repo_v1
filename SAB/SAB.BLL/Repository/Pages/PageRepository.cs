using System.IO;
using System.Xml.Linq;
using SAB.BLL.Entities.Pages;
using SAB.DAL.Ef6;
using SAB.Entities;
using SAB.Framework.DbRepository.DataContext;
using SAB.Framework.DbRepository.Ef6;
using SAB.Framework.DbRepository.UnitOfWork;
using SAB.Infra.Config;
using SAB.Infra.Entities;

namespace SAB.BLL.Repository.Pages
{
	public class PageRepository : IPageRepository
	{

		private void Initialize(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			using (IDataContextAsync aDbContextAsync = OrgDbContextFactory.GetOrgDbConext(theRequest.Data.OrgCode))
			using (IUnitOfWork unitOfWork = new UnitOfWork(aDbContextAsync))
			{
				theRequest.Data.Page = unitOfWork.Repository<Page>().Find(theRequest.Data.PageCode);
				theRequest.Data.Page.Template = unitOfWork.Repository<Template>().Find(theRequest.Data.Page.TemplateCode);
			}

			theRequest.Data.PageDocument = XDocument.Load(Path.Combine(WebConfig.AppSetting.PageBasePath, theRequest.Data.Page.RelativePath));
			theRequest.Data.Template = File.ReadAllText(Path.Combine(WebConfig.AppSetting.TemplateBasePath, theRequest.Data.Page.Template.RelativePath));
		}

		public bool Get(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			Initialize(theRequest, theResponse);
			

			

			var aPageProcessor = new FacadePageProcessor();

			return aPageProcessor.Process(theRequest, theResponse);
		}
	}
}
