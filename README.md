If you are using Postman to get access this API, remember to disable SSL under File -> Settings -> SSL certificate verification

Queries:

GET - Returns all the hotels hosted in the database:

https://localhost:44321/hotels

GET - Returns a single hotel using the hotelId:

https://localhost:44321/hotels/2

GET - Returns hotels setting the size of a page, and the page number: 

Scenario: We have 100 hotels, but we only want to show 20 at a time, then the size should be 20, and the page should be 1, to show the first 20 hotels. 

If we want to show the second round of 20 hotels, then we set the page to 2. 

The following query will display hotels one at a time, and it will show the second page: 

https://localhost:44321/hotels?size=1&page=2

GET - Returns hotels that contain a keyword in their name, this is for a search filter: The following query will only display one hotel from the list of hotels (Plaza Hotel): 

https://localhost:44321/hotels?name=plaza

GET - Returns rooms that are available between the selected days by the user, and with a set capacity: 

https://localhost:44321/rooms?dayStart=25&monthStart=01&yearStart=2022&dayEnd=29&monthEnd=01&yearEnd=2022&capacity=1

PUT - Updates a room with booking details, if the room booking can be done:

https://localhost:44321/rooms?dayStart=25&monthStart=01&yearStart=2022&dayEnd=29&monthEnd=01&yearEnd=2022&roomId=12

GET - Returns a single room using the roomId:

https://localhost:44321/rooms/3

POST -Creates a room booking record:

https://localhost:44321/bookings?dayStart=25&monthStart=01&yearStart=2022&dayEnd=29&monthEnd=01&yearEnd=2022&roomId=2&userId=2&hotelId=2
https://localhost:44321/bookings?dayStart=05&monthStart=05&yearStart=2005&dayEnd=06&monthEnd=05&yearEnd=2005&roomId=3&userId=1&hotelId=1

GET - Returns a single booking using the bookingId:

https://localhost:44321/bookings/5
