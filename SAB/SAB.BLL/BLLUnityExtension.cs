
using Microsoft.Practices.Unity;
using SAB.BLL.Manager;
using SAB.BLL.Repository.Page;

namespace SAB.BLL
{
	public class BLLUnityExtension : UnityContainerExtension
	{

		protected override void Initialize()
		{
			//Container.RegisterType<IPageContentManager, PageContentManager>(new ContainerControlledLifetimeManager(), new Interceptor<InterfaceInterceptor>(), 
			//	new InterceptionBehavior<TestInterceptionBehavior>());
			
			Container.RegisterType<IPageRepository, PageRepository>(new ContainerControlledLifetimeManager());
			Container.RegisterType<IPageManager, PageManager>(new ContainerControlledLifetimeManager());
			
		}
	}
}
