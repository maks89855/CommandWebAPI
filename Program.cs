using CommandWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(s=>s.SerializerSettings.ContractResolver =  new CamelCasePropertyNamesContractResolver());
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddDbContext<CommandContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MicrosoftSQLServer"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
