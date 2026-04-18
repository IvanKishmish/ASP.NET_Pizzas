# 🍕 Pizza & Order API — My First ASP.NET Core Project

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Rider](https://img.shields.io/badge/Rider-000000?style=for-the-badge&logo=jetbrains&logoColor=white&labelColor=000000)

Вітаю! Це мій перший повноцінний бекенд-проєкт на **ASP.NET Core 8**. Почавши з простого каталогу піц, я розвинув його до **системи керування замовленнями**, де реалізована логіка взаємодії між сутностями, автоматичний розрахунок вартості та сучасна архітектура.

---

## 🛠 Технологічний стек

* **Framework:** ASP.NET Core 8 (Web API)
* **Database:** PostgreSQL + Entity Framework Core
* **Validation:** FluentValidation (сувора перевірка вхідних даних)
* **Security:** DotNetEnv (конфігурація через `.env` файли)
* **Architecture:** Dependency Injection, Service Layer, DTO Pattern, Extension Methods

---

## ✨ Ключові особливості

- ✅ **PizzaOrderSystem:** Повноцінна система замовлень. Кожне замовлення прив'язане до конкретної піци через зовнішній ключ (Foreign Key).
- ✅ **Бізнес-логіка в сервісах:** Розрахунок `TotalPrice` відбувається на стороні сервера в `OrderService`, що гарантує безпеку (клієнт не може підробити ціну).
- ✅ **Автоматизація БД:** Завдяки кастомним методам розширення (`DataExtensions.cs`), міграції застосовуються автоматично при старті застосунку.
- ✅ **Професійний мапінг:** Для кожної операції створено окремі DTO (`CreateOrderDto`, `UpdateOrderDto`, `OrderDto`), щоб не виставляти внутрішні сутності БД назовні.

---

## 📂 Структура проєкту

| Папка | Опис |
| :--- | :--- |
| **Controllers** | Обробка HTTP-запитів (`PizzaController`, `OrderController`) |
| **Services** | Реалізація бізнес-логіки та взаємодія з БД |
| **Database** | DbContext, сутності та автоматичні міграції |
| **Dtos** | Моделі даних для безпечного обміну (Data Transfer Objects) |
| **Validators** | Класи FluentValidation для перевірки даних |

---

## 🚀 Як запустити проєкт локально

### 1. Клонування репозиторію
```bash
git clone [https://github.com/IvanKishmish/ASP.NET_Pizzas.git](https://github.com/IvanKishmish/ASP.NET_Pizzas.git)
cd ASP.NET_Pizzas
