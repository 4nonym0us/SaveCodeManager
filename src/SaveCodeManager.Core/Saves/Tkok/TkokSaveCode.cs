using System;

namespace SaveCodeManager.Core.Saves.Tkok
{
    public class TkokSaveCode : ITkokSaveCode
    {
        [Flags]
        public enum HeroKind
        {
            Arcanist,
            Barbarian,
            ChaoticKnight,
            Cleric,
            Druid,
            Hydromancer,
            Paladin,
            PhantomStalker,
            Pyromancer,
            Ranger,
            Shadowblade,
            Warrior
        }

        public TkokSaveCode()
        {
            Map = Map.Tkok;
        }

        public TkokSaveCode(string userName, HeroKind heroKind, int level, int exp, int gold, string password,
            DateTime creationTime, string mapVersion, string fileHash)
            : this()
        {
            UserName = userName;
            Class = heroKind;
            Level = level;
            Exp = exp;
            Gold = gold;
            Password = password;
            CreationTime = creationTime;
            MapVersion = mapVersion;
            FileHash = fileHash;
        }

        public Map Map { get; set; }

        public string FileHash { get; set; }

        public string UserName { get; set; }

        public HeroKind Class { get; set; }

        public string Password { get; set; }

        public int Exp { get; set; }

        public int Level { get; set; }

        public int Gold { get; set; }

        public string MapVersion { get; set; }

        public DateTime CreationTime { get; set; }

        public override string ToString()
        {
            return
                $"Class: {Class}, CreationTime: {CreationTime}, Exp: {Exp}, Gold: {Gold}, Level: {Level}, MapVersion: {MapVersion}, Password: {Password}, UserName: {UserName}";
        }

        public override bool Equals(object obj)
        {
            var saveCode = obj as TkokSaveCode;
            if (saveCode != null)
            {
                var code = saveCode;
                return Password == code.Password;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Password.GetHashCode();
        }
    }
}