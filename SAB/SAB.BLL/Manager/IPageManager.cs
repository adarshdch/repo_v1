
using SAB.BLL.Entities.Page;
using SAB.Infra.Entities;

namespace SAB.BLL.Manager
{
	public interface IPageManager
	{
		bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse );
	}
}
