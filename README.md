# Country Explorer App


##### The "Country Explorer" app is a web application that allows you to explore information about countries around the world.

Prerequisites
Before you begin, ensure you have the following software and tools installed on your machine:

Node.js and npm: You can download and install Node.js from nodejs.org.

.NET SDK: You need the .NET SDK to run the backend server.

Getting Started
Follow these steps to run the application locally on your machine:

Step 1: Clone the Repository

```
git clone https://github.com/romail/Country_explorer.git
```

Step 2: Navigate to the Project Directory

```
cd Country_explorer
```

Step 3: Install Frontend Dependencies
Navigate to the "Country_explorer_app" folder, which contains the frontend code, and install the required Node.js dependencies:

```
cd CountryExplorerApp
npm install
npm start
```

This will compile and run the frontend application. You can access it in your web browser at http://localhost:4200.

Step 5: Install Backend Dependencies
Open a new terminal or command prompt and navigate to the "Country_explorer_API" folder, which contains the backend code:

```
cd ../Country_explorer_API
dotnet restore
dotnet run
```

