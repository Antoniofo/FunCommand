using Synapse.Api.Plugin;

namespace FunCommand
{
    [PluginInformation(
        Author = "Antoiofo",
        Description = "Fun command to play with",
        LoadPriority = 0,
        Name = "FunCommand",
        SynapseMajor = SynapseController.SynapseMajor,
        SynapseMinor = SynapseController.SynapseMinor,
        SynapsePatch = SynapseController.SynapsePatch,
        Version = "v1.0.2"
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
