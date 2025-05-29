using WebApplication1;
using WebApplication1.Classes;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IStudent, ScienceStudent>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//builder.Services.AddSession();

 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSubscribePlease();

//app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapGet("/", (HttpContext context) =>
{
    return Results.Text("Hello there !");
});
//custom login requirements
//app.Use(async (context, next) =>
//{
//    //Code runs before the response
//    await next.Invoke();
//    //Code runs after the response is going back

//});
app.Run();
