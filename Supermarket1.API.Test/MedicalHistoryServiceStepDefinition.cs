using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HealthPlusPlus_AW;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ubiety.Dns.Core;
using Xunit;

namespace Supermarket1.API.Test
{
    [Binding]
    public sealed class MedicalHistoryServiceStepDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private PatientResource Patient { get; set; }
        private ClinicResource Clinic { get; set; }
        
        public MedicalHistoryServiceStepDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/medicalhistory is available")]
        public void GivenTheEndpointHttpsLocalhostApiVMedicalHistoryIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/medicalhistory");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"a Medical History Post request is sent")]
        public void WhenAMedicalHistoryPostRequestIsSent(Table saveMedicalHistoryResource)
        {
            var resource = saveMedicalHistoryResource.CreateSet<SaveMedicalHistoryResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A response with Status (.*) is received for medical history")]
        public void ThenAResponseWithStatusIsReceivedForMedicalHistory(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Then(@"A Medical History Resource is included in Response Body")]
        public async void ThenAMedicalHistoryResourceIsIncludedInResponseBody(Table expectedProductResource)
        {
            var expectedResource = expectedProductResource.CreateSet<MedicalHistoryResource>().First();
            expectedResource.Clinic = Clinic;
            expectedResource.Patient = Patient;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<MedicalHistoryResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource,jsonActualResource);
        }

        [Then(@"a Message of ""(.*)"" is included in Response Body for medical history")]
        public async void ThenAMessageOfIsIncludedInResponseBodyForMedicalHistory(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonActualMessage = actualMessage.ToJson();
            var jsonExpectedMessage = expectedMessage.ToJson();
            Assert.Equal(jsonExpectedMessage,jsonActualMessage);
        }
    }
}