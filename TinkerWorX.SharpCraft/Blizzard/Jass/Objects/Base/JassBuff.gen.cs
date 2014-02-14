using System;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Jass
{
    [JassType("Hbuff;")]
    [Serializable]
    public partial struct JassBuff
    {
        public readonly IntPtr Handle;
        
        public JassBuff(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}
