using System;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Jass
{
    [JassType("Hracepreference;")]
    [Serializable]
    public partial struct JassRacePreference
    {
        public readonly IntPtr Handle;
        
        public JassRacePreference(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}
