using System.Collections.Generic;
using Rocket.API;

namespace WFStudios.StorageTransfer
{
    public class StorageTransferConfiguration : IRocketPluginConfiguration
    {
        public List<ushort> BlacklistedItems { get; set; }
        public float MaxDistance { get; set; }
        
        public void LoadDefaults()
        {
            BlacklistedItems = new List<ushort> { 519, 1241 };
            MaxDistance = 5f;
        }
    }
}