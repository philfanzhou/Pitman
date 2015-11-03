using System.Collections.Generic;

namespace Pitman.Application.DataCollection
{
    internal class CollectionServiceContainer
    {
        private readonly Dictionary<string, ICollectionService> _serviceList
            = new Dictionary<string, ICollectionService>();

        internal CollectionServiceContainer()
        {
            _serviceList.Add("RealTimePriceServices", new RealTimePriceServices());
        }

        public IReadOnlyDictionary<string, ICollectionService> Services
        {
            get { return this._serviceList; }
        }
    }
}
