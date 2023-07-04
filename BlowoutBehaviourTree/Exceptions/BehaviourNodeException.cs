using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlowoutBehaviourTree.Exceptions
{
    public sealed class BehaviourNodeException : Exception
    {
        internal BehaviourNodeException(string message) : base($"An error occurred during child excecution/adding. {message}.")
        {

        }
    }
}
