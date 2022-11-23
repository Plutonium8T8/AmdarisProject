using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyVR
{
    public static class GetSecrets
    {
        public static string AuthKey { get; private set; }
        public static string ConnectionString { get; private set; }
        public static string StripeSecretKey { get; private set; }
        static GetSecrets()
        {
            var BASE_URI = "https://carappkeyvault.vault.azure.net/";
            var CLIENT_SECRET = "ZPk8Q~eOfG1.GF0h2ITkj2P~rhKg09boWPeK5as1";
            var CLIENT_ID = "e601fc5e-c557-4765-8697-1513bf2425b8";
            var TENANT_ID = "544f8ac3-ce4c-47d1-9b72-284ac54b8d1c";

            var client = new SecretClient(new Uri(BASE_URI), new ClientSecretCredential(tenantId: TENANT_ID, clientId: CLIENT_ID, clientSecret: CLIENT_SECRET));

            var authKey = client.GetSecret("AuthKey");

            var connectionString = client.GetSecret("ConnectionString");

            var StripeKey = client.GetSecret("StripeApi");

            AuthKey = authKey.Value.Value;
            ConnectionString = connectionString.Value.Value;
            StripeSecretKey = StripeKey.Value.Value;
        }
    }
}