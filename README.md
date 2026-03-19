# MartianRobots

This repository implements the Martian Robots coding challenge using C#/.NET

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) or later
- IDE
  - [Visual Studio Code](https://code.visualstudio.com/)


## Running the Application

###  Visual Studio Code

1. **Open the workspace**:
   - Open VS Code
   - File → Open Folder → Select the `MartianRobots` folder
2. **Configure launch settings**:
   - launch.json and task.json - build are alrady checked in 
   
4. **Run the application and Test Cases**:
   Application - 
   **Option A: Run through terminal**
   - Open a terminal and run:
     ```Powershell
    dotnet run --project MartianRobots
     ```
   **Option B: Use the debugger**
   - Press `F5` or go to Run → Start Debugging
   - Select ".NET: Launch MartianRobots" configuration 
   - The application will build and launch with debugging1 support
   
   Test Cases 
      - Open a terminal and run:
    ```Powershell
    dotnet test
    ```
5. **Access the application**:
   - The application open in console with two usage options (sample data vs. custom input)

## Project Structure

- **Maritaion.Robots.csproj**: .NET Core Console App with entry from Program
  
- **MartianRobots.Tests.csproj**:  Test Project

## Development Notes

Technology Choices & Rationale:

C# 10.0 & .NET 10.0: Modern language features, performance
MSTest: Built in, reliable testing framework
Console Application: Cross platform, simple interface
Records & Extension Methods: Immutability, clean code organization

Problem Solving Approach:

Maintained Object oriented design, clear separation of concerns with TDD
1 Defined orientation enum and implement left/right turns
2 Created grid class and track boundaries
3 Created robot, implement forward movement and position 
4 Handlnig robots falling off grid and leaving scent, Added lost robot logic with scent prevention
5 Create simulator to parse and execute multiple robots

