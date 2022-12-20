using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//var env = hostingContext.HostingEnvironment;
//config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
//});

// TODO: Uncomment if u want to see log in txt

//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("Log/MemberLog.txt", rollingInterval: RollingInterval.Day).CreateLogger();
//builder.Host.UseSerilog();


builder.Services.AddControllers();
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection"))
//);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//IConfigurationRoot configurationRoot = new ConfigurationBuilder()
//    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//    .AddJsonFile("appsettings.json")
//    .Build();
//Config.Init(configurationRoot);
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});
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
