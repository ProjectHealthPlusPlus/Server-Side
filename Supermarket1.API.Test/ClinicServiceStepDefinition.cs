using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HealthPlusPlus_AW;
using HealthPlusPlus_AW.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Supermarket1.API.Test
{
    [Binding]
    public class ClinicServiceStepDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private ClinicLocationResource ClinicLocation { get; set; }

        public ClinicServiceStepDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/clinic is available")]
        public void GivenTheEndpointHttpsLocalhostApiVClinicIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/clinic");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }
        
        [When(@"a Clinic Post request is sent")]
        public void WhenAClinicPostRequestIsSent(Table saveClinicResource)
        {
            var resource = saveClinicResource.CreateSet<SaveClinicResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        
        
        [Then(@"A Clinic Resource is included in Response Body")]
        public async void ThenAClinicResourceIsIncludedInResponseBody(Table expectedProductResource)
        {
            var expectedResource = expectedProductResource.CreateSet<ClinicResource>().First();
            expectedResource.ClinicLocation = ClinicLocation;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ClinicResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource,jsonActualResource);
        }
        
        [Given(@"A Clinic Location is already stored")]
        public async void GivenAClinicLocationIsAlreadyStored(Table saveClinicLocationResource)
        {
            var categoryUri = new Uri("https://localhost:5001/api/v1/cliniclocation");
            var resource = saveClinicLocationResource.CreateSet<SaveClinicLocationResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var clinicLocationResponse = Client.PostAsync(categoryUri, content);
            var clinicLocationResponseData = await clinicLocationResponse.Result.Content.ReadAsStringAsync();
            var existingClinicLocation = JsonConvert.DeserializeObject<ClinicLocationResource>(clinicLocationResponseData);
            existingClinicLocation.Id = 1;
            ClinicLocation = existingClinicLocation;
        }

        [Then(@"a Message of ""(.*)"" is included in Response Body for clinic")]
        public async void ThenAMessageOfIsIncludedInResponseBodyForClinic(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonActualMessage = actualMessage.ToJson();
            var jsonExpectedMessage = expectedMessage.ToJson();
            Assert.Equal(jsonExpectedMessage,jsonActualMessage);
        }

        [Then(@"A response with Status (.*) is received for clinic")]
        public void ThenAResponseWithStatusIsReceivedForClinic(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }
    }
}