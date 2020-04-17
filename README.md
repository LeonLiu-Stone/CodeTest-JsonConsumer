# CodeTest-JsonConsumer

A code test project for AGL

# Test Description

## Programming challenge

A json web service has been set up at the url: http://agl-developer-test.azurewebsites.net/people.json

You need to write some code to consume the json and output a list of all the cats in alphabetical order under a heading of the gender of their owner.

You can write it in any language you like. You can use any libraries/frameworks/SDKs you choose.

Example:

Male

- Angel
- Molly
- Tigger

Female

- Gizmo
- Jasper

Notes

- Submissions will only be accepted via github or bitbucket
- Use industry best practices
- Use the code to showcase your skill.

# Implementation

## Env:

- VS Studio 2019 for Mac
- .Net Core 3.1
- XUnit
- Github

## Code Structure

### JsonConsumer.Api
- Controllers
  RegistrationController: a endpoint to return expected data
- Middleware
  Global exceptions handler
- Services
 DI services to process data source to the expected data format

### JsonConsumer.Api.Tests
xUnit

- Test cases
- Stub services 

### JsonConsumer.Lib
- Models
- Few common helpers, as copied from preivious projects, so no unit tests for them
