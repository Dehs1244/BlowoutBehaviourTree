using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// Выполняет дочерние ветки, возвращая Running.
    /// </summary>
    public class SequenceNode : IParentBehaviourTreeNode
    {
        public string Name { get; }
        private readonly bool _isBreakOnFail;

        /// <summary>
        /// List of child nodes.
        /// </summary>
        private HashSet<IBehaviourTreeNode> _children = new HashSet<IBehaviourTreeNode>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of node</param>
        /// <param name="isBreakOnFail">It is not interrupted if there was an fail on one of the child nodes</param>
        public SequenceNode(string name, bool isBreakOnFail = true)
        {
            Name = name;
            _isBreakOnFail = isBreakOnFail;
        }

        public BehaviourTreeStatus Tick()
        {
            BehaviourTreeStatus status = BehaviourTreeStatus.Running;
            foreach (var child in _children)
            {
                status = child.Tick();
                if (status != BehaviourTreeStatus.Success && _isBreakOnFail)
                {
                    return status;
                }
            }

            return status;
        }

        /// <summary>
        /// Add a child to the sequence.
        /// </summary>
        public void AddChild(IBehaviourTreeNode child)
        {
            _children.Add(child);
        }
    }
}
