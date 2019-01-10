using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//https://fivethirtyeight.com/features/when-will-the-arithmetic-anarchists-attack
/*The year is 2000, and an arithmetical anarchist group has an idea. 
 * For the next 100 years, it will vandalize a famous landmark whenever 
 * the year (in two-digit form, for example this year is “18”) is the 
 * product of the month and date (i.e. month × date = year, in the MM/DD/YY format).
 * 
 * A few questions about the lawless ensuing century: How many attacks will happen 
*between the beginning of 2001 and the end of 2099? What year will see the most vandalism? 
* The least? What will be the longest gap between attacks?
*/
namespace Riddler_4_6_18
{
    class Program
    {
        static int mostYear;
        static int mostYearAttacks = 0;
        static int leastYear;
        static int leastYearAttacks = 0;
        static int longestGap;
        static int totalAttacks;

        static void Main(string[] args)
        {
            countAttacks();
            Debug.WriteLine("Year with most attacks: 20" + mostYear);
            Debug.WriteLine("Number of attacks that year: " + mostYearAttacks);
            Debug.WriteLine("Year with least attacks: 20" + leastYear.ToString("D2"));
            Debug.WriteLine("Number of attacks that year:" + leastYearAttacks);
            Debug.WriteLine("Longest gap between attacks in days: " + longestGap);
            Debug.WriteLine("Total number of attacks: " + totalAttacks);

            Console.Read();
        }

        public static void countAttacks()
        {
            
            int attacks = 0;
            int gap = 0;
            for(int y = 1; y < 100; y++)
            {
                for(int m = 1; m < 13; m++)
                {
                    int maxDays = 30;
                    if ((m == 1) || (m == 3) || (m == 5) || (m == 7) || (m == 8) || (m == 10) || (m == 12))
                    {
                        maxDays = 31;
                    }
                    else if (m == 2)
                    {
                        if (y % 4 == 0)
                        {
                            maxDays = 29;
                        }
                        else
                        {
                            maxDays = 28;
                        }
                    }
                    
                    for(int d = 1; d < maxDays + 1; d++)
                    {
                        if(productMatches(y, m, d))
                        {
                            attacks++;
                            if (gap > longestGap)
                            {
                                
                                longestGap = gap;
                                System.Console.WriteLine(longestGap);
                            }
                            gap = 0;
                        }
                        else
                        {
                            gap++;
                        }
                    }
                }
                if (attacks > mostYearAttacks)
                {
                    mostYearAttacks = attacks;
                    mostYear = y;
                }
                if (attacks < leastYearAttacks)
                {
                    leastYearAttacks = attacks;
                    leastYear = y;
                }
                totalAttacks += attacks;
                attacks = 0;
            }
        }

        public static bool productMatches(int y, int m, int d)
        {
            return y == m * d;
        }
    }
}
