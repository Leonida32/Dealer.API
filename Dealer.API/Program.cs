using Dealer.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Dealer.API.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContex>(option => option.UseSqlite(@"Data Source= DealerDb.db"));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7031")
        .AllowAnyHeader().AllowAnyMethod()
        );
});


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7031")
});

// builder.Services.AddResponseCompression(o => {
//     o.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {"application/octet-stream"});
// });


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseResponseCompression();   
app.MapHub<React>("/Hub");

app.UseCors(opt => opt.WithOrigins("https://localhost:7031").AllowAnyMethod().AllowAnyHeader()); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
