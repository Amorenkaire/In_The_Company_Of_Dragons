using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils.Types;
using dragonrace.Utility;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragonrace.Archetypes
{
     class Bloodlines
    {
        private const string GoldDragonSorcererName = "GoldDragonSorcerer";
        private const string GoldDragonSorcBreathFeatName = "GoldDragonSorcBreathFeat";
        private const string GoldDragonSorcBreathResourceName = "GoldDragonSOrcBreathResource";
        private const string GoldDragonSorcBreathCDName = "GoldDragonSorcBreathCD";
        private const string GoldDragonSorcBreathName = "GoldDragonSorcBreath";
        public static void Configure()
        {
            var GoldDragonSorcBreathAction =
                ActionsBuilder.New()
                .SavingThrow(Kingmaker.EntitySystem.Stats.SavingThrowType.Reflex,
                onResult: ActionsBuilder.New()
                    .DealDamage(
                        DamageTypes.Energy(Kingmaker.Enums.Damage.DamageEnergyType.Fire),
                        ContextDice.Value(Kingmaker.RuleSystem.DiceType.D6, diceCount: ContextValues.Rank()),
                        halfIfSaved: true));

            var GoldDragonSorcBreathResource =
                AbilityResourceConfigurator.New(GoldDragonSorcBreathResourceName, Guids.GoldDragonSorcBreathResourceGuid)
                .SetMaxAmount(
                    ResourceAmountBuilder.New(3).IncreaseByStat(StatType.Charisma).Build())
                .Configure();

            var GoldDragonSorcBreathCD =
                BuffConfigurator.New(GoldDragonSorcBreathCDName, Guids.GoldDragonSorcBreathCDGuid)
                .SetDisplayName(BuffRefs.GoldenDragonBreathCooldown.Reference.Get().m_DisplayName)
                .SetDescription(BuffRefs.GoldenDragonBreathCooldown.Reference.Get().Description)
                .SetIcon(BuffRefs.GoldenDragonBreathCooldown.Reference.Get().Icon)
                .Configure();

            var GoldDragonSorcBreath =
                AbilityConfigurator.New(GoldDragonSorcBreathName, Guids.GoldDragonSorcBreathGuid)
                .SetDisplayName("GoldDragonSorcBreath.Name")
                .SetDescription("GoldDragonSorcBreath.Description")
                .SetIcon(AbilityRefs.DragonsBreathGold.Reference.Get().Icon)
                .SetType(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Supernatural)
                .SetLocalizedSavingThrow(SavingThrow.ReflexHalf)
                .SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close) //Should be 20 for small size, close is 30?
                .AllowTargeting(enemies: true, point: true, friends: true, self: true)
                .SetAnimation(animation: Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.BreathWeapon)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .SetSpellResistance(false)
                .SetShouldTurnToTarget(true)
                .SetAvailableMetamagic( Metamagic.Empower, Metamagic.Quicken, Metamagic.Heighten, Metamagic.Maximize )
                .AddAbilityDeliverProjectile(
                    type: Kingmaker.UnitLogic.Abilities.Components.AbilityProjectileType.Cone, 
                    projectiles: new() { ProjectileRefs.FireCone30Feet00Breath.ToString() })
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(
                    classes: new[] { CharacterClassRefs.SorcererClass.ToString() 
                                     //Dragon Disciple Alternate Class Here
                    }))
                .AddAbilityEffectRunAction( GoldDragonSorcBreathAction)
                .AddSpellDescriptorComponent(SpellDescriptor.Fire | SpellDescriptor.BreathWeapon)
                .AddAbilityCasterHasNoFacts( facts: new() { GoldDragonSorcBreathCD } )
                .AddAbilityExecuteActionOnCast(
                    actions: ActionsBuilder.New().ApplyBuff(buff: GoldDragonSorcBreathCD, durationValue: ContextDuration.VariableDice(DiceType.D4, diceCount: 1), toCaster: true))
                .AddAbilityResourceLogic(
                    requiredResource: GoldDragonSorcBreathResource,
                    isSpendResource: true,
                    amount: 1)
                .SetEffectOnAlly(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityEffectOnUnit.None)
                .SetEffectOnEnemy(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityEffectOnUnit.Harmful)
                .Configure();

            var GoldDragonSorcBreathFeat =
                FeatureConfigurator.New(GoldDragonSorcBreathFeatName, Guids.GoldDragonSorcBreathFeatGuid)
                .SetDisplayName("GoldDragonSorcBreath.Name")
                .SetDescription("GoldDragonSorcBreath.Description")
                .SetIcon(FeatureRefs.BloodlineDraconicGoldBreathWeaponBaseFeature.Reference.Get().Icon)
                .AddFacts(new() { GoldDragonSorcBreath })
                .AddAbilityResources(
                    resource: GoldDragonSorcBreathResource,
                    useThisAsResource: false,
                    restoreAmount: true,
                    restoreOnLevelUp: false
                    )
                .AddReplaceAbilitiesStat(stat: StatType.Charisma)
                .AddReplaceCasterLevelOfAbility(
                    spell: GoldDragonSorcBreath,
                    clazz: CharacterClassRefs.SorcererClass.ToString()
                    //additionalClasses: Dragon Disciple Alternate Class here
                    )
                .AddBindAbilitiesToClass(
                    abilites: new() { GoldDragonSorcBreath },
                    cantrip: false,
                    characterClass: CharacterClassRefs.SorcererClass.ToString(),
                    //additionalClasses: Dragon Disciple Alternate Class here
                    stat: StatType.Charisma,
                    levelStep: 2,
                    odd: true,
                    fullCasterChecks: true
                )
                .Configure();


            var GDSProg =
                LevelEntryBuilder.New()
                .AddEntry(level: 1, Guids.GoldDragonSorcBreathFeatGuid, FeatureRefs.BloodlineDraconicGoldArcana.ToString(), FeatureRefs.BloodlineDraconicClassSkill.ToString())
                .AddEntry(level: 3, FeatureRefs.BloodlineDraconicSpellLevel1.ToString())
                .AddEntry(level: 5, FeatureRefs.BloodlineDraconicSpellLevel2.ToString())
                .AddEntry(level: 7, FeatureRefs.BloodlineDraconicSpellLevel3.ToString())
                .AddEntry(level: 9, FeatureRefs.BloodlineDraconicSpellLevel4.ToString())
                .AddEntry(level: 11, FeatureRefs.BloodlineDraconicSpellLevel5.ToString())
                .AddEntry(level: 13, FeatureRefs.BloodlineDraconicSpellLevel6.ToString())
                .AddEntry(level: 15, FeatureRefs.BloodlineDraconicSpellLevel7.ToString())
                .AddEntry(level: 17, FeatureRefs.BloodlineDraconicSpellLevel8.ToString())
                .AddEntry(level: 19, FeatureRefs.BloodlineDraconicSpellLevel9.ToString())
                ;

            var GoldDragonSorcerer =
            ProgressionConfigurator.New(GoldDragonSorcererName, Guids.GoldDragonSorcererGuid)
                .SetDisplayName("GoldDragonSorcerer.Name")
                .SetDescription("GoldDragonSorcerer.Description")
                .SetIcon(FeatureRefs.DraconicGoldBloodlineRequisiteFeature.Reference.Get().Icon)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(true)
                .SetForAllOtherClasses(false)
                .AddToArchetypes(Guids.DHSorcererGuid)
                .SetLevelEntries(GDSProg)
                .Configure();
        }

    }
}
