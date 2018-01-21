using System.Threading.Tasks;

namespace luno_api
{
    public interface ILunoClient
    {
        Task<AddAccountResponse> AddAccount(string currency, string name);
        Task<ReceiveAddress> CreateFundingAddress(string asset);
        Task<Withdrawal> DeleteWithdrawal(string id);
        Task<BalanceResponse> GetBalances();
        Task<FeeInfo> GetFeeInfo(string pair);
        Task<ReceiveAddress> GetFundingAddress(string asset, string address = null);
        Task<Order> GetOrder(string orderId);
        Task<OrderBookResponse> GetOrderBook(string pair);
        Task<ListOrderResponse> GetOrders(string state = null, string pair = null);
        Task<TransactionResponse> GetPendingTransactions(string id);
        Task<Ticker> GetTicker(string pair);
        Task<TickerResponse> GetTickers();
        Task<TradeResponse> GetTrades(string pair, int? since = null);
        Task<ListTradeResponse> GetTrades(string pair, int? since, int? limit);
        Task<TransactionResponse> GetTransactions(string id, int minRow, int maxRow);
        Task<GetWithdrawalResponse> GetWithdrawals();
        Task<Withdrawal> GetWithdrawalStatus(string id);
        Task<PostOrderResponse> PostMarketOrder(string pair, string type, string counterVolume = null, string baseVolume = null, string baseAccountId = null, string counterAccountId = null);
        Task<PostOrderResponse> PostOrder(string pair, string type, string volume, string price, string baseAccountId = null, string counterAccountId = null);
        Task<Withdrawal> RequestWithdrawals(string type, string amount, string beneficiaryId);
        Task<StopOrderResponse> StopOrder(string orderId);
    }
}