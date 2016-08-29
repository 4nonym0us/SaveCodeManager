using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using SaveCodeManager.Core.Saves.Tkok;
using SaveCodeManager.Core.Services;

namespace SaveCodeManager.Core
{
    public class SaveCodeManagerCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.RegisterIfNot<ISaveCodesLoader<ITkokSaveCode>, TkokSavesLoader>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}