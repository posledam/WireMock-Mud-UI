# Миграция на WireMock.Net.RestClient

## 📦 Обзор изменений

Проект полностью мигрирован на использование официального **WireMock.Net.RestClient** для взаимодействия с WireMock API вместо кастомной реализации на базе HttpClient.

## 🎯 Цель

Стандартизация взаимодействия с WireMock API через официальный REST клиент с использованием типизированных моделей из пакета WireMock.Net.

## 🔧 Основные изменения

### Зависимости
- ✅ Добавлен `WireMock.Net.RestClient` v1.9.0
- ✅ Добавлен `RestEase.HttpClientFactory` v1.6.4 для интеграции с DI

### Сервисный слой
- ♻️ **WireMockService**: заменен `HttpClient` на `IWireMockAdminApi`
- ♻️ **IWireMockService**: обновлены сигнатуры методов для использования официальных моделей
- 🗑️ Удалены кастомные JSON-обработчики

### Модели данных
Заменены кастомные модели на стандартные из WireMock.Net:

| Было | Стало |
|------|-------|
| `MappingsList` | `IList<MappingModel>` |
| `WireMockMapping` | `MappingModel` |
| `CreateMappingRequest` | `MappingModel` |
| `RequestsList` | `IList<LogEntryModel>` |
| `WireMockRequest` | `LogEntryModel` |

### UI компоненты
Обновлены все 5 Razor-компонентов:
- ✏️ `Mappings.razor` - список маппингов
- ✏️ `Requests.razor` - лог запросов
- ✏️ `CreateMappingDialog.razor` - создание маппинга
- ✏️ `ViewMappingDialog.razor` - просмотр маппинга
- ✏️ `ViewRequestDialog.razor` - просмотр запроса

### Конфигурация
- ⚙️ **Program.cs**: регистрация `IWireMockAdminApi` через RestEase DI

## ✨ Преимущества

1. **Стандартизация** - использование официальных моделей и API
2. **Типобезопасность** - полная поддержка IntelliSense
3. **Расширяемость** - доступ к полному функционалу WireMock Admin API
4. **Поддержка** - официальный пакет от разработчиков WireMock.Net
5. **Меньше кода** - убрана кастомная обработка HTTP и JSON

## ⚠️ Breaking Changes

### Структура данных
- **Path в маппингах**: теперь объект `MatcherModel` вместо строки
- **Requests**: обернуты в `LogEntryModel`, сам запрос в `LogEntryModel.Request`
- **Delay**: тип изменен с `int` на `int?` (nullable)
- **Headers**: могут быть `Dictionary<string, object>` вместо `Dictionary<string, string>`

## 📝 Файлы изменены

- `WireMockUI.csproj` - добавлены пакеты
- `Program.cs` - обновлена регистрация сервисов
- `Services/IWireMockService.cs` - обновлены сигнатуры
- `Services/WireMockService.cs` - переписан на IWireMockAdminApi
- `Components/Pages/Mappings.razor` - обновлены модели
- `Components/Pages/Requests.razor` - обновлены модели
- `Components/Pages/CreateMappingDialog.razor` - создание MappingModel
- `Components/Pages/ViewMappingDialog.razor` - отображение MappingModel
- `Components/Pages/ViewRequestDialog.razor` - отображение LogEntryModel

## 🧪 Тестирование

- ✅ Проект компилируется без ошибок
- ⏳ Требуется функциональное тестирование с работающим WireMock сервером

## 📚 Связанные ресурсы

- [WireMock.Net.RestClient на NuGet](https://www.nuget.org/packages/WireMock.Net.RestClient/)
- [WireMock.Net GitHub](https://github.com/wiremock/WireMock.Net)
- [WireMock.Net Admin API Reference](https://wiremock.org/dotnet/admin-api-reference/)

## 📊 Статистика

- **Коммитов**: 2
- **Файлов изменено**: 9
- **Строк добавлено**: ~107
- **Строк удалено**: ~97

## 🚀 Как создать Pull Request

### Вариант 1: Через GitHub UI
1. Перейдите по ссылке: https://github.com/posledam/WireMock-Mud-UI/pull/new/claude/wiremock-restclient-investigation-01PY33prKCvnXomLph8nusVf
2. Скопируйте содержимое этого файла в описание PR
3. Нажмите "Create Pull Request"

### Вариант 2: Через командную строку
Если у вас установлен GitHub CLI, выполните:

```bash
gh pr create \
  --title "Миграция на WireMock.Net.RestClient" \
  --body-file PR_DESCRIPTION.md \
  --head claude/wiremock-restclient-investigation-01PY33prKCvnXomLph8nusVf
```
