using ShopBridgeBackEnd;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureSevices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();