
namespace SAB.Infra.Entities
{
	public class CusResponse<T> where T: class 
	{
		public T Data { get; set; }

		public TaskStatus Status { get; set; }
	}
}
