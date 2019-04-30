# Services

A service class in Znode ecosystem is usually the last managed tier which breaks a requested user operation into several small sized business logic instructions, data handling and database transactions. It resides in the “Znode.Engine.Services” namespace.

The service classes are usually constructor-injected into API controllers or in some cases Cache helper classes.

## Creating a Service

Assuming that the Znode’s visual studio solution already has custom class library projects created with “Znode.Custom.Engine.Services” and “Znode.Custom.Engine.Api” namespaces, creating a new service class can be accomplished with following steps:

1. Create a new interface with appropriate name suffixed with word “service” in the newly created custom class library project.
1. Create a new class with similar name to the interface (just exclude the letter “I” in the beginning). This class should inherit the “BaseService.cs” as well as implement the newly created service interface.
1. Make sure that all the new service interfaces and service classes reside within “Znode.Custom.Engine.Services” namespace.
1. In the service interface, define all the members which are to be exposed to other components of Znode.
1. Implement all the exposed members in the child service class. The service class can also contain private members which are only to be used within the scope of this class itself.
1. Once the service interface and service class are ready to be used, make sure to register them both into the dependency registry which can be found in “DependencyRegistration.cs” class under “Znode.Custom.Engine.Api” namespace.