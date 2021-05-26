﻿using System.Collections.Generic;

namespace Expenses_Tracker.Models.AuthenticationModels
{
    public class UserAuthenticationModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
    }
}
