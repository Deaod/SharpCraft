using System;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Jass
{
    [JassType("Hhashtable;")]
    [Serializable]
    public partial struct JassHashTable
    {
        public readonly IntPtr Handle;
        
        public JassHashTable(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}
