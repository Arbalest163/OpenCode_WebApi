var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IAccessControlDbContext).Assembly));
    });
    services.AddApplication();
    services.AddPersistence(builder.Configuration);

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AccessControlDbContext>();
        db.Migrate();
    }

    app.UseCustomExceptionHandler();
    app.UseHttpsRedirection();

    app.MapControllers();
}
