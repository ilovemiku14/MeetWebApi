using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<MeetDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")), ServiceLifetime.Scoped); // 将DbContext注册为Scoped服务
//Scaffold-DbContext "Server=Localhost;Database=Meet;uid=sa;Password=123456;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataModel -Context WebApiContext -f
var app = builder.Build();
app.Urls.Add("http://*:5000");
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