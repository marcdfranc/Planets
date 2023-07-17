using AutoMapper;
using System.Net.Http.Headers;
using XCliente.Core;
using XCliente.Core.Dtos;

namespace XCliente.Factories;

public class ServiceFactory
{
    private readonly string _token;
    private readonly AuthenticationHeaderValue _authorization;

    public DateTime? ExpirationDate { get; private set; }

    public bool IsExpired { get => ExpirationDate == null || ExpirationDate < DateTime.Now; }


    public ServiceFactory(string token)
    {
        _token = token;
       //  ExpirationDate = GeteExpiryTime();
        
        _authorization = new AuthenticationHeaderValue("Bearer", _token);  // TO-DO JWT Authorization
    }


    public static T GetAnonymousClient<T>(string baseUrl = null!, string apiKey = null!)
    {
        var httpClient = new HttpClient();
        try
        {
            // var o = new AuthClient(httpClient);
            var client = (T)Activator.CreateInstance(typeof(T), httpClient)!;
             if (!string.IsNullOrEmpty(baseUrl))
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfiles());
                });

                var maper = configuration.CreateMapper();

                var baseClient = new BasicClient
                {
                    BaseUrl = baseUrl
                };

                maper.Map(baseClient, client);

                if (!string.IsNullOrWhiteSpace(apiKey))
                {
                    httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
                }
            }
            return client;
        }
        catch (Exception )
        {
            
            throw;
        }       
    }

    public T GetClient<T>(string baseUrl = null!)
    {

        var httpClient = new HttpClient();

        if (_authorization != null)
        {
            httpClient.DefaultRequestHeaders.Authorization = _authorization;
        }

        // var o = new AuthClient(httpClient);
        var client = (T) Activator.CreateInstance(typeof(T), httpClient)!;

        if (!string.IsNullOrEmpty(baseUrl))
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            });

            var maper = configuration.CreateMapper();

            var baseClient = new BasicClient
            {
                BaseUrl = baseUrl
            };

            maper.Map(baseClient, client);
        }

        return client;
    }

    //TO-DO : Authorizatio JWT
    private DateTime? GeteExpiryTime()
    {
        throw new NotImplementedException();
    }
}
