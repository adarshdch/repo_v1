
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public interface IXmlPageNodeProcessor
	{
		bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse);
	}
}
