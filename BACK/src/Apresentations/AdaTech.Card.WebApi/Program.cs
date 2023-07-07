using AdaTech.Application.Card;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var corsBuilder = new CorsPolicyBuilder();

corsBuilder.AllowAnyHeader();
corsBuilder.AllowAnyMethod();
corsBuilder.AllowAnyOrigin();

builder.Services.AddCors(options => {
    options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
});

builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(CardHandler).Assembly));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("SiteCorsPolicy");

app.Run();
