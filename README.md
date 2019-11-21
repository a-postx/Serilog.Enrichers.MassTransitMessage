## О проекте

Сериложный обогатитель для параметризированного логирования свойств сообщений МассТранзита. Пакет полезен при отладке микросервисных систем для лёгкого отслеживания активностей, источником которых послужило сообщение из шины данных.

## Использование

Установка
```powershell
Install-Package Serilog.Enrichers.MassTransitMessage
```

Подключаем к конвейерам Серилога и МассТранзита
```csharp
using Serilog;
using MassTransit;

public class Startup
{
	public IServiceProvider ConfigureServices(IServiceCollection services)
	{
		Log.Logger = new LoggerConfiguration()
			.Enrich.FromMassTransitMessage()
			.WriteTo.Console()
			.CreateLogger();
  
		services.AddMassTransit(options =>
		{
			options.AddConsumers(GetType().Assembly);
		});

		services.AddSingleton(provider =>
		{
			return Bus.Factory.CreateUsingRabbitMq(cfg =>
			{
				cfg.UseSerilog();
				cfg.UseSerilogMessagePropertiesEnricher();
				
				//...
			});
		});
		
		//...
	}
}
```

В результате получаем события с корреляционныи идентификатором и другими параметрами, которые легко привязать к контексту всего запроса:

![alt text](https://github.com/a-postx/Serilog.Enrichers.MassTransitMessage/blob/master/result.png)

## Лицензия
[MIT](https://github.com/a-postx/Pyhh/blob/master/LICENSE)

## About the project

Serilog enricher for parametrized logging of MassTransit message properties.

## Usage

Setup
```powershell
Install-Package Serilog.Enrichers.MassTransitMessage
```

Insert into MassTransit and Serilog pipeline
```csharp
using Serilog;
using MassTransit;

public class Startup
{
	public IServiceProvider ConfigureServices(IServiceCollection services)
	{
		Log.Logger = new LoggerConfiguration()
			.Enrich.FromMassTransitMessage()
			.WriteTo.Console()
			.CreateLogger();
  
		services.AddMassTransit(options =>
		{
			options.AddConsumers(GetType().Assembly);
		});

		services.AddSingleton(provider =>
		{
			return Bus.Factory.CreateUsingRabbitMq(cfg =>
			{
				cfg.UseSerilog();
				cfg.UseSerilogMessagePropertiesEnricher();
				
				//...
			});
		});
		
		//...
	}
}
```

As a result we're getting events enriched with CorrelationId and other properties that can be easily tied to the overall request flow:

![alt text](https://github.com/a-postx/Serilog.Enrichers.MassTransitMessage/blob/master/result.png)

## License
[MIT](https://github.com/a-postx/Pyhh/blob/master/LICENSE)