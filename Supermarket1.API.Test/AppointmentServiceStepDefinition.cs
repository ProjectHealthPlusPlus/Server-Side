using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HealthPlusPlus_AW;
using HealthPlusPlus_AW.meeting.Resource;
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
    public sealed class AppointmentServiceStepDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private AppointmentResource Appointment { get; set; }
        private AppointmentDetailsResource AppointmentDetails { get; set; }
        private PatientResource Patient { get; set; }
        private DoctorResource Doctor { get; set; }

        public AppointmentServiceStepDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/appointment is available")]
        public void GivenTheEndpointHttpsLocalhostApiVAppointmentIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/appointment");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"an appointment Post request is sent")]
        public void WhenAnAppointmentPostRequestIsSent(Table saveAppointmentResource)
        {
            var resource = saveAppointmentResource.CreateSet<SaveAppointmentResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A response with Status (.*) is received for appointment")]
        public void ThenAResponseWithStatusIsReceivedForAppointment(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Then(@"An appointment Resource is included in Response Body")]
        public async void ThenAnAppointmentResourceIsIncludedInResponseBody(Table expectedAppointmentResource)
        {
            var expectedResource = expectedAppointmentResource.CreateSet<AppointmentResource>().First();
            expectedResource.Doctor = Doctor;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<AppointmentResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource,jsonActualResource);
        }

        [Given(@"A Patient is already stored")]
        public async void GivenAPatientIsAlreadyStored(Table savePatientResource)
        {
            var categoryUri = new Uri("https://localhost:5001/api/v1/patient");
            // var resource = new Category() {Id = 100, Name = "Fruits and Vegetables"};
            var resource = savePatientResource.CreateSet<SavePatientResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var patientResponse = Client.PostAsync(categoryUri, content);
            var patientResponseData = await patientResponse.Result.Content.ReadAsStringAsync();
            var existingPatient = JsonConvert.DeserializeObject<PatientResource>(patientResponseData);
            existingPatient.Id = 1;
            Patient = existingPatient;
        }

        [Given(@"A Doctor is already stored")]
        public async void GivenADoctorIsAlreadyStored(Table saveDoctorResource)
        {
            var categoryUri = new Uri("https://localhost:5001/api/v1/doctor");
            // var resource = new Category() {Id = 100, Name = "Fruits and Vegetables"};
            var resource = saveDoctorResource.CreateSet<SaveDoctorResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var doctorResponse = Client.PostAsync(categoryUri, content);
            var doctorResponseData = await doctorResponse.Result.Content.ReadAsStringAsync();
            var existingDoctor = JsonConvert.DeserializeObject<DoctorResource>(doctorResponseData);
            existingDoctor.Id = 2;
            Doctor = existingDoctor;
        }

        [Then(@"a Message of ""(.*)"" is included in Response Body for appointment")]
        public async void ThenAMessageOfIsIncludedInResponseBody(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonActualMessage = actualMessage.ToJson();
            var jsonExpectedMessage = expectedMessage.ToJson();
            Assert.Equal(jsonExpectedMessage,jsonActualMessage);
        }
    }
}