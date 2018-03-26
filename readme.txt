Program consist from two Parts: 
1) .Net core web api.  SystemData.Api, with logic in SystemData.BL with test. 

Open Visual Studio and run project. ( may require download some nuget package before ) 

2) SystemData.Api\SystemUtilsWeb - web part on Angular 5. 

In "/SystemData.Api/SystemUtilsWeb/src/environments"  need to add web api URL on which web api is hosted ( for example   webapibase: 'http://localhost:52239'   )
	Build application. Copy files to hosted Folder and run with "index.html"