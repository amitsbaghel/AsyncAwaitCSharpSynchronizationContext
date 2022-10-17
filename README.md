# AsyncAwaitCSharpSynchronizationContext
Different behavior of Async Await with a SynchronizationContext ( UI ) and without it in C#

With SynchronizationContext ( e.g. in WPF/WinForms app)

Thread Id initially: 1
Thread Id inside DownloadString call before calling GetAsync: 1
Thread Id inside DownloadString call after calling GetAsync: 1
Thread Id after DownloadString call in Main: 1
Thread Id inside FirstAsyncCall call before Task Delay: 1
Thread Id inside FirstAsyncCall call after Task Delay: 1
Thread Id after all calls in Main: 1
-------------------------------------------------------------------------------

Without SynchronizationContext ( e.g. in a Console app)

Thread Id initially: 1
Thread Id inside DownloadString call before calling GetAsync: 1
Thread Id inside DownloadString call after calling GetAsync: 9
Thread Id after DownloadString call in Main: 9
Thread Id inside FirstAsyncCall call before Task Delay: 9
Thread Id inside FirstAsyncCall call after Task Delay: 5
Thread Id after all calls in Main: 5