using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;

namespace Application.Middleware.Localization;

public class JsonStringLocalizerFactory(IDistributedCache cache) : IStringLocalizerFactory
{
    public IStringLocalizer Create(Type resourceSource)
    {
        return new JsonStringLocalizer(cache);
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        return new JsonStringLocalizer(cache);
    }
}