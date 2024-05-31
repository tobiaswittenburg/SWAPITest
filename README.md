API Testing with Copilot

## Outline
In this Scenario we are implementing some tests to test an API. The implementation here is in C#. However, if you feel more comfortable in another language or Framework, feed free to implement it differently. 

The API we are using is the Star Wars API, which can be found at swapi.dev

Further below you will find sample promts to interact with GitHub Copilot. Please work through the hands-on part and after that compare your prompts with the sample prompts.

## Step 0
Create a new ASP.NET Core Solution
Add an XUnit Test Project

1. New ASP.NET Core Solution (no Project
2. XUnit Test Project erstelltn (SWAPITestXunit)

## Step 2
Use Copilot to accomplish the following:
 - Learn: Ask Copilot what Kind of tests you should implement to test an API.
 - Give Copilot some concreate Information on what you want to implement and what language you are using.
 - Then ask Copilot to implement some Tests for correct data, availability, invalid Input and others. You should end up with at least 10 Tests in your Project.
 - Ask Copilot what is missing.

# SPOILER ALERT: HERE ARE SOME SAMPLE PROMPTS
```
Hello Copilot, please answer in English
```

Of course! I'm here to assist you with your programming questions in English. How can I help you today?

```
I want to Test an external API. What kind of unit tests should I implement?
```

This prompt should give you some Information, e.g. Correctness of Data, Error Handling, Response Time, HTTP Status Code, Authentication, etc. Probably with a sample implementation (e.g. JavaScript)

```
I will be using C# and xunit for these tests
```

This prompt should now give you an implementation in C#

```
The API that I want to test is the Star Wars API, you will find it here https://swapi.dev/api/
A Sample call would be https://swapi.dev/api/people/1 how should I implement a test for correctness of data?
```

This should give you a C# implementation for the endpoint /people/1

```
please implement a test for /people/2
```

This probably explains itself

```
Please test for invalid data input if the API returns a 404 not found
```

Should give you a test for invalid Input

```
What other test for correctness of data can be implemented?
```

Should Point you to other Tests, like Data Type Check, Null Checks, Boundary Value Checks, Consistency Checks, Length Checks; probably with a sample implementation

```
How can I test for error handling?
```

Copilot should give you now some Information on error handling, e.g. Invalid Input, rate limits

```
any other idea on how to test for Error Handling?
```

Sometimes it helps to ask for further ideas….

```
How can I test if the endpoint is available?
```

Should give you now an implementation for the endpoint testing
API Testing with Copilot
