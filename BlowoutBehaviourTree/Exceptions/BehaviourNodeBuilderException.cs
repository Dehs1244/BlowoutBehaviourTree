using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlowoutBehaviourTree.Exceptions
{
    public sealed class BehaviourNodeBuilderException : Exception
    {
        internal BehaviourNodeBuilderException(string message) : base($"An error occurred during node builder. {message}.")
        {

        }
    }
}
