using AspNet1.Database;
using Microsoft.EntityFrameworkCore;

namespace AspNet1;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        // Створюємо Scope, щоб дістати Scoped сервіс (DbContext)
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
        // Застосовує всі міграції, які ще не були застосовані
        dbContext.Database.Migrate(); 
    }
}