//Code First簡易說明

//###首次使用###
/*
 * 	【注意1.】新增ADO專案並選擇 >「來自資料庫的Code First」
 * 	【注意2.】呼叫Nuget Console (套件管理主控台),預設專案選擇ADO Project
 * 
 * 	1.建立Migrations
 * 	【指令】Enable-Migrations
 * 
 * 	2.Initial Migrations
 * 	【指令】Add-Migration Initial
 * 
 * 	3.Initial DataBase
 * 	【指令】Update-DataBase
 */

//###之後更新###
/*	
 * 
 * 	【注意】呼叫Nuget Console (套件管理主控台),預設專案選擇ADO Project
 * 
 * 	1.Add New Migrations
 * 	【指令】Add-Migration {Your_Migration_Update_Title}
 * 
 * 	2.Update DataBase
 * 	【指令】Update-DataBase -Force
 */