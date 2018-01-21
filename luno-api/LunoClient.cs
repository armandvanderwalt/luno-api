using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace luno_api
{
    public class LunoClient : ILunoClient
    {
        //TODO: Implement Send
        //TODO: Implement Quote

        private readonly string _publicKey;
        private readonly string _privateKey;

        public LunoClient(string publicKey, string privateKey)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;
        }

        public async Task<TickerResponse> GetTickers()
        {
            var stringResult = await GetRequest("tickers");

            var result = JsonConvert.DeserializeObject<TickerResponse>(stringResult);

            return result;
        }

        public async Task<Ticker> GetTicker(string pair)
        {
            var stringResult = await GetRequest("ticker", new Dictionary<string, string>
            {
                ["pair"] = pair
            });

            var result = JsonConvert.DeserializeObject<Ticker>(stringResult);

            return result;
        }

        public async Task<OrderBookResponse> GetOrderBook(string pair)
        {
            var stringResult = await GetRequest("orderbook", new Dictionary<string, string>
            {
                ["pair"] = pair
            });

            var result = JsonConvert.DeserializeObject<OrderBookResponse>(stringResult);

            return result;
        }

        public async Task<TradeResponse> GetTrades(string pair, int? since = null)
        {
            var query = new Dictionary<string, string>
            {
                ["pair"] = pair
            };

            if (since != null)
            {
                query.Add("since", since.Value.ToString(CultureInfo.InvariantCulture));
            }

            var stringResult = await GetRequest("trades", query);

            var result = JsonConvert.DeserializeObject<TradeResponse>(stringResult);

            return result;
        }

        public async Task<BalanceResponse> GetBalances()
        {
            var stringResult = await GetSecureRequest("balance");

            var result = JsonConvert.DeserializeObject<BalanceResponse>(stringResult);

            return result;
        }

        public async Task<ListOrderResponse> GetOrders(string state = null, string pair = null)
        {
            Dictionary<string, string> paramaters = null;

            if (state != null)
            {
                paramaters = new Dictionary<string, string> { { "state", state } };

            }

            if (pair != null)
            {
                if (paramaters == null)
                    paramaters = new Dictionary<string, string>();

                paramaters.Add("pair", pair);
            }

            var stringResult = await GetSecureRequest("listorders", paramaters);

            var result = JsonConvert.DeserializeObject<ListOrderResponse>(stringResult);

            return result;
        }

        public async Task<PostOrderResponse> PostOrder(string pair, string type, string volume, string price,
            string baseAccountId = null, string counterAccountId = null)
        {
            var paramaters = new Dictionary<string, string>
            {
                ["pair"] = pair,
                ["type"] = type,
                ["volume"] = volume,
                ["price"] = price
            };

            if (baseAccountId != null)
            {
                paramaters.Add("base_account_id", baseAccountId);
            }

            if (counterAccountId != null)
            {
                paramaters.Add("counter_account_id", counterAccountId);
            }

            var stringResult = await PostSecureRequest("postorder", paramaters);

            var result = JsonConvert.DeserializeObject<PostOrderResponse>(stringResult);

            return result;
        }

        public async Task<PostOrderResponse> PostMarketOrder(string pair, string type, string counterVolume = null, string baseVolume = null,
            string baseAccountId = null, string counterAccountId = null)
        {
            var paramaters = new Dictionary<string, string>
            {
                ["pair"] = pair,
                ["type"] = type
            };

            if (type.Equals("BUY", StringComparison.InvariantCulture))
            {
                paramaters.Add("counter_volume", counterVolume);
            }

            if (type.Equals("SELL", StringComparison.InvariantCulture))
            {
                paramaters.Add("base_volume", baseVolume);
            }
            
            if (baseAccountId != null)
            {
                paramaters.Add("base_account_id", baseAccountId);
            }

            if (counterAccountId != null)
            {
                paramaters.Add("counter_account_id", counterAccountId);
            }

            var stringResult = await PostSecureRequest("marketorder", paramaters);

            var result = JsonConvert.DeserializeObject<PostOrderResponse>(stringResult);

            return result;
        }

        public async Task<StopOrderResponse> StopOrder(string orderId)
        {
            var stringResult = await PostSecureRequest("stoporder", new Dictionary<string, string>
            {
                ["order_id"] = orderId
            });

            var result = JsonConvert.DeserializeObject<StopOrderResponse>(stringResult);

            return result;
        }

        public async Task<Order> GetOrder(string orderId)
        {
            var stringResult = await GetSecureRequest($"orders/{orderId}");

            var result = JsonConvert.DeserializeObject<Order>(stringResult);

            return result;
        }

        public async Task<ListTradeResponse> GetTrades(string pair, int? since, int? limit)
        {

            var paramaters = new Dictionary<string, string>
            {
                ["pair"] = pair
            };

            if (since != null)
            {
                paramaters.Add("since", since.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (limit != null)
            {
                paramaters.Add("limit", limit.Value.ToString(CultureInfo.InvariantCulture));
            }

            var stringResult = await GetSecureRequest("listtrades", paramaters);

            var result = JsonConvert.DeserializeObject<ListTradeResponse>(stringResult);

            return result;
        }

        public async Task<AddAccountResponse> AddAccount(string currency, string name)
        {
            var stringResult = await PostSecureRequest("accounts", new Dictionary<string, string>
            {
                ["currency"] = currency,
                ["name"] = name
            });

            var result = JsonConvert.DeserializeObject<AddAccountResponse>(stringResult);

            return result;
        }

        public async Task<TransactionResponse> GetTransactions(string id, int minRow, int maxRow)
        {
            var stringResult = await GetSecureRequest($"accounts/{id}/transactions", new Dictionary<string, string>
            {
                ["min_row"] = minRow.ToString(CultureInfo.InvariantCulture),
                ["max_row"] = maxRow.ToString(CultureInfo.InvariantCulture)
            });

            var result = JsonConvert.DeserializeObject<TransactionResponse>(stringResult);

            return result;
        }

        public async Task<TransactionResponse> GetPendingTransactions(string id)
        {
            var stringResult = await GetSecureRequest($"accounts/{id}/pending");

            var result = JsonConvert.DeserializeObject<TransactionResponse>(stringResult);

            return result;
        }

        public async Task<FeeInfo> GetFeeInfo(string pair)
        {
            var stringResult = await GetSecureRequest("fee_info", new Dictionary<string, string>
            {
                ["pair"] = pair
            });

            var result = JsonConvert.DeserializeObject<FeeInfo>(stringResult);

            return result;
        }

        public async Task<ReceiveAddress> GetFundingAddress(string asset, string address = null)
        {
            var paramaters = new Dictionary<string, string>
            {
                ["asset"] = asset
            };

            if (address != null)
            {
                paramaters.Add("address", address);
            }

            var stringResult = await GetSecureRequest("funding_address", paramaters);

            var result = JsonConvert.DeserializeObject<ReceiveAddress>(stringResult);

            return result;
        }

        public async Task<ReceiveAddress> CreateFundingAddress(string asset)
        {
            var paramaters = new Dictionary<string, string>
            {
                ["asset"] = asset
            };
            var stringResult = await PostSecureRequest("funding_address", paramaters);

            var result = JsonConvert.DeserializeObject<ReceiveAddress>(stringResult);

            return result;
        }

        public async Task<GetWithdrawalResponse> GetWithdrawals()
        {

            var stringResult = await GetSecureRequest("withdrawals");

            var result = JsonConvert.DeserializeObject<GetWithdrawalResponse>(stringResult);

            return result;
        }

        public async Task<Withdrawal> GetWithdrawalStatus(string id)
        {
            var stringResult = await GetSecureRequest($"withdrawals/{id}");

            var result = JsonConvert.DeserializeObject<Withdrawal>(stringResult);

            return result;
        }

        public async Task<Withdrawal> DeleteWithdrawal(string id)
        {
            var stringResult = await DeleteSecureRequest($"withdrawals/{id}");

            var result = JsonConvert.DeserializeObject<Withdrawal>(stringResult);

            return result;
        }


        public async Task<Withdrawal> RequestWithdrawals(string type, string amount, string beneficiaryId)
        {
            var paramaters = new Dictionary<string, string>
            {
                ["type"] = type,
                ["amount"] = amount
            };
            
            if (beneficiaryId != null)
            {
                paramaters.Add("beneficiary_id", beneficiaryId);
            }

            var stringResult = await PostSecureRequest("withdrawals", paramaters);

            var result = JsonConvert.DeserializeObject<Withdrawal>(stringResult);

            return result;
        }


        private async Task<string> GetRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api.mybitx.com/api/1";

            if (paramaters != null)
            {
                var queryString = QueryStringBuilder.BuildQueryString(paramaters);
                baseUrl = $"{baseUrl}/{path}?{queryString}";
            }
            else
            {
                baseUrl = $"{baseUrl}/{path}";
            }

            using (var client = new WebClient())
            {
                var result = await client.DownloadStringTaskAsync(baseUrl);

                return result;
            }
        }

        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api.mybitx.com/api/1";

            if (paramaters != null)
            {
                var queryString = QueryStringBuilder.BuildQueryString(paramaters);
                baseUrl = $"{baseUrl}/{path}?{queryString}";
            }
            else
            {
                baseUrl = $"{baseUrl}/{path}";
            }

            using (var client = new WebClient())
            {
                client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_publicKey}:{_privateKey}")));

                var result = await client.DownloadStringTaskAsync(baseUrl);

                return result;
            }
        }

        private async Task<string> PostSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = $"https://api.mybitx.com/api/1/{path}";
            
            var keyValueParams = new List<KeyValuePair<string, string>>();

            if (paramaters != null)
            {
                foreach (var paramatersKey in paramaters.Keys)
                {
                    keyValueParams.Add(new KeyValuePair<string, string>(paramatersKey, paramaters[paramatersKey]));
                }
            }

            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(keyValueParams);

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(baseUrl),
                    Method = HttpMethod.Post,
                    Content = requestContent
                };

                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_publicKey}:{_privateKey}")));

                var response = await client.SendAsync(request);

                var responseContent = response.Content;

                using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        private async Task<string> DeleteSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = $"https://api.mybitx.com/api/1/{path}";

            var keyValueParams = new List<KeyValuePair<string, string>>();

            if (paramaters != null)
            {
                foreach (var paramatersKey in paramaters.Keys)
                {
                    keyValueParams.Add(new KeyValuePair<string, string>(paramatersKey, paramaters[paramatersKey]));
                }
            }

            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(keyValueParams);

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(baseUrl),
                    Method = HttpMethod.Delete,
                    Content = requestContent
                };

                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_publicKey}:{_privateKey}")));

                var response = await client.SendAsync(request);

                var responseContent = response.Content;

                using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

    }
}
