# Final Project - ASP.NET WebAPI

## Quick Start

1. **Run the API**
   ```bash
   cd FinalProject
   dotnet run
   ```

2. **Test the API**
   - Open browser to: http://localhost:5148/swagger
   - Or use the .http file (see below)

## Using the .http File

The `FinalProject.http` file lets you test the API directly from VS Code.

### Setup
1. Install the **REST Client** extension in VS Code
   - Press `Cmd+Shift+X` (Mac) or `Ctrl+Shift+X` (Windows)
   - Search for "REST Client"
   - Install the one by **Huachao Mao**

### How to Use
1. Open `FinalProject.http`
2. Click "Send Request" above any request
3. View the response in the right panel

### Examples in the File
- **GET** all team members (first 5)
- **GET** specific team member by id
- **POST** create new team member
- **PUT** update a team member
- **DELETE** remove a team member

## Adding Your Own Table & Controller

Each team member needs to add their own table and controller. Follow these steps:

### Step 1: Create Your Model
1. Copy `Models/TeamMember.cs` and rename it (e.g., `Product.cs`, `Order.cs`, etc.)
2. Change the class name to match your file name
3. Keep at least 5 properties (including `Id`)
4. Example:
   ```csharp
   namespace FinalProject.Models
   {
       public class Product
       {
           public int Id { get; set; }
           public string Name { get; set; } = string.Empty;
           public string Description { get; set; } = string.Empty;
           public decimal Price { get; set; }
           public int Quantity { get; set; }
       }
   }
   ```

### Step 2: Add to Database Context
1. Open `Data/ApplicationDbContext.cs`
2. Add a new line for your model:
   ```csharp
   public DbSet<Product> Products { get; set; }
   ```

### Step 3: Create Your Controller
1. Copy `Controllers/TeamMembersController.cs` and rename it (e.g., `ProductsController.cs`)
2. Find and replace all instances of:
   - `TeamMember` → `Product`
   - `TeamMembers` → `Products`
   - `teamMember` → `product`
3. Update the class name to match your file

### Step 4: Update the Database
Run these commands in the `FinalProject` folder:
```bash
dotnet ef migrations add Add[YourModelName]Table
dotnet ef database update
```

### Step 5: Test Your API
1. Run `dotnet run`
2. Go to http://localhost:5148/swagger
3. Test your new endpoints!

## Team Members
This project was created by:
- Asher Hartman (TeamMembers table)
- Josh Berger
- Peter Schuler
- Jordan Marzougui
