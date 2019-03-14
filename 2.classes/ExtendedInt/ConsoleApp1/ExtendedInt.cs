using System;
using System.Numerics;

namespace ConsoleApp1
{
    public class ExtendedInt
    {
        private string val;

        public string Value
        {
            get { return val; }
            set
            {
                if (IsConst)
                {
                    throw new Exception("The number is a const, you can't assign anything in the const");
                }
                
                if (CheckNumber(value))
                {
                    val = value;
                }
                else
                {
                    throw new Exception($"{value} isn't an int number");
                }
                
            }
        }
        public bool IsConst { get; private set; }
        public bool IsNegative { get; private set; }

        private ExtendedInt(bool isConst)
        {
            IsConst = isConst;
        }
        public ExtendedInt(string number, bool isConst = false) : this(isConst)
        {
            Value = number;
            IsNegative = number[0] == '-';
        }
        public ExtendedInt(long number, bool isConst = false) : this(isConst)
        {
            Value = number.ToString();
            IsNegative = number.ToString()[0] == '-';
        }
        public ExtendedInt(ExtendedInt instance, bool isConst = false) : this(isConst)
        {
            Value = instance.Value;
            IsNegative = instance.IsNegative;
        }

        private bool CheckNumber(string num)
        {
            if (num.Length < 1)
            {
                return false;
            }

            if (num.Length == 1 && !char.IsDigit(num[0]))
            {
                return false;
            }
            //IsNegative = num[0] == '-';
            if (num[0] == '-' || char.IsDigit(num[0]))
            {
                for (int i = 1; i < num.Length; i++)
                {
                    if (!char.IsDigit(num[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        private int GetMaxLength(string left, string right)
        {
            return left.Length > right.Length ? left.Length : right.Length;
        }
        private void ComplimentByZero(ref string str, int maxLength)
        {
            int zeroNeeded = maxLength - str.Length;
            str = new string('0', zeroNeeded) + str;
        }
        private void DeleteMinusSign(ref string str)
        {
            if (str[0] == '-')
            {
                str = str.Remove(0, 1);
            }
        }
        private void DeleteFirstZeroes(ref string str)
        {
            int countOfZeroes = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                {
                    countOfZeroes++;
                }
                else
                {
                    break;
                }
            }
            str = str.Remove(0, countOfZeroes);
        }
        private void AddMinusSign(ref string str)
        {
            str = '-' + str;
        }
        //compare two strings, returns -1 - if str1 > str2; 0 - if str1 == str2; 1 - if str1 < str2
        private sbyte CompareNumStrings(string left, string right)
        {
            if (left.Length > right.Length) return -1;
            if (left.Length < right.Length) return 1;
            return 0;
        }
        //compare strings with the same length; if str1 has a more bigger num than str2 
        //the method returns -1 else returns 1
        private sbyte CompareSameLengthStrings(string left, string right)
        {
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] == right[i])
                {
                    continue;
                }
                else
                {
                    if (left[i] > right[i])
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }
        private string GetResidual(string bigger, string lower)
        {
            string residual = "";

            byte[] biggerNum = new byte[bigger.Length];
            byte[] lowerNum = new byte[lower.Length];
            for (int i = 0; i < biggerNum.Length; i++)
            {
                biggerNum[i] = Convert.ToByte(bigger[i].ToString());
                lowerNum[i] = Convert.ToByte(lower[i].ToString());
            }

            for (int i = biggerNum.Length - 1; i >= 0; i--)
            {
                byte topDig = biggerNum[i];
                byte bottomDig = lowerNum[i];
                if (topDig >= bottomDig)
                {
                    residual = (topDig - bottomDig) + residual;
                }
                else
                {
                    residual = (topDig + 10 - bottomDig) + residual;
                    for (int j = i - 1; j >= 0; j++)
                    {
                        if (biggerNum[j] > 0)
                        {
                            biggerNum[j]--;
                            break;
                        }
                        if (biggerNum[j] == 0)
                        {
                            biggerNum[j] = 9;
                        }
                    }
                }
            }

            DeleteFirstZeroes(ref residual);
            return residual;
        }

        public void Add(string term)
        {
            if (!CheckNumber(term))
            {
                throw new Exception($"{term} isn't an int number");
            }
            if (this.IsConst)
            {
                throw new Exception("The number is a const, you can't assign anything in the const");
            }
            bool isTermNegative = term[0] == '-';

            if (this.IsNegative)
            {
                DeleteMinusSign(ref val);
            }
            if (isTermNegative)
            {
                DeleteMinusSign(ref term);
            }

            bool bothNegative = false;
            if (this.IsNegative && isTermNegative)
            {
                bothNegative = true;
            }
            bool bothPositive = false;
            if (!this.IsNegative && !isTermNegative)
            {
                bothPositive = true;
            }
            if (bothNegative || bothPositive)
            {
                int maxLength = GetMaxLength(Value, term);
                maxLength++;
                ComplimentByZero(ref val, maxLength);
                ComplimentByZero(ref term, maxLength);

                byte carryByte = 0;
                string sum = "";
                for (int i = maxLength - 1; i >= 0; i--)
                {
                    byte ValueDig = Convert.ToByte(Value[i].ToString());
                    byte termDig = Convert.ToByte(term[i].ToString());
                    byte byteSum = (byte)(ValueDig + termDig);
                    sum = (byteSum % 10).ToString() + sum;
                    carryByte = (byte)(byteSum / 10);
                }

                DeleteFirstZeroes(ref sum);
                if (bothNegative)
                {
                    AddMinusSign(ref sum);
                }
                val = sum;
            }
        }
        public void Add(long term)
        {
            Add(term.ToString());
        }
        public void Add(ExtendedInt instance)
        {
            Add(instance.Value);
        }

        public void Sub(string subtrahend)
        {
            if (!CheckNumber(subtrahend))
            {
                throw new Exception($"{subtrahend} isn't an int number");
            }
            if (this.IsConst)
            {
                throw new Exception("The number is a const, you can't assign anything in the const");
            }
            bool isSubtrahendNegative = subtrahend[0] == '-';

            //process x - (-x)
            if (!this.IsNegative && isSubtrahendNegative)
            {
                DeleteMinusSign(ref subtrahend);
                Add(subtrahend);
                return;
            }

            //process (-x) - x
            if (this.IsNegative && !isSubtrahendNegative)
            {
                AddMinusSign(ref subtrahend);
                Add(subtrahend);
                return;
            }

            DeleteMinusSign(ref val);
            DeleteMinusSign(ref subtrahend);
            //process x - x where x == x 
            if (Value == subtrahend)
            {
                Value = "0";
                return;
            }

            sbyte compareInfo = CompareNumStrings(Value, subtrahend);
            if (compareInfo == 0)
            {
                compareInfo = CompareSameLengthStrings(Value, subtrahend);
            }

            int maxLength = GetMaxLength(Value, subtrahend);
            maxLength++;
            ComplimentByZero(ref val, maxLength);
            ComplimentByZero(ref subtrahend, maxLength);

            //process (-x1) -(-x2) where x1 > x2
            if (this.IsNegative && isSubtrahendNegative && compareInfo == -1)
            {
                string result = GetResidual(Value, subtrahend);
                AddMinusSign(ref result);
                val = result;
                return;
            }

            //process (-x1) -(-x2) where x1 < x2
            if (this.IsNegative && isSubtrahendNegative && compareInfo == 1)
            {
                string result = GetResidual(subtrahend, Value);
                val = result;
                return;
            }

            //process x1 -x2 where x1 > x2
            if (compareInfo == -1)
            {
                string result = GetResidual(Value, subtrahend);
                val = result;
                return;
            }

            //process x1 -x2 where x1 < x2
            if (compareInfo == 1)
            {
                string result = GetResidual(subtrahend, Value);
                AddMinusSign(ref result);
                val = result;
                return;
            }
        }
        public void Sub(long subtrahend)
        {
            Sub(subtrahend.ToString());
        }
        public void Sub(ExtendedInt instance)
        {
            Sub(instance.Value);
        }

        public void Div(string denominator)
        {
            BigInteger a, b;
            try
            {
                a = new BigInteger(Convert.ToInt64(Value));
                
            }
            catch (OverflowException e)
            {
                a = new BigInteger(long.MaxValue);
            }
            try
            {
                b = new BigInteger(Convert.ToInt64(denominator));

            }
            catch (OverflowException e)
            {
                b = new BigInteger(long.MaxValue);
            }
            if (a == 0)
            {
                throw new DivideByZeroException("");
            }
            Value = (a / b).ToString();
        }
        public void Div(long denominator)
        {
            Div(denominator.ToString());
        }
        public void Div(ExtendedInt instance)
        {
            Div(instance.Value);
        }

        public void Mul(string denominator)
        {
            BigInteger a, b;
            try
            {
                a = new BigInteger(Convert.ToInt64(Value));

            }
            catch (OverflowException e)
            {
                a = new BigInteger(long.MaxValue);
            }
            try
            {
                b = new BigInteger(Convert.ToInt64(denominator));

            }
            catch (OverflowException e)
            {
                b = new BigInteger(long.MaxValue);
            }

            Value = (a * b).ToString();
        }
        public void Mul(long denominator)
        {
            Mul(denominator.ToString());
        }
        public void Mul(ExtendedInt instance)
        {
            Mul(instance.Value);
        }

        public bool Odd()
        {
            byte lastDig = Convert.ToByte(Value[Value.Length - 1].ToString());
            return lastDig % 2 != 0;
        }
        public bool Even()
        {
            byte lastDig = Convert.ToByte(Value[Value.Length - 1].ToString());
            return lastDig % 2 != 1;
        }
    }
}