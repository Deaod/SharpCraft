﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinkerWorX.SharpCraft.Game;
using TinkerWorX.SharpCraft.Game.Jass;

namespace TinkerWorX.ExamplePlugin
{
    public class ExamplePlugin : GamePluginBase
    {
        //native Cheat takes string cheatStr returns nothing
        private delegate void CheatPrototype(JassStringArg cheatStr);
        private static CheatPrototype Cheat = WarcraftIII.GetNative("Cheat").ToDelegate<CheatPrototype>();

        // native DisplayTextToPlayer takes player toPlayer, real x, real y, string message returns nothing 
        private delegate void DisplayTextToPlayerPrototype(JassPlayer toPlayer, JassRealArg x, JassRealArg y, JassStringArg message);
        private static DisplayTextToPlayerPrototype DisplayTextToPlayer = WarcraftIII.GetNative("DisplayTextToPlayer").ToDelegate<DisplayTextToPlayerPrototype>();

        public override String Name { get { return "The Example Plugin"; } }

        public override Version Version { get { return new Version(0, 0); } }

        private List<JassUnit> units = new List<JassUnit>();

        private Single DegreeToRadian(Single angle)
        {
            return (Single)Math.PI * angle / 180.00f;
        }

        private Single RadianToDegree(Single angle)
        {
            return angle * (180.00f / (Single)Math.PI);
        }

        public void CheatHook(JassStringArg cheatStr)
        {
            switch (cheatStr)
            {
                case "mapinit":
                    DisplayTextToPlayer(JassPlayer.FromLocal(), 0, 0, "You started a map!");
                    DisplayTextToPlayer(JassPlayer.FromLocal(), 0, 0, "Hit |cffffcc00ESC|r to spawn some units under your cursor!");
                    DisplayTextToPlayer(JassPlayer.FromLocal(), 0, 0, "|cffffcc00Lidgren.Network|r");
                    DisplayTextToPlayer(JassPlayer.FromLocal(), 0, 0, " - Resolve('google.com') = " + Lidgren.Network.NetUtility.Resolve("google.com"));
                    break;

                case "tick":
                    const Single dt = 0.01f; // this is how often the timer is updating.
                    const Single speed = 128.00f; // this is how far we want the unit to move per second.
                    foreach (var unit in this.units)
                    {
                        var facing = unit.GetFacing();
                        unit.SetX(unit.GetX() + speed * dt * (Single)Math.Cos(DegreeToRadian(facing)));
                        unit.SetY(unit.GetY() + speed * dt * (Single)Math.Sin(DegreeToRadian(facing)));
                    }
                    break;

                case "esc":
                    var random = new Random();
                    this.units.Add(JassUnit.Create(JassPlayer.FromIndex(0), (JassUnitId)"hfoo", WarcraftIII.Input.MouseTerrain.X, WarcraftIII.Input.MouseTerrain.Y, random.Next() * 360));
                    this.units.Add(JassUnit.Create(JassPlayer.FromIndex(1), (JassUnitId)"hfoo", WarcraftIII.Input.MouseTerrain.X, WarcraftIII.Input.MouseTerrain.Y, random.Next() * 360));
                    this.units.Add(JassUnit.Create(JassPlayer.FromIndex(2), (JassUnitId)"hfoo", WarcraftIII.Input.MouseTerrain.X, WarcraftIII.Input.MouseTerrain.Y, random.Next() * 360));
                    this.units.Add(JassUnit.Create(JassPlayer.FromIndex(3), (JassUnitId)"hfoo", WarcraftIII.Input.MouseTerrain.X, WarcraftIII.Input.MouseTerrain.Y, random.Next() * 360));
                    DisplayTextToPlayer(JassPlayer.FromLocal(), 0, 0, "You hit |cffffcc00ESC|r!");
                    break;

                default:
                    Cheat(cheatStr);
                    break;
            }
        }

        public override void Initialize()
        {
            WarcraftIII.MapStart += this.MapStart;

            // Override the original cheat native, so we can intercept calls.
            WarcraftIII.AddNative(new CheatPrototype(this.CheatHook), "Cheat");
        }

        public void MapStart()
        {
            this.units.Clear();
        }
    }
}
