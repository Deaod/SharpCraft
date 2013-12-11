﻿using System;
using System.Runtime.InteropServices;
using TinkerWorX.SharpCraft.Game.Jass;

namespace TinkerWorX.SharpCraft.Game.Core
{
    [StructLayout(LayoutKind.Sequential, Size = 0x88)]
    unsafe public struct CDestructable
    {
        // The first function in GetDestructableX, GetDestructableY.
        // int __fastcall sub_6F3BE010(int a1)
        // We use __thiscall as a cheat for doing a fastcall with only one argument.
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        [return: MarshalAs(UnmanagedType.LPStruct)]
        private delegate CDestructable sub_6F3BE010Prototype(JassDestructable destructable);

        private static sub_6F3BE010Prototype sub_6F3BE010 = (sub_6F3BE010Prototype)Marshal.GetDelegateForFunctionPointer(WarcraftIII.Module + 0x3BE010, typeof(sub_6F3BE010Prototype));

        public static CDestructable FromHandle(JassDestructable destructable)
        {
            return sub_6F3BE010(destructable);
        }



        public IntPtr VTable;
        public IntPtr field0004;
        public IntPtr field0008;
        public IntPtr field000C;
        public IntPtr field0010;
        public IntPtr field0014;
        public IntPtr field0018;
        public IntPtr field001C;
        public IntPtr field0020;
        public IntPtr field0024;
        public IntPtr field0028;
        public IntPtr field002C;
        public IntPtr field0030;
        public IntPtr field0034;
        public IntPtr field0038;
        public IntPtr field003C;
        public IntPtr field0040;
        public IntPtr field0044;
        public IntPtr field0048;
        public IntPtr field004C;
        public IntPtr field0050;
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

        public CDestructablePtr AsSafe()
        {
            fixed (CDestructable* pointer = &this)
                return new CDestructablePtr(new IntPtr(pointer));
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CDestructablePtr
    {
        private IntPtr pointer;

        public CDestructablePtr(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        unsafe public CDestructable* AsUnsafe()
        {
            return (CDestructable*)this.pointer;
        }
    }
}
