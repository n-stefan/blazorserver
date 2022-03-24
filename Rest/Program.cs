
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContextPool<ApplicationDbContext>(o => o.UseSqlite(builder.Configuration["ConnectionString"]));
builder.Services.AddScoped<IRepository<Cookie>, EfRepository<Cookie, ApplicationDbContext>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();
