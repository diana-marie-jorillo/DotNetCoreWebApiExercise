Version 1.0
GitHub repository: https://github.com/diana-marie-jorillo/DotNetCoreWebApiExercise

============================
   NOTES BEFORE TESTING:
============================

1. This API was written in Visual Studio code, uses SQLite as database, and tested in Swagger. To trigger, please hit F5 or "Run > Start Debugging" and add "/swagger" to the URL 
   (ex. https://localhost:1234/swagger).
2. This API does not include the nice-to-haves and will be added in a later update.
3. You may use "dotnet restore" to download all of the packages listed in bdowebapi.csproj.
4. "UpdateAccountDetails" uses [HttpPatch]. You may use the following load to test. Please add one {} group per field you wish to change:

    [
        {
            "path": "/<variable from Account model, without the <> >",
            "op": "replace",
            "value": "<value to use, without the <> >"
        }
    ]

5. For "DeleteAccount", please perform a Customer search first to get the customer details and paste the result in the request body.
6. For Account Type (Savings/Checking), please see below for the values to use:
    Savings = 1
    Checking = 2
