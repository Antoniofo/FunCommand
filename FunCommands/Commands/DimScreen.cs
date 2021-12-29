using Synapse.Api;
using Synapse.Command;
using Synapse;
using System.Linq;

namespace FunCommand.Commands
{
    [CommandInformation(
        Name = "dimscreen",
        Aliases = new[] { "dim" },
        Description = "Make your screen black until the end of the round (WARNING YOU CANT TURN IT OFF)",
        Permission = "fun.dim",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "dim"
        )]
    class DimScreen : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            CommandResult result = new CommandResult();
            Player p = context.Player;

            if (context.Arguments.Count <= 0)
            {
                p.DimScreen();
                result.Message = "You FOOOL !";
                result.State = CommandResultState.Ok;
            }
            else
            {
                var arg = context.Arguments.Array[1];
                if (arg.Equals("*"))
                {
                    if (Plugin.Config.Nuke)
                    {
                        Round.Get.DimScreens();
                        result.Message = "Entire server Dimmed successfully";
                        result.State = CommandResultState.Ok;
                    }
                    else
                    {
                        result.Message = "Nuke config is not activate";
                        result.State = CommandResultState.Error;
                    }
                }
                else if (arg.ToLower().Equals("admin"))
                {
                    if (Plugin.Config.ActiveAdminTarget)
                    {
                        foreach (Player ps in Server.Get.Players.Where(x => x.RemoteAdminAccess == true))
                        {
                            ps.DimScreen();
                        }
                        result.Message = "Admin Dimmed successfully";
                        result.State = CommandResultState.Ok;
                    }
                    else
                    {
                        result.Message = "Admin config not enabled";
                        result.State = CommandResultState.Error;
                    }
                }
                else
                {
                    int Count = 0;
                    foreach (Player ps in Server.Get.Players)
                    {
                        if (ps.NickName.ToLower().Contains(arg.ToLower()))
                        {
                            ps.DimScreen();
                            Count++;
                            break;
                        }
                    }
                    if (Count == 1)
                    {
                        result.Message = "Player Dimmed successfully";
                        result.State = CommandResultState.Ok;
                    }
                    else if (Count > 1)
                    {
                        result.Message = "Players Dimmed successfully";
                        result.State = CommandResultState.Ok;
                    }
                    else
                    {
                        result.Message = "NO Players Dimmed";
                        result.State = CommandResultState.Ok;
                    }
                }
            }
            return result;
        }
    }
}
