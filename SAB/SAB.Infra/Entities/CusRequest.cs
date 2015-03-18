
namespace SAB.Infra.Entities
{
	public class CusRequest<T> where T : class 
	{
		public T Data { get; set; }
	}
}
