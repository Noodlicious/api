# Noodlicious API

## Overview
The Noodilicious API is built on .NET Core 2.1 and resides [here](https://noodliciousapi.azurewebsites.net).
For the curious programmer noodlr interested in knowing more about instant
ramen optios, this application programming interface (API) will send requests to the
Noodlicious database and returns a list of options.  

The Noodlicious API is fully capable of allowing new noodles and brands to be added 
because us mere mortals have not had the chance to try all there is in the noodle realm.  
If any noodles or brands are mislabeled in our database, the Noodlicious 
API will allow for updates to that particular entry.  Finally, should 
a noodle be discontinued or a brand disappears, the Noodlicious API is able to
delete that noodle or brand from the database.

A seed data file is used to keep the database consistently populated.

---
## Dependencies for the API
This API was built on .NET Core 2.1, which can be downloaded [here](https://www.microsoft.com/net/download/macos).
The [lovely API documentation](https://noodliciousapi.azurewebsites.net/index.html) is a result of Swashbuckle, 
which is a nuget package dependency.  Finally, since this is an ASP.NET application, 
the Microsoft AspNetCore App nuget package is needed as well.

---
## Build for the API and Tests
To run this API locally, install the [.NET Core 2.1 SDK](https://www.microsoft.com/net/download/macos), 
clone this repo onto your machine. From a terminal interface, go to where this was 
cloned and type the following commands:

```
cd NoodleApi
dotnet restore
dotnet run
```

If the nuget packages do not install, or if the API is not functioning,
run the following commands in a terminal interface:

```
Install-Package Microsoft.AspNetCore.App -Version 2.1.0
Install-Package Swashbuckle.AspNetCore -Version 2.5.0
```

The tests for this API relies on the Entity Framework and an in memory database.  
Run the following commands for the tests to run properly:

```
Install-Package Microsoft.EntityFrameworkCore -Version 2.1.1
Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 2.1.1
```

---
## API Brand Endpoint Routes and Walk Through

The following step by step path will be using [swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio&view=aspnetcore-2.1),
which is what the Noodlicious API is using for documentation.

#### GET all brands:

**localhost:yourPortNumber/api/brand** or
**https://noodliciousapi.azurewebsites.net/api/brand**

![Get All Brands](/Assets/getBrang.png)

Click "Try It Out" and then "Execute" in order to see all the brands:

![See All Brands](/Assets/getBrandJSON.png)


#### GET a brand by ID:

**localhost:yourPortNumber/api/brand/`{id}`**
**https://noodliciousapi.azurewebsites.net/api/brand/{id}**

where id is the id of a brand

Click "Try It Out":

![Get Brand By ID](/Assets/getBrandByID.png)

Enter in 2, for this example, and then click "Execute":

![Get Brand By ID Type In Id](/Assets/getBrandByIDTypeInId.png)

Use 2 for this example:

![Show Brand By Id](/Assets/getBrandByIDJSON.png)


#### POST a new brand:

**localhost:yourPortNumber/api/brand** or
**https://noodliciousapi.azurewebsites.net/api/brand**

Click "Try It Out":

![Post New Brand](/Assets/postNewBrand.png)

We'll be using "SamYang", the hottest ramen brand, for this example.
Swagger will display "Id", but we don't need it because the database
will assign it an ID number.  Delete the Id portion when typing
in info for a new brand.

![Post New Brand Example](/Assets/postNewBrandEx.png)

Swagger will show the new entry:

![Post New Brand Response](/Assets/postNewBrandResponse.png)

#### PUT/Update a Brand by ID:

**localhost:yourPortNumber/api/brand/`{id}`**
**https://noodliciousapi.azurewebsites.net/api/brand/{id}**

where id is the id of a brand

Click "Try It Out":

![Update A Brand](/Assets/updateBrang.png)

Let's update the SamYang example we created earlier.  Type the name in ALL
CAPS and let's say they're a North Korean company.  The ID is needed for this
entry.  We can tell which ID it is from the POST request made in the previous
section:

![Update A Brand Example](/Assets/updateBrandEx.png)

Go back to the "GET a brand by ID" direction to check up on the update:

![Check Update](/Assets/checkUpdate.png)

The response shows that SamYang has been updated:

![Check Update Works](/Assets/checkUpdateWorks.png)

#### DELETE a Brand by ID:

**localhost:yourPortNumber/api/brand/`{id}`**
**https://noodliciousapi.azurewebsites.net/api/brand/{id}**

where id is the id of a brand

Let's delete the SAMYANG entry:

![Delete Brand By Id](/Assets/deleteBrandById.png)

See if it's still there by following the directions for 
"GET all brands" directions:

![Check Delete Work](/Assets/getBrand.png)

SAMYANG is no longer in the list of brands:

![List After Deletion](/Assts/deleteBrandWorks.png)

---
## API Noodle Endpoint Routes and Walk Through
#### GET all noodles:

**localhost:yourPortNumber/api/noodle** or
**https://noodliciousapi.azurewebsites.net/api/noodle**

![Get All Noodle](/Assets/getAllNoodle.png)

Click "Try It Out" and then "Execute" in order to see all the noodles:

![See All Noodle](/Assets/getAllNoodleJSON.png)

#### GET a noodle by ID:

**localhost:yourPortNumber/api/noodle`{id}`** or
**https://noodliciousapi.azurewebsites.net/api/noodle/{id}**

where id is the id of a brand

Click "Try It Out":

![Get Noodle By Id](/Assets/getNoodleById.png)

Enter 4 for this example and click "Execute":

![Get Noodle By Id With Id](/Assets/getNoodleByIdWithId.png)

The information for brand #4 will be displayed in a JSON format:
![See Noodle Info](/Assets/getNoodleByIdJSON.png)

#### POST a new noodle

**localhost:yourPortNumber/api/noodle** or
**https://noodliciousapi.azurewebsites.net/api/noodle**

![Post a New Noodle](/Assets/postNoodle.png)

Click "Try It Out":

![Post New Brand](/Assets/postNewBrand.png)

We'll be using "Cup of Noodle", a college staple, for this example.
Swagger will display "Id", but we don't need it because the database
will assign it an ID number.  Delete the Id portion when typing
in a info for a new noodle.

![Post New Noodle Example](/Assets/postNoodleEx.png)

Swagger will show the new entry:

![Post New Noodle Response](/Assets/ViewAddedNoodle.png)


#### PUT/Update a noodle by ID:

**localhost:yourPortNumber/api/noodle/`{id}`**
**https://noodliciousapi.azurewebsites.net/api/noodle/{id}**

where id is the id of a noodle

Click "Try It Out":

![Update A Noodle](/Assets/updateNoodle.png)

Let's update the Cup of Noodle example we created earlier.  Let's change the
option from 'Cup' to 'Bowl'.  The ID is needed for this
entry.  We can tell which ID it is from the POST request made in the previous
section:

![Update A Noodle Example](/Assets/updateNoodleEx.png)

Go back to the "GET all noodles" direction to check up on the update. 
The response shows that 'Cup of Noodle' is now 'Bowl of Noodle':

![Check Update Works](/Assets/updateNoodleInfo.png)

#### Delete a noodle by ID:

**localhost:yourPortNumber/api/noodle/`{id}`**
**https://noodliciousapi.azurewebsites.net/api/noodle/{id}**

where id is the id of a noodle

Click "Try It Out":

![Delete A Noodle](/Assets/deleteNoodle.png)

Let's delete the 'Bowl of Noodle'.  We know its ID is 6 because of our POST
request earlier:

![Delete A Noodle Example](/Assets/deleteNoodleById.png)

Go back to the "GET all noodles" direction to check the noodle list. 
The response shows that 'Bowl of Noodle' is no longer there:

![Delete Noodle](/Assets/deleteNoodleGone.png)


---
## Acknowledgements
- A **huge** thanks to the [Noodlicious team](https://github.com/Noodlicious): [jaatay](https://github.com/jaatay), [IndigoShock](https://github.com/IndigoShock)
and [btaylor93](https://github.com/btaylor93).

- Many thanks to [taylorjoshuaw](https://github.com/taylorjoshuaw) 
for this lovely README layout.