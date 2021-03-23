using System;
using System.Collections.Generic;

namespace string_calculator
{
    [Serializable]
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException()
        {

        }

        public NegativesNotAllowedException(List<int> negatives)
            : base($"Negatives not allowed: {String.Join(", ", negatives)}")
        {

        }
    
    }
}
