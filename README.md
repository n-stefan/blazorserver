# blazorserver

Exploring different ways of accessing the database in a Blazor Server app:

1. REST call
2. gRPC (not gRPC-Web) call
3. Direct database access - no API calls of any kind

Switching between them is done at the DI registration level. The client code stays exactly the same, regardless of which one is being used.
