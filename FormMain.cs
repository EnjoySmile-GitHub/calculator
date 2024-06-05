using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using calculator.Process;

namespace calculator
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 計算フラグ
        /// </summary>
        /// <remarks>
        /// 次に演算子ボタンを押されたら、計算を行っても良い。
        /// </remarks>
        private bool _flgCalculation = false;

        /// <summary>
        /// 数値クリアフラグ
        /// </summary>
        private bool _flgClearNumber = false;

        /// <summary>
        /// 計算を行う演算子
        /// </summary>
        private string _inputSymbol = string.Empty;


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            formInitialization();
        }

        private void buttonNumberClick(object sender, EventArgs e)
        {
            if (labelShowNumber.Text.Equals("0"))
            {
                if (!((System.Windows.Forms.ButtonBase)sender).Text.Equals("00"))
                {
                    labelShowNumber.Text = ((System.Windows.Forms.ButtonBase)sender).Text;
                }
            }
            else
            {
                if (_flgClearNumber)
                {
                    labelShowNumber.Text = ((System.Windows.Forms.ButtonBase)sender).Text;
                    _flgClearNumber = false;
                }
                else
                {
                    labelShowNumber.Text += ((System.Windows.Forms.ButtonBase)sender).Text;
                }
            }
        }

        private void buttonCalculationClick(object sender, EventArgs e)
        {
            double numberNow = 0;
            if (!double.TryParse(labelShowNumber.Text, out numberNow))
            {
                MessageBox.Show(
                    "数値として判定されませんでした。",
                    "警告",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            if (_flgCalculation)
            {
                try
                {
                    double numberHistory = double.Parse(
                    labelShowNumberHistory.Text.Substring(
                        0,
                        labelShowNumberHistory.Text.IndexOf(" ")));

                    double answer = getCalculation(numberHistory, numberNow, _inputSymbol);
                    labelShowNumber.Text = answer.ToString();

                    setlabelShowNumberHistory(numberHistory, numberNow, _inputSymbol);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(
                    "計算処理でエラーが発生しました。\r\n" + ex,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                labelShowNumberHistory.Text = numberNow.ToString() + " " + 
                    ((System.Windows.Forms.ButtonBase)sender).Text;
                labelShowNumber.Text = numberNow.ToString();
                _inputSymbol = ((System.Windows.Forms.ButtonBase)sender).Text;
            }

            _flgCalculation = true;
            _flgClearNumber = true;
        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            if (labelShowNumber.Text.Length > 1)
            {
                labelShowNumber.Text = labelShowNumber.Text.Substring(
                    0,
                    labelShowNumber.Text.Length - 1);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            formInitialization();
        }

        private void buttonDecimalPoint_Click(object sender, EventArgs e)
        {
            if (!labelShowNumber.Text.Contains("."))
            {
                labelShowNumber.Text += ((System.Windows.Forms.ButtonBase)sender).Text;
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void formInitialization()
        {
            labelShowNumber.Text = "0";
            labelShowNumberHistory.Text = "";
            _flgCalculation = false;
            _flgClearNumber = false;
            _inputSymbol = string.Empty;
        }

        /// <summary>
        /// 計算を行う
        /// </summary>
        /// <param name="number1">値1</param>
        /// <param name="number2">値2</param>
        /// <param name="symbol">演算子</param>
        /// <returns>計算結果</returns>
        private double getCalculation(double number1, double number2, string symbol)
        {
            double answer = 0.0;
            switch (_inputSymbol)
            {
                case "+":
                    answer = Calculation.Add(number1, number2);
                    break;
                case "-":
                    answer = Calculation.Sub(number1, number2);
                    break;
                case "*":
                    answer = Calculation.Mul(number1, number2);
                    break;
                case "/":
                    answer = Calculation.Div(number1, number2);
                    break;
                default:
                    break;
            }

            return answer;
        }

        /// <summary>
        /// 計算履歴にセットする
        /// </summary>
        /// <param name="number1">値1</param>
        /// <param name="number2">値2</param>
        /// <param name="symbolOld">ひとつ前の演算子</param>
        /// <param name="symbolNow">現在の演算子</param>
        private void setlabelShowNumberHistory(double number1, double number2, string symbolOld, string symbolNow)
        {
            if(symbolNow == "=")
            {
                // TODO:ここから行う。計算履歴を表示するところから。
            }
            else
            {
                
            }
        }
    }
}
