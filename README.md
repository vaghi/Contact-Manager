# Contact-Manager
.NET Core application that provides a solution for a Contact Manager

# Run / Deploy
The project was built in VS017 as a AWS Serveless Application with .NET Core, so it can be deployed directly to AWS Lambda.

# Classes Managed
**Contact:**
```
{
    "name": "Agustin",
    "company": "Earthflateners",
    "profileImage": null,
    "email": "email@gmail.com",
    "birthday": "1987-03-24",
    "phoneNumber": 0,
    "address": {
    	"state": "State",
        "city": "City",
        "street": "Street",
        "cp": 123
    }
}
```

# Endpoints
**Create Contact**
```
Verb: POST
URL: api/contacts
```
Body:
```
{
    "name": "Agustin",
    "company": "Earthflateners",
    "profileImage": null,
    "email": "email@gmail.com",
    "birthday": "1987-03-24",
    "phoneNumber": 0,
    "address": {
    	"state": "State",
        "city": "City",
        "street": "Street",
        "cp": 123
    }
}
```

Response:
```
Contact created
```

**Get Contact by Id**
```
Verb: GET
URL: api/contacts
```

Response:
```
Contact or if it does not exist a 500 response with the corresponding Exception
```

# Tests
The project has unit test over the endpoint Create Contact.
They can be run throught Visual Studio, from the Test Explorer or from the menu:
```
Test > Run > All Tests
```
They verify: 
 - Response of the endpoint it's ok, has te correct type and that it returns a 200 as a response
 - The given conctact is created and the returned contact is the one given
 - The Id's generated for the created contacts starts on 1 and are incremented by 1
 - The contact is being validated with the mandatory fields (Name and Email)
 - The contact was stored propertly and can be retrieve from the Get Contact endpoint

