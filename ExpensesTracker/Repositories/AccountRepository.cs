using Expenses_Tracker.Models.AuthenticationModels;
using Expenses_Tracker.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expenses_Tracker.Repositories
{
    public class AccountRepository : Repository<UserAuthenticationModel>, IAccountRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public AccountRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UserAuthenticationModel> LoginAsync(string url, UserAuthenticationModel userToLogIn)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (userToLogIn != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(userToLogIn), Encoding.UTF8, "application/json");
            }
            else
            {
                return new UserAuthenticationModel();
            }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            // Improve this and show errors
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var token = await response.Content.ReadAsStringAsync();
                userToLogIn.Token = token;

                return userToLogIn;
            }
            else
            {
                return new UserAuthenticationModel();
            }
        }

        public async Task<bool> RegisterAsync(string url, UserAuthenticationModel userToRegister)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (userToRegister != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(userToRegister), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            // Improve this and show errors
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
