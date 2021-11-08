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
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Supermarket1.API.Test
{
    [Binding]
    public sealed class DiagnosticServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private SpecialtyResource Specialty { get; set; }
        private MedicalHistoryResource MedicalHistory { get; set; }

        public DiagnosticServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/diagnostic is available")]
        public void GivenTheEndpointHttpsLocalhostApiVDiagnosticIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/{version}/diagnostic");
            Client = _factory.CreateClient((new WebApplicationFactoryClientOptions {BaseAddress = BaseUri}));
        }

        [When(@"a diagnostic Post request is sent")]
        public void WhenADiagnosticPostRequestIsSent(Table saveDiagnosticResource)
        {
            var resource = saveDiagnosticResource.CreateSet<SaveDiagnosticResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A response with the Status (.*) is received")]
        public void ThenAResponseWithTheStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Then(@"A Diagnostic Resource is included in Response Body")]
        public async void ThenADiagnosticResourceIsIncludedInResponseBody(Table expectedDiagnosticResource)
        {
            var expectedResource = expectedDiagnosticResource.CreateSet<DiagnosticResource>().First();
            expectedResource.Specialty = Specialty;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<DiagnosticResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource,jsonActualResource);
        }

        [Given(@"A Specialty is already stored")]
        public async void GivenASpecialtyIsAlreadyStored(Table saveSpecialtyResource)
        {
            var categoryUri = new Uri("https://localhost:5001/api/v1/specialty");
            
            var resource = saveSpecialtyResource.CreateSet<SaveSpecialtyResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var specialtyResponse = Client.PostAsync(categoryUri, content);
            var specialtyResponseData = await specialtyResponse.Result.Content.ReadAsStringAsync();
            var existingSpecialty = JsonConvert.DeserializeObject<SpecialtyResource>(specialtyResponseData);
            existingSpecialty.Id = 1;
            Specialty = existingSpecialty;
        }
        
        [Given(@"A Medical History is already stored")]
        public async void GivenAMedicalHistoryIsAlreadyStored(Table saveMedicalHistoryResource)
        {
            var categoryUri = new Uri("https://localhost:5001/api/v1/medicalhistory");
            
            var resource = saveMedicalHistoryResource.CreateSet<SaveMedicalHistoryResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var medicalHistoryResponse = Client.PostAsync(categoryUri, content);
            var medicalHistoryResponseData = await medicalHistoryResponse.Result.Content.ReadAsStringAsync();
            var existingMedicalHistory = JsonConvert.DeserializeObject<MedicalHistoryResource>(medicalHistoryResponseData);
            existingMedicalHistory.Id = 2;
            MedicalHistory = existingMedicalHistory;
        }

        [Then(@"A response with Status (.*) is received for diagnostic")]
        public void ThenAResponseWithTheStatusIsReceivedForDiagnostic(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Then(@"a Message of ""(.*)"" is included in Response Body for diagnostic")]
        public async void ThenAMessageOfIsIncludedInResponseBodyForDiagnostic(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonActualMessage = actualMessage.ToJson();
            var jsonExpectedMessage = expectedMessage.ToJson();
            Assert.Equal(jsonExpectedMessage,jsonActualMessage);
        }

        
    }
}