## О проекте

Сериложный обогатитель для параметризированного логирования свойств сообщений МассТранзита, может быть полезен при 

## Использование

Установка
```powershell
Install-Package Serilog.Enrichers.MassTransitMessage
```

Подключаем к Серилогу и МассТранзиту
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
				cfg.UseSerilogMtMessageEnricher();
				
				//...
			});
		});
		
		//...
	}
}
```

В результате получаем обогащённые события, если источником активности послужило сообщение из шины данных:

![alt text](https://github.com/a-postx/Serilog.Enrichers.MassTransitMessage/blob/master/result.png)

## About the project

Serilog enricher for parametrized logging of MassTransit message properties.  

## Лицензия
[MIT](https://github.com/a-postx/Pyhh/blob/master/LICENSE)