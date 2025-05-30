using RatesOfPlayers.Start.Extensions;

// Создаем объект-строитель приложения ASP.NET Core
var builder = WebApplication.CreateBuilder(args);

// Добавляем в приложение сервисы для работы с хранилищами
builder.AddStorageServices();

// Создаем экземпляр приложения ASP.NET Core
var app = builder.Build();

// Запускаем приложение ASP.NET Core
await app.RunAsync();