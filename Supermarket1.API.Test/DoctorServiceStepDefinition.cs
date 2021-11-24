using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HealthPlusPlus_AW;
using HealthPlusPlus_AW.Heal.Resource;
using HealthPlusPlus_AW.Profile.Resource;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Supermarket1.API.Test
{
    [Binding]
    public class DoctorServiceStepDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private SpecialtyResource Specialty { get; set; }
        private ClinicResource Clinic { get; set; }
        private DoctorResource Doctor { get; set; }
        
        public DoctorServiceStepDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/doctor is available")]
        public void GivenTheEndpointHttpsLocalhostApiVDoctorIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/doctor");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Given(@"A Clinic is already stored")]
        public async void GivenAClinicIsAlreadyStored(Table saveClinicResource)
        {
            var categoryUri = new Uri("https://localhost:5001/api/v1/clinic");
            // var resource = new Category() {Id = 100, Name = "Fruits and Vegetables"};
            var resource = saveClinicResource.CreateSet<SaveClinicResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var clinicResponse = Client.PostAsync(categoryUri, content);
            var clinicResponseData = await clinicResponse.Result.Content.ReadAsStringAsync();
            var existingClinic = JsonConvert.DeserializeObject<ClinicResource>(clinicResponseData);
            existingClinic.Id = 2;
            Clinic = existingClinic;
        }

        [When(@"a Doctor Post request is sent")]
        public void WhenADoctorPostRequestIsSent(Table saveDoctorResource)
        {
            var resource = saveDoctorResource.CreateSet<SaveDoctorResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A response with Status (.*) is received for doctor")]
        public void ThenAResponseWithStatusIsReceivedForDoctor(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Then(@"A Doctor Resource is included in Response Body")]
        public async void ThenADoctorResourceIsIncludedInResponseBody(Table expectedDoctorResource)
        {
            var expectedResource = expectedDoctorResource.CreateSet<DoctorResource>().First();
            expectedResource.Clinic = Clinic;
            expectedResource.Specialty = Specialty;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<DoctorResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource,jsonActualResource);
        }

        [Then(@"a Message of ""(.*)"" is included in Response Body for doctor")]
        public async void ThenAMessageOfIsIncludedInResponseBodyForDoctor(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonActualMessage = actualMessage.ToJson();
            var jsonExpectedMessage = expectedMessage.ToJson();
            Assert.Equal(jsonExpectedMessage,jsonActualMessage);
        }
    }
}