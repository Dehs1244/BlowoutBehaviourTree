using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlowoutBehaviourTree.Exceptions;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// Узел, выполняющий действие если условие истино.
    /// </summary>
    class ConditionNode : IParentBehaviourTreeNode
    {
        public string Name { get; }

        private IBehaviourTreeNode _nodeExecute;
        private Func<bool> _conditionFunction;

        public ConditionNode(string name, Func<bool> condition)
        {
            Name = name;
            _conditionFunction = condition;
        }

        public void AddChild(IBehaviourTreeNode child)
        {
            if(_nodeExecute != null)
            {
                throw new BehaviourNodeException("Condition must have one child! Use another Condition node");
            }
            _nodeExecute = child;
        }

        public BehaviourTreeStatus Tick()
        {
            if (!_conditionFunction.Invoke()) return BehaviourTreeStatus.Running;
            return _nodeExecute.Tick();
        }
    }
}
