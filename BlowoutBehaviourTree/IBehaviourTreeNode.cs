using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// Interface for behaviour tree nodes.
    /// </summary>
    public interface IBehaviourTreeNode
    {
        /// <summary>
        /// Name of node
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Update the time of the behaviour tree.
        /// </summary>
        BehaviourTreeStatus Tick();
    }
}
