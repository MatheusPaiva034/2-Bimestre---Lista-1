using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Permite que a API utilize controllers.
builder.Services.AddControllers();

// Lê a chave de assinatura do arquivo de configuração.
var chaveJwt = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("Chave JWT não configurada.");

// Configura a autenticação usando JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opcoes =>
    {
        // Define como os tokens recebidos serão validados.
        opcoes.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveJwt)),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Habilita o uso de autorização.
builder.Services.AddAuthorization();

var app = builder.Build();

// Identifica o usuário que enviou o token.
app.UseAuthentication();

// Verifica se o usuário pode acessar a rota solicitada.
app.UseAuthorization();

// Disponibiliza as rotas dos controllers.
app.MapControllers();

app.Run();