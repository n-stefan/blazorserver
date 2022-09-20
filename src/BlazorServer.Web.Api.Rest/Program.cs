
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
  .AddControllers()
  .AddOData(o => o.EnableQueryFeatures().AddRouteComponents("odata", GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrWhiteSpace(connection))
{
  throw new Exception("Connectionstring 'Default' not configured!");
}

builder.Services.AddDbContextPool<AppDbContext>(o => o.UseSqlite(connection));
builder.Services.AddScoped<IRepository<Cookie>, CookieRepository>();

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

app.Run();

static IEdmModel GetEdmModel()
{
  var modelBuilder = new ODataConventionModelBuilder();
  var cookie = modelBuilder.EntityType<Cookie>();
  cookie.HasKey(c => c.Id);
  cookie.Property(c => c.Message);
  modelBuilder.EntitySet<Cookie>("cookie");
  return modelBuilder.GetEdmModel();
}
