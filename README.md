## О проекте

Сериложный обогатитель для параметризированного логирования свойств сообщений МассТранзита.
Пакет предназначен для уменьшения боли при трассировке распределённых микросервисных систем. После настройки, логи Серилога станут обогащаться дополнительными свойствами, если источником активности послужило сообщение из шины данных МассТранзита.

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
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fa-postx%2FSerilog.Enrichers.MassTransitMessage.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2Fa-postx%2FSerilog.Enrichers.MassTransitMessage?ref=badge_shield)

## Лицензия
[MIT](https://github.com/a-postx/Serilog.Enrichers.MassTransitMessage/blob/master/LICENSE)

## About

Serilog enricher for parametrized logging of MassTransit message properties.
Package reduces tracing pain in distributed microservice systems. Once configured, Serilog events will be enriched with extra properties in case the activity source is a MassTransit message bus message.

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
[MIT](https://github.com/a-postx/Serilog.Enrichers.MassTransitMessage/blob/master/LICENSE)

[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fa-postx%2FSerilog.Enrichers.MassTransitMessage.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Fa-postx%2FSerilog.Enrichers.MassTransitMessage?ref=badge_large)