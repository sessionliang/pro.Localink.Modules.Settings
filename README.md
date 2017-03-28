# module-settings

开发环境：VS2015 , .Net Framework 4.6.1 , TypeScript 2.2

1. 下载之后，先还原Nuget包，然后生成。

2. 修改Tests文件夹中Web项目的web.config。主要是ConnectString。

3. 把Tests下生成的bin内的文件拷贝到项目根目录dbMigrator文件夹中，然后在packages中找到\EntityFramework.6.1.3\tools，把其中的文件也复制到dbMigrator中，然后打开cmd，运行下面命令。

    migrate.exe Localink.Platform.EntityFramework /connectionString="Server=localhost;Database=数据库名称;User=sa;Password=密码;" /connectionProviderName="System.Data.SqlClient"

    migrate.exe Localink.Modules.CMS.EntityFramework /connectionString="Server=localhost;Database=数据库名称;User=sa;Password=密码;" /connectionProviderName="System.Data.SqlClient"

    migrate.exe Localink.Modules.Main.EntityFramework /connectionString="Server=localhost;Database=数据库名称;User=sa;Password=密码;" /connectionProviderName="System.Data.SqlClient"

    migrate.exe Localink.Modules.Settings.EntityFramework /connectionString="Server=localhost;Database=数据库名称;User=sa;Password=密码;" /connectionProviderName="System.Data.SqlClient"

4. F5运行。