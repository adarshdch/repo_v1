
using SAB.Infra.Entities;

namespace SAB.BLL.Entities.Pages
{
	public class FormXmlPageProcessor : BaseXmlPageProcessor
	{
		public override bool Process(CusRequest<PageRequest> theRequest, CusResponse<PageResponse> theResponse)
		{
			return true;
		}
	}
}
