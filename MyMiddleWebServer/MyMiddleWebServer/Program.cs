using MyMiddleWebServer.MyWebHost;

WebHost host = new(5555);

host.UseStartup<Startup>();
host.Run();