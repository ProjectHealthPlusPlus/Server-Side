Feature: ClinicLocationServiceT
As a Developer
I want to add a new Clinic Location throught API
So that Clinics can have their location registered

	Background: 
		Given the endpoint https://localhost:5001/api/v1/cliniclocation is available
	
	@clinic-location-adding
	Scenario: Add Clinic Location
		When a clinic location Post request is sent
		  | Address | CapitalCity | Country |
		  | Surco   | Lima        | Peru    |
		Then A response with Status 200 is received for clinic location
		And A clinic location Resource is included in Response Body
		  | Address | CapitalCity | Country |
		  | Surco   | Lima        | Peru    |