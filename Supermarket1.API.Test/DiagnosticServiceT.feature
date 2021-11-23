Feature: DiagnosticService
As a Developer
I want to add a new Diagnostic throught API
So that Patients and Doctors would be able to watch them

    Background: 
        Given the endpoint https://localhost:5001/api/v1/diagnostic is available
        And A Specialty is already stored
          | Id | Name       | Description |
          | 1  | Cardiology | Heart       |
        And A Medical History is already stored
          | Id | Name       | Description |
          | 2  | Cardiology | Heart       |
    
    @diagnostic-adding
    Scenario: Add Diagnostic
        When a diagnostic Post request is sent
          | Id  | PublishDate | Description | SpecialtyId | MedicalHistoryId |
          | 101 | null        | Healthy     | 1           | 2             |
        Then A response with Status 200 is received for diagnostic
        And A Diagnostic Resource is included in Response Body
          | Id  | PublishDate | Description | SpecialtyId | MedicalHistoryId |
          | 101 | null        | Healthy     | 1           | 2             |
          
    @diagnostic-invalid-specialty
    Scenario: Add Diagnostic with Invalid Specialty
        When a diagnostic Post request is sent
          | Id | PublishDate | Description | SpecialtyId | MedicalHistoryId |
          | 101  | null        | Healthy     | 404         | null             |
        Then A response with Status 400 is received for appointment
        And a Message of "Invalid Specialty." is included in Response Body for diagnostic
          | PublishDate | Description | SpecialtyId | MedicalHistoryId |
          | null        | Healthy     | 404         | 2                |
        Then A response with Status 400 is received for diagnostic
        And a Message of "Invalid Specialty." is included in Response Body for diagnostic
        
    @diagnostic-invalid-medical-history
    Scenario: Add Diagnostic with Invalid Medical History
      When a diagnostic Post request is sent
        | PublishDate | Description | SpecialtyId | MedicalHistoryId |
        | null        | Healthy     | 1         | 404                |
      Then A response with Status 400 is received for diagnostic
      And a Message of "Invalid Medical History." is included in Response Body for diagnostic
