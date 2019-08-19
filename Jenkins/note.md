/t:Rebuild 
/p:Configuration=Release;PublishProfile=D:\\Program Files (x86)\\Jenkins\\workspace\\EFMVC\\LoginTest\\Properties\\PublishProfiles\\FolderProfile;DeployOnBuild=true;VisualStudioVersion=14.0  





D:\Software\nuget.exe restore "D:\Program Files (x86)\Jenkins\workspace\EFMVC\WebMVCEF.sln" -NoCache




/m /t:Rebuild /p:Configuration=Release /p:TargetFrameworkVersion=4.5

D:\Jenkins\nuget.exe restore "C:\Users\xxx\.jenkins\workspace\test\MBFC.sln" -NoCache