using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevisionApplication.Services
{
    public class DummyService
    {
        public bool CheckData()
        {
            return true;
        }
        public int GetNumber()
        {
            return new Random().Next();
        }
        public int TakeRangeAndGetNumber(int min,int max)
        {
            return new Random().Next(min,max);
        }
        public void ExceptionCheck(int n1,int n2)
        {
            int result = 0;
            result = n1 / n2;
            //return result;
        }
    }
}
