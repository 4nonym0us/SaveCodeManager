using System;

namespace SaveCodeManager.Core.Saves
{
    /// <summary>
    /// This interface must be implemented by all save codes to identify them by convention.
    /// </summary>
    public interface ISaveCode
    {
        Map Map { get; set; }
        
        string FileHash { get; set; }

        DateTime CreationTime { get; set; }
    }
}