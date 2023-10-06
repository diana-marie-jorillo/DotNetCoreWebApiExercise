Version 1.0
GitHub repository: https://github.com/diana-marie-jorillo/BDOWebApi
Private repository; please contact diana-marie.jorillo@capgemini.com for access request and include your email address.

============================
   NOTES BEFORE TESTING:
============================

1. This API uses SQLite as database and tested in Swagger. To trigger, please hit F5 or "Run > Start Debugging" and add "/swagger" to the URL 
   (ex. https://localhost:1234/swagger).
2. You may use "dotnet restore" to download all of the packages listed in bdowebapi.csproj.
3. "UpdateAccountDetails" uses [HttpPatch]. You may use the following load to test. Please add one {} group per field you wish to change:

    [
        {
            "path": "/<variable from Account model, without the <> >",
            "op": "replace",
            "value": "<value to use, without the <> >"
        }
    ]

4. This API does not include the nice-to-haves and will be added in a later update.