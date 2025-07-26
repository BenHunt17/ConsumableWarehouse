# ConsumableWarehouse
A back office web app and REST API Endpoints for a consumable wishlist business.

### Problem domain
Buying and giving gifts is something most people have to do every year for birthdays and occasions. For many people it can be challenging to find the right gift for someone.
With online wishlists become more popular, this problem has become significantly easier. However, products listed may fall out of budget or other gifters may have bought it first.
An easier alternative are consumables - they're affordable, can be gifted more than once and are an all-around safer option. However consumables can come across as low effort or even worse - the recipient doesn't like it or can't use it.
This problem of not knowing what consumables are appropriate to gift to an individual is what a hypothetical business is trying to solve.

### Solution
This hypothetical business has decided to start an online service where people can effortlessly create "Consumable wishlists" and share the link with family and friends - similar to other online wishlists.
This addresses the problem of unwanted consumable gifts because people can specify what they want (And what they dont want as a future use case).
While existing wishlists services do allow consumbales to be added, it isn't the main focus. And because most products are one time wants, people need to activly maintain their wishlist and update it every year which a lot of people don't do.
The nice thing about focusing on consumables exclusivly is that people can create a list once and then leave it. It's would take a lot longer than a year for a consumables wishlist to be out of date because preferences rarely change significantly and appliances have long lifespans.
This means that buyers are more likely to keep returning to use these wishlists reguarly when buying gifts for people. The real potential of this lies in the possible future affiliate partnerships with consumable providers.

## The system
For this service to be possible, the company will need to invest in building a modern software solution not only to allow people to create and share wishlists, but also to facilitate back-office business operations and
manage B2B partnerships.

The high level overview of this system comprises of the following:
	- A customer-facing website with a low-friction user flow for creating, maintaining and sharing wishlists. 
	- A back-office management system which allows for administrative tasks, analytics and B2B operations.
	- A scalable, well documented API with both public endpoints for the customer-facing website, and private endpoints for operations like importing product data from partners.

### Scope
This project will not be focused on the customer-facing website because there will be a seperate team developing it (hypothetically).

This project will be focused on the back-office application and REST API endpoints for both B2C and B2B use.
The product import endpoint data contract is standardised and the task of converting data given by the partners to this standardised format falls outside of the scope of this project.
Since this is a hypothetical project, I will not be developing the full application and will instead focus on only a handful of features. This will be more focused on the architectural decisions I make and writing maintainable code which can be extended for future use cases.

## Technologies
Since the scope of the project is the whole backend system and an in-house web app, it will use the .NET ecosystem

- ASP.Net Core Blazor Server for the back-office web application
- ASP.NET Core Web API for the public and private API
- Entity Framework Core with SQL Server for data persistance

## MVP
- A back-office web application
	- The ability to register a business as a partner
	- The ability to read, update and delete partnerships.
	- Deleting a partnership should also delete all data about products they provide
- Private REST API Endpoints
	- Endpoint to batch import partner product data (using a standardised data contract)
	- Endpoint to get all information about a partner product
- Public REST API Endpoints
    - Endpoint to get a partner product (with limited information)
	- Endpoint to search for a list of partner products using a category filter and a search term (with limited information).
    - The ability to CRUD a wishlist
	
## Optional extras
- If I have time I can also integrate authentication and authorization into the endpoints so that users can only modify the state of their own wishlists.