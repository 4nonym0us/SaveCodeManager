using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Dependency;
using SaveCodeManager.Core.Saves;

namespace SaveCodeManager.Core.Services
{
    public interface ISaveCodesLoader<TSaveCode> : ITransientDependency
        where TSaveCode : ISaveCode
    {
        Task<ICollection<TSaveCode>> LoadCodesAsync(string war3Path);
    }
}