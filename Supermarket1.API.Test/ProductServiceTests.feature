Feature: ProductServiceTests
	As a Developer 
	I want to add a new Product throught API
	So that I can be available for applications.

Background: 
	Given the endpoint https://localhost:5001/api/v1/products is available
	And A Category is already stored
	  | Id | Name                  |
	  | 1  | Fruits and Vegetables |
	
	@product-adding
	Scenario: Add prduct
		When a Post request is sent 
		| Name   | QuantityPackage | UnitOfMeasurement | CategoryId |
		| Apple | 3               | 2                 | 1        |
		Then A response with Status 200 is received
		And A product Resource is included in Response Body
		| Name  | QuantityPackage | UnitOfMeasurement | CategoryId |
		| Apple | 3               | MG                | 1        |
	@product-invalid-category
	Scenario: Add Product with Invalid Category
		When a Post request is sent 
		  | Name   | QuantityPackage | UnitOfMeasurement | CategoryId |
		  | Orange | 1               | 2                 | 200        |
		Then A response with Status 400 is received
		And a Message of "Invalid Category." is included in Response Body
	@duplicated-product
	Scenario: Add prduct with existing Name
		Given a Product is already stored
		  | Name   | QuantityPackage | UnitOfMeasurement | CategoryId |
		  | Banana | 2               | 2                 | 1          |
		When a Post request is sent 
		  | Name   | QuantityPackage | UnitOfMeasurement | CategoryId |
		  | Banana | 1               | 2                 | 1          |
		Then A response with Status 400 is received
		And a Message of "Product Name already exists." is included in Response Body