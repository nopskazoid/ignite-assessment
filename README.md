## IgniteData Technical Assessment - Brian Purvis

### Description

There are 4 projects: 
 - Medication.Entities : code first entity classes
 - Medication.Api : ASPNet Core Web API service project with MedicationRequest endpoint
 - Medication.Tests : Unit tests implemented with XUnit
 - docker-compose : Orchestration of the service container and dependent Postgres container

To run, set the target project to docker-compose and click run. 

### To Do:

Given more time I would have liked to have added:
  - Authentication
  - Some server-side validation around the POST method
  - Caching : eg Redis
  - Cancellation of async operations
  - Better error handling
  - More unit tests for error conditions
  - Bug - POST passing invalid foreign key refs returns success but (correctly) doesn't insert
  - Bug - POST doesn't return new Id