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

namespace dragonrace.Race
{   
    class Dragon
    {
        private static readonly string DragonFormBuffName = "DragonFormBuffName";
        private static readonly string DragonFormBuffGuid = "2E1F1EA3-C614-409A-AB2C-DEAA31991F3B";

        private static readonly string DragonFormToggle = "DragonFormToggle";
        private static readonly string DragonFormToggleGuid = "421CBCA1-2E07-47F5-9C79-7942DB12240E";
        private static readonly string DragonFormDisplayName = "DragonForm.Name";
        private static readonly string DragonFormDescription = "DragonFormDescription";

        private static readonly string DragonFormFeat = "DragonFormFeat";
        private static readonly string DragonFormFeatGuid = "04A4CC53-BC76-488D-96CC-61ADE6D7C55D";

        private static readonly string DragonRaceName = "Dragon";
        private static readonly string DragonRaceGuid = "9F36923C-7585-444D-BAC0-82DB48390FB7";

        private static readonly string DragonImmunityName = "DragonImmunity";
        private static readonly string DragonImmunityGuid = "0937E6AD-63CB-4F2C-8D5A-799AD1544024";
        private static readonly string DragonImmunityDescription = "DragonImmunity.Description";

        private static readonly string ScaledHideName = "ScaledHide";
        private static readonly string ScaledHideDescription = "ScaledHide.Description";
        private static readonly string ScaledHideGuid = "7E3DC053-D929-4046-B44B-902BCF78025E";

        private static readonly string SuperiorAwarenessName = "SuperiorAwareness";
        private static readonly string SuperiorAwqarenessDescription = "SuperiorAwaremess.Description";
        private static readonly string SuperiorAwarenessGuid = "B47290CE-C762-4EDC-92E8-044A70CFA2A2";

        private static readonly string HumanFormResourceName = "HumanFormResource";
        private static readonly string HumanFormResourceGuid = "D8DE3696-AED5-48DE-812A-FF0B31E43F1E";

        internal const string DragonDisplayName = "Dragon.Name";
        private static readonly string DragonDescription = "Dragon.Description";

        private static readonly string UnfetteredPredatorName = "DragonFormScale";
        private static readonly string UnfetteredPredatorGuid = "9434F8A6-E4B0-4F64-933E-97036FC6FCDF";

        public static void Configure()
        {
            var dragonimmunities =
                FeatureConfigurator.New(DragonImmunityName, DragonImmunityGuid)
                .SetDisplayName("DragonImmunity.Name")
                .SetDescription("DragonImmunity.Description")
                .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.Paralyzed)
                .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.Sleeping)
                .Configure();

            var scaledhide =
                FeatureConfigurator.New(ScaledHideName, ScaledHideGuid)
                .SetDisplayName("ScaledHide.Name")
                .SetDescription("ScaledHide.Description")
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.NaturalArmorForm, stat: StatType.AC, value: 2)
                .Configure();

            var superiorawareness =
                FeatureConfigurator.New(SuperiorAwarenessName, SuperiorAwarenessGuid)
                .SetDisplayName("SuperiorAwareness.Name")
                .SetDescription("SuperiorAwarenessDescription")
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillPerception, value: 2)
                .Configure();

            var unfetteredpredator =
                FeatureConfigurator.New(UnfetteredPredatorName, UnfetteredPredatorGuid)
                .Configure();


            var DragonFormBuffI =
            BuffConfigurator.New(DragonFormBuffName, DragonFormBuffGuid)
                .CopyFrom(BuffRefs.FormOfTheDragonIGoldBuff, typeof(Polymorph))
                .EditComponent<Polymorph>(
                    c =>
                    {
                        c.m_AdditionalLimbs = null;
                        c.m_SecondaryAdditionalLimbs = null;
                        c.Size = Size.Small;
                        c.StrengthBonus = 0;
                        c.ConstitutionBonus = 0;
                        c.NaturalArmor = 2;
                        c.m_KeepSlots = true;
                        c.m_Facts = null;
                    }
                )
                .SetDisplayName(DragonFormDisplayName)
                .SetDescription(DragonFormDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                //.AddSecondaryAttacks(ItemWeaponRefs.Claw1d4.ToString())
                //.AddSecondaryAttacks(ItemWeaponRefs.Claw1d4.ToString())
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d3.ToString())
                //.AddUnitScale(scaleIncreaseCoefficient:0.15F)
                .Configure();


            var dragonformtoggleability =
                 ActivatableAbilityConfigurator.New(DragonFormToggle, DragonFormToggleGuid)
                    //.SetIcon(Icon)
                    .SetDisplayName(DragonFormDisplayName)
                    .SetDescription(DragonFormDescription)
                    .SetBuff(DragonFormBuffI)
                    .SetIsOnByDefault(true)
                    .Configure();

            var DragonFormToggleFeature =
                FeatureConfigurator.New(DragonFormFeat, DragonFormFeatGuid)
                .AddFacts(new() { dragonformtoggleability })
                .SetDisplayName(DragonFormDisplayName)
                .SetDescription(DragonFormDescription)
                .Configure();

            var race =
            RaceConfigurator.New(DragonRaceName, DragonRaceGuid)
                .CopyFrom(RaceRefs.HumanRace)
                .SetDisplayName(DragonDisplayName)
                .SetDescription(DragonDescription)
                .SetSelectableRaceStat(false)
                .SetFeatures(DragonFormToggleFeature, dragonimmunities, superiorawareness)
                //.AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: Kingmaker.EntitySystem.Stats.StatType.Constitution, value: 2)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: Kingmaker.EntitySystem.Stats.StatType.Dexterity, value: -2)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: Kingmaker.EntitySystem.Stats.StatType.Charisma, value: 2)
                .SetRaceId(Kingmaker.Blueprints.Race.Halfling)
                .Configure();

            var raceRef = race.ToReference<BlueprintRaceReference>();
            ref var races = ref BlueprintRoot.Instance.Progression.m_CharacterRaces;

            var length = races.Length;
            Array.Resize(ref races, length + 1);
            races[length] = raceRef;
        }
    }
}
