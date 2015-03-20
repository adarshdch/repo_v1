
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public interface IPageProcessor
	{
		bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse);
	}
}
