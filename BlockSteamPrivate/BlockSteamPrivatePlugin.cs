using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockSteamPrivate
{
    public class BlockSteamPrivatePlugin : RocketPlugin
    {
        public static BlockSteamPrivatePlugin Instance; 
        protected override void Load()
        {
            Instance = this;
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            Logger.Log("Se han bloqueado los perfiles privados - By Margarita#8172");
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
        }

        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            if(player.SteamProfile.PrivacyState == "private" || player.SteamProfile.PrivacyState == "Private")
            {
                Provider.kick(player.CSteamID, "No Esta Permitido El Perfil En Privado");
            }
        }
    }
}
