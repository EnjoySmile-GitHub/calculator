using System;
using System.Windows.Forms;

using calculator.Process;

namespace calculator
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 数値クリアフラグ
        /// </summary>
        private bool _flgClearNumber = false;

        /// <summary>
        /// 数値を一時保存
        /// </summary>
        private double _tempNumber = 0;

        /// <summary>
        /// 演算子を一時保存
        /// </summary>
        private string _tempSymbol = string.Empty;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            formInitialization();
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

        private void buttonNumberClick(object sender, EventArgs e)
        {
            if (_flgClearNumber)
            {
                labelShowNumber.Text = ((System.Windows.Forms.ButtonBase)sender).Text;
                _flgClearNumber = false;
            }
            else
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

            if (_tempNumber == 0)
            {
                if (!((System.Windows.Forms.ButtonBase)sender).Text.Equals("="))
                {
                    _flgClearNumber = true;
                    _tempNumber = numberNow;
                    _tempSymbol = ((System.Windows.Forms.ButtonBase)sender).Text;

                    setEnzansilabelShowNumberHistory(_tempNumber, _tempSymbol);
                }
            }
            else
            {
                if (_tempSymbol.Equals(""))
                {
                    if (!((System.Windows.Forms.ButtonBase)sender).Text.Equals("="))
                    {
                        _tempNumber = numberNow;
                        _tempSymbol = ((System.Windows.Forms.ButtonBase)sender).Text;

                        setEnzansilabelShowNumberHistory(_tempNumber, _tempSymbol);
                    }
                }
                else
                {
                    if (((System.Windows.Forms.ButtonBase)sender).Text.Equals("="))
                    {
                        double answer = getCalculation(_tempNumber, numberNow, _tempSymbol);
                        setEquallabelShowNumberHistory(_tempNumber, numberNow, _tempSymbol);

                        labelShowNumber.Text = answer.ToString();
                        _tempNumber = 0;
                        _tempSymbol = "";
                    }
                    else
                    {
                        _tempSymbol = ((System.Windows.Forms.ButtonBase)sender).Text;
                        setEnzansilabelShowNumberHistory(_tempNumber, _tempSymbol);
                    }
                }
            }
        }

        /// <summary>
        /// フォーム初期化
        /// </summary>
        private void formInitialization()
        {
            labelShowNumber.Text = "0";
            labelShowNumberHistory.Text = "";
            _flgClearNumber = false;
            _tempNumber = 0;
            _tempSymbol = "";
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
            switch (_tempSymbol)
            {
                case "+":
                    answer = Calculation.Add(number1, number2);
                    break;
                case "-":
                    answer = Calculation.Sub(number1, number2);
                    break;
                case "×":
                    answer = Calculation.Mul(number1, number2);
                    break;
                case "÷":
                    answer = Calculation.Div(number1, number2);
                    break;
                default:
                    break;
            }

            return answer;
        }

        /// <summary>
        /// 「=」の場合、計算履歴にセットする。
        /// </summary>
        /// <param name="number1">値1</param>
        /// <param name="number2">値2</param>
        /// <param name="symbolOld">演算子</param>
        private void setEquallabelShowNumberHistory(double number1, double number2, string symbolOld)
        {
            labelShowNumberHistory.Text = number1 + " " + symbolOld + " " + number2;
        }

        /// <summary>
        /// 「+,-,×,÷」の場合、計算履歴にセットする。
        /// </summary>
        /// <param name="number">値</param>
        /// <param name="symbol">現在の演算子</param>
        private void setEnzansilabelShowNumberHistory(double number, string symbol)
        {
            labelShowNumberHistory.Text = number + " " + symbol;
        }
    }
}
