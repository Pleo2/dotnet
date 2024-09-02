using ApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);
// * Add services to the container.
// builder.Services.AddSingleton<IPeopleService, People2Service>();
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("keytoaccesName");

// Diferrents types of Injection Dependencies
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("RandomSingletoneService");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("RandomScopeService");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("RandomTransientService");

builder.Services.AddKeyedScoped<IPostsService, PostsService>("PostService");

/*
IHttpClientFactory
this the correct patrom of desing more viable 
*/
// builder.Services.AddHttpClient<IPostsService, PostsService>(client => {
//     client.BaseAddress = new Uri(builder.Configuration["BaseUrlPost"]);
// });

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
