
var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddServiceModelServices()
  .AddServiceModelMetadata()
  .AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

builder.Services.AddDbContextPool<AppDbContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IRepository<Cookie>, CookieRepository>();

builder.Services.AddScoped<CookieService>();

var app = builder.Build();

var wsHttpBinding = new WSHttpBinding(SecurityMode.Transport);
wsHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

app.UseServiceModel(builder => builder
    .AddService<CookieService>(options =>
    {
      var baseAddresses = app.Configuration["BaseAddresses"].Split(';');
      Array.ForEach(baseAddresses, baseAddress => options.BaseAddresses.Add(new Uri(baseAddress)));
    })
    .AddServiceEndpoint<CookieService, ICookieService>(new BasicHttpBinding(), "/CookieService/BasicHttp")
    .AddServiceEndpoint<CookieService, ICookieService>(wsHttpBinding, "/CookieService/WSHttp"));

var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();
