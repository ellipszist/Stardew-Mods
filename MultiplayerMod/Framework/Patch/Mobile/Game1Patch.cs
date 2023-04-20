﻿using HarmonyLib;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerMod.Framework.Patch.Mobile
{
    public class Game1Patch : IPatch
    {
        public static readonly Type PATCH_TYPE = typeof(Game1);
        public static IReflectedField<int> xEdgeField;
        public static IReflectedField<string> savesPathField;
        public static IReflectedField<Texture2D> mobileSpriteSheetField;
        public Game1Patch()
        {
            xEdgeField = ModUtilities.Helper.Reflection.GetField<int>(PATCH_TYPE, "xEdge");
            savesPathField = ModUtilities.Helper.Reflection.GetField<string>(PATCH_TYPE, "savesPath");
            mobileSpriteSheetField = ModUtilities.Helper.Reflection.GetField<Texture2D>(PATCH_TYPE, "mobileSpriteSheet");
        }
         

        public static Texture2D mobileSpriteSheet
        {
            get
            {
                return mobileSpriteSheetField.GetValue();
            }
            set { mobileSpriteSheetField.SetValue(value); }
        }

        public static int xEdge
        {
            get
            {
                return xEdgeField.GetValue();
            }
            set
            {
                xEdgeField.SetValue(value);
            }
        }
        public static string savesPath
        {
            get
            {
                return savesPathField.GetValue();
            }
            set
            {
                savesPathField.SetValue(value);
            }
        }

        public void Apply(Harmony harmony)
        {
             
        }      
    }
}
