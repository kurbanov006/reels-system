var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.RegisterDbContext();
builder.Services.RegisterRepository();
builder.Services.RegisterMediatR();
builder.Services.RegisterValidation();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.MapControllers();
app.Run();