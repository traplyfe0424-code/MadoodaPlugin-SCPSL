using System.Threading;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Features.Wrappers;

namespace MadoodaPlugin;

using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;


public class EventsHandler : CustomEventsHandler
{
    public override void OnPlayerEnteredPocketDimension(PlayerEnteredPocketDimensionEventArgs ev)
    {
        if (MyFirstPlugin.Singleton.Config is null)
            return;
        
        ev.Player.SendBroadcast(MyFirstPlugin.Singleton.Config.Turnt, MyFirstPlugin.Singleton.Config.Duration);
      //ev.Player.SendBroadcast("I'm off the kirkocet", for 6 seconds);

      Thread.Sleep(3000);
      //Waits 3 seconds
      

    }
}