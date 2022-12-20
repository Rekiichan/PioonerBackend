using Pioneer_Backend.DataAccess;
using Pioneer_Backend.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.Configure<PioneerDatabaseSettings>(
    builder.Configuration.GetSection("PioneerDatabase"));

builder.Services.AddSingleton<MemberService>();
builder.Services.AddSingleton<RewardService>();
builder.Services.AddSingleton<ProjectService>();
builder.Services.AddSingleton<EventService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
