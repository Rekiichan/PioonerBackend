using Pioneer_Backend.DataAccess;
using Pioneer_Backend.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Add services to the container.
builder.Services.Configure<MemberDatabaseSettings>(
    builder.Configuration.GetSection("MemberStoreDatabase"));
builder.Services.Configure<RewardDatabaseSettings>(
    builder.Configuration.GetSection("RewardStoreDatabase"));
builder.Services.Configure<ProjectDatabaseSettings>(
    builder.Configuration.GetSection("ProjectStoreDatabase"));

builder.Services.AddSingleton<MemberService>();
builder.Services.AddSingleton<RewardService>();
builder.Services.AddSingleton<ProjectService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

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
