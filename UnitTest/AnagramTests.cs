using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace Anagram
{
    [TestFixture]
    public class AnagramTests
    {
        List<Tuple<string, string>> valueList = new List<Tuple<string, string>>();        

        [Test]       
        public void Anagram_IsAnagram_True()
        {
            valueList.Add(new Tuple<string,string>("They see", "The eyes"));
            List<bool> result =(List<bool>)new Anagram().Check(valueList);
            foreach (var item in result)
            {
                Assert.IsTrue(item);
            }            
        }

        [Test]
        public void Anagram_IsNotAnagram_False()
        {
            valueList.Add(new Tuple<string, string>("They see many", "The eyes"));
            List<bool> result = (List<bool>)new Anagram().Check(valueList);
            foreach (var item in result)
            {
                Assert.IsFalse(item);
            }
        }

        [Test]
        public void Anagram_IsEmptyConfirmPwd_False()
        {
            valueList.Add(new Tuple<string, string>("They see many", ""));
            List<bool> result = (List<bool>)new Anagram().Check(valueList);
            foreach (var item in result)
            {
                Assert.IsFalse(item);
            }
        }

        [Test]
        public void Anagram_BothEmpty_False()
        {
            valueList.Add(new Tuple<string, string>("", ""));
            List<bool> result = (List<bool>)new Anagram().Check(valueList);
            foreach (var item in result)
            {
                Assert.IsFalse(item);
            }
        }
    }
}
