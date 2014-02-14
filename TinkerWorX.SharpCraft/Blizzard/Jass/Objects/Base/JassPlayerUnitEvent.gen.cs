using System;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Jass
{
    [JassType("Hplayerunitevent;")]
    [Serializable]
    public partial struct JassPlayerUnitEvent
    {
        public readonly IntPtr Handle;
        
        public JassPlayerUnitEvent(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}
