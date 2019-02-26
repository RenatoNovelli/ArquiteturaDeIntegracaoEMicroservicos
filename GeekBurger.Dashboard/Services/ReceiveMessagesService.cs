using GeekBurger.Dashboard.Interfaces.Service;
using GeekBurger.Dashboard.ServiceBus;
using GeekBurger.Orders.Contract.Messages;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Services
{
    public class ReceiveMessagesService
    {
        private readonly string _topicName;
        private readonly string _subscriptionName;
        private static ServiceBusConfiguration _serviceBusConfiguration;

        private readonly ISalesService _salesService;

        public ReceiveMessagesService(
                                      ISalesService salesService,
                                      string topic,
                                      string subscription,
                                      string filterName = null,
                                      string filter = null)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _salesService = salesService;
            _serviceBusConfiguration = configuration.GetSection("serviceBus").Get<ServiceBusConfiguration>();

            _topicName = topic;
            _subscriptionName = subscription;

            ReceiveMessages(filterName, filter);
        }

        public void ReceiveMessages(string filterName = null, string filter = null)
        {
            var subscriptionClient = new SubscriptionClient
                (_serviceBusConfiguration.ConnectionString, _topicName, _subscriptionName);

            var mo = new MessageHandlerOptions(ExceptionHandle) { AutoComplete = true };

            if (filterName != null && filter != null)
            {
                const string defaultRule = "$default";

                if (subscriptionClient.GetRulesAsync().Result.Any(x => x.Name == defaultRule))
                    subscriptionClient.RemoveRuleAsync(defaultRule).Wait();

                if (subscriptionClient.GetRulesAsync().Result.All(x => x.Name != filterName))
                    subscriptionClient.AddRuleAsync(new RuleDescription
                    {
                        Filter = new CorrelationFilter { Label = filter },
                        Name = filterName
                    }).Wait();

            }

            subscriptionClient.RegisterMessageHandler(Handle, mo);
        }

        public Task Handle(Message message, CancellationToken arg2)
        {
            var messageString = "";
            if (message.Body != null)
                messageString = Encoding.UTF8.GetString(message.Body);

            //TODO: be more generic
            OrderChangedMessage orderChanged = null;
            if (message.Label == "orderchanged")
                orderChanged = JsonConvert.DeserializeObject<OrderChangedMessage>(messageString);
            //if (message.Label == "userwithlessoffer")
            //    orderChanged = JsonConvert.DeserializeObject<List<GeekBurger.Orders.Contract.Messages.>>(messageString);

            _salesService.SaveSale(orderChanged);
            return Task.CompletedTask;
        }

        public Task ExceptionHandle(ExceptionReceivedEventArgs arg)
        {
            var context = arg.ExceptionReceivedContext;
            return Task.CompletedTask;
        }
    }
}
