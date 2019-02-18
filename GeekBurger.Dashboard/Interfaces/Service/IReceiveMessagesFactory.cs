using GeekBurger.Dashboard.Services;

namespace GeekBurger.Dashboard.Interfaces.Service
{
    public interface IReceiveMessagesFactory
    {
        ReceiveMessagesService CreateNew(string topic, string subscription, string filterName = null, string filter = null);
    }
}
