using BlowoutBehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// A node equivalent to a Sequence node, but skips Condition nodes in this branch if any Condition node was true and executed. 
    /// It is convenient to use as the root node.
    /// </summary>
    class ContinuatorNode : IParentBehaviourTreeNode
    {

        public string Name { get; }
        private List<IBehaviourTreeNode> _childrens = new List<IBehaviourTreeNode>();

        public ContinuatorNode(string name)
        {
            Name = name;
        }

        public void AddChild(IBehaviourTreeNode child)
        {
            _childrens.Add(child);
        }

        public BehaviourTreeStatus Tick()
        {
            var ignoring = false;
            foreach (var child in _childrens)
            {
                if(child is ConditionNode && ignoring) continue;
                var childStatus = child.Tick();
                if (child is ConditionNode && childStatus == BehaviourTreeStatus.Success) ignoring = true;
            }
            return ignoring ? BehaviourTreeStatus.Success : BehaviourTreeStatus.Failure;
        }
    }
}
