using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// Дочерний узел выполняющий какое-либо действие.
    /// </summary>
    public class ActionNode : IBehaviourTreeNode
    {
        public string Name { get; }

        private readonly Func<BehaviourTreeStatus> _action;
        

        public ActionNode(string name, Func<BehaviourTreeStatus> fn)
        {
            Name = name;
            _action = fn;
        }


        public BehaviourTreeStatus Tick()
        {
            return _action();
        }
    }
}
