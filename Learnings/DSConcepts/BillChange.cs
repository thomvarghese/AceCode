using System.Collections.Generic;
using System.Linq;

namespace DSConcepts
{
    public class BillChange
    {
        public static bool IsBillChangeable(List<int> bills)
        {
            if (bills == null || !bills.Any())
                return true;
            int fiveCount = 0;
            int tenCount = 0;
            foreach (var bill in bills)
            {
                if (bill == 5)
                {
                    ++fiveCount;
                }
                else if (bill == 10)
                {
                    if (fiveCount < 0)
                    {
                        return false;
                    }
                    ++tenCount;
                    --fiveCount;
                }
                else if (bill == 20)
                {
                    if (tenCount > 0)
                    {
                        tenCount--;
                        if (fiveCount > 0)
                        {
                            fiveCount--;
                        }
                        else
                            return false;
                    }
                    else if (fiveCount > 2)
                    {
                        fiveCount -= 3;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
