# Troubleshooting Common Problems

The page has information about some of the common problems that Znode developers run into.

## Miscellaneous Visual Studio Build Errors

**Problem:** Visual Studio is failing to build Znode, and there are no code changes that cause breakage.

**Possible Solutions:**

* Try building again. Sometimes this is enough to push through the failures.
* Try a full clean/rebuild.

## Znode.Libraries.Report Project Failed to Load

**Problem:** When opening the Znode solution with Visual Studio, a migration report with an error is presented.

![migration report](_assets/migration-report.png)

**Solution:** Install [SSRS](https://docs.microsoft.com/en-us/sql/reporting-services/create-deploy-and-manage-mobile-and-paginated-reports?view=sql-server-2017) if desired. Note that Znode currently has reports implemented in two different frameworks: (1) [SSRS](https://docs.microsoft.com/en-us/sql/reporting-services/create-deploy-and-manage-mobile-and-paginated-reports?view=sql-server-2017), and (2) [DevExpress](https://www.devexpress.com/). The DevExpress reports are replacing the SSRS reports, so SSRS reports are not critical to have functional. 

**Bottom line:** This error can be safely ignored if not interested in Znode's deprecated SSRS reports.

## TypeScript Compiler (TSC) Error

**Problem:** When building the Znode solution with Visual Studio, TypeScript errors occur.

**Possible Solutions:** This problem sometimes occurs in the Admin UI and WebStore applications but is inconsistent. Possible solutions include:

* Restart Visual Studio and/or Windows itself.
* Upgrade the version of TypeScript used in the Admin UI and WebStore projects.
  * For the `Znode.Engine.Admin` and `Znode.Engine.WebStore` projects, in Visual Studio, right click on the project, go to `Properties` > `TypeScript Build` tab, then in the `TypeScript version` field choose a later (or latest) version. Try building again, possibly restarting Visual Studio and/or Windows if necessary.

## Roslyn 'csc.exe' Error

**Problem:** The Znode Admin UI / API / WebStore application(s) are failing to load, possibly (but not necessarily) giving the following error:

![roslyn csc.exe error](_assets/roslyn-csc-error.png)

Alternatively, there may be no useful error presented. To check if this problem is the cause of one (or more) of the applications failing to load, check the `bin` folders of the applications. If any of the following folders are empty, the problem is occuring:

* Znode.Engine.Admin\bin\roslyn
* Znode.Engine.Api\bin\roslyn
* Znode.Engine.WebStore\bin\roslyn

**Possible Solutions:** This problem is very inconsistent among Znode developers, and seems to be [inconsistent among the .NET community in general](https://stackoverflow.com/questions/32780315/could-not-find-a-part-of-the-path-bin-roslyn-csc-exe). Possible solutions include:

* Copy the `roslyn` folder from one of the applications that has it to the application(s) that don't have it.
* Update the Microsoft.CodeDom.Providers.DotNetCompilerPlatform NuGet package.
* Download [this copy](_assets/roslyn.zip) of the `roslyn` folder and place it in the application `bin` folders.