Feature: DoctorServiceT
As a Developer
I want to add a new Doctor throught API
So that Doctors can have their own profile

	Background: 
		Given the endpoint https://localhost:5001/api/v1/doctor is available
		And A Specialty is already stored
		  | Id | Name       | Description |
		  | 1  | Cardiology | Heart       |
		And A Clinic is already stored
		  | Id | Dni      | Name    | Lastname | Age | ClinicLocationId |
		  | 2  | 88888888 | Ricardo | Palma    | 23  | null             |
	@doctor-adding
	Scenario: Add Doctor
		When a Doctor Post request is sent
		  | Dni      | Name  | Lastname | Age | SpecialtyId | ClinicId |
		  | 72837483 | Simba | Tino     | 23  | 1         | 2        |
		Then A response with Status 200 is received for doctor
		And A Doctor Resource is included in Response Body
		  | Dni      | Name  | Lastname | Age | SpecialtyId | ClinicId |
		  | 2837483 | Simba | Tino     | 23  | 1         | 2        |
	@doctor-invalid-specialty
	Scenario: Add Doctor with Invalid Specialty
		When a Doctor Post request is sent
		  | Dni      | Name  | Lastname | Age  | SpecialtyId | ClinicId |
		  | 72837483 | Simba | Tino     | 23   | 404         | 2        |
		Then A response with Status 400 is received for doctor
		And a Message of "Invalid Specialty." is included in Response Body for doctor
	@doctor-invalid-clinic
	Scenario: Add Doctor with Invalid Clinic
		When a Doctor Post request is sent
		  | Id | Dni      | Name  | Lastname | Age | SpecialtyId | ClinicId |
		  | 3  | 72837483 | Simba | Tino     | 23  | 1         | 404      |
		Then A response with Status 400 is received for doctor
		And a Message of "Invalid Clinic." is included in Response Body for doctor