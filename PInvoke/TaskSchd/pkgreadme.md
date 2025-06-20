![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.TaskSchd NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.TaskSchd?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported for Windows Task Scheduler 1.0 and 2.0 COM objects.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.TaskSchd**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
GetNetScheduleAccountInformation SetNetScheduleAccountInformation                                            | TASK_TRIGGER_TYPE TaskDaysOfTheWeek TaskFlags TaskMonths TaskStatus TaskTriggerFlags TaskWhichWeek TASK_ACTION_TYPE TASK_COMPATIBILITY TASK_CREATION TASK_ENUM_FLAGS TASK_INSTANCES_POLICY TASK_LOGON_TYPE TASK_PROCESSTOKENSID_TYPE TASK_RUN_FLAGS TASK_RUNLEVEL_TYPE TASK_SESSION_STATE_CHANGE_TYPE TASK_STATE TASK_TRIGGER_TYPE2 TaskWeeksOfMonth                          | DAILY MONTHLYDATE MONTHLYDOW TASK_TRIGGER TRIGGER_TYPE_UNION WEEKLY                                        | ITask ITaskScheduler IAction IActionCollection IBootTrigger IComHandlerAction IDailyTrigger IEmailAction IEventTrigger IExecAction IIdleSettings IIdleTrigger ILogonTrigger IMaintenanceSettings IMonthlyDOWTrigger IMonthlyTrigger INetworkSettings IPrincipal IPrincipal2 IRegisteredTask IRegisteredTaskCollection IRegistrationInfo IRegistrationTrigger IRepetitionPattern IRunningTask IRunningTaskCollection ISessionStateChangeTrigger IShowMessageAction ITaskDefinition ITaskFolder ITaskFolderCollection ITaskHandler ITaskHandlerStatus ITaskNamedValueCollection ITaskNamedValuePair ITaskService ITaskSettings ITaskSettings2 ITaskSettings3 ITaskVariables ITimeTrigger ITrigger ITriggerCollection IWeeklyTrigger 
