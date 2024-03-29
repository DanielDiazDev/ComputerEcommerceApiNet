﻿namespace ComputerEcommerce.API.Configurations
{
    public class DatabaseConnectionSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool TrustedConnection { get; set; }
        public bool TrustServerCertificate { get; set; }
    }
}
