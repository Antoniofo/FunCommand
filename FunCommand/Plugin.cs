using Synapse.Api.Plugin;

namespace FunCommand
{
    [PluginInformation(
        Author = "Antoiofo",
        Description ="Fun command to play with",
        LoadPriority =0,
        Name = "FunCommand",
        SynapseMajor =2,
        SynapseMinor =8,
        SynapsePatch =0,
        Version = "v1.0.1"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "FunCommand")]
        public static Config Config { get; set; }
        public override void Load()
        {
            base.Load();
        }

        public override void ReloadConfigs()
        {
            base.ReloadConfigs();
        }
    }
}
