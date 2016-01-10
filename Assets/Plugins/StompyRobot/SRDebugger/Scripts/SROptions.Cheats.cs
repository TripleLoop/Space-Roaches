using System.ComponentModel;

public partial class SROptions
{
    private bool _godMode;

    [Category("Cheats")]
    public bool GodMode
    {
        get { return _godMode; }
        set { _godMode = value; }
    }
}