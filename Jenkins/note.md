/t:Rebuild 
/p:Configuration=Release;PublishProfile=D:\\Program Files (x86)\\Jenkins\\workspace\\EFMVC\\LoginTest\\Properties\\PublishProfiles\\FolderProfile;DeployOnBuild=true;VisualStudioVersion=14.0  





D:\Software\nuget.exe restore "D:\Program Files (x86)\Jenkins\workspace\EFMVC\WebMVCEF.sln" -NoCache




/m /t:Rebuild /p:Configuration=Release /p:TargetFrameworkVersion=4.5

D:\Jenkins\nuget.exe restore "C:\Users\xxx\.jenkins\workspace\test\MBFC.sln" -NoCache






2018-10-29
002. 建立基本的Windows版本的Jenkins部署到IIS站台：使用MSBuild 建置專案，搭配Git 進行版控，最後以PowerShell 上到IIS站台
258 0 Continuous Integration 檢舉文章
Jenkins 相關部署

應用所需

1. Jenkins 2.148  (需額外安裝以下套件)

    a. MSBuild

    b. Windows PowerShell 

2. Visual Studio 2017 C#  Asp.net MVC Web

3. internet information services (iis)

4. Git

目的：	
1. 學習到基本的Jenkins 自動部署網站 =>

    當簽入Git後自動部署到IIS WebSite上

2. 減少工程師部署程式耗費的時間，可以將省下來的時間泡杯咖啡

☺  
本篇分為三部分 + 補充：
一、	搭配Git + IIS WebSite站台架設 ( 二、三步驟所需)
二、	
Jenkins 建立一個基本的Job (內含外掛)

三、	撰寫PowerShell 腳本進行簡易部署
補充：	
1. MSBuild 的安裝

2. Windows PowerShell 

 

1. 搭配Git + IIS WebSite站台架設 ( 二、三步驟所需)
Step 1： 以下是測試的網站，一個MVC Web專案，基本的套版



Step 2. 我們這邊將上面的檔案，簽入版控軟體的位置中 ，並且取得連結 (※ 這邊是使用Git，您可以使用Subversion、Team Foundation Server，都可以，這邊使用Git)

測試用的網站版本位置：	 https://github.com/gotoa1234/PracticesWebsite.git


Step 3. 取得版控檔案  



Step 4. 部署到IIS 站台上，這邊以Local 本機架設



Step 5. 執行瀏覽網站，會如下畫面



2. Jenkins 建立一個基本的Job (內含外掛)
Step 1：  請選擇【新增作業】，我們建立一個全新的Job

※如果需要安裝的夥伴，可以先到連結安裝Jenknis 這邊使用Windows 版本



Step 2：  建立一個新的Job

1. 輸入Job 名稱

2. 建立的類型

3. 確定



Step 3： 原始碼管理的部分，使用【第一部份】的Git位址 https://github.com/gotoa1234/PracticesWebsite.git  => 然後按下 Add 輸入取得版控的帳號密碼



Step 4： 輸入自己Git的 Username與 Password，便於取得檔案



Step 5： 接著在建置觸發程序中，打勾 輪詢SCM => H/2 * * * * 這是表示每隔2分鐘檢查是否git版控有異動，當異動時會自動建置

H/2 * * * *
※可以不做



Step 6： 建置環境部分 -> 新增建置步驟 -> Build a Visual Studio project or solution using Msbuild.

建造Visaul 2017的專案檔

※如果需要沒有出現選項 可以看最下面的【補充章節  1. MSBuild 安裝方式】



Step 7： 輸入如下資料

 MSBuild Build File :   

PracticesWebsite/PracticesWebsite.csproj 
 Command Line Agiments : 

/T:Package /P:visualStudioVersion=15.0  /P:Configuration=Release /p:Platform=AnyCPU 
 

https://shine.dev/2017/12/14/jenkins-for-webdeploy/

Jenkins集成
若要通过命令行调用Web Deploy相关功能，只需在MSBuild工具附加下述参数：p:DeployOnBuild=True;PublishProfile=WebDeploy-Demo;Password=P@ssw0rd+;AllowUntrustedCertificate=true




键	            值	                说明
DeployOnBuild	True or False	    编译后是否发布
PublishProfile	ProfileName	        使用的发布文件。注意：不需要添加发布文件的扩展名。
Password	  发布用户的密码	     此方式会在脚本中暴露对应用户的密码，建议使用证书进行用户认证。
AllowUntrustedCertificate	    True or False	        具有中间人攻击的安全风险，建议使用证书进行用户认证。


在编译成功后，MSBuild会直接调用Web Deploy相关的功能进行发布。