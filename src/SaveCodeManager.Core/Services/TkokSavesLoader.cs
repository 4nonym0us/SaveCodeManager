using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SaveCodeManager.Core.Helpers;
using SaveCodeManager.Core.Saves.Tkok;

namespace SaveCodeManager.Core.Services
{
    public class TkokSavesLoader : ISaveCodesLoader<ITkokSaveCode>
    {
        private string _tkokSavePath = @"TKoK_Save_Files";

        public async Task<ICollection<ITkokSaveCode>> LoadCodesAsync(string war3Path)
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

            var list = new List<ITkokSaveCode>();
            foreach (var saveFolder in tkokSaveFolders)
            {
                var saveFilesDir = new DirectoryInfo(saveFolder);
                foreach (var saveFile in saveFilesDir.GetFiles())
                    list.Add(await RegexpHelper.ParseTkokSaveAsync(saveFile));
            }
            return list;
        }
    }
}