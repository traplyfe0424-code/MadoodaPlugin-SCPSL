using System.Threading;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Features.Wrappers;

namespace MadoodaPlugin;

using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;


public class EventsHandler : CustomEventsHandler
{
    public override void OnPlayerChangingRadioRange(PlayerChangingRadioRangeEventArgs ev)
    
    {

        if (MyFirstPlugin.Singleton.Config is null)
            return;

        ev.Player.SendBroadcast(MyFirstPlugin.Singleton.Config.Message, MyFirstPlugin.Singleton.Config.Duration);
        //ev.Player.SendBroadcast("I'm off the kirkocet", for 6 seconds);


        Thread.Sleep(3000);

        TimedGrenadeProjectile.SpawnActive(ev.Player.Position, ItemType.GrenadeHE, ev.Player, 0.1f);


        //Creates a grenade at the player's position









    }
}