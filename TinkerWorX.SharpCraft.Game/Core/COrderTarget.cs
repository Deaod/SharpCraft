﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TinkerWorX.SharpCraft.Game.Jass;

namespace TinkerWorX.SharpCraft.Game.Core
{
    [StructLayout(LayoutKind.Sequential, Size = 0x454)]
    unsafe public struct COrderTarget
    {
        public IntPtr VTable;
        public IntPtr field0004;
        public IntPtr field0008;
        public IntPtr field000C;

        public IntPtr field0010;
        public IntPtr field0014;
        public IntPtr field0018;
        public IntPtr field001C;

        public IntPtr field0020;
        public JassOrder Order;
        public IntPtr field0028;
        public IntPtr field002C;

        public IntPtr field0030;
        public IntPtr field0034;
        public IntPtr field0038;
        public IntPtr field003C;

        public IntPtr field0040;
        public IntPtr field0044;
        public Single X;
        public IntPtr field004C;

        public Single Y;
        public IntPtr field0054;
        public IntPtr field0058;
        public IntPtr field005C;

        public IntPtr field0060;
        public IntPtr field0064;
        public IntPtr field0068;
        public IntPtr field006C;

        public IntPtr field0070;
        public IntPtr field0074;
        public IntPtr field0078;
        public IntPtr field007C;

        public IntPtr field0080;
        public IntPtr field0084;

        public COrderTargetPtr AsSafe()
        {
            fixed (COrderTarget* pointer = &this)
                return new COrderTargetPtr(new IntPtr(pointer));
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COrderTargetPtr
    {
        private IntPtr pointer;

        public COrderTargetPtr(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        unsafe public COrderTarget* AsUnsafe()
        {
            return (COrderTarget*)this.pointer;
        }
    }
}
