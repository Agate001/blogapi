# Blog BackEnd API - project overview

## Project Goal
Create a backend for Blog Application:

- Support full CRUD operations
- All users to create an account and log in
- Deploy to Azure
- Uses SCRUM workflow concepts
- Introduces Azure DevOps practices

## Stack

- Backend will be in .Net 9, ASP.NET core, EF Core, and SQL Server.
- Front end will be done in Next.js with TypeScript and Flowbite(Tailwind). Deployment will be on Vercel or Azure.

## Application Features

### User Capabilities
- Create an account and log in
- Login
- Delete account

### Blog Features
- view all blog posts
- filter blog posts 
- create blog post
- edit blog post
- delete blog post
- publish blog post
- unpublish blog post

### Pages (Frontend connected to our API)

- Create account page
- Blog view post page of published items
- Dashboard page ( this is the profile page where we edit, delete, publish and unpublish blog posts)

- **Blog Page**
    - Display all published blog posts

- **Dashboard Page**
    - User profile page
    - create a blog post
    - edit a blog post
    - delete a blog post

## Project Folder Structure

### Controllers

#### UserController

Handles all users interactions.

Endpoints: 
- Login
- Add user
- Update user
- Delete user

#### BlogController

Handles all blog operations.

Endpoints:
- Create Blog Item (C)
- Get All Blog Items (R)
- Get Blog Item by category (R)
- Get Blog Item by ID (R)
- Get Blog Item by Tags (R)
- Get Blog Item by Date (R)
- Get published Blog Items (R)
- Update Blog Item (U)
- Delete Blog Item (D)

-Delete will be use for soft delete / publish logic

## Models

### User Model

```csharp

int Id 
string Username
string Salt
string Hash 

### BlogItemModel

int Id
int UserId
string PublisherName
string Title
string Image
string Description
string Date
string Category
string Tags
bool IsPublished
bool IsDeleted

## Items Saved to our DB

### We need a way to sign in with our username and passsword.

```csharp
### LoginModel
    string Username
    string Password

### CreateAccountModel
int Id = 0
    string Username
    string Password

### PasswordModel
    string Salt
    string Hash
```

### Services
    Context/Folder
    -DataContext
    -UserService/file
        -GetUserByUsername
        -Login
        -AddUser
        -UpdateUser
        -DeleteUser
### BlogItemService
    -AddBlogItems
    -GetAllBlogItems
    -GetBlogItemByCategory
    -GetBlogItemsByTags
    -GetBlogItemsByDate
    -GetPublishedBlogItems
    -UpdateBlogItems
    -DeleteBlogItems
    -GetUserById

### PasswordService
    
    -HashPassword
    -VeryHash