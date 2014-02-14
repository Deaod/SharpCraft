﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TinkerWorX.SharpCraft.Blizzard.GameModule.Types;
using TinkerWorX.Utilities;
using TinkerWorX.Windows;

namespace TinkerWorX.SharpCraft.Blizzard.GameModule
{
    unsafe internal static class Interface
    {
        private static GameFunctions.CGameUI__ConstructorPrototype CGameUI__Constructor;

        public static CGameUI* GameUI { get; private set; }

        public static Single FPS { get { return Memory.Read<Single>(GameAddresses.ValueFPS); } }

        public static void Initialize()
        {
            if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
                throw new Exception("Attempted to initialize " + typeof(Interface).Name + " before 'game.dll' has been loaded.");

            if (!GameAddresses.IsReady)
                throw new Exception("Attempted to initialize " + typeof(Interface).Name + " before " + typeof(GameAddresses).Name + " was ready.");

            var address = IntPtr.Zero;

            address = GameAddresses.CGameUI__Constructor;
            Trace.Write("CGameUI__Constructor: 0x" + address.ToString("X8") + " . ");
            Interface.CGameUI__Constructor = Memory.InstallHook(address, new GameFunctions.CGameUI__ConstructorPrototype(Interface.CGameUI__ConstructorHook), true, false);
            Trace.WriteLine("installed!");
        }

        private static IntPtr CGameUI__ConstructorHook(CGameUIPtr @this)
        {
            var result = CGameUI__Constructor(@this);

            Interface.GameUI = @this.AsUnsafe();

            return result;
        }
    }
}
