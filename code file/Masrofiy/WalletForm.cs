using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Masrofiy
{
    public partial class WalletForm : Form
    {
        public static WalletForm WaFo = new WalletForm();
        public List<string> movmentName = new List<string>();
        public List<double> amount = new List<double>();
        public List<DateTime> movmentDate = new List<DateTime>();
        public List<DateTime> historyTime = new List<DateTime>();
        public double Amount; 
        public WalletForm()
        {
            InitializeComponent();
            Amount =Convert.ToDouble( BalanceLabel.Text);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            double x;
            string amo = AmountTxtbox.Text;
            if (!double.TryParse(amo, out x))
            {
                MessageBox.Show("please just enter number!!");
                return;
            }
            LastBalanceLabel.Text = BalanceLabel.Text;
            movmentName.Add(MovmentNameTxtbox.Text);
            amount.Add(Convert.ToDouble(amo));
            BalanceLabel.Text = (Convert.ToDouble(amo) + Convert.ToDouble(BalanceLabel.Text)).ToString();
            movmentDate.Add(DateMovementTxtbox.Value);
            historyTime.Add(DateTime.Now);
            Amount = Convert.ToDouble(BalanceLabel.Text);
            AmountTxtbox.Text = "";
            MovmentNameTxtbox.Text = "";
        }
        private void ExitImg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeductBtn_Click(object sender, EventArgs e)
        {
            double x;
            string amo = AmountTxtbox.Text;
            if (!double.TryParse(amo, out x))
            {
                MessageBox.Show("please just enter number!!");
                return;
            }
            LastBalanceLabel.Text = BalanceLabel.Text;
            movmentName.Add(MovmentNameTxtbox.Text);
            amount.Add(-Convert.ToDouble(amo));
            movmentDate.Add(DateMovementTxtbox.Value);
            BalanceLabel.Text = (Convert.ToDouble(BalanceLabel.Text) - (Convert.ToDouble(amo))).ToString();
            historyTime.Add(DateTime.Now);
            Amount = Convert.ToDouble(BalanceLabel.Text);
            AmountTxtbox.Text = "";
            MovmentNameTxtbox.Text = "";
        }

        private void ChartImg_Click(object sender, EventArgs e)
        {
            ChartForm chartForm = new ChartForm();
            chartForm.Show();
            this.Hide();
            WaFo = this;
        }

        private void HistoyImg_Click(object sender, EventArgs e)
        {
            HistoryForm histForm = new HistoryForm();
            histForm.Show();
            this.Hide();
        }

        private void WalletForm_Load(object sender, EventArgs e)
        {
            movmentName.Add("Lorns");
            amount.Add(20);
            movmentDate.Add(DateTime.Now);
            historyTime.Add(DateTime.Now);
            movmentName.Add("Barjas");
            amount.Add(23);
            movmentDate.Add(DateTime.Now);
            historyTime.Add(DateTime.Now);
            movmentName.Add("ajar");
            amount.Add(40);
            movmentDate.Add(DateTime.Now);
            historyTime.Add(DateTime.Now);
            movmentName.Add("dady");
            amount.Add(10);
            movmentDate.Add(DateTime.Now);
            historyTime.Add(DateTime.Now);
        }

       
    }
}
