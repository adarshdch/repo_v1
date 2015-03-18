
using SAB.BLL.Entities.Page;
using SAB.Infra.Entities;

namespace SAB.BLL.Repository.Page
{
	public interface IPageRepository
	{
		CusResponse<PageResponse> Get(CusRequest<PageRequest> thePageRequest);
	}
}
