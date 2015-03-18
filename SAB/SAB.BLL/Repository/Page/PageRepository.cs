
using SAB.BLL.Entities.Page;
using SAB.Infra.Entities;

namespace SAB.BLL.Repository.Page
{
	public class PageRepository : IPageRepository
	{
		
		public CusResponse<PageResponse> Get(CusRequest<PageRequest> thePageRequest)
		{
			return new CusResponse<PageResponse>()
			{
				Status = TaskStatus.Success,
				Data = new PageResponse()
				{
					Result = "This is page response"
				}
			};
		}
	}
}
