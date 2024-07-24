using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragonrace.Archetypes
{
    class DragonHeroArchetype
    {



        public static void Configure()
        {
            //var paladin = CharacterClassRefs.PaladinClass.ToString();


            //FeatureConfigurator.New(DHSmiteFeatName, DHSmiteFeatGuid)
            //    .CopyFrom(FeatureRefs.SmiteEvilFeature.ToString(), typeof(AddFacts))
            //    .EditComponent<AddFacts>(
            //        c =>
            //            c.
            //        )
            //    .Configure();


            var DHPaladin =
            ArchetypeConfigurator.New(DHPaladinName, DHPaladinGuid, CharacterClassRefs.PaladinClass.ToString())
            .SetLocalizedName(DHDisplayName)
            .SetLocalizedDescription(DHDescription)
            //Remove features
            .AddToRemoveFeatures(1, FeatureRefs.SmiteEvilFeature.ToString())
            .AddToRemoveFeatures(3, FeatureSelectionRefs.SelectionMercy.ToString())
            .AddToRemoveFeatures(4, FeatureRefs.SmiteEvilAdditionalUse.ToString())
            .AddToRemoveFeatures(5, FeatureRefs.PaladinDivineBond.ToString())
            .AddToRemoveFeatures(9, FeatureSelectionRefs.SelectionMercy.ToString())
            .AddToRemoveFeatures(11, FeatureRefs.AuraOfJusticeFeature.ToString())
            .AddToRemoveFeatures(15, FeatureSelectionRefs.SelectionMercy.ToString())
            .AddToRemoveFeatures(20, FeatureRefs.HolyChampion.ToString())

            //Testing
            .AddToAddFeatures(1, FeatureRefs.SneakAttack.ToString())

            //.AddToAddFeatures(4, DHSmiteFeatName)
            .Configure();

        }
    }
}









//ProgressionConfigurator.New(DragonHeroName, DragonHeroGuid)
//    .SetClasses()
//    .Configure();