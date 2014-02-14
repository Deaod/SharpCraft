using System;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Jass
{
    [JassType("Hfogmodifier;")]
    [Serializable]
    public partial struct JassFogModifier
    {
        public readonly IntPtr Handle;
        
        public JassFogModifier(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}
