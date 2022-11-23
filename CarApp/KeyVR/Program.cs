using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using Microsoft.AspNetCore.Hosting;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace KeyVR
{
    class Program
    {
        static void Main(string[] args)
        {
            var BASE_URI = "https://carappkeyvault.vault.azure.net/";
            var CLIENT_SECRET = "ZPk8Q~eOfG1.GF0h2ITkj2P~rhKg09boWPeK5as1";
            var CLIENT_ID = "e601fc5e-c557-4765-8697-1513bf2425b8";
            var TENANT_ID = "544f8ac3-ce4c-47d1-9b72-284ac54b8d1c";

            var client = new SecretClient(new Uri(BASE_URI), new ClientSecretCredential(tenantId: TENANT_ID, clientId: CLIENT_ID, clientSecret: CLIENT_SECRET));

            var authKey = client.GetSecret("AuthKey");

            var connectionString = client.GetSecret("ConnectionString");

            Console.WriteLine(authKey);
        }
    }
}