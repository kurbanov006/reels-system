# Реализация команды создания платежа с использованием CQRS и MediatR

## В проекте использовались следующие паттерны
### `CQRS (Command Query Responsibility Segregation)`
### `Repository (Репозиторий)`
### `Dependency Injection (Внедрение зависимостей)`
### `Data Transfer Object (DTO)`
### `Mediator (Посредник)`
### `Vertical Slice`
### `Validation (Валидация входных данных)`
### `Result Wrapper (Обёртка результата)`
### `Extension Methods (Методы расширения)`

### Сделано 2 доп. запроса 
1. Получаем комментарии по ID Video
2. Получаем все видео по заданному названию

## Содержание
1. [Описание проекта](#описание-проекта)
2. [Требования](#требования)
3. [Структура проекта](#структура-проекта)
4. [Заключение](#заключение)
5. [Над проектом работали](#над-проектом-работали)

---

## Описание проекта

Этот проект фокусируется на создании платформы для публикации и просмотра видео, что может быть полезно для различных онлайн-сервисов, таких как образовательные платформы, видеохостинги или социальные сети.

Данный проект демонстрирует реализацию команды для создания платежа с использованием паттерна **CQRS** и библиотеки **MediatR**. Команда позволяет:
- Передавать данные для создания платежа.
- Валидировать входные данные.
- Выполнять операцию создания через репозиторий.

---

## Требования

Для работы с проектом вам понадобится:
- **.NET 6+**
- **MediatR 12.0.0+**
- **FluentValidation 11.0.0+**

Установите зависимости:
```bash
dotnet add package MediatR
dotnet add package FluentValidation
```

## Структура проекта
```bash
Project
│
├── Commands
│   ├── CreatePaymentInfo.cs                # Описание команды
│   └── PaymentCreateCommandHandler.cs      # Обработчик команды
│
├── Validators
│   └── CreatePaymentInfoValidator.cs       # Валидация команды
│
├── Repositories
│   └── IPaymentRepository.cs               # Интерфейс репозитория
│
├── Models
│   └── Payment.cs                          # Модель данных
│
└── Extensions
    └── CreatePaymentInfoExtensions.cs      # Маппинг команд в модели
```


## Основная цель проекта
### Проект предназначен для реализации платформы, на которой пользователи могут:

1. Публиковать видео — пользователи могут загружать видеофайлы на платформу, заполнять описание и метаданные, такие как теги, категории и другие параметры.
2. Просматривать видео — пользователи могут просматривать опубликованные видео, используя различные функции, такие как фильтрация по категориям, поисковые запросы, и т. д.
3. Платные видео — в рамках проекта также поддерживается возможность создания платных видео, которые доступны только после оплаты. Это может быть полезно для образовательных курсов, эксклюзивных видео или других платных контентов.


## Что делает проект
### Загрузка и хранение видео:

#### Пользователи могут загружать видеофайлы в систему. Каждый загруженный файл будет сохраняться в базе данных, а также в файловом хранилище (например, облачном или локальном).
#### Видео может быть связано с метаданными, такими как название, описание, категория, теги, продолжительность, автор и т. д.
### Просмотр видео:

#### Платформа позволяет пользователям просматривать видео. В зависимости от настроек приватности, видео может быть доступно всем или только авторизованным пользователям.
#### Реализована поддержка различных форматов видео и адаптивного потокового воспроизведения.
### Платные видео:

#### Для определённых видео можно установить платный доступ. Пользователь должен заплатить определённую сумму для получения доступа к видео.
#### Платные видео можно классифицировать в рамках различных категорий (например, курсы, премиум-контент и т.д.).
### Категории и теги:

#### Видео могут быть классифицированы по категориям (например, «Образование», «Развлечения», «Спорт»).
#### Пользователи могут искать и фильтровать видео по категориям, тегам или ключевым словам, что улучшает навигацию и пользовательский опыт.
### Платформа для авторов:

#### Авторы видео могут создавать, редактировать, удалять и управлять своими видео.
#### Также предусмотрена возможность для авторов устанавливать платный доступ к своим видео и управлять этим процессом.



## Заключение
- Этот проект предоставляет основные функции для создания платформы, на которой можно публиковать, просматривать и монетизировать видео. Используемая архитектура позволяет легко масштабировать проект и добавлять новые функции, такие как рекомендации, комментарии и подписки.


## Над проектом работали
## `Kurbanov Daler`