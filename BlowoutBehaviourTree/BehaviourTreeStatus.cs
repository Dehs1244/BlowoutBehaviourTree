using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// The return type when invoking behaviour tree nodes.
    /// </summary>
    public enum BehaviourTreeStatus
    {
        Success = 2,
        Failure = 1,
        Running = 0
    }
}
