var builder = WebApplication.CreateBuilder(args);

//service map các đầu route api của các class controllers có sử dụng [route]
builder.Services.AddControllers();

//Add service swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

//sử dụng swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//sử dụng map route controllers
app.MapControllers();

app.Run();
