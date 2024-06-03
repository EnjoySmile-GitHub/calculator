using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormInitialization();
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
                labelShowNumber.Text += ((System.Windows.Forms.ButtonBase)sender).Text;
            }
        }

        private void buttonCalculationClick(object sender, EventArgs e)
        {
            double number = 0;
            bool numberCheck = false;

            numberCheck = double.TryParse(labelShowNumber.Text, out number);
            if (!numberCheck)
            {
                MessageBox.Show(
                    "数値として判定されませんでした。",
                    "警告",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            _flgCalculation = true;

            labelShowNumberHistory.Text = number.ToString() + 
                ((System.Windows.Forms.ButtonBase)sender).Text;
            labelShowNumber.Text = number.ToString();

            // TODO:四則演算処理を追加する。
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
            FormInitialization();
        }

        private void buttonDecimalPoint_Click(object sender, EventArgs e)
        {
            if (!labelShowNumber.Text.Contains("."))
            {
                labelShowNumber.Text += ((System.Windows.Forms.ButtonBase)sender).Text;
            }
        }

        /// <summary>
        /// フォーム初期化
        /// </summary>
        private void FormInitialization()
        {
            labelShowNumber.Text = "0";
            labelShowNumberHistory.Text = "";
            _flgCalculation = false;
        }
    }
}
