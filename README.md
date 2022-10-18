# AsyncAwaitCSharpSynchronizationContext
Different behavior of async await with/wihout a SynchronizationContext ( UI ) in C#

With SynchronizationContext ( e.g. in WPF/WinForms app) 

Thread Id initially: 1  <br />
Thread Id inside DownloadString call before calling GetAsync: 1  <br />
Thread Id inside DownloadString call after calling GetAsync: 1  <br />
Thread Id after DownloadString call in Main: 1  <br />
Thread Id inside FirstAsyncCall call before Task Delay: 1  <br />
Thread Id inside FirstAsyncCall call after Task Delay: 1  <br />
Thread Id after all calls in Main: 1  <br />
-------------------------------------------------------------------------------  <br />

Without SynchronizationContext ( e.g. in a Console app)  <br />

Thread Id initially: 1  <br />
Thread Id inside DownloadString call before calling GetAsync: 1  <br />
Thread Id inside DownloadString call after calling GetAsync: 9  <br />
Thread Id after DownloadString call in Main: 9  <br />
Thread Id inside FirstAsyncCall call before Task Delay: 9  <br />
Thread Id inside FirstAsyncCall call after Task Delay: 5  <br />
Thread Id after all calls in Main: 5  <br />
