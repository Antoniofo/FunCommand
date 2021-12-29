using Synapse.Config;
using System.ComponentModel;

namespace FunCommand
{
    public class Config : AbstractConfigSection
    {
        [Description("Active admin target")]
        public bool ActiveAdminTarget { get; set; } = true;

        [Description("Activate to dimscreen the entire server (Don't do that)")]
        public bool Nuke { get; set; } = false;
    }
}
