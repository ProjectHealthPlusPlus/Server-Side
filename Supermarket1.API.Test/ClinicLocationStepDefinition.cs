using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HealthPlusPlus_AW;
using HealthPlusPlus_AW.meeting.Resource;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Supermarket1.API.Test
{
    [Binding]
    public class ClinicLocationStepDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }

        public ClinicLocationStepDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/cliniclocation is available")]
        public void GivenTheEndpointHttpsLocalhostApiVCliniclocationIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/cliniclocation");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }
        
        [When(@"a clinic location Post request is sent")]
        public void WhenAClinicLocationPostRequestIsSent(Table saveClinicLocationResource)
        {
            var resource = saveClinicLocationResource.CreateSet<SaveClinicLocationResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A response with Status (.*) is received for clinic location")]
        public void ThenAResponseWithStatusIsReceivedForClinicLocation(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Then(@"A clinic location Resource is included in Response Body")]
        public async void ThenAClinicLocationResourceIsIncludedInResponseBody(Table expectedProductResource)
        {
            var expectedResource = expectedProductResource.CreateSet<ClinicLocationResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ClinicLocationResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource,jsonActualResource);
        }
    }
}