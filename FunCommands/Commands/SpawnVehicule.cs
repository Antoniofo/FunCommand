using Synapse.Api;
using Synapse.Command;

namespace FunCommand.Commands
{
    [CommandInformation(
        Name = "SpawnVehicule",
        Aliases = new[] { "vehicule", "sv" },
        Description = "Spawn Chaos car or ouloucoupter for mtf",
        Permission = "fun.vehicule",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "sv chaos or sv mtf",
        Arguments = new[] { "chaos; mtf or 1;0" }
        )]
    class SpawnVehicule : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            CommandResult result = new CommandResult();
            Player p = context.Player;

            if (context.Arguments.Count <= 0)
            {
                result.Message = "missing argument";
                result.State = CommandResultState.Error;
            }
            else
            {
                var arg = context.Arguments.Array[1];
                if (arg.ToLower() == "mtf" || arg == "0")
                {
                    Round.Get.SpawnVehicle();
                    result.Message = "MTFs chopper arrives !";
                    result.State = CommandResultState.Ok;
                }
                else if (arg.ToLower() == "chaos" || arg == "1")
                {
                    Round.Get.SpawnVehicle(true);
                    result.Message = "Chaos car arrives !";
                    result.State = CommandResultState.Ok;
                }
                else
                {
                    result.Message = "Wrong argument Try to use 'chaos' or 'mtf'";
                    result.State = CommandResultState.Error;
                }
            }
            return result;
        }
    }
}
