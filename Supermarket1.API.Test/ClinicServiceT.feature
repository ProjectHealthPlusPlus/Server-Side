Feature: ClinicServiceT
As a Developer
I want to add a new Clinic throught API
So that Clinics can have their Admind Account

    Background: 
        Given the endpoint https://localhost:5001/api/v1/clinic is available
        And A Clinic Location is already stored
          | Id | Address    | CapitalCity | Country |
          | 1  | Cardiology | Lima        | Peru    |

    @clinic-adding
    Scenario: Add Clinic
        When a Clinic Post request is sent
          | Dni      | Name    | Lastname | Age | ClinicLocationId |
          | 88888888 | Ricardo | Palma    | 23  | 1                |
        Then A response with Status 200 is received for clinic
        And A Clinic Resource is included in Response Body
          | Dni      | Name    | Lastname | Age | ClinicLocationId |
          | 88888888 | Ricardo | Palma    | 23  | 1                |
    @clinic-invalid-clinic-location
    Scenario: Add Clinic with Invalid Clinic Location
        When a Clinic Post request is sent
          | Dni      | Name    | Lastname | Age | ClinicLocationId |
          | 88888888 | Ricardo | Palma    | 23  | 404              |
        Then A response with Status 400 is received for clinic
        And a Message of "Invalid Clinic Location." is included in Response Body for clinic
