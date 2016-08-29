using System.Collections.Generic;
using System.IO;
using System.Linq;
using SaveCodeManager.Core.Helpers;
using SaveCodeManager.Core.Saves.Tkok;

namespace SaveCodeManager.Core.Services
{
    public class TkokSavesLoader : ISaveCodesLoader<ITkokSaveCode>
    {
        private string _tkokSavePath = @"TKoK_Save_Files";

        public ICollection<ITkokSaveCode> LoadCodes(string war3Path)
        {
            if (!Directory.Exists(war3Path))
            {
                return new List<ITkokSaveCode>();
            }

            var tkokSavesFolder = Path.Combine(war3Path, _tkokSavePath);
            if (!Directory.Exists(tkokSavesFolder))
            {
                return new List<ITkokSaveCode>();
            }

            var tkokSaveFolders = Directory.GetDirectories(tkokSavesFolder);

            return (from saveFolder in tkokSaveFolders
                    select new DirectoryInfo(saveFolder)
                    into saveFilesDir
                    from saveFile in saveFilesDir.GetFiles()
                    select RegexpHelper.ParseTkokSave(saveFile)).ToList();
        }
    }
}