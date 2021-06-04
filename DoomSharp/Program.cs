using System;
using DoomSharp.WAD;
using Luminal;
using Luminal.Entities.Components;
using Luminal.Entities.World;

namespace DoomSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Luminal.Core.Engine();

            engine.OnFinishedLoad += _ =>
            {
                var cam = new Object3D("camera");
                cam.CreateComponent<Camera3D>();

                WADLoader.LoadFile($"doom.wad");
            };

            engine.StartRenderer(1280, 720, "doomsharp", typeof(Program), Luminal.Core.LuminalFlags.NoPhysics);
        }
    }
}
