using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using onepathapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure services before building the app
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Add your custom services here
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IProviderService, ProviderService>();
builder.Services.AddSingleton<IChatService, ChatService>();
builder.Services.AddSingleton<IAppointmentService, AppointmentService>();
builder.Services.AddSingleton<IScanService, ScanService>();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline after building the app
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
