﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel.Types;
using PhysX;
using Rhino.Geometry;

namespace PhysX.GH.Kernel
{
    public abstract class PxGhRigidStatic : PxGhRigidBody
    {
        internal RigidStatic actor;
    }
}
