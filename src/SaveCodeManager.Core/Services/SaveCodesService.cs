using System;
using System.Collections.Generic;
using Abp.Dependency;
using Castle.Core.Logging;
using SaveCodeManager.Saves;

namespace SaveCodeManager.Services
{
    [Obsolete("I dunno why I created this service...")]
    public class SaveCodesService : ITransientDependency
    {
        private readonly IIocManager _iocManager;
        private readonly ILogger _logger;

        public ICollection<ISaveCode> SaveCodes { get; set; }

        public SaveCodesService(IIocManager iocManager, ILogger logger)
        {
            _iocManager = iocManager;
            _logger = logger;
        }

        public ISaveCodesLoader<T> GetLoaderForType<T>(bool overwrite)
            where T : ISaveCode
        {
            return _iocManager.Resolve<ISaveCodesLoader<T>>();
        }
    }
}
