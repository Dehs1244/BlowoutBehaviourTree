using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// Used to pass time values to behaviour tree nodes.
    /// Not using
    /// </summary>
    [Obsolete]
    internal readonly struct TransferTree
    {
        public float DeltaTime { get; }

        public TransferTree(float deltaTime)
        {
            DeltaTime = deltaTime;
        }

    }
}
