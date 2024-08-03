using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dragonrace.Utility;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Actions.Builder;
using Kingmaker.Blueprints.Classes.Selection;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;

namespace dragonrace.Feats
{
    class Feats
    {
        private static readonly string LatentDraconicGiftName = "LatentDraconicGift";

        private static string NaturalSorcerySpellBookName = "NaturalSorcerySpellBook";
        private static string NaturalSorceryLearnSpellName = "NaturalSorceryLearnSpell";
        private static string NaturalSorceryIName = "ExemplarNaturalSorceryI";
        private static string NaturalSorceryIIName = "ExemplarNaturalSorceryII";
        private static string NaturalSorceryIIIName = "ExemplarNaturalSorceryIII";

        public static void Configure()
        {
            //var paragon = 
            //
            //FeatureConfigurator.New(LatentDraconicGiftName, Guids.LatentDragonicGiftGuid)
            //    .SetDisplayName("LatentDraconicGift.Name")
            //    .SetDescription("LatentDraconicGift.Description")
            //
            //    .AddPrerequisiteFeature(Guids.DracomorphosisIGuid)
            //.Configure();


            //Natural Sorcery. Increases spells known and spells per day as a 2nd level sorcerer, or increases sorcerer casting by 2.
            //Can be learned up to three times. Must be at least ninth level to gain this gift.
            //Should make this a gift, then just make the feat offer a selection of gifts.

            var NaturalSorcerySpellBookReplace =
            FeatureReplaceSpellbookConfigurator.New(NaturalSorcerySpellBookName, Guids.NaturalSorcerySpellBookGuid)
            .AddPrerequisiteClassSpellLevel(CharacterClassRefs.SorcererClass.ToString())
            .AddSpellbook(spellbook: SpellbookRefs.SorcererSpellbook.ToString())
            .SetRanks(2)
            .Configure();

            

            var NaturalSorceryLearnSpell =
                ParametrizedFeatureConfigurator.New(NaturalSorceryLearnSpellName, Guids.NaturalSorceryLearnSpellGuid)
                .AddLearnSpellParametrized(
                    spellcasterClass: CharacterClassRefs.SorcererClass.ToString(),
                    spellList: SpellListRefs.WizardSpellList.ToString(),
                    specificSpellLevel: false,
                    spellLevelPenalty: 0,
                    spellLevel: 0
                    )
                .Configure();

            FeatureConfigurator.New(NaturalSorceryIName, Guids.NaturalSorceryIGuid)
            .AddPrerequisiteCharacterLevel(9)
            .AddPrerequisiteFeature(Guids.DragonRaceGuid)
            .AddPrerequisiteFeature(Guids.DracomorphosisIGuid)
            .SetDisplayName("NaturalSorcery.Name")
            .SetDescription("NaturalSorcery.Description")
            //.AddSpellbookFeature(spellbook: SpellbookRefs.SorcererSpellbook.ToString())
            .AddSpellbookLevel(spellbook: SpellbookRefs.SorcererSpellbook.ToString())
            .AddSpellbookLevel(spellbook: SpellbookRefs.SorcererSpellbook.ToString())
            //.AddParametrizedFeatures(new() { NaturalSorceryLearnSpell })
            //.AddFacts(new() { NaturalSorceryLearnSpell })
            .SetIsClassFeature(true)
            .SetRanks(1)
            .AddToGroups(Kingmaker.Blueprints.Classes.FeatureGroup.Feat)
            .Configure();

            FeatureConfigurator.New(NaturalSorceryIIName, Guids.NaturalSorceryIIGuid)
            .AddPrerequisiteCharacterLevel(9)
            .AddPrerequisiteFeature(Guids.DragonRaceGuid)
            .AddPrerequisiteFeature(Guids.DracomorphosisIIIGuid)
            .AddPrerequisiteFeature(NaturalSorceryIName)
            .SetDisplayName("NaturalSorcery.Name")
            .SetDescription("NaturalSorcery.Description")
            .SetHideNotAvailibleInUI(true)
            .AddSpellbookLevel(spellbook: SpellbookRefs.SorcererSpellbook.ToString())
            .AddSpellbookLevel(spellbook: SpellbookRefs.SorcererSpellbook.ToString())
            .SetIsClassFeature(true)
            .SetRanks(1)
            .AddToGroups(Kingmaker.Blueprints.Classes.FeatureGroup.Feat)
            .Configure();

            FeatureConfigurator.New(NaturalSorceryIIIName, Guids.NaturalSorceryIIIGuid)
            .AddPrerequisiteCharacterLevel(9)
            .AddPrerequisiteFeature(Guids.DragonRaceGuid)
            .AddPrerequisiteFeature(Guids.DracomorphosisIIGuid)
            .AddPrerequisiteFeature(NaturalSorceryIIIName)
            .SetDisplayName("NaturalSorcery.Name")
            .SetDescription("NaturalSorcery.Description")
            .SetHideNotAvailibleInUI(true)
            .AddSpellbookLevel(spellbook: SpellbookRefs.SorcererSpellbook.ToString())
            .AddSpellbookLevel(spellbook: SpellbookRefs.SorcererSpellbook.ToString())
            .SetIsClassFeature(true)
            .SetRanks(1)
            .AddToGroups(Kingmaker.Blueprints.Classes.FeatureGroup.Feat)
            .Configure();

            FeatureSelectionConfigurator.New(LatentDraconicGiftName, Guids.LatentDraconicGiftGuid)
                            .SetDisplayName("LatentDraconicGift.Name")
                            .SetDescription("LateantDraconicGift.Description")
                            .SetIsClassFeature(true)
                            .AddToGroups(FeatureGroup.Feat)
                            .AddToAllFeatures(
                            NaturalSorceryIName,
                            NaturalSorceryIIName,
                            NaturalSorceryIIIName)
                        .Configure();
        }
    }
}