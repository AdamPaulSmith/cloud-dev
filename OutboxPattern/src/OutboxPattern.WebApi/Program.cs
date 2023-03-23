using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo
                                      .Console()
                                      .CreateBootstrapLogger();

Log.Information("Starting up");
try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((context, configuration) => configuration.WriteTo.Console()
                                                                     .ReadFrom.Configuration(context.Configuration));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    WebApplication app = builder.Build();

    if(app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occured during startup");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}