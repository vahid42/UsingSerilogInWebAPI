using Serilog;


namespace Sample_UsingSerilogInWebApi
{
    public static class SerilogConfiguration
    {
        public static void Initial(WebApplicationBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                        .Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Elasticsearch()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    
    }
}
