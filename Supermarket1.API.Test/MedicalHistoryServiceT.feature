Feature: MedicalHistoryServiceT
As a Developer
I want to add a new Medical History throught API
So that Doctors and Patients can watch the Patient Medical Record

	Background: 
		Given the endpoint https://localhost:5001/api/v1/medicalhistory is available
		And A Patient is already stored
		  | Id | Dni      | Name  | Lastname | Age | Address |
		  | 1  | 72837483 | Simba | Tino     | 23  | Lima    |
		And A Clinic is already stored
		  | Id | Dni      | Name    | Lastname | Age | ClinicLocationId |
		  | 2  | 88888888 | Ricardo | Palma    | 23  | null             |
		
	@medical-history-adding
	Scenario: Add Medical History
		When a Medical History Post request is sent
		  | Id | PatientId | DoctorId |
		  | 3  | 1         | 2        |
		Then A response with Status 200 is received for medical history
		And A Medical History Resource is included in Response Body
		  | Id | PatientId | DoctorId |
		  | 3  | 1         | 2        |
	@medical-history-invalid-clinic
	Scenario: Add Medical History with Invalid Clinic
		When a Medical History Post request is sent
		  | Id | PatientId | DoctorId |
		  | 3  | 1         | 404      |
		Then A response with Status 400 is received for medical history
		And a Message of "Invalid Clinic." is included in Response Body for medical history
	@medical-history-invalid-patient
	Scenario: Add Medical History with Invalid patient
		When a Medical History Post request is sent
		  | Id | PatientId | DoctorId |
		  | 3  | 404       | 1      |
		Then A response with Status 400 is received for medical history
		And a Message of "Invalid Patient." is included in Response Body for medical history