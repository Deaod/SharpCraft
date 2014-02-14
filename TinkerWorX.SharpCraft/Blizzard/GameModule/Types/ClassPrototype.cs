﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x14)]
    unsafe public struct ClassPrototype
    {
        public Int32 ClassSize;
        public Int32 BatchSize;
        public Int32 ElementsCreatedCount;
        public IntPtr MemoryAreas;
        public IntPtr FirstFreeElement;

        public ClassPrototypePtr AsSafe()
        {
            fixed (ClassPrototype* pointer = &this)
                return new ClassPrototypePtr(pointer);
        }

        public IntPtr AsIntPtr()
        {
            fixed (void* pointer = &this)
                return new IntPtr(pointer);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ClassPrototypePtr
    {
        private IntPtr pointer;

        unsafe public ClassPrototypePtr(ClassPrototype* pointer)
        {
            this.pointer = new IntPtr(pointer);
        }

        unsafe public ClassPrototype* AsUnsafe()
        {
            return (ClassPrototype*)this.pointer;
        }

        public IntPtr AsIntPtr()
        {
            return this.pointer;
        }
    }
}
