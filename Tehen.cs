namespace CA250401;
internal class Tehen : IEquatable<Tehen>
{
    public string ID { get; set; }
    public Dictionary<string, int> Mennyisegek { get; private set; } = new()
    {
        { "hétfő",     0 },
        { "kedd",      0 },
        { "szerda",    0 },
        { "csütörtök", 0 },
        { "péntek",    0 },
        { "szombat",   0 },
        { "vasárnap",  0 },
    };

    public int HetiTej => Mennyisegek.Values.Sum();

    public int AtlagosFejesiMennyiseg
    {
        get
        {
            int naponAdottTejet = Mennyisegek.Values.Count(v => v != 0);
            if (naponAdottTejet >= 3)
                return (int)Math.Round(HetiTej / (double)naponAdottTejet);
            return -1;
        }
    }

    public override string ToString()
    {
        string str = $"\t ID: {ID}\n";
        foreach (var kvp in Mennyisegek)
        {
            if (kvp.Value != 0) str += $"\t   {kvp.Key+":", -10} {kvp.Value, 2} liter\n";
        }
        return str;
    }

    public bool Equals(Tehen masikTehen) => this.ID == masikTehen.ID;

    public void TejMennyisegRogzit(int napIndex, int tejMennyiseg)
    {
        switch (napIndex)
        {
            case 0:
                Mennyisegek["hétfő"] = tejMennyiseg;
                return;
            case 1:
                Mennyisegek["kedd"] = tejMennyiseg;
                return;
            case 2:
                Mennyisegek["szerda"] = tejMennyiseg;
                return;
            case 3:
                Mennyisegek["csütörtök"] = tejMennyiseg;
                return;
            case 4:
                Mennyisegek["péntek"] = tejMennyiseg;
                return;
            case 5:
                Mennyisegek["szombat"] = tejMennyiseg;
                return;
            case 6:
                Mennyisegek["vasárnap"] = tejMennyiseg;
                return;
            default:
                throw new Exception("hibás napindex!");
        }
    }

    public Tehen(string id) => ID = id;
}
