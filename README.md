# CrowdFeed 🍽️ 
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![ASP.NET](https://img.shields.io/badge/Built%20with-ASP.NET-5C2D91)](https://dotnet.microsoft.com/apps/aspnet)
![Version](https://img.shields.io/badge/version-1.0.0-blue)

## 📋 Overview

CrowdFeed is a comprehensive platform that connects mall visitors with real-time information on restaurant seat availability. The system employs advanced seat sensor technology to provide accurate, up-to-the-minute data, enhancing the dining experience for customers while offering valuable insights to mall owners and restaurant managers.

<details>
<summary>🔍 Problem Statement</summary>

CrowdFeed addresses the common frustration of finding available seating in busy mall food courts and restaurants. Mall visitors often waste time circling food courts looking for available seating, leading to poor dining experiences and reduced customer satisfaction.
</details>

---

## ✨ Key Features

The platform consists of three integrated web portals:

### 👥 Customer Portal (Site1)
- 🔴 Real-time seat availability visualization
- 🔍 Mall and restaurant search functionality
- ℹ️ Restaurant details and information
- 👤 User profiles and preferences
- 📱 Mobile-responsive design for on-the-go access
- 📊 Transaction history for registered users

### 🏢 Partner Portal (Site2)
- ✅ Mall registration and onboarding
- 🍔 Restaurant management interface
- 📈 Real-time analytics dashboard
- 💳 Transaction processing and reporting
- 🔌 Integration with seat sensor technology
- 📝 Confirmation page for transactions

### ⚙️ Admin Portal (Site3)
- 🔧 Comprehensive system management
- 📝 Mall and outlet administration
- 👥 User management and authentication
- 📊 Transaction monitoring and reporting
- ⚙️ System configuration and maintenance
- 👁️ Manager view for operational oversight

---

## 🛠️ Technical Architecture

CrowdFeed is built using ASP.NET with a multi-tiered architecture:

```
┌─────────────────────────────────────┐
│          Presentation Layer          │
│  (ASPX pages with code-behind files) │
├─────────────────────────────────────┤
│          Business Logic Layer        │
│      (Manager and service classes)   │
├─────────────────────────────────────┤
│           Data Access Layer          │
│    (Data models and repositories)    │
├─────────────────────────────────────┤
│        Hardware Integration          │
│      (Seat sensor API integration)   │
└─────────────────────────────────────┘
```

### 📁 Directory Structure

```
CrowdFeed/
├── App_Data/             # Application data storage
├── assets/               # Static resources
├── bin/                  # Compiled assemblies
├── Css/                  # Stylesheet files
├── documentation/        # Project documentation
├── Imgs/                 # Image resources
├── Js/                   # JavaScript files
├── obj/                  # Compiler-generated files
├── packages/             # NuGet dependencies
└── Properties/           # Project properties
```

### 🧩 Core Components

| Component | Description |
|-----------|-------------|
| **Mail.cs/Mail_Info.cs** | Email notification system |
| **Manager.cs** | Business logic management |
| **Outlet.cs** | Restaurant/outlet data models |
| **Report.cs** | Reporting functionality |
| **TransactionPart1.cs/TransactionPart2.cs** | Transaction processing |

---

## 📡 Sensor Technology

CrowdFeed leverages proprietary seat sensor technology that:
- ✅ Accurately detects seat occupancy in real-time
- 📊 Provides aggregated availability statistics
- 🔧 Requires minimal maintenance and setup
- ⚡ Operates on low power consumption for sustainability
- 🔄 Integrates seamlessly with the CrowdFeed platform

---

## 💻 Installation and Setup

### Prerequisites

- [Microsoft Visual Studio](https://visualstudio.microsoft.com/) 2019 or later
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) 4.7.2 or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 2016 or later
- [IIS](https://www.iis.net/) 10.0 or later

### Development Environment Setup

1. Clone the repository
   ```bash
   git clone https://github.com/yourusername/crowdfeed.git
   cd crowdfeed
   ```

2. Open the solution file in Visual Studio
   ```
   CrowdFeed.sln
   ```

3. Restore NuGet packages
   ```bash
   nuget restore
   ```

4. Update connection strings in Web.config
   ```xml
   <connectionStrings>
     <add name="CrowdFeedDB" connectionString="Data Source=yourserver;Initial Catalog=CrowdFeed;Integrated Security=True" providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

5. Build the solution
   ```bash
   msbuild CrowdFeed.sln
   ```

6. Run the application
   ```
   F5 in Visual Studio
   ```

### Production Deployment

<details>
<summary>Expand for deployment instructions</summary>

1. Build the solution in Release mode
2. Deploy to IIS using Web Deploy
3. Configure application pool settings
4. Set up SQL Server database
5. Configure mail settings for notifications
</details>

---

## 💼 Business Model

CrowdFeed operates on a dual revenue stream:

1. **Sensor Hardware Sales**: One-time purchase of seat sensor technology by mall partners
2. **Subscription Service**: Ongoing service fees for the CrowdFeed platform with tiered pricing based on mall size and number of participating restaurants

---

## 🚀 Future Enhancements

- 📱 Mobile applications for iOS and Android
- 🧠 AI-driven crowd prediction algorithms
- 🗺️ Integration with mall navigation systems
- 🪑 Table reservation capabilities
- 📊 Expanded analytics for business intelligence
- 🍔 Integration with popular food delivery platforms



