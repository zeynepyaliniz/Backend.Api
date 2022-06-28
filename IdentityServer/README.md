# This is Identity Server Implementation
### NugetPackage:
#### IdentityServer4 
### Startup.cs
```cs
// in ConfigureServices:
 services.AddIdentityServer()
                .AddInMemoryClients(new List<Client>())
                .AddInMemoryIdentityResources(new List<IdentityResource>())
                .AddInMemoryApiResources(new List<ApiResource>())
                .AddInMemoryApiScopes(new List<ApiScope>())
                .AddTestUsers(new List<TestUser>())
                .AddDeveloperSigningCredential();

// in Configure:
app.UseIdentityServer();
```

