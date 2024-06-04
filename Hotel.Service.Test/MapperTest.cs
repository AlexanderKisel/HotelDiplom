using AutoMapper;
using Hotel.Services.AutoMappers;
using Xunit;

namespace Hotel.Service.Test
{
    public class MapperTest
    {
        /// <summary>
        /// Тесты на маппер
        /// </summary>
        [Fact]
        public void TestMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });

            config.AssertConfigurationIsValid();
        }
    }
}
