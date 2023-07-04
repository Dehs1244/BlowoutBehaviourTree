using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlowoutBehaviourTree.Exceptions;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// A decorator node that inverts the result of Success/Failure.
    /// </summary>
    public class InverterNode : IParentBehaviourTreeNode
    {
        public string Name { get; }

        /// <summary>
        /// The child to be inverted.
        /// </summary>
        private IBehaviourTreeNode _childNode;

        public InverterNode(string name)
        {
            Name = name;
        }

        public BehaviourTreeStatus Tick()
        {
            if (_childNode == null)
            {
                throw new BehaviourNodeException("InverterNode must have a child node!");
            }

            var result = _childNode.Tick();
            if (result == BehaviourTreeStatus.Failure)
            {
                return BehaviourTreeStatus.Success;
            }
            else if (result == BehaviourTreeStatus.Success)
            {
                return BehaviourTreeStatus.Failure;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Add a child to the parent node.
        /// </summary>
        public void AddChild(IBehaviourTreeNode child)
        {
            if (this._childNode != null)
            {
                throw new ApplicationException("Can't add more than a single child to InverterNode!");
            }

            this._childNode = child;
        }
    }
}
