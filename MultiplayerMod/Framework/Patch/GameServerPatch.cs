﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MultiplayerMod.Framework.Network;
using StardewValley.Network;
namespace MultiplayerMod.Framework.Patch
{
    internal class GameServerPatch : IPatch
    {
        private readonly Type PatchType = typeof(GameServer);
        public void Apply(Harmony harmonyInstance)
        {
            harmonyInstance.Patch(AccessTools.Constructor(PatchType, new Type[] { typeof(bool) }), postfix: new HarmonyMethod(AccessTools.Method(this.GetType(), nameof(Postfix_contruction))));
        }
        private static void Postfix_contruction(GameServer __instance)
        {
            List<Server> servers = ModUtilities.Helper.Reflection.GetField<List<Server>>(__instance, "servers").GetValue();
            ModServer modServer = new ModServer(__instance, ModUtilities.ModConfig);
            servers.Add(modServer);
        }
    }
}