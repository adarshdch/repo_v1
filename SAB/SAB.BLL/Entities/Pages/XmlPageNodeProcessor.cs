
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public abstract class XmlPageNodeProcessor : IXmlPageNodeProcessor
	{
		public abstract bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse);
	}
}
