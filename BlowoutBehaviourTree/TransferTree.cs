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
    public readonly struct TransferTree
    {
        public float DeltaTime { get; }
        public Dictionary<string, object> Form { get; }

        public TransferTree(float deltaTime)
        {
            DeltaTime = deltaTime;
            Form = new Dictionary<string, object>();
        }

    }
}
