
using SAB.BLL.Entities.Pages;
using SAB.Infra.Entities;

namespace SAB.BLL.Manager
{
	public interface IPageManager
	{
		bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse );
	}
}
