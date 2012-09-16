using Microsoft.Practices.Unity;

namespace McKinsey.GameOfLife
{
    public class IoCContainer
    {
        private static IUnityContainer _container;
        private static readonly object Lock = new object();

        public static IUnityContainer Container
        {
            get
            {

                if (_container == default(IUnityContainer))
                {
                    lock (Lock)
                    {
                        _container = new UnityContainer();

                    }
                }
                return _container;
            }
        }
    }
}
