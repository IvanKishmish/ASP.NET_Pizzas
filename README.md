# 🍕 Pizza API — My First ASP.NET Core Project

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Rider](https://img.shields.io/badge/Rider-000000?style=for-the-badge&logo=jetbrains&logoColor=white&labelColor=000000)

Вітаю! Це мій перший повноцінний бекенд-проєкт, створений на базі **ASP.NET Core 8**. Проєкт реалізує RESTful API для керування асортиментом піцерії, з фокусом на архітектуру та безпеку даних.

---

## 🛠 Технологічний стек

* **Framework:** ASP.NET Core 8 (Web API)
* **Database:** PostgreSQL + Entity Framework Core
* **Validation:** FluentValidation (для вхідних DTO)
* **Security:** DotNetEnv (приховування конфіденційних даних у `.env`)
* **Architecture:** Dependency Injection, Service Layer, DTO Pattern, Extension Methods

---

## ✨ Ключові особливості

-   ✅ **Чистий код:** Використання методів розширення (`DataExtensions.cs`) для розвантаження `Program.cs`.
-   ✅ **Ефективність:** Застосування `.AsNoTracking()` для швидкого читання та `ExecuteUpdate`/`ExecuteDelete` для масових операцій.
-   ✅ **Безпека:** Рядки підключення винесені в змінні оточення.
-   ✅ **Валідація:** Сувора перевірка даних (ціна, довжина назви тощо) перед потраплянням у базу.

---

## 📂 Структура проєкту

| Папка | Опис |
| :--- | :--- |
| **Controllers** | Ендпоінти API та обробка HTTP-запитів |
| **Services** | Бізнес-логіка (Abstractions & Implementations) |
| **Database** | DbContext, сутності (Entities) та міграції |
| **Dtos** | Моделі даних для безпечного обміну з клієнтом |
| **Validators** | Класи валідації FluentValidation |

---

## 🚀 Як запустити проєкт локально

### 1. Клонування репозиторію
```bash
git clone [https://github.com/IvanKishmish/AspNet1.git](https://github.com/IvanKishmish/AspNet1.git)
