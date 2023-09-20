﻿using EventManager.Models.Account;

namespace EventManager.Models.ViewModels
{
    public class Login
    {
        public string LoginName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; } 
    }
}
