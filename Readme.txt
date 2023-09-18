Hi,

Design patterns used. 
 - CQRS pattern with mediator. 
 - Clean architecture 

Security - JWT token.

Urls:

To get token 
	https://localhost:44381/api/login
	Please pass this object in the body. { "Username":"onyxuser", "Password": "Password1" }

To get all products.

	Need to pass token in the header
	https://localhost:44381/api/product/GetProducts
	
To filter products by colour.

	Need to pass token in the header
	https://localhost:44381/api/product/GetProductsByColour?colour=blue

Health check 
	https://localhost:44381/