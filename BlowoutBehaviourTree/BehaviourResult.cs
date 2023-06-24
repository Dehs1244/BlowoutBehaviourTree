using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlowoutBehaviourTree
{
    public struct BehaviourResult<T>
    {
        private T _result;
        private IEnumerable<T> _resultEnumerable;
        public BehaviourTreeStatus Status;

        public BehaviourResult(BehaviourTreeStatus status, T result)
        {
            _result = result;
            _resultEnumerable = null;
            Status = status;
        }

        public BehaviourResult(BehaviourTreeStatus status, IEnumerable<T> result)
        {
            _resultEnumerable = result;
            _result = default;
            Status = status;
        }

        public object GetRaw() => _result == null ? _resultEnumerable : _result;

        public T GetObject() => _result;
        public IEnumerable<T> GetEnumerableObject() => _resultEnumerable;
    }
}
