
using APIAPRSoftware.Services;
using Common.Constantes;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models.Common;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Pruebas multitenancy

//string contextMultitenantDB = builder.Configuration.GetConnectionString("aprsoftwareTenant");
//builder.Services.AddMultitenanceConfiguration(contextMultitenantDB); 

var llave = Encoding.ASCII.GetBytes(Claves.SecretoJwt);
builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(d =>
{
    d.RequireHttpsMetadata = false;
    d.SaveToken = true;
    d.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(llave),
        ValidateIssuer = false,
        ValidateAudience = false
        
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.UseMultiTenant();
var frontUrl = ConfigurationBinder.GetValue<string>(builder.Configuration, "frontend_url");
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins(frontUrl).WithHeaders("*"));
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute("default", "{__tenant__}/{controller=Home}/{action=Index}");
//});
app.Run();
