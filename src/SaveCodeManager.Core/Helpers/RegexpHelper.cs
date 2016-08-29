using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SaveCodeManager.Core.Saves.Tkok;

namespace SaveCodeManager.Core.Helpers
{
    public static class RegexpHelper
    {
        public static async Task<ITkokSaveCode> ParseTkokSaveAsync(FileInfo file)
        {
            using (var fs = File.OpenRead(file.FullName))
            {
                var content = await new StreamReader(fs).ReadToEndAsync();
                var matches = Regex.Matches(content, @"\w+:[-load ]*\s+(.*?)\r\n");

                var userName = matches[0].Result("$1");
                var className = EnumHelper.GetValueFromName<TkokSaveCode.HeroKind>(matches[1].Result("$1"));
                var level = int.Parse(matches[2].Result("$1"));
                var exp = int.Parse(matches[3].Result("$1"));
                var gold = int.Parse(matches[4].Result("$1"));
                var password = matches[5].Result("$1");

                var mapVersion = file.Directory?.Name.Replace("TKoK_", "");

                var sha = new SHA256CryptoServiceProvider();
                var fileHash = BitConverter.ToString(sha.ComputeHash(fs));

                var saveCode = new TkokSaveCode(userName, className, level, exp, gold, password, file.CreationTime, mapVersion, fileHash);
                return saveCode;
            }
        }
    }
}