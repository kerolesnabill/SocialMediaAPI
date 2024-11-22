# Social Media API

A RESTful API for a social media platform built using ASP.NET Web API. This project follows the Clean Architecture principles and provides features like user authentication, post management, comments, likes, and more.

## Project Overview

This API serves as the backend for a social media platform, providing functionality for user authentication, content creation, user interaction, and administrative control. The project demonstrates expertise in building scalable, secure, and maintainable backend systems.

## Features

- **User Management**:

  - User registration, login, and profile updates.
  - Upload profile picture.
  - Change user password.

- **Posts**:

  - CRUD operations for posts.
  - Like/unlike functionality for posts.
  - Feed generation for followed users.

- **Comments**:

  - CRUD operations for comments on posts.
  - Like/unlike functionality for comments.

- **Search**:

  - Search for posts by keyword.
  - Search for users by username or name.

- **Follow System**:

  - Follow and unfollow users.
  - View followers and following lists.

- **Admin Controls**:
  - Manage user roles.
  - Delete any user, post, or comment.

## Technologies Used

- **Framework**: ASP.NET Web API
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: ASP.NET Identity with JWT
- **Architecture**: Clean Architecture
- **Libraries and Tools**:
  - `AutoMapper` - Object mapping.
  - `FluentValidation.AspNetCore` - Validation.
  - `MediatR` - Mediator pattern for CQRS.
  - `Serilog` - Logging.
  - `Swashbuckle.AspNetCore` - Swagger documentation.
  - `xUnit` `Moq` - Testing.

## API Endpoints

### Posts

- `POST /api/posts` - Create a new post.
- `GET /api/posts` - Get all posts.
- `GET /api/posts/feed` - Get posts from followed users.
- `GET /api/posts/{id}` - Get a post by ID.
- `PATCH /api/posts/{id}` - Update a post.
- `DELETE /api/posts/{id}` - Delete a post.
- `POST /api/posts/{postId}/like` - Like/unlike a post.
- `GET /api/posts/{postId}/likes` - Get a list of users who liked a post.

### Comments

- `POST /api/posts/{postId}/comments` - Add a comment to a post.
- `GET /api/posts/{postId}/comments` - Get all comments on a post.
- `PATCH /api/posts/{postId}/comments/{commentId}` - Update a comment.
- `DELETE /api/posts/{postId}/comments/{commentId}` - Delete a comment.
- `POST /api/posts/{postId}/comments/{commentId}/like` - Like/unlike a comment.
- `GET /api/posts/{postId}/comments/{commentId}/likes` - Get a list of users who liked a comment.

### Users

- `POST /api/users/register` - Register a new user.
- `POST /api/users/login` - Log in.
- `POST /api/users/refresh` - Refresh JWT token.
- `GET /api/users/{id}` - Get user profile by ID.
- `PATCH /api/users/me` - Update current user profile.
- `DELETE /api/users/me` - Delete current user account.
- `POST /api/users/{id}/follow` - Follow a user.
- `DELETE /api/users/{id}/unfollow` - Unfollow a user.
- `POST /api/users/manage/info` - Change the password.

### Admin

- `POST /api/admin/userRole` - Assign a role to a user.
- `DELETE /api/admin/userRole` - Remove a role from a user.
- `GET /api/admin/users` - Get all users.
- `DELETE /api/admin/users/{userId}` - Delete a user.
- `DELETE /api/admin/posts/{postId}` - Delete a post.

### Search

- `GET /api/search/posts` - Search posts by keyword.
- `GET /api/search/users` - Search users by username or email.

## Live Demo

- On Azure: https://social-media-api.azurewebsites.net/swagger
- On MonsterASP.NET: http://social-media.runasp.net/swagger

## Setup Instructions

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/kerolesnabill/SocialMediaAPI.git
   cd SocialMediaAPI
   ```

2. **Install Dependencies**:

   ```bash
    dotnet restore
   ```

3. **Configure the Database**:

   - Update the `appsettings.json` file with your SQL Server and blob storage connection strings.

4. **Run Migrations**:

   ```bash
   dotnet ef database update
   ```

5. **Run the Application**:

   ```bash
   dotnet run
   ```

6. **Access Swagger UI**:
   - Open `http://localhost:{port}/swagger` in your browser.

## Testing

To run the tests:

```bash
dotnet test
```

## License

- This project is licensed under the MIT License.
