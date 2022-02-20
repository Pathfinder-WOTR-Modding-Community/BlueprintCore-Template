using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using ModTemplate.Content;
using ModTemplate.Content.Archetypes;
using ModTemplate.Content.Feats;
using System;
using UnityModManagerNet;

namespace ModTemplate
{
  static class Main
  {
    private static LogWrapper Logger = LogWrapper.Get("ModTemplate");

    /// <summary>
    /// Unity Mod Manager entry point. Called to load the mod.
    /// </summary>
    static bool Load(UnityModManager.ModEntry modEntry)
    {
      try
      {
        new Harmony(modEntry.Info.Id).PatchAll();
        Logger.Info("Finished harmony patching.");
      }
      catch (Exception e)
      {
        Logger.Error("Harmony patching failed.", e);
        return false; // Flags the init failure for UMM
      }

      return true;
    }

    /// <summary>
    /// Patch for BlueprintsCache.Init(). This is when it is safe to add / modify blueprints.
    /// </summary>
    [HarmonyPatch(typeof(BlueprintsCache))]
    static class BlueprintsCache_Patch
    {
      private static bool Initialized = false;

      [HarmonyPriority(Priority.First)]
      [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
      static void Init()
      {
        try
        {
          if (Initialized)
          {
            // Make sure init doesn't get called twice
            Logger.Info("Already initialized.");
            return;
          }
          Initialized = true;
          Logger.Info("Initializing blueprints.");

          // Call your configure/init methods for new content (blueprints) here

          MyArchetype.Configure();
          MyClass.Configure();
          MySpell.Configure();

          Logger.Info("Initialization finished.");
        }
        catch (Exception e)
        {
          Logger.Error("Initialization failed.", e);
        }
      }
    }
  }
}
