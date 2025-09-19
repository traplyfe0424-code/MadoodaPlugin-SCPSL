using LabApi.Events.CustomHandlers;

namespace MadoodaPlugin;

using System;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;



public class MyFirstPlugin : Plugin<Config>
 {
    public static MyFirstPlugin Singleton { get; set; } = null!;
            
    // The name of the plugin
    public override string Name { get; } = "MadoodaIsLearning";

    // The description of the plugin
    public override string Description { get; } = "Kirk";

    // The author of the plugin
    public override string Author { get; } = "Nasheed (Pat1ence)";

    // The current version of the plugin
    public override Version Version { get; } = new Version(1, 0, 0, 0);

    // The required version of LabAPI (usually the version the plugin was built with)
    public override Version RequiredApiVersion { get; } = new (LabApiProperties.CompiledVersion);

    public EventsHandler Events { get; } = new();

    public override void Enable()
    {
        Singleton = this;
        CustomHandlersManager.RegisterEventsHandler(Events);
        AudioClipStorage.LoadClip(@"C:\Users\Dallas\Documents\SCPSL\Development\MadoodaPlugin\AudioClips\Kirk.ogg");
        
    }

    public override void Disable()
    {
        Singleton = null!;
        CustomHandlersManager.UnregisterEventsHandler(Events);
    }







 }