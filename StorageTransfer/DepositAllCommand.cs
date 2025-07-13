using System.Collections.Generic;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

namespace WFStudios.StorageTransfer;

public class DepositAllCommand : IRocketCommand
{
    public AllowedCaller AllowedCaller => AllowedCaller.Player;
    public string Name => "depositall";
    public string Help => "Deposits your entire inventory into the storage your looking at.";
    public string Syntax => "";
    public List<string> Aliases => [];
    public List<string> Permissions => [];

    public void Execute(IRocketPlayer caller, string[] command)
    {
        var player = (UnturnedPlayer)caller;
        var config = StorageTransferPlugin.Instance.Configuration.Instance;
        
        var ray = DamageTool.raycast(new Ray(player.Player.look.aim.position, player.Player.look.aim.forward), config.MaxDistance, RayMasks.BARRICADE);

        if (ray.transform == null)
        {
            UnturnedChat.Say(player, "You aren't looking at a storage item.", Color.red);
            return;
        }

        var storage = ray.transform.GetComponent<InteractableStorage>();
        
        if (storage == null)
        {
            UnturnedChat.Say(caller, "You aren't looking at a storage item.");
            return;
        }

        for (byte page = 0; page <= 7; page++)
        {
            var itemCount = player.Inventory.getItemCount(page);

            for (int i = itemCount - 1; i >= 0; i--)
            {
                var jar = player.Inventory.getItem(page, (byte)i);
                if (jar == null) continue;

                var item = jar.item;

                if (config.BlacklistedItems.Contains(jar.item.id))
                {
                    continue;
                }

                if (storage.items.tryAddItem(item))
                {
                    player.Inventory.removeItem(page, (byte)i);
                }
            }
        }
        
        UnturnedChat.Say(player, "Deposited everything that could fit in this storage.", Color.green);
    }
}