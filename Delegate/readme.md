Ver Depois

* https://en.wikibooks.org/wiki/C_Sharp_Programming/Delegates_and_Events
* http://www.macoratti.net/16/11/c_evthdl1.htm
* https://docs.microsoft.com/pt-br/dotnet/standard/events/

Event thing

    public delegate void EveryActionTest();
    public static event EveryActionTest EveryPrepareAction;

    EveryPrepareAction?.Invoke(); 
