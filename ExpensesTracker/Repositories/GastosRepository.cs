using Expenses_Tracker.Models.GastosModels;
using Expenses_Tracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Expenses_Tracker.Repositories
{
    public class GastosRepository : Repository<GastosResource>, IGastosRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public GastosRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

    }
}
