# Swashbuckle.OData.v2.18.7.WithErrorHandling
A "fork" of the Swashbuckle.OData (version 2.18.7) with minor changes

This contains the same source as Swashbuckle.OData version 2.18.7 but with a couple of minor improvements.

Swashbuckle.OData version 2.18.7 contains the following errors:
- It throws an exception when it encounters any logic error during the rendering of a swagger document

This version prevents this error by simply using a try/catch statement. In the event of a logic error when rendering a swagger document, this version will simply skip adding the API route that was causing the logic error.
