namespace GeekBurger.Dashboard.ServiceBus
{
    internal class ServiceBusConfiguration
    {
        public string ClientId { get; } = "31d24bf2-5475-41e7-86c4-3e3d971ad2cb";
        public string ClientSecret { get; } = "lovetoteach";
        public string TenantId { get; } = "11dbbfe2-89b8-4549-be10-cec364e59551";
        public string SubscriptionId { get; } = "dbc49a7f-caee-46b5-a6a6-7eac85bf97f1";
        public string ResourceGroup { get; } = "fiap";
        public string NamespaceName { get; } = "GeekBurger";
        public string ConnectionString { get; } = "Endpoint=sb://geekburger.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=/PGLAJOC7WDV5QkBNz+GodPhlnBPEL6Iwd/ThkKnBcs=";
    }
}