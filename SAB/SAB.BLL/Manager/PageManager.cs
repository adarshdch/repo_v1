
using SAB.BLL.Entities.Page;
using SAB.BLL.Repository.Page;
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


		public bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			return _pageRepository.Get(theRequest, theResponse);
		}
	}
}
