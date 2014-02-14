﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinkerWorX.SharpCraft.Blizzard.Types;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Types
{
    unsafe public interface IAgent<T>
    {
        T AsSafe();
        IntPtr AsIntPtr();
        CAgent* ToBase();

        ObjectIdL GetClassId(); // virtual function 7
        String GetClassName(); // virtual function 22
    }
}
