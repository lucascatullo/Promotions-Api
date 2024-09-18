## Libreries

1. MediatR was added with a real project in mind, featuring multiple entities and both queries and commands. It allows handling complex interactions between applications and hiding complexity from the controllers (eliminating the need to add services with DI to them).
2. The library Asp.Versioning.MVC was added to document versioning. (Swagger doc)
3. The AutoMapper library was added to simplify the instantiation of DTOs.



## Note 

AutoMapper makes DTO mapping easier by using reflection. The amount of resources it uses is significantly higher compared to doing the mapping manually.



## Code ChangeLog

1. The controllers were moved to a higher folder hierarchy.
2. The repository base class and its interface were created. (The class is empty since there is no actual database connection, but in a real scenario, it would include the common operations for the entities. This is also useful for UT)
3. The promotions repository was created. (SoC)
4. The database connection was converted into a service, so it is no longer necessary to create the connection in the handlers. (SoC)
5. The base response class was created. All responses should extend this class to provide a commun class for Exceptions, response format , etc..
6. The manual mapping from the database model to DTO was removed. Instead, AutoMapper is used with a MappingProfile. Improves readability but at a performance cost. 
7. The exception handling in the handler was removed, and a GlobalExceptionHandler was created to run in the MediatR pipeline. (SoC)
8. The endpoints specified in the exercise were added. 
9. A new version of the API documentation was generated in Swagger.


Considerations:

Add service classes (e.g., PromotionService) in case the project has business logic.
Create handled custom exceptions (even if they consume more resources) to improve error handling.
Consider adding validations to the MediatR pipeline.
With the current configuration, if an endpoint had many different possible HTTP responses, the controllers would become cluttered.


## Unit testing

1. Unit tests were added to verify that DTO mapping is performed correctly.
2. Tests were added to ensure that the handler performs the correct operations (e.g., calling the repository with the correct values, executing the mapping, etc.).
3. Tests were added to verify that the queries return the correct response type.
4. A repository tests folder was created. In this folder, tests should be conducted with a fake dataset to verify that the repositories perform their tasks correctly, such as FilterbyCountryCode_Returns_OnlyEntitiesWithTheCorrectCountryCode. This was not done to avoid creating a fake dataset on top of another fake dataset.



## Docker 

Follow these steps to run the project in Docker:

1. Open a command prompt (CMD) and navigate to the root folder of the solution.
2. Run the command:
   docker build . -t <app-name>
   docker run -p 8080:80 <app-name>

