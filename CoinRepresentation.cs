using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctionTask
{

    /// <summary>
    ///  This class contains a static method Solve and a static Hashtable.
    ///  It will provide unqiue combinations, which add up to original value.
    /// </summary

    public class CoinRepresentation
    {

        public static List<long> CreateList(long value)
        {
            List<long> twok = new List<long>();
            int k = 0;
            do
            {
                twok.Add((long)Math.Pow(2, k)); twok.Add((long)Math.Pow(2, k));
                k++;

            } while (value > Math.Pow(2, k));
            return twok;
        }


        /// <summary>
        ///  The following Dictonary will contain the combination which will be stored through the progression of the program
        ///  furthermore, since considering it's static status, the Dictonary will assist for values closer to the maximum
        ///  memo is required to optimise the space and time required, to prevent values from requiring extra coins
        ///  e.g. if the value is 10, the maximum consideration would have to be 2^3 (nothing greater)
        /// </summary
        private static Dictionary<long, long> memo = new Dictionary<long, long>();

        /// <summary>
        /// The solve method will perform a recursion, solving the total number of unique combination possible for a 2^k, where only 2 of each coin exists
        /// Duplicated combinations will be considered as "1" solution contribution.
        /// The last execution of the Solve will add identify the original as a key, and the total combination as a value (in respect to the key)
        /// Overall, the method will return a long varaible signifiying the the unqiue combination require for the value
        /// </summary
        public static long Solve(long value)
        {
            // base cases
            if (value == 0) return 1; // All combination are discovered (recursion will concatinate Solve(value/2 + solve(value / 2 - 1)) to produce total)

            if (!memo.ContainsKey(value)) // if the value is completely new (not stored in the dic), and has not yet been explored, the following will occur
            {
                if (value % 2 == 0) // even number
                {
                    memo.Add(value, Solve(value / 2) + Solve(value / 2 - 1));
                }
                else // odd number
                {
                    memo.Add(value, Solve((value - 1) / 2));
                }
            }
            return memo[value];
        }

    }
}

