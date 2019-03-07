using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class Extensions
    {
        public static int GetLength(this int num)
        {
            return num.ToString().Length;
        }
    }
    class Program
    {
        static int[] GetFirstThreeNum(string sequenceOfNum, int numLength)
        {
            int[] firstThreeNums = new int[3];
            int currentPosition = 0; 
            for (int i = 0; i < 3; i++)
            {
                firstThreeNums[i] = Convert.ToInt32(sequenceOfNum.Substring(currentPosition, numLength));
                currentPosition += numLength;
            }
            return firstThreeNums;
        }

        //the method simply assumes that the first 3 numbers are a sequence (taking into account the omission of the sequence members)
        static bool ValidSequenceByThreeNum(int[] firstThreeNums)
        {
            byte countOfAssumption = 0; //if after the for loop the counter will be equal to 2, then most likely it is a sequence
            for (int i = 1; i < 3; i++)
            {
                if ((firstThreeNums[i] - firstThreeNums[i - 1] == 1) || (firstThreeNums[i] - firstThreeNums[i - 1] == 2))
                {
                    countOfAssumption++;
                }
            }
            if (countOfAssumption == 2)
            {
                return true;
            }
            return false;
        }

        //if the string is a sequence, the method will return it (as a list), otherwise it will return a list with the first elements equal to -1
        static List<int> GetSeq(string sequenceOfNum, int firstNumLength)
        {
            int previousNum = Convert.ToInt32(sequenceOfNum.Substring(0, firstNumLength));
            int currentPosition = previousNum.GetLength();
            int GetNextNum(int numberLength)
            {
                return Convert.ToInt32(sequenceOfNum.Substring(currentPosition, numberLength));
            }
            List<int> sequence = new List<int>();
            sequence.Add(previousNum);

            while (currentPosition < sequenceOfNum.Length)
            {
                int currentNum = 777; //the variable is simply initialized with a random number. There is nothing like that special:)
                                      //the first or the second conditional will change the value

                int incPrevious = previousNum + 1;
                if (incPrevious.GetLength() == previousNum.GetLength())
                {
                    currentNum = GetNextNum(previousNum.GetLength());
                }
                //this condition correctly parses string for example 891011 ... will be get like 8 9 10 11 not like 8 9 1 0 1 1
                if (incPrevious.GetLength() > previousNum.GetLength())
                {
                    int nextNumLength = previousNum.GetLength() + 1;

                    currentNum = GetNextNum(nextNumLength);
                }
                sequence.Add(currentNum);
                currentPosition += currentNum.GetLength();
                previousNum = currentNum;
            }

            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] - sequence[i - 1] > 2)
                {
                    sequence[0] = -1;
                    return sequence;
                }
            }

            return sequence;
        }

        static int SearchMissing(List<int> sequence)
        {
            int checkingNum = sequence[0];
            int missingNum = 322; //the variable is simply initialized with a random number.
                                  //int the for loop value will be changed 
            int missedCount = 0; //the variable is responsible for the number of mismatches
            for (int i = 0; i < sequence.Count; i++)
            {
                if (checkingNum++ != sequence[i])
                {
                    missingNum = checkingNum - 1;
                    missedCount++;
                    checkingNum++;
                }
            }
            if (missedCount >= 2) return -1;
            if (missedCount == 1) return missingNum;
            return -1;
        }

        public static int Execute(string sequenceStr)
        {
            List<int> sequence = new List<int>();
            for (int numLength = 1; numLength < (sequenceStr.Length / 3) + 1; numLength++)
            {
                int[] firstThreeNum = GetFirstThreeNum(sequenceStr, numLength);
                if (ValidSequenceByThreeNum(firstThreeNum))
                {
                    sequence = GetSeq(sequenceStr, numLength);
                    if (sequence[0] != -1)
                    {
                        break;
                    }
                }
            }
            return SearchMissing(sequence);
        }

        static void Main(string[] args)
        {
            string sequenceStr;
            int result;
            //---------------- seq from 1 to 9 ----------------\\
            sequenceStr = "123456789";      // nothing is missed
            result = Execute(sequenceStr);  // output -1

            sequenceStr = "12456789";       // 3 is missed
            result = Execute(sequenceStr);  // output 3

            sequenceStr = "1245689";        // 3 and 7 are missed 
            result = Execute(sequenceStr);  // output -1

            //---------------- seq from 10 to 19 ----------------\\
            sequenceStr = "10111213141516171819";   // nothing is missed
            result = Execute(sequenceStr);          // output -1

            sequenceStr = "101112131416171819";     // 15 is missed
            result = Execute(sequenceStr);          // output 15

            sequenceStr = "10111213141516171819";   // 11 and 15 are missed
            result = Execute(sequenceStr);          // output -1

            //---------------- seq from 120 to 129 ----------------\\
            sequenceStr = "120121122123124125126127128129";     // nothing is missed
            result = Execute(sequenceStr);                      // output -1

            sequenceStr = "120121122123124125127128129";        // 126 is missed
            result = Execute(sequenceStr);                      // output 126

            sequenceStr = "120122123124125127129";              // 121, 126 and 128 are missed
            result = Execute(sequenceStr);                      // output -1

            //---------------- seq from 1 to 18 ----------------\\
            sequenceStr = "134567891012131415161718";          // 2 and 11 are missed
            result = Execute(sequenceStr);                     // output -1

            //---------------- seq from 54321 to 54325 ----------------\\
            sequenceStr = "54321543235432454325";              //  54322 is missed
            result = Execute(sequenceStr);                     // output 54322

            //---------------- seq from 5 to 11 ----------------\\
            sequenceStr = "5678911";                           // 10 is missed
            result = Execute(sequenceStr);                     // output 10

            Console.WriteLine($"For {sequenceStr} answer is {result}");
        }
    }
}
