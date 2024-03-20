using TcpApp.Application.AppData.Service.TCPClient;
using TcpApp.Application.AppData.Service.TCPListener;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITCPClientService, TCPClientService>();
builder.Services.AddScoped<ITCPListenerService, TCPListenerService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//  asdasdasdasd
app.Lifetime.ApplicationStarted.Register(async () =>
{
    var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (var scope = serviceScopeFactory.CreateScope())
    {
        var services = scope.ServiceProvider;
        var tcpClient = services.GetRequiredService<ITCPClientService>();
        var tcpListenerService = services.GetRequiredService<ITCPListenerService>();

        // Запуск сервисов асинхронно

        _ = tcpListenerService.ReceivingData();
        _ = tcpClient.SendingData();
    }
});

app.Run();
