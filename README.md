# Swashbuckle.OData.v2.18.7.WithErrorHandling
This is just a "fork" of the Swashbuckle.OData (version 2.18.7) with a couple of small changes. This repository contains the same source as Swashbuckle.OData version 2.18.7 but with added error handling to prevent swagger documents from failing to render.

You can find the original project of Swashbuckle.OData at
[Swashbuckle.OData](https://github.com/rbeauchamp/Swashbuckle.OData)

Swashbuckle.OData version 2.18.7 contains the following behavior:
- When Swashbuckle.OData tries to render a swagger document and encounters a logic error
- It will throw an exception and, instead of returning a swagger document, the request for a swagger document will return a server-side error

This version prevents this behavior by simply using a try/catch statement. In the event that Swashbuckle.OData runs into a logic error when rendering a swagger document, this version will:
- simply silently "catch" the error, 
- skip adding the API route that was causing the logic error,
- return a working swagger document without the API route that caused the error.
