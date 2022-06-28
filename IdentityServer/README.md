- [This is Identity Server Implementation](#this-is-identity-server-implementation)
- [NugetPackage:](#nugetpackage-)
- [IdentityServer4](#identityserver4)
    + [Startup.cs](#startupcs)
- [ApiResources](#apiresources)
- [ApiScopes](#apiscopes)
- [Clients](#clients)
- [IdentityResources](#identityresources)
- [TestUsers](#testusers)
- [DeveloperSigningCredentials](#developersigningcredentials)

<small><i><a href='http://ecotrust-canada.github.io/markdown-toc/'>Table of contents generated with markdown-toc</a></i></small>

### This is Identity Server Implementation
### NugetPackage: 
``` cs dotnet install IdentityServer4 ```
### IdentityServer4 
##### Startup.cs
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

### ApiResources
### ApiScopes
### Clients
### IdentityResources
### TestUsers
### DeveloperSigningCredentials

