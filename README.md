# 📚 AlikaBook  

**AlikaBook** is a modern e-commerce platform designed specifically for book enthusiasts. It offers a seamless experience for browsing, searching, and purchasing books across various genres.  

---

## 🌟 Features  

- **📖 Browse Books**: Easily discover books by categories and genres.  
- **🔍 Advanced Search**: Find books by title, author, or keywords.  
- **🛒 Shopping Cart**: Add books to your cart and proceed to a secure checkout.  
- **🎨 Intuitive UI**: User-friendly design with a focus on accessibility and performance.  
- **⚡ Scalable and Secure**: Built with modern technologies for reliability and scalability.  

---

## 🚀 Technologies Used  

- **HTML**:
- **CSS**:
- **ASP.NET**:
- **SQL Server**:

---

## 📂 File Structure  

```plaintext
├── /Alikabook
│   ├── /wwwroot           # Static files like CSS, JS, images
│   ├── /Areas             # Areas for different sections of the app
│   ├── /Controllers       # Controllers for the application logic
│   ├── /Views             # Views (Razor pages) for rendering content
│   ├── appsettings.json   # Configuration file
│   └── Program.cs         # Main application entry point
├── /Alikabook.DataAccess
│   ├── /Data              # Database context and models
│   ├── /Migration         # Migrations for database schema changes
│   └── /Repository.cs     # Repository classes for data handling
├── /Alikabook.Models       # Data models and DTOs
└── /Alikabook.Utility      # Helper classes and utilities      
```

## 🛠️ Setup and Installation  

### Prerequisites  
- Visual Studio (or another C# IDE)  
- SQL Server  

### Steps  
1. Clone the repository:  
   ```bash
   git clone https://github.com/angelobracero/Alikabook.git
   cd Alikabook
   ```
2. Install dependencies:  
   - Open the solution in Visual Studio and restore NuGet packages.

3. Set up the database:  
   - Set up a SQL Server database and update the connection string in `appsettings.json`.

4. Run the migrations:  
   - Apply database migrations to set up the schema. You can run this from the terminal or package manager console:
     ```bash
     dotnet ef database update
     ```

5. Start the application:  
   - Run the application using Visual Studio or from the command line:
     ```bash
     dotnet run
     ```

6. Visit the app in your browser:  
   ```plaintext
   http://localhost:5000
   ```

