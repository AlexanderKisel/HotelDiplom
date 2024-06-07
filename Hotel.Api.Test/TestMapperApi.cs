﻿using AutoMapper;
using Hotel.Infrastructures;
using Xunit;

namespace Hotel.Api.Test
{
    /// <summary>
    /// Тест мапперов в Api
    /// </summary>
    public class TestMapperApi
    {
        /// <summary>
        /// Тесты на маппер Api
        /// </summary>
        [Fact]
        public void TestMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiAutoMapperProfile());
            });

            config.AssertConfigurationIsValid();
        }
    }
}
