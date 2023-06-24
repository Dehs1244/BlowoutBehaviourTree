using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// Executes nodes until Success is received.
    /// </summary>
    public class SelectorNode : IParentBehaviourTreeNode
    {
        public string Name { get; }

        /// <summary>
        /// List of child nodes.
        /// </summary>
        private readonly HashSet<IBehaviourTreeNode> _children = new HashSet<IBehaviourTreeNode>();

        public SelectorNode(string name)
        {
            Name = name;
        }

        public BehaviourTreeStatus Tick()
        {
            foreach (var child in _children)
            {
                var childStatus = child.Tick();
                if (childStatus == BehaviourTreeStatus.Success)
                {
                    return childStatus;
                }
            }

            return BehaviourTreeStatus.Failure;
        }

        /// <summary>
        /// Add a child node to the selector.
        /// </summary>
        public void AddChild(IBehaviourTreeNode child)
        {
            _children.Add(child);
        }
    }
}
