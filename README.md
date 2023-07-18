Привет! Меня зовут Дмитриев Семён и, скорее всего, вы сюда попали по ссылке из моего резюме.
PizzaGoApi - мой пет проект, в котором я демонстрирую свои навыки разработки back-end части web приложения интернет магазина доставки.
Проект еще в работе, но уже какое-то представление о моих навыках вы можете получить из представленной информации.

Реализовано:
- создание api и возврат ресурсов;
- работа с MS SQL (code-first) через ORM (EF Core), а также паттерны UnitOfWork и Repository. Используются сущности Product и Category. Добавлена простая таблица пользователей.;
- управление ресурсами (CRUD);
- фильтрация, поиск;
- кастомный веб-сервис по отправке сообщений и внедрение зависимостей;
- Аутентификация с помощью JWT-токена;
- Хэширование пароля с помощью алгоритма BCrypt (В проекте не используются готовые решения Identity в ASP.Net)
- Простая кастомная авторизация админ/юзер на основе информации из JWT-токена, без использования готовых решений ролей пользователей;

В процессе реализации:
- Работа с заказами (корзина)
- Улучшение логики построения продукта
