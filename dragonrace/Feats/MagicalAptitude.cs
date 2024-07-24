using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragonrace.Feats
{
    public class MagicalAptitude
    {
        private static readonly string FeatName = "MagicalAptitudeFeat";
        private static readonly string FeatGuid = "E47A36AB-EBCC-4D94-9888-B795ABD398F3";
        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, FeatGuid, Kingmaker.Blueprints.Classes.FeatureGroup.Feat)
                .SetReapplyOnLevelUp()
                .SetDisplayName("MagicalAptitude.Name")
                .SetDescription("MagicalAptitude.Description")
                .AddFeatureTagsComponent(Kingmaker.Blueprints.Classes.Selection.FeatureTag.Skills)

                .AddContextRankConfig(ContextRankConfigs.BaseStat(StatType.SkillKnowledgeArcana).WithCustomProgression((9, 2), (10, 4)))
                .AddContextStatBonus(StatType.SkillKnowledgeArcana, ContextValues.Rank(), descriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable)

                .AddContextRankConfig(ContextRankConfigs.BaseStat(StatType.SkillUseMagicDevice, type: Kingmaker.Enums.AbilityRankType.StatBonus).WithCustomProgression((9, 2), (10, 4)))
                .AddContextStatBonus(StatType.SkillUseMagicDevice, ContextValues.Rank(type: Kingmaker.Enums.AbilityRankType.StatBonus), descriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable)

                .Configure();
        }
    }
}