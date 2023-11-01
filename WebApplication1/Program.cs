using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

// variable builder the application
var app = builder.Build();

// variable parameter environment for run application on IIS using app.run() function
startup.Configure(app, app.Environment);
app.Run();
