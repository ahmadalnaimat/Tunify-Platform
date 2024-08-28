# Tunify Platform

## Introduction

Tunify Platform is a music streaming web application that allows users to create and manage playlists, explore songs, albums, and artists, and subscribe to various service tiers. The platform is designed with a robust database structure to efficiently manage the relationships between users, subscriptions, playlists, songs, albums, and artists.

## ERD Diagram

![Tunify ERD Diagram](Tunify.png)



## Entity-Relationship Overview

The Tunify Platform database is structured as follows:

- **Users**: Each user in the platform has a unique identifier (UserID), and can manage multiple playlists. Users are associated with a subscription type, defined by a foreign key (Subscription_ID).

- **Subscriptions**: This entity defines the different subscription types available in the platform, each with a unique Subscription_ID, a type description (Subscription_Type), and a price.

- **Playlists**: Playlists are created by users and can contain multiple songs. Each playlist is linked to a user through the User_ID foreign key. The Playlist entity stores the playlist's name and creation date.

- **Songs**: Songs are a core component of the platform. Each song has a unique identifier (Song_ID), and is linked to an artist and an album through foreign keys (Artist_ID and Album_ID). Songs also have attributes like title, duration, and genre.

- **Albums**: Albums group songs together and are associated with an artist. Each album has a unique Album_ID, a name, and a release date.

- **Artists**: Artists are the creators of the songs and albums. Each artist has a unique identifier (Artist_ID), along with a name and biography.

- **PlaylistSongs**: This junction table manages the many-to-many relationship between playlists and songs. Each entry in this table links a playlist to a song using foreign keys (Playlist_ID and Song_ID).

### Entity Relationships

- **Users** have a one-to-many relationship with **Playlists**. Each user can create multiple playlists.
- **Users** are associated with a single **Subscription** through a one-to-one relationship.
- **Playlists** and **Songs** have a many-to-many relationship, managed through the **PlaylistSongs** table.
- **Songs** belong to one **Artist** and one **Album**, forming a many-to-one relationship with both entities.
- **Albums** and **Artists** also have a many-to-one relationship, where an artist can release multiple albums.

## Repository Pattern

### What is the Repository Pattern?

The Repository Pattern is a way to manage how data is accessed in your application. It creates a separate layer that handles all interactions with the database, keeping your business logic clean and organized.

### How It Helps Tunify Platform

- **Organized Code**: Keeps data access code separate from business logic, making your code easier to understand and maintain.
  
- **Easy Updates**: You can change how data is accessed or stored without affecting the rest of your application.

- **Reusability**: Makes it simple to use the same data access methods in different parts of your app.

In Tunify Platform, using the Repository Pattern helps keep our code structured and manageable, making it easier to work with and update.

1. **Navigation Properties**:
   - Added navigation properties to the `Playlist`, `Song`, and `Artist` models to establish and manage relationships.

2. **Routing for Playlist-Song Relationships**:
   - Implemented an endpoint to add a song to a playlist:
     - `POST api/playlists/{playlistId}/songs/{songId}`
   - Added an endpoint to retrieve all songs in a playlist.

3. **Routing for Artist-Song Relationships**:
   - Implemented an endpoint to add a song to an artist:
     - `POST api/artists/{artistId}/songs/{songId}`
   - Added an endpoint to retrieve all songs by a specific artist.

4. **Relationship Management**:
   - Extended the `PlaylistService` with a method to handle adding a song to a playlist.
   - Extended the `ArtistService` with a method to handle adding a song to an artist.

5. **Database Updates**:
   - Updated `OnModelCreating` in `TunifyDbContext` to define composite keys for join tables and seeded initial data for `Playlist`, `Song`, and `Artist` models.
   - Applied necessary migrations to update the database schema.

6. **Unit Testing**:
   - Added unit tests using xUnit and mocks to verify the implementation of the new relationships and routing functionalities.

   Here's an updated section for your `README.md` that includes an explanation of Swagger UI and instructions on how to access and use it:

---

## Swagger UI Integration

### What is Swagger UI?

Swagger UI is an interactive API documentation tool that automatically generates and displays API documentation based on the project's code. It allows developers and testers to explore and test API endpoints directly within a web browser, making it easier to understand and interact with the API.

### How It Helps Tunify Platform

- **Interactive API Documentation**: Provides a user-friendly interface to interact with the Tunify Platform API.
  
- **Ease of Testing**: Allows you to test different API endpoints without the need for additional tools.
  
