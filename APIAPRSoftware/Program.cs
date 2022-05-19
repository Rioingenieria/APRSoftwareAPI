
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
var frontUrl = ConfigurationBinder.GetValue<string>(builder.Configuration, "frontend_url");
app.UseCors(c=>c.AllowAnyHeader().AllowAnyMethod().WithOrigins(frontUrl));

app.UseAuthorization();

app.MapControllers();

app.Run();
