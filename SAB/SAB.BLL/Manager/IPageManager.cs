
using SAB.BLL.Entities.Page;
using SAB.Infra.Entities;

namespace SAB.BLL.Manager
{
	public interface IPageManager
	{
		CusResponse<PageResponse> Get(CusRequest<PageRequest> thePageRequest);
	}
}
