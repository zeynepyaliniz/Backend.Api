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
## To Generate Token:
```cs
private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days          
           
            Claim[] getClaims()
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));
                foreach (var item in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
                return claims.ToArray();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(getClaims()),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
```
# JWT middleware in case but not is not active!
