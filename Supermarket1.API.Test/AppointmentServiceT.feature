Feature: AppointmentService
As a Developer
I want to add a new Appointment throught API
So that Patients can book them

    Background: 
        Given the endpoint https://localhost:5001/api/v1/appointment is available
        And A Patient is already stored
          | Id | Dni      | Name  | Lastname | Age | Address |
          | 1  | 72837483 | Simba | Tino     | 23  | Lima    |
        And A Doctor is already stored
          | Id | Dni      | Name  | Lastname | SpecialtyId | Clinic |
          | 2  | 72837483 | Simba | Tino     | null        | null   |
    
    @appointment-adding
    Scenario: Add appointment
        When an appointment Post request is sent
          |  StartAt | AppointmentDetailsId | PatientId | DoctorId |
          | null    | null                 | 1         | 2        |
        Then A response with Status 200 is received for appointment
        And An appointment Resource is included in Response Body
          | StartAt | AppointmentDetailsId | PatientId | DoctorId |
          | null    | null                 | 1         | 2        |
    @appointment-invalid-doctor
    Scenario: Add Appointment with Invalid Doctor
        When an appointment Post request is sent
          | StartAt | AppointmentDetailsId | PatientId | DoctorId |
          | null    | null                 | 1         | 202      |
        Then A response with Status 400 is received for appointment
        And a Message of "Invalid Doctor." is included in Response Body for appointment