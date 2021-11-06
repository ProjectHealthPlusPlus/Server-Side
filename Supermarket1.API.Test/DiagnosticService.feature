Feature: SpecialtyService
	As a Developer 
	I want to add a new Diagnostic throught API
	So that I can be available for applications.

	
Background: 
	Given the endpoint https://localhost:5001/api/v1/diagnostic is available
	And A Specialty is already stored
		| Id | Name                  | Description     |
		| 1  | Cardiology            | Foccus on Heart |
  
@diagnostic-adding
Scenario: Add diagnostic
	When a diagnostic Post request is sent
		| Id | PublishDate | Description                | SpecialtyId | MedicalHistoryId |
		| 1  | null        | Se encuentra bien de salud | 1           | null             |
	Then A response with Status 200 is received
	And A Diagnostic Resource is included in Response Body
	  | Id | PublishDate | Description                | SpecialtyId | MedicalHistoryId |
	  | 1  | null        | Se encuentra bien de salud | 1           | null             |
   
@product-invalid-specialty
Scenario: Add Diagnostic with Invalid Specialty
	When a diagnostic Post request is sent 
	  | Id | PublishDate | Description                | SpecialtyId | MedicalHistoryId |
	  | 1  | null        | Se encuentra bien de salud | 2           | null             |
	Then A response with Status 400 is received
	And a Message of "Invalid Category." is included in Response Body
#@duplicated-diagnostic
#Scenario: Add diagnostic with existing Name
#	Given a Product is already stored
#	  | Name   | QuantityPackage | UnitOfMeasurement | CategoryId |
#	  | Banana | 2               | 2                 | 1          |
#	When a Post request is sent 
#	  | Name   | QuantityPackage | UnitOfMeasurement | CategoryId |
#	  | Banana | 1               | 2                 | 1          |
#	Then A response with Status 400 is received
#	And a Message of "Product Name already exists." is included in Response Body