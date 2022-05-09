![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.TaskSchd NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.TaskSchd?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported for Windows Task Scheduler 1.0 and 2.0 COM objects.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.TaskSchd

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
GetNetScheduleAccountInformation<br>SetNetScheduleAccountInformation<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | TASK_TRIGGER_TYPE<br>TaskDaysOfTheWeek<br>TaskFlags<br>TaskMonths<br>TaskStatus<br>TaskTriggerFlags<br>TaskWhichWeek<br>TASK_ACTION_TYPE<br>TASK_COMPATIBILITY<br>TASK_CREATION<br>TASK_ENUM_FLAGS<br>TASK_INSTANCES_POLICY<br>TASK_LOGON_TYPE<br>TASK_PROCESSTOKENSID_TYPE<br>TASK_RUN_FLAGS<br>TASK_RUNLEVEL_TYPE<br>TASK_SESSION_STATE_CHANGE_TYPE<br>TASK_STATE<br>TASK_TRIGGER_TYPE2<br>TaskWeeksOfMonth<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | DAILY<br>MONTHLYDATE<br>MONTHLYDOW<br>TASK_TRIGGER<br>TRIGGER_TYPE_UNION<br>WEEKLY<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | ITask<br>ITaskScheduler<br>IAction<br>IActionCollection<br>IBootTrigger<br>IComHandlerAction<br>IDailyTrigger<br>IEmailAction<br>IEventTrigger<br>IExecAction<br>IIdleSettings<br>IIdleTrigger<br>ILogonTrigger<br>IMaintenanceSettings<br>IMonthlyDOWTrigger<br>IMonthlyTrigger<br>INetworkSettings<br>IPrincipal<br>IPrincipal2<br>IRegisteredTask<br>IRegisteredTaskCollection<br>IRegistrationInfo<br>IRegistrationTrigger<br>IRepetitionPattern<br>IRunningTask<br>IRunningTaskCollection<br>ISessionStateChangeTrigger<br>IShowMessageAction<br>ITaskDefinition<br>ITaskFolder<br>ITaskFolderCollection<br>ITaskHandler<br>ITaskHandlerStatus<br>ITaskNamedValueCollection<br>ITaskNamedValuePair<br>ITaskService<br>ITaskSettings<br>ITaskSettings2<br>ITaskSettings3<br>ITaskVariables<br>ITimeTrigger<br>ITrigger<br>ITriggerCollection<br>IWeeklyTrigger<br>
