# Backend.Api
Auth Role Based JWT implementation
## configure Startup.cs
```cs
 // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
```
## appsetting.json
```cs
"AppSettings": {
    "Secret": "this is my custom Secret key for authentication"
  }
```
## For the CORS

```cs
services.AddCors(options =>
            {
                options.AddPolicy("default",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000",
                                                          "http://www.contoso.com")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
```
# JWT middleware in case but not is not active!
