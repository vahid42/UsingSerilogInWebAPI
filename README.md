# Connect to Elasticsearch to insert logs into it using Serilog.3.0.1 in ASP.NET Core WebAPI 7
 You can see how to connect to Elastic Search in this sample code, the steps to do this are explained:
 
# 1:Install-Packages
 Install-Package Serilog
 Install-Package serilog.sinks.Elasticsearch
 Install-Package Serilog.Settings.Configuration
 Install-Package Serilog.Extensions.Hosting
 Install-Package Serilog.Sinks.Console
# 2: Create Class SerilogConfiguration
In this class, Reading the appsettings.json, Create a Create Logger and Use the UseSerilog is defined

 >Reading the appsettings.json
 ```
  var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")                
                         .Build();
```
 >CreateLogger   
```
 Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()            
            .WriteTo.Console()       
            .WriteTo.Elasticsearch()       
             .ReadFrom.Configuration(configuration) 
                .CreateLogger();
```                
                
>Use the UseSerilog
```
builder.Host.UseSerilog();  
```
# 3: appsettings.json
```
{
  "AllowedHosts": "*",
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.Elasticsearch" ],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Information",
        "Microsoft.Hosting.Lifetime": "Warning",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "Elasticsearch",
        "Args": {
          "nodeUris": "http://192.168.7.66:32412/",
          "indexFormat": "Sample_UsingSerilogInWebApi-{0:yyyy-MM-dd}",
          "numberOfShards": 2,
          "numberOfReplicas": 1
        }
      }
    ],
    "Enrich": [ "FromLogContext", "WithMachineName" ],
    "Properties": {
      "app_name": "SerilogInWebApi"
    }
  }

}

```










