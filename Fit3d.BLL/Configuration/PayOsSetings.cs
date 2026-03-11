namespace Fit3d.BLL.Configuration
{
    public class PayOsSetings
    {
        public string ClientId { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string ChecksumKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public string OrderReturnUrl { get; set; } = string.Empty;
        public string OrderCancelUrl { get; set; } = string.Empty;
        public string SubscriptionReturnUrl { get; set; } = string.Empty;
        public string SubscriptionCancelUrl { get; set; } = string.Empty;
        public int ExpirationSeconds { get; set; } = 900;
    }
}
