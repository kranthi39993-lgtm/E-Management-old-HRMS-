# E-Management System - Build Instructions

## Overview
This is an ASP.NET VB.NET web application for Employee Management System (HRMS).

**Language Composition:**
- Visual Basic .NET: 46.9%
- ASP.NET: 45.9%
- HTML: 2.7%
- JavaScript: 2.3%
- CSS: 1.2%
- C#: 1%

## Prerequisites

1. **Visual Studio 2022** or later
   - Workload: ASP.NET and web development
   - Workload: .NET desktop development

2. **.NET Framework 4.7.2** or later
   - Download from: https://dotnet.microsoft.com/download/dotnet-framework

3. **SQL Server** (2016 or later)
   - Express Edition or higher
   - For local development, can use SQL Server LocalDB

4. **IIS** (Internet Information Services)
   - Optional for local development (Visual Studio Development Server can be used)

## Build Steps

### 1. Clone and Open the Project
```bash
git clone https://github.com/kranthi39993-lgtm/E-Management-old-HRMS-.git
cd "E-Management (old HRMS)"
```

### 2. Open Solution in Visual Studio
- Open `E-Management.sln` in Visual Studio 2022

### 3. Restore NuGet Packages
- In Solution Explorer, right-click the solution
- Select "Restore NuGet Packages"
- Or use Package Manager Console:
  ```
  Update-Package -Reinstall
  ```

### 4. Configure Database Connection
- Edit `Web.config` file
- Update the connection string:
  ```xml
  <connectionStrings>
    <add name="EMSConnection" 
         connectionString="Server=YOUR_SERVER;Database=EMS;User Id=YOUR_USER;Password=YOUR_PASSWORD;" 
         providerName="System.Data.SqlClient"/>
  </connectionStrings>
  ```

### 5. Build the Solution
- Press `Ctrl+Shift+B` or go to Build → Build Solution
- Verify no build errors in the Error List

### 6. Run the Application
- Press `F5` or click Debug → Start Debugging
- Application will open in your default browser

## Project Structure

```
E-Management (old HRMS)/
├── Access/                 # Access control and role management
├── announcement/          # Announcements module
├── CRMnLog/              # CRM and Logistics modules
├── Class/                # Business Logic Layer (BLL) and Data Access Layer (DAL)
├── FMD/                  # Firing Machine Data management
├── Governance/           # Governance related pages
├── HRMIS/                # HR Management Information System
├── Hiring/               # Recruitment and hiring module
├── MMforms/              # Maintenance and Material forms
├── bin/                  # Compiled binaries
├── obj/                  # Build object files
├── Css/                  # Stylesheets
├── js/                   # JavaScript files
├── images/               # Image assets
├── My Project/           # Project configuration files
├── E-Management.vbproj   # Project file
├── E-Management.sln      # Solution file
└── Web.config            # ASP.NET configuration
```

## Common Build Issues and Solutions

### Issue 1: Missing References
**Error:** Could not find assembly 'AjaxControlToolkit'
**Solution:** 
- Ensure `AjaxControlToolkit.dll` is in the bin folder
- Extract `AjaxControlToolkit.zip` if present

### Issue 2: Database Connection Failure
**Error:** "Failed to connect to database"
**Solution:**
- Verify SQL Server is running
- Check connection string in Web.config
- Verify database exists on the server

### Issue 3: Framework Version Mismatch
**Error:** "The project targets .NET Framework version X.X"
**Solution:**
- Install the required .NET Framework version
- Update project target framework in project properties if compatible

### Issue 4: Missing Crystal Reports
**Error:** "Could not find assembly 'CrystalDecisions'"
**Solution:**
- Install Crystal Reports for Visual Studio
- Download from SAP website or update via NuGet

## Deployment

### For Development
1. Use Visual Studio Development Server (built-in)
2. Press F5 to run

### For Production
1. Right-click project → Publish
2. Configure publish profile
3. Deploy to IIS server
4. Update Web.config for production environment

## Code Cleanup Required

1. **Remove Binary Files**
   - ASPAJAXExtSetup.msi (not needed in repo)
   - AjaxControlToolkit.zip (extract and remove)

2. **Clean Build Output**
   - Delete bin/ and obj/ directories before commit
   - These are auto-generated during builds

3. **Update Connection Strings**
   - Set default to local SQL Server or Azure
   - Use environment variables for sensitive data

## Testing

After successful build:
1. Verify login page loads
2. Test database connectivity
3. Check all modules load without errors
4. Review browser console for JavaScript errors

## Additional Resources

- ASP.NET VB.NET Documentation: https://docs.microsoft.com/en-us/aspnet/
- Crystal Reports Guide: https://help.sap.com/viewer/e3328ae6f47b4e98b56f8f22fcfb85e0/
- SQL Server Connection Strings: https://www.connectionstrings.com/

## Support

For build issues, check:
1. Visual Studio Output window for detailed error messages
2. Error List panel for compilation errors
3. Application Event Viewer for runtime errors
4. SQL Server logs for database issues
