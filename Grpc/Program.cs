
using Cookie = Data.Cookie;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddDbContextPool<ApplicationDbContext>(o => o.UseSqlite(builder.Configuration["ConnectionString"]));
builder.Services.AddScoped<IRepository<Cookie>, EfRepository<Cookie, ApplicationDbContext>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<CookieService>();
    endpoints.MapGet("/", async context => await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"));
});

await app.RunAsync();
