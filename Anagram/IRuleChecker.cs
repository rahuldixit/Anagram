using System;
using System.Collections.Generic;
using System.Text;

namespace Anagram
{    
        public interface IRuleChecker
        {
            IList<bool> Check(List<Tuple<string, string>> valueList);
        }    
}
