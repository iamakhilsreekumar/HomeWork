using BrokenAPI.common;
using BrokenAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BrokenAPI.Test
{
    public class HomeControllerTest
    {
        private Mock<IConfiguration> config;
        private HomeController test;
        public HomeControllerTest()
        {
            config = new Mock<IConfiguration>();



        }
        [Fact]
        public void TestValid_IndexLoad()
        {
            Mock<HttpHandlers> http = new Mock<HttpHandlers>(config.Object);
            HomeController test = new HomeController(http.Object);
            var result = test.Index() as ViewResult;
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Test_GetPeopleAsync_With_Valid()
        {
            Mock<HttpHandlers> http = new Mock<HttpHandlers>(config.Object);
            ApiParser api = new ApiParser()
            {
                results = new System.Collections.Generic.List<Result>
                {
                    new Result
                    {
                        uid="",
                        url="",
                        name="Sathish Davan"
                    }
                }
            };
            http.Setup(x => x.CallAPIAsync<ApiParser>()).ReturnsAsync(api);
            HomeController test = new HomeController(http.Object);
            var result = await test.GetPeopleAsync("s") as ContentResult;
            Assert.True(!string.IsNullOrEmpty(result.Content));
        }

        [Fact]
        public async Task Test_GetPeopleAsync_With_Invalid()
        {
            Mock<HttpHandlers> http = new Mock<HttpHandlers>(config.Object);
            ApiParser api = new ApiParser()
            {
                results = new System.Collections.Generic.List<Result>
                {
                    new Result
                    {
                        uid="",
                        url="",
                        name="Davan"
                    }
                }
            };
            http.Setup(x => x.CallAPIAsync<ApiParser>()).ReturnsAsync(api);
            HomeController test = new HomeController(http.Object);
            var result = await test.GetPeopleAsync("s") as ContentResult;
            Assert.True(string.IsNullOrEmpty(result.Content));
        }
    }
}

 

