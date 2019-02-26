using GeekBurger.Dashboard.Interfaces.Service;

namespace GeekBurger.Dashboard.Services
{
    public class ReceiveMessagesFactory : IReceiveMessagesFactory
    {
        private readonly ISalesService _salesService;

        public ReceiveMessagesFactory(ISalesService salesService)
        {
            _salesService = salesService;
            //By default, creates this receivemessageservice
            CreateNew("orderchanged", "Dashboard");
        }

        public ReceiveMessagesService CreateNew(string topic, string subscription, string filterName = null, string filter = null)
        {
            return new ReceiveMessagesService(_salesService, topic, subscription, filterName, filter);
        }
    }
}
