# .NET8.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET8.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET8.0 upgrade.
3. Upgrade JongBrabant.Kantinescherm.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

| Project name | Description |
|:-----------------------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name | Current Version | New Version | Description |
|:------------------------------------------|:---------------:|:-----------:|:----------------------------------------------|
| Microsoft.EntityFrameworkCore.Design |6.0.8 |8.0.21 | Recommended for .NET8.0 |
| Microsoft.EntityFrameworkCore.Sqlite |6.0.8 |8.0.21 | Recommended for .NET8.0 |
| Microsoft.EntityFrameworkCore.SqlServer |6.0.8 |8.0.21 | Recommended for .NET8.0 |
| Microsoft.EntityFrameworkCore.Tools |6.0.8 |8.0.21 | Recommended for .NET8.0 |
| Microsoft.Extensions.Logging.AzureAppServices |6.0.8 |8.0.21 | Recommended for .NET8.0 |

### Project upgrade details

#### JongBrabant.Kantinescherm.csproj modifications

Project properties changes:
 - Target framework should be changed from `net6.0` to `net8.0`

NuGet packages changes:
 - Microsoft.EntityFrameworkCore.Design should be updated from `6.0.8` to `8.0.21`
 - Microsoft.EntityFrameworkCore.Sqlite should be updated from `6.0.8` to `8.0.21`
 - Microsoft.EntityFrameworkCore.SqlServer should be updated from `6.0.8` to `8.0.21`
 - Microsoft.EntityFrameworkCore.Tools should be updated from `6.0.8` to `8.0.21`
 - Microsoft.Extensions.Logging.AzureAppServices should be updated from `6.0.8` to `8.0.21`

Feature upgrades:
 - None identified.

Other changes:
 - None identified.
