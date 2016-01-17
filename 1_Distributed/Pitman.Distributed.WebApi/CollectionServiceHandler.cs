using Pitman.Application.DataCollection;

namespace Pitman.Distributed.WebApi
{
    public class CollectionServiceHandler
    {
        private static IServiceManager _managerInstance;

        public static IServiceManager Manager
        {
            get { return _managerInstance; }
            set { _managerInstance = value; }
        }
    }
}
