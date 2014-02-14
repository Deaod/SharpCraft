﻿using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Types
{
    [StructLayout(LayoutKind.Sequential/*, Size = unknown*/)]
    unsafe public struct VirtualMachine
    {
        public IntPtr field0000;
        public IntPtr field0004;
        public IntPtr field0008;
        public IntPtr field000C;
        public IntPtr field0010;
        public IntPtr field0014;
        public IntPtr field0018;
        public IntPtr field001C;
        public IntPtr CurrentOpcode;
        public IntPtr field0024;
        public IntPtr field0028;
        public IntPtr field002C;
        public IntPtr field0030;
        public IntPtr field0034;
        public IntPtr field0038;
        public IntPtr field003C;
        public IntPtr field0040;
        public Int32 MaxOperations;
        public IntPtr field0048;
        public fixed Byte Variables[0x100 * 0x28];
        public IntPtr field284C;
        public IntPtr field2850;
        public IntPtr field2854;
        public SymbolTable* SymbolTable;
        public IntPtr GlobalTable;
        public IntPtr field2860;
        public IntPtr field2864;
        public IntPtr LocalScope;
        public IntPtr field286C;
        public IntPtr JumpTable;
        public IntPtr StringTable;
        public IntPtr field2878;
        public IntPtr field287C;
        public IntPtr field2880;
        public IntPtr FunctionTable;
        public IntPtr field2888;
        public IntPtr field288C;
        public IntPtr field2890;
        public IntPtr field2894;
        public IntPtr field2898;
        public IntPtr field289C;
        public IntPtr DecrementHandleFunction;
        public IntPtr HandleTable;
        public IntPtr table28A8;
        public IntPtr table28AC;
        public IntPtr table28B0;

        public VirtualMachinePtr AsSafe()
        {
            fixed (VirtualMachine* pointer = &this)
                return new VirtualMachinePtr(pointer);
        }

        public IntPtr AsIntPtr()
        {
            fixed (void* pointer = &this)
                return new IntPtr(pointer);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VirtualMachinePtr
    {
        private IntPtr pointer;

        unsafe public VirtualMachinePtr(VirtualMachine* pointer)
        {
            this.pointer = new IntPtr(pointer);
        }

        unsafe public VirtualMachine* AsUnsafe()
        {
            return (VirtualMachine*)this.pointer;
        }

        public IntPtr AsIntPtr()
        {
            return this.pointer;
        }
    }
}
