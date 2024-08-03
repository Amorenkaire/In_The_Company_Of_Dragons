using BlueprintCore.Blueprints.Configurators.Classes;
using dragonrace.Utility;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UI.MVVM._VM.ServiceWindows.MythicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dragonrace.Class
{

    class DragonParagon
    {
        private static readonly string DragonParagonClassName = "DragonParagonClass";

        public static void Configure()
        {
           
            
            BlueprintCharacterClass dragonParagonClass =
            CharacterClassConfigurator.New(DragonParagonClassName, Guids.DragonParagonClassGuid)
            .Configure();
        }
    }
}
