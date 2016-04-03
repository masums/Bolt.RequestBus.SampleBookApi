using System.Configuration;

namespace BookWorm.Api.Features.Shared
{
    public interface ISettings
    {
        string ApplicationId { get; }
    }

    public class Settings : ISettings
    {
        public Settings()
        {
            ApplicationId = ConfigurationManager.AppSettings["ApplicationId"];
        }

        public string ApplicationId { get; }
    }
}