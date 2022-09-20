
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<CookieQuery>();

var connection = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrWhiteSpace(connection))
{
  throw new Exception("Connectionstring 'Default' not configured!");
}

builder.Services.AddDbContextPool<AppDbContext>(o => o.UseSqlite(connection));
builder.Services.AddScoped<IRepository<Cookie>, CookieRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGraphQL();

app.Run();
