using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlowoutBehaviourTree
{
    /// <summary>
    /// Runs child nodes in parallel.
    /// </summary>
    public class ParallelNode : IParentBehaviourTreeNode
    {
        public string Name { get; }

        /// <summary>
        /// List of child nodes.
        /// </summary>
        private readonly List<IBehaviourTreeNode> _children = new List<IBehaviourTreeNode>();

        /// <summary>
        /// Number of child failures required to terminate with failure.
        /// </summary>
        private int _numbersToRequiredToFail { get; }

        /// <summary>
        /// Number of child successess require to terminate with success.
        /// </summary>
        private int _numbersToRequiredToSucceed { get; }

        public ParallelNode(string name, int numRequiredToFail, int numRequiredToSucceed)
        {
            Name = name;
            _numbersToRequiredToFail = numRequiredToFail;
            _numbersToRequiredToSucceed = numRequiredToSucceed;
        }

        public BehaviourTreeStatus Tick()
        {
            var numChildrenSuceeded = 0;
            var numChildrenFailed = 0;

            foreach (var child in _children)
            {
                var childStatus = child.Tick();
                switch (childStatus)
                {
                    case BehaviourTreeStatus.Success: ++numChildrenSuceeded; break;
                    case BehaviourTreeStatus.Failure: ++numChildrenFailed; break;
                }
            }

            if (_numbersToRequiredToSucceed > 0 && numChildrenSuceeded >= _numbersToRequiredToSucceed)
            {
                return BehaviourTreeStatus.Success;
            }

            if (_numbersToRequiredToFail > 0 && numChildrenFailed >= _numbersToRequiredToFail)
            {
                return BehaviourTreeStatus.Failure;
            }

            return BehaviourTreeStatus.Running;
        }

        public void AddChild(IBehaviourTreeNode child)
        {
            _children.Add(child);
        }
    }
}
