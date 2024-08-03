using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dragonrace.Utility;
using dragonrace.Archetypes;
using Kingmaker.Enums;
using System.Configuration;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.FactLogic;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using UnityEngine.ProBuilder.MeshOperations;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints.Root;
using Kingmaker.ResourceLinks;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Visual;
using static Kingmaker.Visual.CharacterSystem.CharacterStudio;
using Kingmaker.Visual.Animation;
using Kingmaker.Blueprints.JsonSystem.Converters;
using Kingmaker.Designers.Mechanics.Facts;
using System.Runtime.Remoting;
using BlueprintCore.Conditions.Builder.BasicEx;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Buffs.Components;

namespace dragonrace.Race.Heritages
{
    class DragonGold
    {
        private static readonly string DragonHeritageGoldGuid = "497EF9CF-C09B-44EC-8FB5-6E11C4F15A1D";

        private static readonly string DragonFormGoldToggle = "DragonFormGoldToggle";
        private static readonly string DragonFormGoldToggleGuid = "421CBCA1-2E07-47F5-9C79-7942DB12240E";

        private static readonly string DragonFormGoldFeat = "DragonFormGoldFeat";
        private static readonly string DragonFormGoldFeatGuid = "04A4CC53-BC76-488D-96CC-61ADE6D7C55D";

        private static readonly string DragonFormGoldBuffIName = "DragonFormGoldBuffIName";
        private static readonly string DragonFormGoldBuffIIName = "DragonFormGoldBuffIIName";
        private static readonly string DragonFormGoldBuffIIIName = "DragonFormGoldBuffIIIName";
        private static readonly string DragonFormGoldBuffIVName = "DragonFormGoldBuffIVName";
        private static readonly string DragonFormGoldBuffVName = "DragonFormGoldBuffVName";

        private static readonly string DragonShrinkName = "DragonShrink";
        private static readonly string DragonFormGoldBuffBaseName = "applyDragonFormGoldBuffName";

        private static readonly string DragonGoldName = "DragonHeritageGold";
        // private static readonly string DragonHeritageGoldGuid = "3EC8FC61-E3AA-49F6-99CA-0BFD49725737";
        public static void Configure()
        {
            var DragonFormGoldBuffI =
            BuffConfigurator.New(DragonFormGoldBuffIName, Guids.DragonFormGoldBuffIGuid)
            .AddPolymorph(
                prefab: "7a47bc6dbd2e2014aa5be8519e93a02e",
                specialDollType: SpecialDollType.None,
                keepSlots: true,
                size: Size.Small,
                useSizeAsBaseForDamage: true,
                naturalArmor: 2,
                mainHand: null,
                offHand: null,
                allowDamageTransfer: false,
                additionalLimbs: [
                    ItemWeaponRefs.Bite1d6.ToString(),
                    //ItemWeaponRefs.Claw1d4.ToString(),
                    //ItemWeaponRefs.Claw1d4.ToString()
                    ],
                //enterTransition: null,
                //exitTransition: null,
                transitionExternal: UnityObjectConverter.AssetList.Get("5687f6801ca6ea848a8d48298d892a8e", 11400000)
                    as PolymorphTransitionSettings,
                silentCaster: true

             )
            .SetDisplayName("DragonForm.Name")
            .SetDescription("DragonFormI.Description")
            .AddArmorCheckPenaltyIncrease(-2)
            .SetIcon(AbilityRefs.FormOfTheDragonIGold.Reference.Get().Icon)
            .AddReplaceSourceBone("a4254468ed4a410d9fd5785b7565e2e5")
            .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d4.ToString())
            .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.NaturalSpell)
            .Configure();

