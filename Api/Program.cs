using Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

await app.ResetDatabase();

app.Run();
