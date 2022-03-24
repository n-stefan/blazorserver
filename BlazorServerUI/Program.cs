
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContextPool<ApplicationDbContext>(o => o.UseSqlite(builder.Configuration["ConnectionString"]));
builder.Services.AddScoped<IRepository<Cookie>, EfRepository<Cookie, ApplicationDbContext>>();

// Register only one of the following services
builder.Services.AddScoped<ICookieService, DirectCookieService>();
//builder.Services.AddScoped<ICookieService, GrpcCookieService>();
//builder.Services.AddHttpClient<ICookieService, RestCookieService>(client => client.BaseAddress = new Uri(builder.Configuration["RestBaseUrl"]));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

await app.RunAsync();
