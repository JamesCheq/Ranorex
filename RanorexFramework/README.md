# Ranorex

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Folder Structure](#folder-structure)
- [Running Tests](#running-tests)
- [Parallel Execution Configuration](#parallel-execution-configuration)
- [Reporting](#reporting)

## Introduction
This project is an automated testing framework built using Ranorex Studio for desktop application testing. The framework is designed to automate functional, regression, and smoke testing of Windows desktop applications.

## Features
- **Desktop Application Automation**
- **Modular Test Architecture**
- **Data-Driven Testing**
- **Centralized Object Repository**
- **Automated Reporting**
- **Scalable Test Execution**

## Installation
 **Pre-requisites:**
 1. **Install Ranorex Studio**  
    - Download and install Ranorex Studio
    - Ensure the installed version is compatible with the project framework.
 2. **Install .NET Framework**  
    - Install the required .NET Framework version supported by the Ranorex project.

 3. **Desktop Application Access**  
    - Ensure the desktop application under test is installed and accessible on the test machine.

 4. **Verify Ranorex Installation**  
    - Open Ranorex Studio successfully.
    - Confirm that the following tools are accessible:
      - Ranorex Spy
      - Ranorex Repository
      - Test Suite Runner

**Installation Steps:**
 1. Clone the Repository to your local machine:
```
- git clone <repository-url>
- cd <project-folder>
```

 2. Open the Solution
    - Navigate to the project directory
    - Click Open Existing Project
    - Select the `.rxsln` solution file

 3. Restore / Build Project Dependencies
    - Build the solution
    - Allow Ranorex to restore project references automatically

**Configuration:**
```
· Playwright Configuration: Modify the playwright.config.ts test timeout, retries and other Playwright-specific settings.
· Environment Variables: Use .env files to manage environment URL.
```

## Folder Structure
  ```
RanorexFramework/
├── References/                   # Project dependencies (DLLs & libraries)
├── Reports/                      # Execution reports (auto-generated)
├── Applications/                 # AUT (Application Under Test)
│   └── RxDemoApp.exe
│
├── Config/                       # Configuration & Startup Settings
│   ├── app.config
│   ├── AssemblyInfo.cs
│   └── Program.cs
│
├── Modules/                      # Reusable automation modules (Coded modules)
│   ├── Introduction/
│   ├── Coded_CloseAUT.cs
│   └── Coded_StartAUT.cs
│
├── Pages/                        # Page-level test modules (Recorded + UserCode)
│   ├── Introduction/
│   │   ├── MOD_EnterName.rxrec
│   │   └── MOD_ValidateBanner.rxrec
│   │
│   ├── Test Database/
│   │   ├── MOD_AddDatabaseEntry.rxrec
│   │   └── MOD_DeleteEntry.rxrec
│   │
│   ├── MOD_CloseAUT.rxrec
│   │   ├── MOD_CloseAUT.cs
│   │   └── MOD_CloseAUT.UserCode.cs
│   │
│   └── MOD_StartAUT.rxrec
│       ├── MOD_StartAUT.cs
│       └── MOD_StartAUT.UserCode.cs
│
├── Repository/                   # Ranorex UI Repository
│   ├── RanorexFrameworkRepository.rxrep
│       ├── RanorexFrameworkRepository.cs
│       └── RanorexFrameworkRepository.rximg
│
├── TestData/                     # Test datasets (Excel / CSV)
│
├── Utilities/                    # Helper / Utility classes
│   ├── ExcelHelper.cs
│
├── packages.config              # NuGet dependencies
├── RanorexFramework.cd          # Class diagram (if used)
├── RanorexFramework.rxsxc       # Solution config
├── RanorexFramework.rxtmg       # Test suite metadata
│
├── TS001_Introduction.rxtst     # Introduction test suite
└── TS002_TestDatabase.rxtst     # Database test suite 
  ```

## Running Tests

- Run Entire Test Suite
  - Open MainTestSuite.rxtst
  - Click Run

- Run Specific Test Case
  - Expand the Test Suite
  - Right-click a test case
  - Select Run Selected Item


## Parallel Execution Configuration
To enable or configure parallel execution of tests, follow these steps:
1. Open the `playwright.config.ts` file.
2. Locate the `workers` property. By default, it is set to `4`:
   ```typescript
   workers: 4,
   ```
3. Update the value of `workers` to the desired number of parallel workers. For example:
   ```typescript
   workers: 6, // Run tests with 6 parallel workers
   ```
   The recommended value depends on your system's CPU cores and available resources.

## Reporting
- Execution reports are generated automatically inside:
```
/Reports
```

  - Reports include: 
     - Execution summary
     - Pass/fail results
     - Logs
     - Failure screenshots (if enabled)