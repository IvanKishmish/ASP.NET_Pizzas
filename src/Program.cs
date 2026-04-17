using AspNet1.Database;
using AspNet1.Services.Abstractions;
using AspNet1.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// --- КОНФІГУРАЦІЯ (Configuration) ---

// Завантажуємо змінні з .env файлу
Env.Load();

// Додаємо змінні оточення в загальну конфігурацію 
// Це дозволяє перекривати налаштування з appsettings.json системними змінними 
builder.Configuration.AddEnvironmentVariables();

//дістане або з appsettings.json або з іншого середовища
var connectionString = builder.Configuration.GetConnectionString("DB_CONNECTION_STRING");

// --- СЕРВІСИ (Dependency Injection Container) ---

// Реєструємо контекст бази даних. За замовчуванням він реєструється як Scoped
// Використання DI дозволяє уникнути "new AppDbContext()" всередині сервісів 
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString));

// Реєструємо бізнес-сервіси як Scoped
// Scoped гарантує, що для кожного HTTP-запиту буде створено свій екземпляр сервісу
builder.Services.AddScoped<IPizzaService, PizzaService>();

// Додаємо підтримку контролерів. Це реєструє всі класи, що наслідуються від ControllerBase 
builder.Services.AddControllers();

// Налаштування Swagger/OpenAPI. Необхідно для автоматичної документації API 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- КОНВЕЄР ОБРОБКИ ЗАПИТІВ (Middleware Pipeline) ---

// Вмикаємо Swagger лише в середовищі розробки (Development) для безпеки продуктового коду 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Візуальний інтерфейс за адресою /swagger
}

// Перенаправлення HTTP запитів на HTTPS для забезпечення безпеки передачі даних 
app.UseHttpsRedirection();

// Маршрутизація для контролерів. Цей метод знаходить відповідний Action 
// у контролері на основі URL та HTTP-методу запиту
app.MapControllers(); 

app.Run();
