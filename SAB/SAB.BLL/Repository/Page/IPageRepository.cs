
using SAB.BLL.Entities.Page;
using SAB.Infra.Entities;

namespace SAB.BLL.Repository.Page
{
	public interface IPageRepository
	{
		bool Get(CusRequest<PageRequest> thePageRequest, CusResponse<PageResponse> thResponse);
	}
}
