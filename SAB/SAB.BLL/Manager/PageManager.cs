
using SAB.BLL.Entities.Pages;
using SAB.BLL.Repository.Pages;
using SAB.Infra.Entities;

namespace SAB.BLL.Manager
{
	public class PageManager : IPageManager
	{
		private readonly IPageRepository _pageRepository;

		public PageManager(IPageRepository thPageRepository)
		{
			_pageRepository = thPageRepository;
		}

		private static void InitializeRequest(CusRequest<PageRequest> theRequest)
		{

		}


		public bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			InitializeRequest(theRequest);
			return _pageRepository.Get(theRequest, theResponse);
		}
	}
}
