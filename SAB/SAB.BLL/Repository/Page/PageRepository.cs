
using SAB.BLL.Entities.Pages;
using SAB.Infra.Entities;

namespace SAB.BLL.Repository.Page
{
	public class PageRepository : IPageRepository
	{

		public bool Get(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			var aPageProcessor = new FacadePageProcessor();

			return aPageProcessor.Process(theRequest, theResponse);
		}
	}
}
