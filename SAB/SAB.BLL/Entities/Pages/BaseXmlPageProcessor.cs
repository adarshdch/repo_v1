
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public abstract class BaseXmlPageProcessor : IPageProcessor
	{

		public abstract bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse);
	}
}
