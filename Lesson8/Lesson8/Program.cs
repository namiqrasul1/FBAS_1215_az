var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints => {
    //endpoints.MapControllerRoute("custom3", "{controller}/{action}/{id:int?}/{a?}/{b:length(5)?}");
    //endpoints.MapControllerRoute("custom2", "anasehife", new {controller = "Home", action = "Index"});
    //endpoints.MapControllerRoute("cutsom1", "{action}/salam/{controller}");
    //endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});

app.Run();
