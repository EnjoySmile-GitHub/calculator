using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Process
{
    internal class Calculation
    {
        /// <summary>
        /// 加算を行う。
        /// </summary>
        /// <param name="number1">値1</param>
        /// <param name="number2">値2</param>
        /// <returns>計算結果</returns>
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        /// <summary>
        /// 減算を行う。
        /// </summary>
        /// <param name="number1">値1</param>
        /// <param name="number2">値2</param>
        /// <returns>計算結果</returns>
        public static double Sub(double number1, double number2)
        {
            return number1 - number2; 
        }

        /// <summary>
        /// 掛け算を行う。
        /// </summary>
        /// <param name="number1">値1</param>
        /// <param name="number2">値2</param>
        /// <returns>計算結果</returns>
        public static double Mul(double number1, double number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// 割り算を行う。
        /// </summary>
        /// <param name="number1">値1</param>
        /// <param name="number2">値2</param>
        /// <returns>計算結果</returns>
        public static double Div(double number1, double number2)
        {
            return number1 / number2;
        }
    }
}
