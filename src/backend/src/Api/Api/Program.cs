var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Security headers (basic)
app.Use(async (context, next) =>
{
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["X-Frame-Options"] = "DENY";
    context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
    context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    await next(context);
});

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Minimal API endpoints
var api = app.MapGroup("/api");
api.MapGet("/", () => Results.Ok(new { name = "My API", version = "v1" }));

// Health checks
app.MapHealthChecks("/health");

app.Run();
