# Contact-Manager
.NET Core application that provides a solution for a Contact Manager

## Run / Deploy
The project was built in VS017 as a AWS Serveless Application with .NET Core, so it can be deployed directly to AWS Lambda.

The project has been already deployed on AWS Lambda and can be accessed via the URL:\
    https://fciytka6gk.execute-api.sa-east-1.amazonaws.com/Prod/ + endpoint
    
It can also be run locally with Visual Studio, running the main project "ContactManager".

## The Business
The project provides a solution for a Contact Manager.

Contacts can be:
    Created, Updated, Deleted, Got by Id, Email or Phone Number, or obtained by State or City.

The contact to be created follows this restrictions:
* * Name * * its mandatory
* * Email * * its mandatory, must have a valid format and can't be repeated
* * Phone Number * * must have a valid format and can't be repeated


## Classes Managed
**Contact:**
```javascript
{
    "name": "Agustin",
    "company": "Earthflateners",
    "profileImage": null,
    "email": "email@gmail.com",
    "birthday": "1987-03-24",
    "phoneNumber": 0123456789,
    "address": {
    	"state": "State",
        "city": "City",
        "street": "Street",
        "cp": 123
    }
}
```

## Endpoints
* **Create Contact**\
Creates a contact and validates the mandatory fields
```
Verb: POST
URL: api/contacts
```
Body:
```javascript
{
    "name": "Agustin",
    "company": "Earthflateners",
    "profileImage": null,
    "email": "email@gmail.com",
    "birthday": "1987-03-24",
    "phoneNumber": 0123456789,
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

* **Get Contact by Id**\
Retreives a contact with the given id or returns an error message
```
Verb: GET
URL: api/contacts/contactId
```

Response:
```
Contact or if the id does not match with any stored contact a 500 response with the corresponding Exception message
```

* **Update Contact**\
Updates a contact with the given id, and validate the mandatory fields or returns an error message
```
Verb: PUT
URL: api/contacts
```

Body:
```javascript
{
    "id": 1,
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
Contact or if the id does not match with any stored contact a 500 response with the corresponding Exception message
```

* **Delete Contact by Id**\
Deletes a contact with the given id or returns an error message
```
Verb: DELETE
URL: api/contacts/contactId
```

Response:
```
Ok response with a status 200 or if the id does not match with any stored contact a 500 status response with the corresponding Exception message
```

* **Get Contact by Email**\
Retreives a contact with the given email or returns an error message
```
Verb: GET
URL: api/contacts/getByEmail/{email}
```

Response:
```
Contact or if the email does not match with any stored contact a 500 response with the corresponding Exception message
```

* **Get Contact by Phone**\
Retreives a contact with the given phone or returns an error message
```
Verb: GET
URL: api/contacts/getByPhone/{phone}
```

Response:
```
Contact or if the phone does not match with any stored contact a 500 response with the corresponding Exception message
```

* **Get Contacts from State**\
Retreives all contacts with the given state in their Address, not case sensitive
```
Verb: GET
URL: api/contacts/getContactsFromState/{state}
```

Response:
```
List<Contact>
```

* **Get Contacts from City**\
Retreives all contacts with the given city in their Address, not case sensitive
```
Verb: GET
URL: api/contacts/getContactsFromCity/{city}
```

Response:
```
List<Contact>
```


## Tests
The project has unit test over the endpoint Create Contact.
They can be run throught Visual Studio, from the Test Explorer or from the menu:
```
Test > Run > All Tests
```
They verify: 
 * Response of the endpoint it's ok, has te correct type and that it returns a 200 as a response
 * The given conctact is created and the returned contact is the one given
 * The Id's generated for the created contacts starts on 1 and are incremented by 1
 * The contact is being validated with the mandatory fields (Name and Email) and with valid values
 * The contact was stored propertly and can be retrieve from the Get Contact endpoint

Pending tests to add:
* Create Contact: Validate invalid and duplicated values for email and phone number
* Update Contact: All tests
* Delete Contact: All tests
* Get Contact by Id: All tests
* Get Contact by Email: All tests
* Get Contact by Phone: All tests
* Get Contacts by State: All tests
* Get Contacts by City: All tests
    

