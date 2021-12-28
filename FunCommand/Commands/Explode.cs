using Synapse;
using Synapse.Api;
using Synapse.Command;
using System.Linq;

namespace FunCommand.Commands
{
    [CommandInformation(
        Name = "explode",
        Aliases = new[] { "exp" },
        Description = "Make somebody explode",
        Permission = "fun.exp",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "explode <PlayerName>",
        Arguments = new[] { "Player" }
        )]
    class Explode : ISynapseCommand
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
                if (arg.Equals("*"))
                {
                    if (Plugin.Config.Nuke){
						foreach (Player ps in Server.Get.Players)
						{
							Map.Get.Explode(ps.Position);
						}
						result.Message = "Everyone Exploded";
						result.State = CommandResultState.Ok;
					}else{
						result.Message = "Nuke config not enabled";
						result.State = CommandResultState.Error;
					}
                    
                }else if (arg.ToLower().Equals("admin"))
                {
					if(Plugin.Config.ActiveAdminTarget){
						foreach (Player ps in Server.Get.Players.Where(x => x.RemoteAdminAccess == true))
						{
							Map.Get.Explode(ps.Position);    
						}
						result.Message = "All Admin exploded";
						result.State = CommandResultState.Ok;
					}else{
						result.Message = "Admin Config not enabled";
						result.State = CommandResultState.Error;
					}
                    
                }
                else
                {
					int Count = 0;
                    foreach (Player ps in Server.Get.Players)
                    {
                        if (ps.NickName.ToLower().Contains(arg.ToLower())){
                            Map.Get.Explode(ps.Position);
							Count++;
                            break;
                        }
                    }
					if(Count == 1){
						result.Message = "Player exploded successfully";
						result.State = CommandResultState.Ok;	
					}else if(Count > 1){
						result.Message = "Players exploded successfully";
						result.State = CommandResultState.Ok;	
					}else{
						result.Message = "NO Players exploded";
						result.State = CommandResultState.Ok;	
					}
					
                }
                
            }            
            return result;
        }
    }
}
