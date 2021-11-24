Feature: SpecialtyServiceT
As a Developer
I want to add a new Specialty Location throught API
So that Diagnostic and Doctors can have the specialty registered

	Background: 
		Given the endpoint https://localhost:5001/api/v1/specialty is available
	
	@specialty-adding
	Scenario: Add Specialty
		When a specialty Post request is sent
		  | Name       | Description |
		  | Cardiology | Heart       |
		Then A response with Status 200 is received for specialty
		And A specialty Resource is included in Response Body
		  | Name       | Description |
		  | Cardiology | Heart       |