using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Anagram
{
    public class Anagram : IRuleChecker
    {
        public IList<bool> Check(List<Tuple<string, string>> valueList)
        {
            SortedDictionary<char, int> currentPwdHash = new SortedDictionary<char, int>();
            SortedDictionary<char, int> confirmPwdHash = new SortedDictionary<char, int>();
            List<bool> result = new List<bool>();

            foreach (var item in valueList)
            {
                var currentPwd = item.Item1;
                var confirmPwd = item.Item2;
                if (currentPwd == "" && confirmPwd == "")
                {
                    result.Add(false);
                }
                else
                {
                    currentPwdHash = ParsePwd(currentPwdHash, currentPwd);
                    confirmPwdHash = ParsePwd(confirmPwdHash, confirmPwd);                    
                    result.Add(AreSortedDictionariesEqual(currentPwdHash, confirmPwdHash));
                }
            }
            return result;
        }

        public bool AreSortedDictionariesEqual(SortedDictionary<char, int> dict1, SortedDictionary<char, int> dict2)
        {
            if (dict1.Count != dict2.Count)
            {
                return false;
            }
            else
            {
                for(var i=0; i<dict1.Count;i++)
                {
                    if (dict1.ElementAt(i).Key != dict2.ElementAt(i).Key)
                        return false;
                    if (dict1.ElementAt(i).Value != dict2.ElementAt(i).Value)
                        return false;
                }
            }
            return true;
        }

        public SortedDictionary<char, int> ParsePwd(SortedDictionary<char, int> dict, string pwd)
        {
            foreach (char c in pwd)
            {
                if (!dict.ContainsKey(c))
                    dict.Add(c, 1);
                else
                    dict[c] = (int)dict[c] + 1;
            }
            return dict;
        }
    }
}
