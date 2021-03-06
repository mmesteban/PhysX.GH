﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper;
using PhysX;
using Rhino;
using Rhino.Commands;

namespace PhysX.GH
{
    static class PhysXManager
    {
        internal static Foundation Foundation;
        internal static Physics Physics;
        internal static Scene Scene;


        internal static void Initialize()
        {
            if (Foundation != null) return;
            Foundation = new Foundation();
            Physics = new Physics(Foundation);
            Scene = Physics.CreateScene();

            Command.EndCommand += DisposePhysXOnGrasshopperUnloaded;
        }

        private static void DisposePhysXOnGrasshopperUnloaded(object sender, CommandEventArgs args)
        {
            // Check if the Rhino command being executed is "GrasshopperUnloadPlugin" 
            if (args.CommandId != new Guid("fc760140-ef99-42da-b2b4-2cdff7a4c8c4"))
                return;

            Command.EndCommand -= DisposePhysXOnGrasshopperUnloaded;
            Destroy();
        }


        internal static void ClearScene()
        {
            Scene.Dispose();
            Scene = Physics.CreateScene();
        }


        internal static void Destroy()
        {
            Scene.Dispose();
            Physics.Dispose();
            Foundation.Dispose();
        }
    }
}
