using System.Reflection;
using Abp.Modules;
using SaveCodeManager.Core;

namespace SaveCodeManager.Cli
{
    [DependsOn(typeof(SaveCodeManagerCoreModule))]
    public class SaveCodeManagerCliModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
