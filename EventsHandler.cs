
using System.Threading;
using GameCore;
using LabApi.Features.Wrappers;
using UnityEngine;
using LabApi.Features.Console;
using Logger = UnityEngine.Logger;

namespace MadoodaPlugin
{



    using LabApi.Events.Arguments.PlayerEvents;
    using LabApi.Events.CustomHandlers;


    public class EventsHandler : CustomEventsHandler
    {
        public override void OnPlayerChangingRadioRange(PlayerChangingRadioRangeEventArgs ev)

        {

            if (MyFirstPlugin.Singleton.Config is null)
                return;

            ev.Player.SendBroadcast(MyFirstPlugin.Singleton.Config.Message, MyFirstPlugin.Singleton.Config.Duration);
            //ev.Player.SendBroadcast("I'm off the kirkocet", for 6 seconds)
            
          LabApi.Features.Console.Logger.Info("Player changing radio range");

            AudioPlayer audioPlayer = AudioPlayer.CreateOrGet($"Player {ev.Player.Nickname}", onIntialCreation: (p) =>
            {
                // Attach created audio player to player.
                p.transform.parent = ev.Player.GameObject.transform;

                // This created speaker will be in 3D space.
                Speaker speaker = p.AddSpeaker("Main", isSpatial: true, minDistance: 5f, maxDistance: 15f);

                // Attach created speaker to player.
                speaker.transform.parent = ev.Player.GameObject.transform;

                // Set local positino to zero to make sure that speaker is in player.
                speaker.transform.localPosition = Vector3.zero;
            });

            // As example we will add clip
            audioPlayer.AddClip("Kirk");






            Thread.Sleep(3000);


            TimedGrenadeProjectile.SpawnActive(ev.Player.Position, ItemType.GrenadeHE, ev.Player, 0.1f);


        }

    }
}