using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Masrofiy
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
        }
        private void ExitImg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void WalletImg_Click(object sender, EventArgs e)
        {
            WalletForm.WaFo.Show();
            this.Close();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            BalanceLabel.Text = WalletForm.WaFo.Amount.ToString();
            double res = 0;
            for (int i = 29; i >= 0; i--)
            {
                for (int j = 0; j < WalletForm.WaFo.movmentDate.Count; j++)
                {
                    if (WalletForm.WaFo.movmentDate[j].Day == DateTime.Now.AddDays(-i).Day)
                    {
                        res += WalletForm.WaFo.amount[j];
                    }
                }
                AmountChart.Series[0].Points.AddXY(DateTime.Now.AddDays(-i).Day.ToString(), res);
            }
        }

        private void HistoyImg_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();    
            historyForm.Show();
            this.Close();
        }
    }
}
