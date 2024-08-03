using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using dragonrace.Race.Heritages;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dragonrace.Race;
using dragonrace.Utility;
using Kingmaker.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Enums;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Unity.Burst.Intrinsics;

namespace dragonrace.Archetypes
{
    class DragonHeroArchetypes
    {
        private const string DragonHeroProgName = "DragonHero";
        private const string DragonHeroProgGuid = "B1BC8661-55E3-4BB7-8899-C9B97C99AEA1";

        private const string DragonHeroProgDisplayName = "DragonHeroProg.Name";
        private const string DragonHeroProgDescription = "DragonHeroProgDescription";

        private const string DragonHeroProgFeatName = "DragonHeroProgFeat";
        private const string DragonHeroProgFeatGuid = "485C9FAA-B9AC-4469-AAB9-F03601FFC957";

        private const string DSGoldI = "DSGold";
        private const string DSGoldGuidI = "55622C45-FD5E-493F-BCD1-15DE5EECD118";
        private const string DSGoldII = "DSGoldII";
        private const string DSGoldGuidII = "9DC5759D-CEC0-48E6-8509-781F0093F88B";
        private const string DSGoldIII = "DSGoldIII";
        private const string DSGoldGuidIII = "EEE654EF-8DCD-40D7-BF38-4A038C8B6D0B";
        private const string DSGoldIV = "DSGoldIV";
        private const string DSGoldGuidIV = "152CCE94-6601-41F2-B59E-7A1858721B6C";

        private const string DracomorphosisIName = "DracomorphosisI";
        private const string DracomorphosisIIName = "DracomorphosisII";
        private const string DracomorphosisIIIName = "DracomorphosisIII";
        private const string DracomorphosisIVName = "DracomorphosisIV";

        private const string PowerfulspellcastingIName = "PowerfulSpellcastingI";
        private const string PowerfulspellcastingIIName = "PowerfulSpellcastingII";
        private const string PowerfulspellcastingIIIName = "PowerfulSpellcastingIII";
        private const string PowerfulspellcastingIVName = "PowerfulSpellcastingIV";

        //Archetype Strings
        internal const string ArchetypeDisplayName = "DragonHero.Name";
        //private const string ArchetypeDescription = "DragonHero.Description";

        private const string DHPaladinName = "DHPaladin";
        private const string DHPaladinDisplayName = "DHPaladin.Name";
        private const string DHDescription = "DHDescription";
        private const string DHPaladinGuid = "98069190-D027-466C-A814-61EF89EB98BD";

        private const string DHSmiteFeat = "DHSmite";
        private const string DHSmiteFeatGuid = "345B0A20-DBC6-4E85-B6A6-1308F6A5316E";
        private const string DHSmiteDescription = "DHSmiteDescription";
        private const string DHSmiteAbility = "DHSmiteAbility";
        private const string DHSmiteAbilityGuid = "3B7FFBF8-94CA-4A97-8262-9C32786905BA";

        private const string DHMonkName = "DHMonk";

        private const string Spellbook = "DHSorc.Spellbook";
        private const string SpellsPerDay = "SpellsPerDay";
        private const string DHSorcererName = "DHSorcerer";
        private const string DHSorcGoldFeatName = "DHSorcGoldFeat";
        private const string DragonDiminishedCastingName = "DragonDiminishedCasting";


        private const string DHSorcererArcaneTrickster = "DHSorcerer.ArcaneTrickster";
        private const string DHSorcererDragonDisciple = "DHSorcerer.DragonDisciple";
        private const string DHSorcererEldritchKnight = "DHSorcerer.EldritchKnight";
        private const string DHSorcererHellknightSignifier = "DHSorcerer.HellknightSignifier";
        private const string DHSorcererLoremaster = "DHSorcerer.Loremaster";
        private const string DHSorcererMysticTheurge = "DHSorcerer.MysticTheurge";

