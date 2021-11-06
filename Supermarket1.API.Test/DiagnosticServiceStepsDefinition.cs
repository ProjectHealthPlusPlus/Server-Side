using System;
using System.Net.Http;
using System.Threading.Tasks;
using HealthPlusPlus_AW;
using HealthPlusPlus_AW.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;

namespace Supermarket1.API.Test
{
    [Binding]
    public class DiagnosticServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private Task<HttpResponseMessage> Response { get; set; }
        private SpecialtyResource Specialty { get; set; }
        private DiagnosticResource Diagnostic { get; set; }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/diagnostic is available")]
        public void GivenTheEndpointHttpsLocalhostApiVDiagnosticIsAvailable(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }
    }
}