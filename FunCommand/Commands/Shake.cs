using Synapse.Api;
using Synapse.Command;
using Synapse;
using System.Linq;
using Synapse.Api.Enum;

namespace FunCommand.Commands
{
    [CommandInformation(
        Name = "shake",
        Aliases = new[] { "sh" },
        Description = "Make your screen shaking",
        Permission = "fun.shake",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "shake"
        )]
    class Shake : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            CommandResult result = new CommandResult();
            Player p = context.Player;

            if (context.Arguments.Count <= 0)
            {
                if (p.Zone == ZoneType.Surface)
                {
                    p.ShakeScreen();
                    result.Message = "You FOOOL !";
                }
                else
                {
                    result.Message = "If you really want to to that you will be stuck with a orange screen until end of the game";
                }
                
                result.State = CommandResultState.Ok;
            }
            else
            {
                var arg = context.Arguments.Array[1];
                if (arg.Equals("*"))
                {
                    if (Plugin.Config.Nuke)
                    {
                        foreach (Player ps in Server.Get.Players)
                        {
                            if(ps.Zone == ZoneType.Surface)
                            {
                                ps.ShakeScreen();
                            }
                        }
                        result.Message = "Entire server shake successfully";
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
                            if (ps.Zone == ZoneType.Surface)
                            {
                                ps.ShakeScreen();
                            }
                        }
                        result.Message = "Admin shake successfully";
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
                            if (ps.Zone == ZoneType.Surface)
                            {
                                ps.ShakeScreen();
                                Count++;
                            }
                            
                            break;
                        }
                    }
                    if (Count == 1)
                    {
                        result.Message = "Player shake successfully";
                        result.State = CommandResultState.Ok;
                    }
                    else if (Count > 1)
                    {
                        result.Message = "Players shake successfully";
                        result.State = CommandResultState.Ok;
                    }
                    else
                    {
                        result.Message = "NO Players shaked";
                        result.State = CommandResultState.Ok;
                    }
                }
            }
            return result;
        }
    }
}
