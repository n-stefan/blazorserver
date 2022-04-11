
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContextPool<ApplicationDbContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IRepository<Cookie>, CookieRepository>();

// Register only one of the following services
builder.Services.AddScoped<ICookieService, DirectCookieService>();
//builder.Services.AddScoped<ICookieService, GrpcCookieService>();
//builder.Services.AddHttpClient<ICookieService, RestCookieService>(client => client.BaseAddress = new Uri(builder.Configuration["RestBaseUrl"]));
//builder.Services.AddHttpClient<ICookieService, GraphQLCookieService>(client => client.BaseAddress = new Uri(builder.Configuration["GraphQLBaseUrl"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
