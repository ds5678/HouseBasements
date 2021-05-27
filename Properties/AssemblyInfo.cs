using MelonLoader;
using System.Reflection;
using System.Runtime.InteropServices;
using BuildInfo = HouseBasements.BuildInfo;

[assembly: ComVisible(false)]
[assembly: Guid("a8a09ed8-01c2-499b-88a1-3e8d0af9cfde")]

[assembly: AssemblyTitle(BuildInfo.Name)]
[assembly: AssemblyDescription(BuildInfo.Description)]
[assembly: AssemblyCompany(BuildInfo.Company)]
[assembly: AssemblyProduct(BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + BuildInfo.Author)]
[assembly: AssemblyTrademark(BuildInfo.Company)]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion(BuildInfo.Version)]
[assembly: AssemblyFileVersion(BuildInfo.Version)]
[assembly: MelonInfo(typeof(HouseBasements.Implementation), BuildInfo.Name, BuildInfo.Version, BuildInfo.Author, BuildInfo.DownloadLink)]
[assembly: MelonGame("Hinterland", "TheLongDark")]