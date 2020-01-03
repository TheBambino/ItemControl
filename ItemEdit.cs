﻿using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;
using Terraria.ID;


namespace ItemControl
{
    class ItemEdit : ModPlayer
    {
        public static int Timer2 = 0;
        public static ItemConfig Karl = new ItemConfig();
        public static int intervall = 30;

        public override void PreUpdate()
        {
            if (Timer2 >= intervall)
            {
                if (Karl == null)
                {
                    return;
                }

                ItemDefinition test = new ItemDefinition();

                foreach (var item in player.inventory)
                {
                    test = new ItemDefinition(item.type);
                    if (Karl.BannedItems.Contains(test))
                    {
                        if (Karl.sendMessages)
                        {
                            Main.NewText(item.Name + " is banned", Color.Red);
                        }
                        item.TurnToAir();
                    }
                }

                test = new ItemDefinition(Main.mouseItem.type);

                if(Karl.BannedItems.Contains(test))
                {
                    if (Karl.sendMessages)
                    {
                        Main.NewText(Main.mouseItem.Name + " is banned", Color.Red);
                    }
                    Main.mouseItem.TurnToAir();
                }

                foreach (var item in player.armor)
                {
                    test = new ItemDefinition(item.type);
                    if (Karl.BannedItems.Contains(test))
                    {
                        if (Karl.sendMessages)
                        {
                            Main.NewText(item.Name + " is banned", Color.Red);
                        }
                        item.TurnToAir();
                    }
                }
            }
            Timer2++;
        }
    }
}
