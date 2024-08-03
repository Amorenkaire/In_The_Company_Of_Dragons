using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UI.MVVM._PCView.CharGen.Phases.Race;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Customization;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.UI.Common;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UI.ServiceWindow.CharacterScreen;
using System.ComponentModel;
using UnityEngine;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Items.Weapons;
using UnityEngine.XR;
using System.Windows.Markup;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using dragonrace.Utility;
using Kingmaker.RuleSystem;

namespace dragonrace.Race
{   
    class Dragon
    {
        private static readonly string DragonRace = "Dragon";
        //private static readonly string DragonRaceGuid = "9F36923C-7585-444D-BAC0-82DB48390FB7";

        private static readonly string DragonImmunityName = "DragonImmunity";
        private static readonly string DragonImmunityGuid = "0937E6AD-63CB-4F2C-8D5A-799AD1544024";

        private static readonly string SuperiorAwarenessName = "SuperiorAwareness";
        private static readonly string SuperiorAwarenessGuid = "B47290CE-C762-4EDC-92E8-044A70CFA2A2";

        internal const string DragonDisplayName = "Dragon.Name";
        private static readonly string DragonDescription = "Dragon.Description";

        private static readonly string UnfetteredPredatorName = "UnfetteredPredator";
        private static readonly string UnfetteredPredatorBuffName = "UnfetteredPredatorBuff";
        

        //Heritages
        private static readonly string DragonHeritageSelectionName = "DragonHeritageSelection";
        private static readonly string DragonHeritageSelectionGuid = "FD830208-547B-4EC4-8C66-70AEF9C24016";


        //private static readonly string DragonHeritageGoldGuid = "3EC8FC61-E3AA-49F6-99CA-0BFD49725737";

        public static void Configure()
        {
            Heritages.DragonGold.Configure();

                var heritageGold = BlueprintTool.Get<BlueprintFeature>(Guids.DragonGoldGuid);

                Blueprint<BlueprintFeatureReference>[] heritageList = new Blueprint<BlueprintFeatureReference>[]
                {
                    heritageGold
                };

                var heritageSelection =
                    FeatureSelectionConfigurator.New(DragonHeritageSelectionName, DragonHeritageSelectionGuid)
                    .SetDisplayName("Dragon.HeritageSelection.Name")
                    .SetDescription("DragonHeritageGold.Description")
                    .AddToGroups(FeatureGroup.Racial)
                    .SetAllFeatures(heritageList)
                    //.SetIcon()
                    .Configure();

            var dragonimmunities =
                FeatureConfigurator.New(DragonImmunityName, DragonImmunityGuid)
                .SetDisplayName("DragonImmunity.Name")
                .SetDescription("DragonImmunity.Description")
                .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.Paralyzed)
                .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.Sleeping)
                .Configure();

            var superiorawareness =
                FeatureConfigurator.New(SuperiorAwarenessName, SuperiorAwarenessGuid)
                .SetDisplayName("SuperiorAwareness.Name")
                .SetDescription("SuperiorAwareness.Description")
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillPerception, value: 2)
                .Configure();

            var unfetteredpredatorbuff =
                BuffConfigurator.New(UnfetteredPredatorBuffName, Guids.UnfetteredPredatorBuffGuid)
                .SetDisplayName("UnfetteredPredator.Name")
                .SetDescription("UnfetteredPredator.Description")
                .SetIcon(ItemWeaponRefs.Claw1d10.Reference.Get().Icon)
                .AddAttackBonus(-2)
                .Configure();

            var unfetteredpredator =
                FeatureConfigurator.New(UnfetteredPredatorName, Guids.UnfetteredPredatorGuid)
                .SetDisplayName("UnfetteredPredator.Name")
                .SetDescription("UnfetteredPredator.Description")
                .SetIcon(ItemWeaponRefs.Claw1d10.Reference.Get().Icon)
                //.AddArmorCheckPenaltyIncrease(-2) Added to the dragonform buffs so it only applies while in dragon form.
                .AddBuffOnLightOrNoArmor(
                    buff: unfetteredpredatorbuff)
                .Configure();

            //var dextrousclaws =
               // FeatureConfigurator.New(DextrousClawsName, Guids.DextrousClawsGuid)
                //.SetDisplayName("DextrousClaws.Name")
                //.SetDescription("DextrousClaws.Description")
                //.Configure();

            var race =
            RaceConfigurator.New(DragonRace, Guids.DragonRaceGuid)
                .CopyFrom(RaceRefs.HumanRace)
                .SetDisplayName(DragonDisplayName)
                .SetDescription(DragonDescription)
                .SetSelectableRaceStat(false)
                .SetFeatures(heritageSelection, dragonimmunities, superiorawareness, unfetteredpredator)
                //.AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: Kingmaker.EntitySystem.Stats.StatType.Constitution, value: 2)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: Kingmaker.EntitySystem.Stats.StatType.Dexterity, value: -2)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: Kingmaker.EntitySystem.Stats.StatType.Charisma, value: 2)
                .SetRaceId(Kingmaker.Blueprints.Race.HalfElf)
                .Configure(delayed: true);

            var raceRef = race.ToReference<BlueprintRaceReference>();
            ref var races = ref BlueprintRoot.Instance.Progression.m_CharacterRaces;

            var length = races.Length;
            Array.Resize(ref races, length + 1);
            races[length] = raceRef;
        }
    }
}
