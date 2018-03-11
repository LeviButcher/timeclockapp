using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }

    public class Greeter : IGreeter
    {
        private readonly IConfiguration _config;

        public Greeter(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GetMessageOfTheDay()
        {
            return _config["Greeting"];
        }
    }

}