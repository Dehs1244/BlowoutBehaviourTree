using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlowoutBehaviourTree.Exceptions;

namespace BlowoutBehaviourTree
{
    public class BehaviourTreeBuilder
    {
        /// <summary>
        /// Last created branch.
        /// </summary>
        private IBehaviourTreeNode curNode = null;
        private BehaviourTreeChildBuilder _ChildBuilder => new BehaviourTreeChildBuilder(this);

        private Stack<IParentBehaviourTreeNode> parentNodeStack = new Stack<IParentBehaviourTreeNode>();

        internal IParentBehaviourTreeNode GetBuildingNode()
        {
            if (parentNodeStack.Count <= 0)
            {
                throw new BehaviourNodeBuilderException("Can't get parent node");
            }

            return parentNodeStack.Peek();
        }

        public BehaviourTreeChildBuilder MakeDoScheme() => _ChildBuilder;

        public BehaviourTreeChildBuilder Condition(string name, Func<bool> condition)
        {
            var conditionNode = new ConditionNode(name, condition);
            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(conditionNode);
            }

            parentNodeStack.Push(conditionNode);
            return _ChildBuilder;
        }

        public BehaviourTreeBuilder Inverter(string name)
        {
            var inverterNode = new InverterNode(name);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(inverterNode);
            }

            parentNodeStack.Push(inverterNode);
            return this;
        }

        public BehaviourTreeChildBuilder Sequence(string name)
        {
            var sequenceNode = new SequenceNode(name);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(sequenceNode);
            }

            parentNodeStack.Push(sequenceNode);
            return _ChildBuilder;
        }

        public BehaviourTreeBuilder Parallel(string name, int numRequiredToFail, int numRequiredToSucceed)
        {
            var parallelNode = new ParallelNode(name, numRequiredToFail, numRequiredToSucceed);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(parallelNode);
            }

            parentNodeStack.Push(parallelNode);
            return this;
        }

        public BehaviourTreeBuilder Selector(string name)
        {
            var selectorNode = new SelectorNode(name);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(selectorNode);
            }

            parentNodeStack.Push(selectorNode);
            return this;
        }

        public BehaviourTreeBuilder Continuator(string name)
        {
            var continuatorNode = new ContinuatorNode(name);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(continuatorNode);
            }

            parentNodeStack.Push(continuatorNode);
            return this;
        }

        public BehaviourTreeBuilder Splice(IBehaviourTreeNode subTree)
        {
            if (subTree == null)
            {
                throw new ArgumentNullException("subTree");
            }

            if (parentNodeStack.Count <= 0)
            {
                throw new ApplicationException("Can't splice an unnested sub-tree, there must be a parent-tree.");
            }

            parentNodeStack.Peek().AddChild(subTree);
            return this;
        }

        public IBehaviourTreeNode Build()
        {
            if (curNode == null)
            {
                throw new ApplicationException("Can't create a behaviour tree with zero nodes");
            }
            return curNode;
        }

        public BehaviourTreeBuilder End()
        {
            curNode = parentNodeStack.Pop();
            return this;
        }
    }
}
