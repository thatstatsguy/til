using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Caching.Memory;

namespace PollyWalkthrough.Caching;


public static class CachingEndpoints
{
    
    public static WebApplication AddCachingBackEndpoints(this WebApplication app)
    {
        MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
        MemoryCacheProvider memoryCacheProvider = new MemoryCacheProvider(memoryCache);
        //potential to use redis/sql server as caching mechanism as well
        //https://github.com/App-vNext/Polly/tree/main#cache
        var cachePolicy = Policy.CacheAsync(memoryCacheProvider, TimeSpan.FromMinutes(1));
        
        
        app.MapGet("/Caching", async ([FromServices] IHttpClientFactory clientFactory) =>
        {
            var getResult = async () =>
            {
                var client = clientFactory.CreateClient("boredapi");
                
                var result =  await client.GetAsync("activity");
                return await result.Content.ReadAsStringAsync();
            };
            var result = await cachePolicy.ExecuteAsync(context => getResult() , new Context("FooKey") );
            return Results.Ok(result);
        });
            
        return app;
    }
}