// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace CasgemMicroservice.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog") { Scopes = { "catalog_full_permission" } },
                new ApiResource("resource_photo_stock"){Scopes = { "photo_stock_full_permission" }},
                    new ApiResource("resource_basket"){Scopes = { "basket_full_permission" }},
                        new ApiResource("resource_discount"){Scopes = { "discount_full_permission" }},
                            new ApiResource("resource_order"){Scopes = { "order_full_permission" }},
                                new ApiResource("resource_cargo"){Scopes = { "cargo_full_permission" }},
                                    new ApiResource("resource_payment"){Scopes = { "payment_full_permission" }},
                                        new ApiResource("resource_gateway"){Scopes = { "gateway_full_permission" }},
                                            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_full_permission", "Catalog API için full erişim"),
                new ApiScope("photo_stock_full_permission", "Photo Stock API için full erişim"),
                new ApiScope("basket_full_permission", "Basket API için full erişim"),
                new ApiScope("discount_full_permission", "Basket API için full erişim"),
                new ApiScope("order_full_permission", "Order API için full erişim"),
                new ApiScope("cargo_full_permission", "Cargo API için full erişim"),
                new ApiScope("payment_full_permission", "Payment API için full erişim"),
                new ApiScope("gateway_full_permission", "Gateway API için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m",
                    ClientName = "CoreClient",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { "catalog_full_permission", "photo_stock_full_permission", "gateway_full_permission", IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientName = "CoreClient2",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,


                    AllowOfflineAccess = true,
                    AllowedScopes = { "catalog_full_permission", "photo_stock_full_permission", "basket_full_permission", "discount_full_permission", "order_full_permission", "cargo_full_permission", "payment_full_permission", "gateway_full_permission", IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                    AccessTokenLifetime = 3600
                },
            };
    }
}