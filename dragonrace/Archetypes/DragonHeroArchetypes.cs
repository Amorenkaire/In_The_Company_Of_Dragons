using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragonrace.Archetypes
{
    class DragonHeroArchetypes
    {
        private const string DragonHeroName = "DragonHero";
        private const string DragonHeroGuid = "B1BC8661-55E3-4BB7-8899-C9B97C99AEA1";

        internal const string ArchetypeDisplayName = "DragonHero.Name";
        private const string ArchetypeDescription = "DragonHero.Description";

        private const string DHPaladinName = "DHPaladin";
        private const string DHDisplayName = "DHPaladin.Name";
        private const string DHDescription = "DHDescription";
        private const string DHPaladinGuid = "98069190-D027-466C-A814-61EF89EB98BD";

        private const string DHSmiteFeatName = "DHSmite";
        private const string DHSmiteFeatGuid = "345B0A20-DBC6-4E85-B6A6-1308F6A5316E";

        public static void Configure()
        {
            var x = LevelEntryBuilder.New();
            x
                .AddEntry(level: 1, FeatureRefs.SmiteEvilFeature.ToString())
                .AddEntry(level: 3, FeatureSelectionRefs.SelectionMercy.ToString())
                .AddEntry(level: 4, FeatureRefs.SmiteEvilAdditionalUse.ToString())
                .AddEntry(level: 5, FeatureRefs.PaladinDivineBond.ToString())
                .AddEntry(level: 9, FeatureSelectionRefs.SelectionMercy.ToString())
                .AddEntry(level: 11, FeatureRefs.AuraOfJusticeFeature.ToString())
                .AddEntry(level: 15, FeatureSelectionRefs.SelectionMercy.ToString())
                .AddEntry(level: 20, FeatureRefs.HolyChampion.ToString());

            var DHPaladin =
                ArchetypeConfigurator.New(DHPaladinName, DHPaladinGuid, CharacterClassRefs.PaladinClass)
                .SetLocalizedName(DHDisplayName)
                .SetLocalizedDescription(DHDescription)
                .AddToRemoveFeatures(x)
                .Configure();

                //.AddToRemoveFeatures(level: 1, FeatureRefs.SmiteEvilFeature.ToString())
                //.AddToRemoveFeatures(level: 3, FeatureSelectionRefs.SelectionMercy.ToString())
                //.AddToRemoveFeatures(level: 4, FeatureRefs.SmiteEvilAdditionalUse.ToString())
                //.AddToRemoveFeatures(level: 5, FeatureRefs.PaladinDivineBond.ToString())
                //.AddToRemoveFeatures(level: 9, FeatureSelectionRefs.SelectionMercy.ToString())
                //.AddToRemoveFeatures(level: 11, FeatureRefs.AuraOfJusticeFeature.ToString())
                //.AddToRemoveFeatures(level: 15, FeatureSelectionRefs.SelectionMercy.ToString())
                //.AddToRemoveFeatures(level: 20, FeatureRefs.HolyChampion.ToString())
                //.Configure();
        }
    }
}