        private const string DHEldritchKnightName = "DHEldritchKnight";
        private const string DHDragonDiscipleName = "DHDragonDisciple";


      
        public static void Configure()
        {

            var dragonheroprogression =
            ProgressionConfigurator.New(DragonHeroProgName, DragonHeroProgGuid);

            var DragonEssenceGoldI =
                FeatureConfigurator.New(DSGoldI, DSGoldGuidI)
                .SetDisplayName("DragonEssenceGold.Name")
                .SetDescription("DragonEssenceGoldDescription")
                .AddResistEnergyContext(type: Kingmaker.Enums.Damage.DamageEnergyType.Fire, value: ContextValues.Rank())
                //.AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { DragonHeroProgName }).WithCustomProgression((4, 5), (9, 10), (14, 20), (15, 30)))
                .AddResistEnergy(type: Kingmaker.Enums.Damage.DamageEnergyType.Fire, value: 5)
                .Configure();

            var DragonEssenceGoldII =
                FeatureConfigurator.New(DSGoldII, DSGoldGuidII)
                .SetDisplayName("DragonEssenceGold.Name")
                .SetDescription("DragonEssenceGoldDescription")
                .AddResistEnergy(type: Kingmaker.Enums.Damage.DamageEnergyType.Fire, value: 10)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetHideInUI(true)
                .Configure();

            var DragonEssenceGoldIII =
                 FeatureConfigurator.New(DSGoldIII, DSGoldGuidIII)
                .SetDisplayName("DragonEssenceGold.Name")
                .SetDescription("DragonEssenceGoldDescription")
                .AddResistEnergy(type: Kingmaker.Enums.Damage.DamageEnergyType.Fire, value: 20)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetHideInUI(true)
                .Configure();

            var DragonEssenceGoldIV =
                 FeatureConfigurator.New(DSGoldIV, DSGoldGuidIV)
                .SetDisplayName("DragonEssenceGold.Name")
                .SetDescription("DragonEssenceGoldDescription")
                .AddResistEnergy(type: Kingmaker.Enums.Damage.DamageEnergyType.Fire, value: 30)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetHideInUI(true)
                .Configure();

            var DracomorphosisI =
                FeatureConfigurator.New(DracomorphosisIName, Guids.DracomorphosisIGuid)
                .SetDisplayName("DracomorphosisI.Name")
                .SetDescription("DracomorphosisIDescription")
                .Configure();

            var DracomorphosisII =
                FeatureConfigurator.New(DracomorphosisIIName, Guids.DracomorphosisIIGuid)
                .SetDisplayName("DracomorphosisII.Name")
                .SetDescription("DracomorphosisIIDescription")
                .Configure();

            var DracomorphosisIII =
                FeatureConfigurator.New(DracomorphosisIIIName, Guids.DracomorphosisIIIGuid)
                .SetDisplayName("DracomorphosisIII.Name")
                .SetDescription("DracomorphosisIIIDescription")
                .Configure();

            var DracomorphosisIV =
                FeatureConfigurator.New(DracomorphosisIVName, Guids.DracomorphosisIVGuid)
                .SetDisplayName("DracomorphosisIV.Name")
                .SetDescription("DracomorphosisIVDescription")
                .Configure();

            var PowerfulSpellcastingI =
                FeatureConfigurator.New(PowerfulspellcastingIName, Guids.PowerfulSpellcastingIGuid)
                .SetDisplayName("PowerfulSpellcasting.Name")
                .SetDescription("PowerfulSpellcasting.Description")
                .AddSpellPenetrationBonus(value: 1)
                .Configure();

            var PowerfulSpellcastingII =
                FeatureConfigurator.New(PowerfulspellcastingIIName, Guids.PowerfulSpellcastingIIGuid)
                .SetDisplayName("PowerfulSpellcasting.Name")
                .SetDescription("PowerfulSpellcasting.Description")
                .AddSpellPenetrationBonus(value: 1)
                .Configure();

            var PowerfulSpellcastingIII =
                FeatureConfigurator.New(PowerfulspellcastingIIIName, Guids.PowerfulSpellcastingIIIGuid)
                .SetDisplayName("PowerfulSpellcasting.Name")
                .SetDescription("PowerfulSpellcasting.Description")
                .AddSpellPenetrationBonus(value: 1)
                .Configure();

            var PowerfulSpellcastingIV =
                FeatureConfigurator.New(PowerfulspellcastingIVName, Guids.PowerfulSpellcastingIVGuid)
                .SetDisplayName("PowerfulSpellcasting.Name")
                .SetDescription("PowerfulSpellcasting.Description")
                .AddSpellPenetrationBonus(value: 1)
                .Configure();

            var DHProg =
                LevelEntryBuilder.New();
            DHProg
                .AddEntry(level: 1, DragonEssenceGoldI)
                .AddEntry(level: 5, DragonEssenceGoldII, DracomorphosisI, PowerfulSpellcastingI)
                .AddEntry(level: 10, DragonEssenceGoldIII, DracomorphosisII, PowerfulSpellcastingII)
                .AddEntry(level: 15, DragonEssenceGoldIV, DracomorphosisIII, PowerfulSpellcastingIII)
                .AddEntry(level: 20, DracomorphosisIV, PowerfulSpellcastingIV)
                ;

            //TODO: Create copied version which reduces Smite Damage to Paladin level -3.
            //FeatureConfigurator.New(DHSmiteFeat, DHSmiteFeatGuid)
            //    .CopyFrom(FeatureRefs.SmiteEvilFeature.ToString(), typeof(AddFacts), typeof(AddAbilityResources))
            //    .SetDescription(DHSmiteDescription)
            //    .Configure();

            //AbilityConfigurator.New(DHSmiteAbility, DHSmiteAbilityGuid)
            //    .CopyFrom(AbilityRefs.SmiteEvilAbility.ToString(), typeof(AbilityEffectRunAction), typeof(ContextCalculateSharedValue), typeof(ContextRankConfig), typeof(AbilityResourceLogic), typeof(AbilitySpawnFx), typeof(AbilityCasterAlignment), typeof(AbilityTargetIsAlly)))
            //    .Configure();
            var paladinremove = LevelEntryBuilder.New();
            paladinremove
                .AddEntry(level: 1, FeatureRefs.SmiteEvilFeature.ToString())
                .AddEntry(level: 3, FeatureSelectionRefs.SelectionMercy.ToString())
                .AddEntry(level: 4, FeatureRefs.SmiteEvilAdditionalUse.ToString())
                .AddEntry(level: 5, FeatureSelectionRefs.PaladinDivineBondSelection.ToString())
                .AddEntry(level: 9, FeatureSelectionRefs.SelectionMercy.ToString())
                .AddEntry(level: 11, FeatureRefs.AuraOfJusticeFeature.ToString())
                .AddEntry(level: 15, FeatureSelectionRefs.SelectionMercy.ToString())
                .AddEntry(level: 20, FeatureRefs.HolyChampion.ToString());

            var DHPaladin =
                ArchetypeConfigurator.New(DHPaladinName, DHPaladinGuid, CharacterClassRefs.PaladinClass)
                .AddPrerequisiteFeature(Guids.DragonRaceGuid)
                .SetLocalizedName(DHPaladinDisplayName)
                .SetLocalizedDescription(DragonHeroProgDescription)
                .SetBuildChanging(false)
                .SetRemoveSpellbook(false)
                .AddToRemoveFeatures(paladinremove.GetEntries())
                .AddToAddFeatures(1, DragonHeroProgName.ToString())
                .AddToAddFeatures(4, FeatureRefs.SmiteEvilFeature.ToString())
                .SetReplaceStartingEquipment(false)
                .SetHiddenInUI(false)
                .Configure();

            var sorcererremove = LevelEntryBuilder.New();
            sorcererremove
            .AddEntry(level: 1, FeatureSelectionRefs.SorcererBloodlineSelection.ToString())
            .AddEntry(level: 7, FeatureSelectionRefs.SorcererFeatSelection.ToString())
            .AddEntry(level: 13, FeatureSelectionRefs.SorcererFeatSelection.ToString())
            .AddEntry(level: 19, FeatureSelectionRefs.SorcererFeatSelection.ToString());

            var DragonDiminishedCasting =
                FeatureConfigurator.New(DragonDiminishedCastingName, Guids.DragonDiminishedCastingGuid)
                .SetDisplayName("DragonDiminishedCasting.Name")
                .SetDescription("DragonDiminishedCasting.Description")
                //.AddSpellsPerDay(
                //    amount: -1,
                //    levels: [
                //        1, 2, 3, 4, 5, 6, 7, 8, 9
                //        ]
                //)
                .Configure();

           // SpellsTableConfigurator.New(SpellsPerDay, Guids.SorcSpellsPerDayGuid).Configure();
            
            //var spellbook =
            //SpellbookConfigurator.New(DHSorcSpellBookName, Guids.DHSorcSpellBookGuid)
            //.SetName("DHSorcerer.Name")
            //Make spells per day one less!
            //.SetSpellsPerDay(GetSpellSlots())
            //.SetSpellsKnown(SpellsTableRefs.SorcererSpellsKnownTable.ToString())
            //.SetSpellList(SpellListRefs.WizardSpellList.ToString())
            //.SetCharacterClass(CharacterClassRefs.SorcererClass.ToString())
            //.SetCastingAttribute(Kingmaker.EntitySystem.Stats.StatType.Charisma)
            //.SetSpontaneous(true)
            //.SetIsArcane(true)
            //.Configure();
            
            Bloodlines.Configure();

            var DHSorcerer =
                ArchetypeConfigurator.New(DHSorcererName, Guids.DHSorcererGuid, CharacterClassRefs.SorcererClass)
                .AddPrerequisiteFeature(Guids.DragonRaceGuid)
                .SetLocalizedName("DHSorcerer.Name")
                .SetLocalizedDescription("DHSorcerer.Description")
                .SetBuildChanging(false)
                .SetReplaceSpellbook(CreateSpellbook())
                .AddToRemoveFeatures(sorcererremove.GetEntries())
                .AddToAddFeatures(1, DragonHeroProgName.ToString(), DragonDiminishedCasting, Guids.GoldDragonSorcererGuid)
                .SetReplaceStartingEquipment(false)
                .SetHiddenInUI(false)
                .Configure();

            var monkremove = LevelEntryBuilder.New();
            monkremove
            .AddEntry(level: 1, FeatureRefs.MonkFlurryOfBlowstUnlock.ToString(), FeatureSelectionRefs.MonkBonusFeatSelectionLevel1.ToString(), FeatureRefs.MonkACBonusUnlock.ToString())
            .AddEntry(level: 2, FeatureSelectionRefs.MonkBonusFeatSelectionLevel1.ToString())
            .AddEntry(level: 3, FeatureRefs.KiPowerFeature.ToString())
            .AddEntry(level: 4, FeatureRefs.StillMind.ToString(), FeatureSelectionRefs.MonkKiPowerSelection.ToString(), FeatureRefs.StunningFistFatigueFeature.ToString())
            .AddEntry(level: 6, FeatureSelectionRefs.MonkBonusFeatSelectionLevel6.ToString(), FeatureSelectionRefs.MonkKiPowerSelection.ToString())
            .AddEntry(level: 8, FeatureSelectionRefs.MonkKiPowerSelection.ToString(), FeatureRefs.StunningFistSickenedFeature.ToString())
            .AddEntry(level: 10, FeatureSelectionRefs.MonkBonusFeatSelectionLevel10.ToString(), FeatureSelectionRefs.MonkKiPowerSelection.ToString())
            .AddEntry(level: 11, FeatureRefs.MonkFlurryOfBlowstLevel11Unlock.ToString())
            .AddEntry(level: 12, FeatureSelectionRefs.MonkKiPowerSelection.ToString())
            .AddEntry(level: 14, FeatureSelectionRefs.MonkBonusFeatSelectionLevel10.ToString(), FeatureSelectionRefs.MonkKiPowerSelection.ToString())
            .AddEntry(level: 16, FeatureSelectionRefs.MonkKiPowerSelection.ToString())
            .AddEntry(level: 18, FeatureSelectionRefs.MonkBonusFeatSelectionLevel10.ToString(), FeatureSelectionRefs.MonkKiPowerSelection.ToString())
            .AddEntry(level: 20, FeatureRefs.KiPerfectSelfFeature.ToString(), FeatureSelectionRefs.MonkKiPowerSelection.ToString())
            ;

            var DHMonk =
                ArchetypeConfigurator.New(DHMonkName, Guids.DHMonkGuid, CharacterClassRefs.MonkClass)
                .AddPrerequisiteFeature(Guids.DragonRaceGuid)
                .SetLocalizedName("DHMonk.Name")
                .SetLocalizedDescription("DHMonk.Description")
                .SetBuildChanging(false)
                .SetRemoveSpellbook(false)
                .AddToRemoveFeatures(monkremove.GetEntries())
                .AddToAddFeatures(1, DragonHeroProgName.ToString(), FeatureRefs.ScaledFistACBonusUnlock.ToString())
                .AddToAddFeatures(2, FeatureSelectionRefs.ScaledFistBonusFeatSelectionLevel1.ToString())
                .AddToAddFeatures(3, FeatureSelectionRefs.ScaledFistDragonSelection.ToString(), FeatureRefs.ScaledFistDraconicMettle.ToString(), FeatureRefs.ScaledFistPowerFeature.ToString())
                .AddToAddFeatures(4, FeatureSelectionRefs.ScaledFistKiPowerSelection.ToString(), FeatureRefs.ScaledFistStunningFistFatigueFeature.ToString())
                .AddToAddFeatures(6, FeatureSelectionRefs.ScaledFistBonusFeatSelectionLevel6.ToString(), FeatureSelectionRefs.ScaledFistKiPowerSelection.ToString())
                .AddToAddFeatures(8, FeatureSelectionRefs.ScaledFistKiPowerSelection.ToString(), FeatureRefs.ScaledFistStunningFistSickenedFeature.ToString())
                .AddToAddFeatures(10, FeatureSelectionRefs.ScaledFistBonusFeatSelectionLevel10.ToString(), FeatureSelectionRefs.ScaledFistKiPowerSelection.ToString())
                .AddToAddFeatures(14, FeatureSelectionRefs.ScaledFistKiPowerSelection.ToString())
                .AddToAddFeatures(16, FeatureSelectionRefs.ScaledFistKiPowerSelection.ToString())
                .AddToAddFeatures(18, FeatureSelectionRefs.ScaledFistBonusFeatSelectionLevel10.ToString(), FeatureSelectionRefs.ScaledFistKiPowerSelection.ToString())
                .AddToAddFeatures(20, FeatureSelectionRefs.ScaledFistKiPowerSelection.ToString())
                .SetReplaceStartingEquipment(false)
                .SetHiddenInUI(false)
                .Configure();

            var EKremove = LevelEntryBuilder.New();
            EKremove
                .AddEntry(1, FeatureSelectionRefs.EldritchKnightFeatSelection.ToString())
                .AddEntry(9, FeatureSelectionRefs.EldritchKnightFeatSelection.ToString())
                ;

            var DHEldritchKnight =
                ArchetypeConfigurator.New(DHEldritchKnightName, Guids.DHEldritchKnightGuid, CharacterClassRefs.EldritchKnightClass)
                .AddPrerequisiteFeature(Guids.DragonRaceGuid)
                .SetLocalizedName("DHEldritchKnight.Name")
                .SetLocalizedDescription("DHEldritchKnight.Description")
                .AddToRemoveFeatures(EKremove.GetEntries())
                .AddToAddFeatures(1, DragonHeroProgName.ToString())
                .Configure();

            var Dragondiscipleremove = LevelEntryBuilder.New();
            Dragondiscipleremove
                .AddEntry(1, FeatureSelectionRefs.BloodOfDragonsSelection.ToString())
                .AddEntry(2, FeatureSelectionRefs.BloodlineDraconicFeatSelection.ToString(), FeatureRefs.DragonDiscipleBiteFeatureFirst.ToString())
                .AddEntry(3, FeatureRefs.DragonDiscipleBreathFeature.ToString())
                .AddEntry(6, FeatureRefs.DragonDiscipleBiteFeatureSecond.ToString())
                .AddEntry(7, FeatureRefs.DragonDiscipleFormFeatureFirst.ToString())
                .AddEntry(9, FeatureRefs.DragonDiscipleFormFeatureWings.ToString())
                .AddEntry(10, FeatureRefs.DragonDiscipleFormFeatureUltimate.ToString())
                ;

            var DHDragonDisciple =
                ArchetypeConfigurator.New(DHDragonDiscipleName, Guids.DHDragonDiscipleGuid, CharacterClassRefs.DragonDiscipleClass)
                .AddPrerequisiteFeature(Guids.DragonRaceGuid)
                .SetLocalizedName("DHDragonDisciple.Name")
                .SetLocalizedDescription("DHDragonDisciple.Description")
                .AddToRemoveFeatures(Dragondiscipleremove.GetEntries())
                .AddToAddFeatures(1, DragonHeroProgName.ToString())
                .Configure();

            dragonheroprogression
                .SetDisplayName(DragonHeroProgName)
                .SetDescription(DragonHeroProgDescription)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(true)
                .SetForAllOtherClasses(false)
                .AddToArchetypes(DHMonkName, DHPaladinName, DHSorcererName, DHEldritchKnightName, DHDragonDiscipleName)
                .SetLevelEntries(DHProg)
                .Configure();


        }
        private static BlueprintSpellbook CreateSpellbook()
        {
            var spellbook = SpellbookConfigurator.New(Spellbook, Guids.DHSorcSpellBookGuid)
              .SetName("DHSorcerer.Name")
              .SetSpellsPerDay(GetSpellSlots())
              .SetSpellsKnown(SpellsTableRefs.SorcererSpellsKnownTable.ToString())
              .SetSpellList(SpellListRefs.WizardSpellList.ToString())
              .SetCharacterClass(CharacterClassRefs.SorcererClass.ToString())
              .SetCastingAttribute(Kingmaker.EntitySystem.Stats.StatType.Charisma)
              .SetSpontaneous(true)
              .SetIsArcane(true)
              .Configure();

            var sorcerer = CharacterClassRefs.SorcererClass.ToString();

            // Update references to the sorcerer spellbook to include the new spellbook
            FeatureConfigurator.For(FeatureRefs.DLC3_ArcaneModFeature)
              .EditComponent<AddAbilityUseTrigger>(
                c =>
                  c.m_Spellbooks = CommonTool.Append(c.m_Spellbooks, spellbook.ToReference<BlueprintSpellbookReference>()))
              .Configure();

            // Arcane Trickster

            ArchetypeConfigure.ConfigureArchetypeSpellbookReplacement(
              characterClass: sorcerer,
              archetype: Guids.DHSorcererGuid,
              baseReplacement: FeatureReplaceSpellbookRefs.ArcaneTricksterSorcerer.ToString(),
              sourceReplacement: FeatureReplaceSpellbookRefs.ArcaneTricksterSorcerer.ToString(),
              replacementName: DHSorcererArcaneTrickster,
              replacementGuid: Guids.DHSorcererArcaneTrickster,
              spellbook,
              replacementSelection: FeatureSelectionRefs.ArcaneTricksterSpellbookSelection.ToString());

            // Dragon Disciple
            ArchetypeConfigure.ConfigureArchetypeSpellbookReplacement(
              characterClass: sorcerer,
              archetype: Guids.DHSorcererGuid,
              baseReplacement: FeatureReplaceSpellbookRefs.DragonDiscipleSorcerer.ToString(),
              sourceReplacement: FeatureReplaceSpellbookRefs.DragonDiscipleSorcerer.ToString(),
              replacementName: DHSorcererDragonDisciple,
              replacementGuid: Guids.DHSorcererDragonDisciple,
              spellbook,
              replacementSelection: FeatureSelectionRefs.DragonDiscipleSpellbookSelection.ToString());

            // Eldritch Knight
            ArchetypeConfigure.ConfigureArchetypeSpellbookReplacement(
              characterClass: sorcerer,
              archetype: Guids.DHSorcererGuid,
              baseReplacement: FeatureReplaceSpellbookRefs.EldritchKnightSorcerer.ToString(),
              sourceReplacement: FeatureReplaceSpellbookRefs.EldritchKnightSorcerer.ToString(),
              replacementName: DHSorcererEldritchKnight,
              replacementGuid: Guids.DHSorcererEldritchKnight,
              spellbook,
              replacementSelection: FeatureSelectionRefs.EldritchKnightSpellbookSelection.ToString());

            // Hellknight Signifier
            ArchetypeConfigure.ConfigureArchetypeSpellbookReplacement(
              characterClass: sorcerer,
              archetype: Guids.DHSorcererGuid,
              baseReplacement: FeatureReplaceSpellbookRefs.HellknightSigniferSorcerer.ToString(),
              sourceReplacement: FeatureReplaceSpellbookRefs.HellknightSigniferSorcerer.ToString(),
              replacementName: DHSorcererHellknightSignifier,
              replacementGuid: Guids.DHSorcererHellknightSignifier,
              spellbook,
              replacementSelection: FeatureSelectionRefs.HellknightSigniferSpellbook.ToString());

            // Loremaster
            ArchetypeConfigure.ConfigureArchetypeSpellbookReplacement(
              characterClass: sorcerer,
              archetype: Guids.DHSorcererGuid,
              baseReplacement: FeatureReplaceSpellbookRefs.LoremasterSorcerer.ToString(),
              sourceReplacement: FeatureReplaceSpellbookRefs.LoremasterSorcerer.ToString(),
              replacementName: DHSorcererLoremaster,
              replacementGuid: Guids.DHSorcererLoremaster,
              spellbook,
              replacementSelection: FeatureSelectionRefs.LoremasterSpellbookSelection.ToString());
            ArchetypeConfigure.AddToLoremasterSecrets(
              Guids.DHSorcererLoremaster,
              ParametrizedFeatureRefs.LoremasterClericSecretSorcerer.ToString(),
              ParametrizedFeatureRefs.LoremasterDruidSecretSorcerer.ToString(),
              ParametrizedFeatureRefs.LoremasterWizardSecretSorcerer.ToString());

            // MysticTheurge
            ArchetypeConfigure.ConfigureArchetypeSpellbookReplacement(
              characterClass: sorcerer,
              archetype: Guids.DHSorcererGuid,
              baseReplacement: FeatureReplaceSpellbookRefs.MysticTheurgeSorcerer.ToString(),
              sourceReplacement: FeatureReplaceSpellbookRefs.MysticTheurgeSorcerer.ToString(),
              replacementName: DHSorcererMysticTheurge,
              replacementGuid: Guids.DHSorcererMysticTheurge,
              spellbook,
              replacementSelection: FeatureSelectionRefs.MysticTheurgeArcaneSpellbookSelection.ToString());

            return spellbook;
        }

        // Generates the diminished spell slots
        private static BlueprintSpellsTable GetSpellSlots()
        {
            var sorcSpellSlots = SpellsTableRefs.SorcererSpellsDailyTable.Reference.Get();
            var levelEntries =
              sorcSpellSlots.Levels.Select(
                l =>
                {
                    var count = l.Count.Select(c => Math.Max(0, c - 1)).ToArray();
                    return new SpellsLevelEntry { Count = count };
                });
            return SpellsTableConfigurator.New(SpellsPerDay, Guids.SorcSpellsPerDayGuid)
              .SetLevels(levelEntries.ToArray())
              .Configure();
        }
    }
}