            var DragonFormGoldBuffII =
                BuffConfigurator.New(DragonFormGoldBuffIIName, Guids.DragonFormGoldBuffIIGuid)
                //.CopyFrom(BuffRefs.FormOfTheDragonIGoldBuff)
                .AddPolymorph(
                    prefab: "7a47bc6dbd2e2014aa5be8519e93a02e",
                    specialDollType: SpecialDollType.None,
                    keepSlots: true,
                    size: Size.Medium,
                    useSizeAsBaseForDamage: false,
                    strengthBonus: 2,
                    naturalArmor: 4,
                    mainHand: null,
                    offHand: null,
                    allowDamageTransfer: false,
                    additionalLimbs: [ItemWeaponRefs.Bite1d8.ToString()],
                    secondaryAdditionalLimbs: [
                        ItemWeaponRefs.Wing1d4.ToString(),
                        ItemWeaponRefs.Wing1d4.ToString()
                    ],
                    transitionExternal: UnityObjectConverter.AssetList.Get("5687f6801ca6ea848a8d48298d892a8e", 11400000)
                        as PolymorphTransitionSettings,
                    silentCaster: true
                )
                .SetDisplayName("DragonForm.Name")
                .SetDescription("DragonFormII.Description")
                .AddArmorCheckPenaltyIncrease(-2)
                .SetIcon(AbilityRefs.FormOfTheDragonIGold.Reference.Get().Icon)
                .AddReplaceSourceBone("a4254468ed4a410d9fd5785b7565e2e5")
                .AddBuffMovementSpeed(value: 10, descriptor: ModifierDescriptor.Racial)
                .AddACBonusAgainstAttacks(againstMeleeOnly: true, againstRangedOnly: false, onlySneakAttack: false, notTouch: false, isTouch: false, onlyAttacksOfOpportunity: false, value: 3, descriptor: ModifierDescriptor.Dodge)
                .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.DifficultTerrain)
                .AddBuffDescriptorImmunity(descriptor: SpellDescriptor.Ground)
                .AddSpellImmunityToSpellDescriptor(descriptor: SpellDescriptor.Ground)
                .AddFormationACBonus(3)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d6.ToString())
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.NaturalSpell)
                .Configure();

            var DragonFormGoldBuffIII =
                BuffConfigurator.New(DragonFormGoldBuffIIIName, Guids.DragonFormGoldBuffIIIGuid)
                //.CopyFrom(BuffRefs.FormOfTheDragonIGoldBuff)
                .AddPolymorph(
                    prefab: "8c5c0a5027478304a94bb321a0f815b1",
                    specialDollType: SpecialDollType.None,
                    keepSlots: true,
                    size: Size.Large,
                    useSizeAsBaseForDamage: false,
                    strengthBonus: 4,
                    dexterityBonus: -2,
                    constitutionBonus: 2,
                    naturalArmor: 7,
                    mainHand: null,
                    offHand: null,
                    allowDamageTransfer: false,
                    additionalLimbs: [ItemWeaponRefs.BiteLarge2d6.ToString()],
                    secondaryAdditionalLimbs: [
                        ItemWeaponRefs.WingLarge1d6.ToString(),
                        ItemWeaponRefs.WingLarge1d6.ToString(),
                        ItemWeaponRefs.TailLarge1d8.ToString()
                    ],
                    transitionExternal: UnityObjectConverter.AssetList.Get("5687f6801ca6ea848a8d48298d892a8e", 11400000)
                        as PolymorphTransitionSettings,
                    silentCaster: true
                )
                .SetDisplayName("DragonForm.Name")
                .SetDescription("DragonFormIII.Description")
                .AddArmorCheckPenaltyIncrease(-2)
                .SetIcon(AbilityRefs.FormOfTheDragonIIGold.Reference.Get().Icon)
                .AddReplaceSourceBone("bd93ee9e72a24b1c918f137d972ba130")
                .AddBuffMovementSpeed(value: 10, descriptor: ModifierDescriptor.Racial)
                .AddACBonusAgainstAttacks(againstMeleeOnly: true, againstRangedOnly: false, onlySneakAttack: false, notTouch: false, isTouch: false, onlyAttacksOfOpportunity: false, value: 3, descriptor: ModifierDescriptor.Dodge)
                .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.DifficultTerrain)
                .AddBuffDescriptorImmunity(descriptor: SpellDescriptor.Ground)
                .AddSpellImmunityToSpellDescriptor(descriptor: SpellDescriptor.Ground)
                .AddFormationACBonus(3)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d8.ToString())
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.NaturalSpell)
                .Configure();

            var DragonFormGoldBuffIV =
                BuffConfigurator.New(DragonFormGoldBuffIVName, Guids.DragonFormGoldBuffIVGuid)
                .AddPolymorph(
                    prefab: "7a47bc6dbd2e2014aa5be8519e93a02e",
                    specialDollType: SpecialDollType.None,
                    keepSlots: true,
                    size: Size.Huge,
                    useSizeAsBaseForDamage: false,
                    strengthBonus: 6,
                    dexterityBonus: -4,
                    constitutionBonus: 2,
                    naturalArmor: 10,
                    mainHand: null,
                    offHand: null,
                    allowDamageTransfer: false,
                    additionalLimbs: [ItemWeaponRefs.BiteHuge2d8.ToString()],
                    secondaryAdditionalLimbs: [
                        ItemWeaponRefs.WingHuge1d8.ToString(),
                        ItemWeaponRefs.WingHuge1d8.ToString(),
                        ItemWeaponRefs.TailHuge2d6.ToString()
                    ],
                    transitionExternal: UnityObjectConverter.AssetList.Get("5687f6801ca6ea848a8d48298d892a8e", 11400000)
                        as PolymorphTransitionSettings,
                    silentCaster: true
                )
                .SetDisplayName("DragonForm.Name")
                .SetDescription("DragonForm.IVDescription")
                .AddArmorCheckPenaltyIncrease(-2)
                .SetIcon(AbilityRefs.FormOfTheDragonIIIGold.Reference.Get().Icon)
                .AddReplaceSourceBone("d0e04502420b4bfc95b43e6060b8c965")
                .AddBuffMovementSpeed(value: 10, descriptor: ModifierDescriptor.Racial)
                .AddACBonusAgainstAttacks(againstMeleeOnly: true, againstRangedOnly: false, onlySneakAttack: false, notTouch: false, isTouch: false, onlyAttacksOfOpportunity: false, value: 3, descriptor: ModifierDescriptor.Dodge)
                .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.DifficultTerrain)
                .AddBuffDescriptorImmunity(descriptor: SpellDescriptor.Ground)
                .AddSpellImmunityToSpellDescriptor(descriptor: SpellDescriptor.Ground)
                .AddFormationACBonus(3)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw2d6.ToString())
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.NaturalSpell)
                //Crush Attack?
                .Configure();

            var DragonFormGoldBuffV =
                BuffConfigurator.New(DragonFormGoldBuffVName, Guids.DragonFormGoldBuffVGuid)
                .AddPolymorph(
                    prefab: "7a47bc6dbd2e2014aa5be8519e93a02e",
                    specialDollType: SpecialDollType.None,
                    keepSlots: true,
                    //Try to mod Gargantuan, or keep huge with buffs? xD
                    size: Size.Huge,
                    useSizeAsBaseForDamage: false,
                    strengthBonus: 8,
                    dexterityBonus: -6,
                    constitutionBonus: 4,
                    naturalArmor: 13,
                    mainHand: null,
                    offHand: null,
                    allowDamageTransfer: false,
                    additionalLimbs: [ItemWeaponRefs.BiteHuge3d6.ToString()],
                    secondaryAdditionalLimbs: [
                        ItemWeaponRefs.WingHuge1d8.ToString(),
                        ItemWeaponRefs.WingHuge1d8.ToString(),
                        ItemWeaponRefs.TailHuge2d8.ToString()
                    ],
                    transitionExternal: UnityObjectConverter.AssetList.Get("5687f6801ca6ea848a8d48298d892a8e", 11400000)
                        as PolymorphTransitionSettings,
                    silentCaster: true
                )
                .SetDisplayName("DragonForm.Name")
                .SetDescription("DragonFormV.Description")
                .AddArmorCheckPenaltyIncrease(-2)
                .SetIcon(AbilityRefs.FormOfTheDragonIIIGold.Reference.Get().Icon)
                .AddReplaceSourceBone("d0e04502420b4bfc95b43e6060b8c965")
                .AddBuffMovementSpeed(value: 10, descriptor: ModifierDescriptor.Racial)
                .AddACBonusAgainstAttacks(againstMeleeOnly: true, againstRangedOnly: false, onlySneakAttack: false, notTouch: false, isTouch: false, onlyAttacksOfOpportunity: false, value: 3, descriptor: ModifierDescriptor.Dodge)
                .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.DifficultTerrain)
                .AddBuffDescriptorImmunity(descriptor: SpellDescriptor.Ground)
                .AddSpellImmunityToSpellDescriptor(descriptor: SpellDescriptor.Ground)
                .AddFormationACBonus(3)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw2d8.ToString())
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.NaturalSpell)
                .Configure();

            var DragonFormGoldBuffBase =
                BuffConfigurator.New(DragonFormGoldBuffBaseName, Guids.DragonFormGoldBuffBaseGuid)
                .SetDisplayName("DragonForm.Name")
                .SetDescription("DragonFormDescription")
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .AddFactContextActions(
                    activated:
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().CasterHasFact(Guids.DracomorphosisIVGuid),
                                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(DragonFormGoldBuffV, isNotDispelable: true, asChild: true)
                            )
                            .Conditional(
                                ConditionsBuilder.New().CasterHasFact(Guids.DracomorphosisIIIGuid).CasterHasFact(Guids.DracomorphosisIVGuid, negate: true),
                                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(DragonFormGoldBuffIV, isNotDispelable: true, asChild: true)
                            )
                            .Conditional(
                                ConditionsBuilder.New().CasterHasFact(Guids.DracomorphosisIIGuid).CasterHasFact(Guids.DracomorphosisIIIGuid, negate: true),
                                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(DragonFormGoldBuffIII, isNotDispelable: true, asChild: true)
                            )
                            .Conditional(
                            ConditionsBuilder.New().CasterHasFact(Guids.DracomorphosisIGuid).CasterHasFact(Guids.DracomorphosisIIGuid, negate: true),
                            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(DragonFormGoldBuffIIName, isNotDispelable: true, asChild: true)
                            )
                            .Conditional(
                                ConditionsBuilder.New().CasterHasFact(Guids.DracomorphosisIGuid),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(DragonFormGoldBuffIName, isNotDispelable: true, asChild: true))
                )
                .Configure();


            var DragonFormGoldToggleAbility =
                 ActivatableAbilityConfigurator.New(DragonFormGoldToggle, DragonFormGoldToggleGuid)
                    //.SetIcon(Icon)
                    .SetDisplayName("DragonForm.Name")
                    .SetDescription("DragonFormDescription")
                    .SetIcon(AbilityRefs.DragonFormAbillity.Reference.Get().Icon)
                    .SetBuff(DragonFormGoldBuffBase)
                    .SetDeactivateImmediately(true)
                    //.SetActivationType(Action )
                    .SetIsOnByDefault(true)
                    .Configure();

            var DragonFormGoldToggleFeature =
                FeatureConfigurator.New(DragonFormGoldFeat, DragonFormGoldFeatGuid)
                .AddFacts(new() { DragonFormGoldToggleAbility })
                .SetDisplayName("DragonForm.Name")
                .SetDescription("DragonFormDescription")
                .SetIcon(FeatureRefs.BloodragerDragonFormOfTheDragonGold.Reference.Get().m_Icon)
                .Configure();

            var heritageGold =
                FeatureConfigurator.New(DragonGoldName, Guids.DragonGoldGuid)
                .SetDisplayName("DragonHeritageGold.Name")
                .SetDescription("DragonHeritageGold.Description")
                .AddToGroups(Kingmaker.Blueprints.Classes.FeatureGroup.Racial)
                .AddFacts(new() { DragonFormGoldToggleFeature })
                //.SetIcon()
                .Configure();
        }
    }
}
