using dotnet03_webapi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//service map các đầu route api của các class controllers có sử dụng [route]
builder.Services.AddControllers();

//Add service swagger
builder.Services.AddSwaggerGen();

//khai báo service EF
var connectionString = "Server=127.0.0.1,1433; Database=QuanLyNhanVienDB;User Id = sa;Password=Khoideptrai312@;TrustServerCertificate=True";

builder.Services.AddDbContext<QLNVContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

//sử dụng swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//sử dụng map route controllers
app.MapControllers();

app.Run();
