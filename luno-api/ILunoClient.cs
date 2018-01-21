using System.Threading.Tasks;

namespace luno_api
{
    public interface ILunoClient
    {
        Task<AddAccountResponse> AddAccountAsync(string currency, string name);
        Task<ReceiveAddress> CreateFundingAddressAsync(string asset);
        Task<Withdrawal> DeleteWithdrawalAsync(string id);
        Task<BalanceResponse> GetBalancesAsync();
        Task<FeeInfo> GetFeeInfoAsync(string pair);
        Task<ReceiveAddress> GetFundingAddressAsync(string asset, string address = null);
        Task<Order> GetOrderAsync(string orderId);
        Task<OrderBookResponse> GetOrderBookAsync(string pair);
        Task<ListOrderResponse> GetOrdersAsync(string state = null, string pair = null);
        Task<TransactionResponse> GetPendingTransactionsAsync(string id);
        Task<Ticker> GetTickerAsync(string pair);
        Task<TickerResponse> GetTickersAsync();
        Task<TradeResponse> GetTradesAsync(string pair, int? since = null);
        Task<ListTradeResponse> GetTradesAsync(string pair, int? since, int? limit);
        Task<TransactionResponse> GetTransactionsAsync(string id, int minRow, int maxRow);
        Task<GetWithdrawalResponse> GetWithdrawalsAsync();
        Task<Withdrawal> GetWithdrawalStatusAsync(string id);
        Task<PostOrderResponse> PostMarketOrderAsync(string pair, string type, string counterVolume = null, string baseVolume = null, string baseAccountId = null, string counterAccountId = null);
        Task<PostOrderResponse> PostOrderAsync(string pair, string type, string volume, string price, string baseAccountId = null, string counterAccountId = null);
        Task<Withdrawal> RequestWithdrawalsAsync(string type, string amount, string beneficiaryId);
        Task<StopOrderResponse> StopOrderAsync(string orderId);
    }
}