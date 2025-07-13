using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace WFStudios.StorageTransfer
{
    public class StorageTransferPlugin : RocketPlugin<StorageTransferConfiguration>
    {
        public static StorageTransferPlugin Instance { get; private set; }        
        
        protected override void Load()
        {
            Instance = this;
            
            Logger.Log("StorageTransfer has loaded.");
            Logger.Log("Made by Wimfish1");
        }

        protected override void Unload()
        {
            Logger.Log("StorageTransfer has unloaded.");
            Logger.Log("Made by Wimfish1");
        }
    }
}