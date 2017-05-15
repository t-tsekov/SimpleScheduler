# SimpleScheduler
For the application to work, an empty SQL Database needs to be created on the server(default name is HangfireDB) and the connection string in appsettings.json needs to updated.

If this was a real project the follwing settings would have to be applied to the deployment server in order to ensure correct behaviour:

1.Enable automatic start-up for Windows Process Activation (WAS) and World Wide Web Publishing (W3SVC) services (enabled by default).

2.Configure Automatic Startup for an Application pool (enabled by default).

3.Enable Always Running Mode for Application pool.
