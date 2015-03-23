using SAB.BLL.Entities.Pages;
using SAB.Infra.Entities;

namespace SAB.BLL.Repository.Pages
{
	public interface IPageRepository
	{
		bool Get(CusRequest<PageRequest> thePageRequest, CusResponse<PageResponse> thResponse);
	}
}
