
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
  .AddControllers()
  .AddOData(o => o.EnableQueryFeatures().AddRouteComponents("odata", GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<AppDbContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("Default")));
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
  modelBuilder.EntitySet<Cookie>("Cookies");
  return modelBuilder.GetEdmModel();
}
