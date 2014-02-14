using System;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Jass
{
    [JassType("Hdialog;")]
    [Serializable]
    public partial struct JassDialog
    {
        public readonly IntPtr Handle;
        
        public JassDialog(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}
