using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnityModManagerNet;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.JsonSystem;
using dragonrace.Feats;
using dragonrace.Race;
using dragonrace.Archetypes;
using dragonrace.Race.Heritages;
using BlueprintCore.Blueprints.Configurators.Root;
using dragonrace.Utility;

namespace dragonrace;

#if DEBUG
[EnableReloading]
#endif
public static class Main {
    internal static Harmony HarmonyInstance;
    internal static UnityModManager.ModEntry.ModLogger log;

    public static bool Load(UnityModManager.ModEntry modEntry) {
        log = modEntry.Logger;
#if DEBUG
        modEntry.OnUnload = OnUnload;
#endif
        modEntry.OnGUI = OnGUI;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        return true;
    }

    public static void OnGUI(UnityModManager.ModEntry modEntry) {

    }

#if DEBUG
    public static bool OnUnload(UnityModManager.ModEntry modEntry) {
        HarmonyInstance.UnpatchAll(modEntry.Info.Id);
        return true;
    }
#endif
    [HarmonyPatch(typeof(BlueprintsCache))]
    static class BlueprintsCaches_Patch
    {
        // Uses BlueprintCore's LogWrapper which uses Owlcat's internal logging.
        // Logs to `%APPDATA%\..\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\GameLogFull.txt` and the Mods
        // channel in RemoteConsole.
        private static readonly LogWrapper Logger = LogWrapper.Get("MagicalAptitude");
        private static bool Initialized = false;

        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        static void Postfix()
        {
            try
            {
                if (Initialized)
                {
                    Logger.Info("Already initialized blueprints cache.");
                    return;
                }
                Initialized = true;

                Logger.Info("Configuring Race Blueprints.");
                // Configure Race
                Dragon.Configure();

                Logger.Info("Configuring Archetype Blueprints.");
                DragonHeroArchetypes.Configure();

                Logger.Info("Configuring Feat Blueprints");
                Feats.Feats.Configure();
            }
            catch (Exception e)
            {
                Logger.Error("Failed to initialize.", e);
            }
        }

        [HarmonyPatch(typeof(StartGameLoader))]
        static class StartGameLoader_Patch
        {
            private static bool Initialized = false;

            [HarmonyPatch(nameof(StartGameLoader.LoadPackTOC)), HarmonyPostfix]
            static void LoadPackTOC()
            {
                try
                {
                    if (Initialized)
                    {
                        Logger.Info("Already configured delayed blueprints.");
                        return;
                    }
                    Initialized = true;

                    RootConfigurator.ConfigureDelayedBlueprints();
                }
                catch (Exception e)
                {
                    Logger.Error("Failed to configure delayed blueprints.", e);
                }
            }
        }
    }
}
