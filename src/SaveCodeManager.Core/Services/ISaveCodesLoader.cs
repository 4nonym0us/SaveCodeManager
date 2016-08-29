using System.Collections.Generic;
using Abp.Dependency;
using SaveCodeManager.Core.Saves;

namespace SaveCodeManager.Core.Services
{
    public interface ISaveCodesLoader<TSaveCode> : ITransientDependency
        where TSaveCode : ISaveCode
    {
        ICollection<TSaveCode> LoadCodes(string war3Path);
    }
}