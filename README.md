# WWP Revit C# Add-in Template

This template builds one add-in project that targets Revit 2024 (.NET Framework 4.8), Revit 2025 (.NET 8), and Revit 2026 (.NET 8) via configuration.

## Setup

1. Make sure Revit 2024/2025/2026 are installed in the default locations, or edit `build/LocalRevitPaths.props`.
2. Open `WWP_Revit_C-ADDON.sln` in Visual Studio 2022.
3. Select the configuration that matches your Revit version:
   - `Debug2024` builds and deploys the 2024 add-in
   - `Debug2025` builds and deploys the 2025 add-in
   - `Debug2026` builds and deploys the 2026 add-in

Each build writes the add-in manifest to:
`%AppData%\Autodesk\Revit\Addins\<Version>\WWP_Revit_C-ADDON.addin`
and copies the DLL/PDB to:
`%AppData%\Autodesk\Revit\Addins\<Version>\WWP_Revit_C-ADDON`

## Projects

- `src/WWP.RevitAddin/WWP.RevitAddin.csproj` - single project with per-version configurations

## Notes

- The add-in entry point is `WWP.RevitAddin.App`.
- Update `Directory.Build.props` if you want to change the AddInId or metadata.
