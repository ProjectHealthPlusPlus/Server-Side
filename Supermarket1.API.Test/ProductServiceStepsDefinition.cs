﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HealthPlusPlus_AW;
using HealthPlusPlus_AW.Example.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Supermarket1.API.Test
{
    [Binding]
    public class ProductServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private CategoryResource Category { get; set; }
        private ProductResource Product { get; set; }

        public ProductServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/product is available")]
        public void GivenTheProductEndpointIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/product");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"a Post request is sent")]
        public void WhenAPostRequestIsSent(Table saveProductResource)
        {
            var resource = saveProductResource.CreateSet<SaveProductResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A response with Status (.*) is received")]
        public void ThenAResponseIsReceivedWitStatus(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Then(@"A product Resource is included in Response Body")]
        public async void ThenAProductResourceIsIncludedInResponseBody(Table expectedProductResource)
        {
            var expectedResource = expectedProductResource.CreateSet<ProductResource>().First();
            expectedResource.Category = Category;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ProductResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource,jsonActualResource);
        }
        
        [Given(@"A Category is already stored")]
        public async void GivenACategoryIsAlreadyStored(Table saveCategoryResource)
        {
            var categoryUri = new Uri("https://localhost:5001/api/v1/categories");
            // var resource = new Category() {Id = 100, Name = "Fruits and Vegetables"};
            var resource = saveCategoryResource.CreateSet<SaveCategoryResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var categoryResponse = Client.PostAsync(categoryUri, content);
            var categoryResponseData = await categoryResponse.Result.Content.ReadAsStringAsync();
            var existingCategory = JsonConvert.DeserializeObject<CategoryResource>(categoryResponseData);
            existingCategory.Id = 1;
            Category = existingCategory;
        }

        [Then(@"a Message of ""(.*)"" is included in Response Body")]
        public async void ThenAMessageIsIncludedInResponseBodyWithValue(string expectedMessage)
        {   
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonActualMessage = actualMessage.ToJson();
            var jsonExpectedMessage = expectedMessage.ToJson();
            Assert.Equal(jsonExpectedMessage,jsonActualMessage);
        }

        [Given(@"a Product is already stored")]
        public async void GivenAProductIsAlreadyStored(Table existingProductResource)
        {
            var resource = existingProductResource.CreateSet<SaveProductResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var productResponse = Client.PostAsync(BaseUri, content);
            var productResponseData = await productResponse.Result.Content.ReadAsStringAsync();
            var existingProduct = JsonConvert.DeserializeObject<ProductResource>(productResponseData);
            Product = existingProduct;
        }
    }
}