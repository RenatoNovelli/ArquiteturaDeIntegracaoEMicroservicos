namespace GeekBurger.Dashboard.Services
{
    public class ReceiveMessagesFactory
    {
        public ReceiveMessagesFactory()
        {
            //By default, creates this receivemessageservice
            CreateNew("uicommand", "html");
            CreateNew("orderpaid", "html", "filter-store", "8048e9ec-80fe-4bad-bc2a-e4f4a75c834e");
        }

        public ReceiveMessagesService CreateNew(string topic, string subscription, string filterName = null, string filter = null)
        {
            return new ReceiveMessagesService(topic, subscription, filterName, filter);
        }
    }
}
