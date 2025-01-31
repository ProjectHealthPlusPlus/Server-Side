﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Supermarket1.API.Test
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class DiagnosticServiceFeature : object, Xunit.IClassFixture<DiagnosticServiceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "DiagnosticServiceT.feature"
#line hidden
        
        public DiagnosticServiceFeature(DiagnosticServiceFeature.FixtureData fixtureData, Supermarket1_API_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "", "DiagnosticService", "As a Developer\r\nI want to add a new Diagnostic throught API\r\nSo that Patients and" +
                    " Doctors would be able to watch them", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
    #line hidden
#line 7
        testRunner.Given("the endpoint https://localhost:5001/api/v1/diagnostic is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Description"});
            table12.AddRow(new string[] {
                        "1",
                        "Cardiology",
                        "Heart"});
#line 8
        testRunner.And("A Specialty is already stored", ((string)(null)), table12, "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "PatientId",
                        "ClinicId"});
            table13.AddRow(new string[] {
                        "2",
                        "null",
                        "null"});
#line 11
        testRunner.And("A Medical History is already stored", ((string)(null)), table13, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add Diagnostic")]
        [Xunit.TraitAttribute("FeatureTitle", "DiagnosticService")]
        [Xunit.TraitAttribute("Description", "Add Diagnostic")]
        [Xunit.TraitAttribute("Category", "diagnostic-adding")]
        public virtual void AddDiagnostic()
        {
            string[] tagsOfScenario = new string[] {
                    "diagnostic-adding"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Diagnostic", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 16
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "PublishDate",
                            "Description",
                            "SpecialtyId",
                            "MedicalHistoryId"});
                table14.AddRow(new string[] {
                            "null",
                            "Healthy",
                            "1",
                            "2"});
#line 17
        testRunner.When("a diagnostic Post request is sent", ((string)(null)), table14, "When ");
#line hidden
#line 20
        testRunner.Then("A response with Status 200 is received for diagnostic", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "PublishDate",
                            "Description",
                            "SpecialtyId",
                            "MedicalHistoryId"});
                table15.AddRow(new string[] {
                            "null",
                            "Healthy",
                            "1",
                            "2"});
#line 21
        testRunner.And("A Diagnostic Resource is included in Response Body", ((string)(null)), table15, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add Diagnostic with Invalid Specialty")]
        [Xunit.TraitAttribute("FeatureTitle", "DiagnosticService")]
        [Xunit.TraitAttribute("Description", "Add Diagnostic with Invalid Specialty")]
        [Xunit.TraitAttribute("Category", "diagnostic-invalid-specialty")]
        public virtual void AddDiagnosticWithInvalidSpecialty()
        {
            string[] tagsOfScenario = new string[] {
                    "diagnostic-invalid-specialty"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Diagnostic with Invalid Specialty", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 26
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "PublishDate",
                            "Description",
                            "SpecialtyId",
                            "MedicalHistoryId"});
                table16.AddRow(new string[] {
                            "101",
                            "null",
                            "Healthy",
                            "404",
                            "2"});
#line 27
        testRunner.When("a diagnostic Post request is sent", ((string)(null)), table16, "When ");
#line hidden
#line 30
        testRunner.Then("A response with Status 400 is received for diagnostic", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 31
        testRunner.And("a Message of \"Invalid Specialty.\" is included in Response Body for diagnostic", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add Diagnostic with Invalid Medical History")]
        [Xunit.TraitAttribute("FeatureTitle", "DiagnosticService")]
        [Xunit.TraitAttribute("Description", "Add Diagnostic with Invalid Medical History")]
        [Xunit.TraitAttribute("Category", "diagnostic-invalid-medical-history")]
        public virtual void AddDiagnosticWithInvalidMedicalHistory()
        {
            string[] tagsOfScenario = new string[] {
                    "diagnostic-invalid-medical-history"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Diagnostic with Invalid Medical History", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 34
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "PublishDate",
                            "Description",
                            "SpecialtyId",
                            "MedicalHistoryId"});
                table17.AddRow(new string[] {
                            "101",
                            "null",
                            "Healthy",
                            "2",
                            "404"});
#line 35
      testRunner.When("a diagnostic Post request is sent", ((string)(null)), table17, "When ");
#line hidden
#line 38
      testRunner.Then("A response with Status 400 is received for diagnostic", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
      testRunner.And("a Message of \"Invalid Medical History.\" is included in Response Body for diagnost" +
                        "ic", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                DiagnosticServiceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                DiagnosticServiceFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
