# API Methods

A controller method is what binds with an HTTP endpoint and is used to process incoming HTTP requests. In the Znode ecosystem, the methods in the controller usually rely on cache helper classes and service classes to fulfil a certain request. Apart from handling the HTTP requests, API methods also sometimes perform error handling and logging as well as input validations.

Every method in API controllers may return a JSON or an HTML response. In case of any exception or validation error, these methods may return responses with certain Error Codes and exception messages.

Each new API controller in Znode API has to inherit from “BaseController” which resides in “Znode.Engine.Api.Controllers” namespace. The BaseController defines a number of methods which assist in forming Znode’s standard HTTP responses. These methods can be used by any new controller methods to make sure that the HTTP responses from Znode API are always standardized and consistent. Such methods are listed below:

* CreateOKResponse (HTTP 200)
* CreateCreatedResponse (HTTP 201)
* CreateInternalServerErrorResponse (HTTP 500)
* CreateNotFoundResponse (HTTP 404)
* CreateNoContentResponse (HTTP 204)
* CreateUnauthorizedResponse (HTTP 401)

Apart from above methods, BaseController also includes logic for checking authorization header in the incoming requests and parsing route uri to retrieve vital information about the request.

## Registering HTTP Routes

Most of the HTTP routes are mapped in the WebApiConfig.cs file in the App_Start folder. In the Znode API, all the existing HTTP routes come registered and do not need further modifications to enable them.

At the same time, new HTTP routes can also be introduced in the Znode API when it is being extended. These new routes have to be registered as well in order to enable them in Znode API. All the new routes can be registered in the custom WebApiConfig file found in the Znode.Custom.Engine.Api project’s App_Start folder.