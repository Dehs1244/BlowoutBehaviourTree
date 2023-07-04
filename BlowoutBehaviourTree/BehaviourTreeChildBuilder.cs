using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlowoutBehaviourTree
{
    public class BehaviourTreeChildBuilder
    {
        private BehaviourTreeBuilder _root;
        private IParentBehaviourTreeNode _parentNode;

        internal BehaviourTreeChildBuilder(BehaviourTreeBuilder root)
        {
            _root = root;
            _parentNode = _root.GetBuildingNode();
        }

        public BehaviourTreeChildBuilder Do(string name, Func<BehaviourTreeStatus> function)
        {
            var actionNode = new ActionNode(name, function);
            _parentNode.AddChild(actionNode);
            return this;
        }

        public BehaviourTreeBuilder End()
        {
            return _root.End();
        }

    }
}
