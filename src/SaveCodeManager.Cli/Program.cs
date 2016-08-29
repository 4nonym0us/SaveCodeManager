using System;
using System.Collections.Generic;
using System.Linq;
using Abp;
using Abp.Dependency;
using Abp.Threading;
using Castle.Facilities.Logging;
using SaveCodeManager.Core.Saves.Tkok;
using SaveCodeManager.Core.Services;

namespace SaveCodeManager.Cli
{
    class Program
    {
        private static AbpBootstrapper _bootstrapper;

        static void Main(string[] args)
        {

            _bootstrapper = AbpBootstrapper.Create<SaveCodeManagerCliModule>();
            _bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));

            _bootstrapper.Initialize();

            var loader = IocManager.Instance.Resolve<TkokSavesLoader>();

            var testW3Path = @"D:\Games\WarcraftIII 1.27a";
            var saveCodes = AsyncHelper.RunSync(() => loader.LoadCodesAsync(testW3Path));

            var finalCodes = new List<ITkokSaveCode>();
            foreach (TkokSaveCode.HeroKind className in Enum.GetValues(typeof(TkokSaveCode.HeroKind)))
            {
                var codeForClass = saveCodes.FirstOrDefault(s => s.Class == className);
                if (codeForClass != null) finalCodes.Add(codeForClass);
            }

            foreach (var saveCode in finalCodes)
            {
                Console.WriteLine(saveCode);
            }
            Console.ReadKey(true);
        }
    }
}
