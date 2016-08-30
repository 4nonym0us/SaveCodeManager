using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using SaveCodeManager.Saves.Tkok;
using SaveCodeManager.Services;

namespace SaveCodeManager
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