- **Live API Testing**: Enables real-time testing of your API, which is particularly useful during development and debugging.

### Accessing Swagger UI

1. **Starting the Application**:
   - Ensure the Tunify Platform application is running. You can start the application using your preferred method, such as through Visual Studio, the .NET CLI, or Docker.

2. **Navigating to Swagger UI**:
   - Open your web browser and navigate to the following URL:
     ```
     http://localhost:{PORT}/
     ```
   - Replace `{PORT}` with the port number on which your application is running. By default, this is usually `5000` for HTTP or `5001` for HTTPS.

3. **Exploring the API**:
   - On the Swagger UI homepage, you'll see a list of available API endpoints categorized by controllers.
   - Click on any endpoint to expand it and see details such as the request method, parameters, and response types.
   - You can test the endpoints directly from this interface by clicking the "Try it out" button.

### Example Endpoints

- **Get All Playlists**: 
  - `GET /api/playlists`
  - Use this endpoint to retrieve a list of all playlists in the system.
  
- **Add a Song to a Playlist**:
  - `POST /api/playlists/{playlistId}/songs/{songId}`
  - This endpoint allows you to add a specific song to a playlist.

### Customizing Swagger UI

The Swagger UI for Tunify Platform is configured to display at the root URL (`http://localhost:{PORT}/`). The JSON documentation is accessible at:
```
http://localhost:{PORT}/api/v1/swagger.json
```



## Identity Setup

### Overview

Tunify Platform utilizes ASP.NET Core Identity to handle user authentication and authorization. This setup enables users to securely register, log in, and manage their accounts within the platform. The Identity framework provides a comprehensive solution for managing user roles, passwords, and authentication states.

### Identity Configuration

In the `Program.cs` file, Identity services are configured to use the `TunifyDbContext` for storing user information:

```csharp
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<TunifyDbContext>();
```

The middleware configuration ensures that the application uses authentication mechanisms:

```csharp
app.UseAuthentication();
```

### Identity Features

- **Registration**: Users can create a new account by providing their username, email, and password.
- **Login**: Registered users can log in to the platform using their credentials.
- **Logout**: Authenticated users can log out, clearing their authentication cookies.

### Using the Registration, Login, and Logout Features

#### 1. Registration

To register a new user account:

- **Endpoint**: `POST /api/Account/Register`
- **DTO**: `RegisterDto`
- **Required Fields**:
  - `Username`: The desired username for the account.
  - `Email`: The user's email address.
  - `Password`: A secure password for the account.

**Example Request**:
```json
{
  "Username": "johndoe",
  "Email": "johndoe@example.com",
  "Password": "StrongPassword123"
}
```

**Example Response**:
- On successful registration: `200 OK` with a message `"Registration successful"`
- On failure: `400 BadRequest` with error details.

#### 2. Login

To log in as a registered user:

- **Endpoint**: `POST /api/Account/Login`
- **DTO**: `LoginDto`
- **Required Fields**:
  - `Username`: The username of the account.
  - `Password`: The password associated with the account.

**Example Request**:
```json
{
  "Username": "johndoe",
  "Password": "StrongPassword123"
}
```

**Example Response**:
- On successful login: `200 OK` with a message `"Login successful"`
- On failure: `401 Unauthorized` with an error message `"Invalid login attempt"`

#### 3. Logout

To log out the currently authenticated user:

- **Endpoint**: `POST /api/Account/Logout`

**Example Response**:
- On successful logout: `200 OK` with a message `"Logout successful"`

### Testing Identity Features via Swagger UI

Using Swagger UI, you can interact with the Identity features in a user-friendly interface:

1. **Access Swagger UI**:
   - Navigate to `http://localhost:{PORT}/`
   - Look for the `Account` controller in the list of available endpoints.

2. **Register a User**:
   - Expand the `POST /api/Account/Register` endpoint.
   - Click `Try it out`, fill in the required fields, and execute the request.

3. **Log in a User**:
   - Expand the `POST /api/Account/Login` endpoint.
   - Provide the username and password, then execute the request to authenticate.

4. **Log out a User**:
   - Expand the `POST /api/Account/Logout` endpoint.
   - Execute the request to log out the authenticated user.

### Error Handling and Feedback

Tunify Platform implements robust error handling mechanisms for Identity operations. Users receive clear feedback when registration, login, or logout actions fail, allowing for a smoother user experience. Additionally, errors are logged for troubleshooting purposes.

