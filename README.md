# **CALCULATOR APP**

## 1. GENERAL INFO
This is a demo calculator app solution.  
Uses: Source code for CalculatorLib.  

### Includes folowing projects:
- Console App  
- Shared Components
- CalculatorLib

Api portion is not implemented.


## 2. REQUIREMENTS
The solution contains the following projects. Check each `.csproj` file for target frameworks and dependencies:

- [AppConsole/AppConsole.csproj](./AppConsole/AppConsole.csproj)
- [AppApi/AppApi.csproj](./WebApi/WebApi.csproj)
- [Shared/Shared.csproj](./Shared/Shared.csproj)
- [CalculatorLib/Calculator.csproj](./CalculatorLib/CalculatorLib.csproj)

## 3. LOCAL USAGE
### 1. Clone the Repository
```bash
git clone https://github.com/drago1979/CalculatorSolutionSource.git
```
```CalculatorSolutionSource
cd CalculatorSolutionWithNuGet
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Build & Run
```bash
dotnet build
```
```bash
dotnet run --project AppConsole
```