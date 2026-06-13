# E-Management System (Old HRMS)

A comprehensive ASP.NET-based Human Resource Management Information System (HRMS) with integrated modules for employee management, recruitment, logistics, and governance.

## 📋 Project Overview

This application is an enterprise-level HR management system built with:
- **Backend:** ASP.NET with VB.NET (46.9%), ASP.NET Framework (45.9%)
- **Frontend:** HTML (2.7%), JavaScript (2.3%), CSS (1.2%)
- **Additional:** C# (1%)
- **Architecture:** Layered (BLL/DAL separation)
- **Database:** SQL Server

## 🎯 Key Modules

### 1. **Access Control** (`Access/`)
- Company management
- Role-based access control
- Module permissions
- Employee roles assignment
- Comprehensive reporting

### 2. **HRMIS** (`HRMIS/`)
- Employee master data
- Attendance management
- Leave management
- Salary administration
- HR reporting

### 3. **Recruitment** (`Hiring/`)
- Application form submission
- Candidate registration
- Interview evaluation
- Company evaluation
- Recruitment reporting

### 4. **Logistics & CRM** (`CRMnLog/`)
- Forwarder management
- Invoice processing
- Quotation management
- Expense tracking
- Bill uploading
- Vehicle information

### 5. **Firing Machine Data** (`FMD/`)
- Machine master data
- Production verification
- Temperature monitoring
- Zone failure reporting
- Abnormality reports

### 6. **Announcements** (`announcement/`)
- COVID-19 declarations
- Daily announcements
- Temperature checkup tracking
- Staff notifications

### 7. **Governance** (`Governance/`)
- Whistleblower reporting
- Compliance tracking

## 🛠 Technology Stack

| Technology | Version | Purpose |
|-----------|---------|---------|
| .NET Framework | 4.7.2+ | Application runtime |
| Visual Studio | 2022+ | Development IDE |
| SQL Server | 2016+ | Database |
| Crystal Reports | 10.2+ | Reporting |
| AJAX Control Toolkit | 1.0+ | UI enhancements |
| IIS | 7.5+ | Web hosting |

## 📦 Build & Deployment

### Quick Start
```bash
# Clone repository
git clone https://github.com/kranthi39993-lgtm/E-Management-old-HRMS-.git

# Navigate to project
cd "E-Management (old HRMS)"

# Open in Visual Studio
start E-Management.sln
```

### Build
```
Ctrl+Shift+B (in Visual Studio)
```

### Run
```
F5 (in Visual Studio) or Ctrl+F5
```

### Full Instructions
See [BUILD_INSTRUCTIONS.md](BUILD_INSTRUCTIONS.md)

## 📁 Project Structure

```
E-Management (old HRMS)/
├── Class/                  # Business Logic & Data Access
│   ├── BLL/               # Business Logic Layer
│   ├── DAL/               # Data Access Layer
│   └── GlobalInfo/        # Global configuration
├── Access/                # Access control modules
├── HRMIS/                 # HR Management modules
├── CRMnLog/               # CRM & Logistics modules
├── FMD/                   # Firing Machine Data
├── Hiring/                # Recruitment modules
├── Governance/            # Compliance modules
├── announcement/          # Announcements system
├── Css/                   # Stylesheets
├── js/                    # JavaScript
├── images/                # Images & assets
├── bin/                   # Compiled output
├── obj/                   # Build objects
├── My Project/            # Project configuration
├── E-Management.sln       # Solution file
├── E-Management.vbproj    # Project file
└── Web.config             # ASP.NET configuration
```

## 🔐 Key Features

✅ **Role-Based Access Control** - Granular permission management
✅ **Multi-Module System** - Integrated HR, Logistics, and Governance
✅ **Crystal Reports** - Advanced reporting capabilities
✅ **Employee Management** - Complete HR lifecycle
✅ **Recruitment Pipeline** - End-to-end hiring workflow
✅ **Compliance Tracking** - Governance and audit trails
✅ **Real-time Data** - Live dashboard and reports
✅ **Form-based Interface** - User-friendly web forms

## 🚀 Performance Considerations

- **Database:** Indexed for optimal query performance
- **Caching:** In-process session management
- **Output:** XML documentation generation
- **Security:** Forms authentication with session management

## 📊 Reporting

The system includes comprehensive reporting via Crystal Reports:
- Employee reports (Birthday calendars, role assignments)
- Logistics reports (Forwarder lists, expenses, vehicle info)
- Firing machine reports (Production, temperature, zones)
- Recruitment reports (Applications, evaluations)
- HR reports (Attendance, leave, salaries)

## 🔧 Configuration

### Web.config Settings
```xml
<connectionStrings>
  <add name="EMSConnection" 
       connectionString="Server=localhost;Database=EMS;User Id=sa;Password=password;" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>

<appSettings>
  <add key="ApplicationName" value="E-Management System"/>
</appSettings>
```

## 📝 Database

- **Type:** SQL Server
- **Tables:** 50+ tables covering all modules
- **Relationships:** Complex referential integrity
- **Stored Procedures:** Event-driven business logic
- **Views:** Optimized data access patterns

## 🐛 Known Issues & Maintenance

- Legacy codebase (ASP.NET VB.NET)
- Some components need modernization
- Consider migration to ASP.NET Core for future versions
- Binary files (MSI, ZIP) should be removed from repository

## 📚 Documentation

- **Module Documentation:** Available in individual module folders
- **Database Schema:** SQL scripts in project
- **API References:** Inline code documentation
- **User Guides:** Available in documentation folder

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Ensure all builds pass
5. Submit a pull request

## 📄 License

[Specify your license here]

## 📞 Support

For technical support or questions:
- Create an issue in the repository
- Contact the development team
- Check documentation in [BUILD_INSTRUCTIONS.md](BUILD_INSTRUCTIONS.md)

## 🔄 Version History

- **Current Version:** Legacy (for archive/reference)
- **Framework:** .NET Framework 4.7.2
- **Last Updated:** 2025
- **Status:** Maintenance/Archive

---

**Note:** This is a legacy application maintained for reference and archive purposes. Consider modernizing to ASP.NET Core for new deployments.
