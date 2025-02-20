## IgniteData Technical Assessment - Brian Purvis

### My Experience

I found this an interesting task but also really quite challenging to complete in 3 hours. I admit, I spent 
about 4 hours in total but had delays due to EF migrations in Postgres, and I did want to show it working.

### Description

There are 4 projects: 
 - Medication.Entities : code first entity classes
 - Medication.Api : ASPNet Core Web API project with MedicationRequest endpoint
 - Medication.Tests : Unit tests implemented with XUnit
 - docker-compose : Orchestration of the service container and dependent Postgres container

To run, set the target project to docker-compose and click run. The API is configured to run on port 8081 (https).

### To Do:

Given more time I would have liked to have added:
  - Authentication
  - Some server-side validation around the POST method
  - Caching : eg Redis
  - Cancellation of async operations
  - Better error handling
  - More unit tests for error conditions
  - Use Gherkin for unit tests
  - Bug - POST passing invalid foreign key refs returns success but (correctly) doesn't insert
  - Bug - POST doesn't return new Id