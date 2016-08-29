namespace SaveCodeManager.Core.Saves.Tkok
{
    public interface ITkokSaveCode : ISaveCode
    {
        TkokSaveCode.HeroKind Class { get; set; }

        int Exp { get; set; }

        int Gold { get; set; }

        int Level { get; set; }

        string Password { get; set; }

        string UserName { get; set; }

        string MapVersion { get; set; }

        string ToString();
    }
}