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
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void WalletImg_Click(object sender, EventArgs e)
        {
            WalletForm.WaFo.Show();
            this.Close();
        }

        private void ChartImg_Click(object sender, EventArgs e)
        {
            ChartForm chartForm = new ChartForm();
            chartForm.Show();
            this.Close();
        }

        private void ExitImg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < WalletForm.WaFo.movmentName.Count; i++)
            {
                NameList.Items.Insert(0,WalletForm.WaFo.movmentName[i]);
                MovmentDateList.Items.Insert(0,WalletForm.WaFo.movmentDate[i].ToShortDateString());
                AmountList.Items.Insert(0, WalletForm.WaFo.amount[i]);
                AddDateList.Items.Insert(0,WalletForm.WaFo.historyTime[i].ToShortDateString());
            }
        }

        private void SearchTxtbox_TextChanged(object sender, EventArgs e)
        {
            if (SearchTxtbox.Text == "")
            {
                NameList.Items.Clear();
                for (int i = 0; i < WalletForm.WaFo.movmentName.Count; i++)
                {
                    NameList.Items.Insert(0, WalletForm.WaFo.movmentName[i]);
                    MovmentDateList.Items.Insert(0, WalletForm.WaFo.movmentDate[i].ToShortDateString());
                    AmountList.Items.Insert(0, WalletForm.WaFo.amount[i]);
                    AddDateList.Items.Insert(0, WalletForm.WaFo.historyTime[i].ToShortDateString());
                }
                return;
            }

            List<int> list_index = new List<int>();
            for (int i = 0; i < SearchTxtbox.TextLength; i++)
            {
                for(int j = 0; j < NameList.Items.Count; j++)
                {
                    for (int h = 0; h < NameList.Items[j].ToString().Length; h++)
                    {
                        if (SearchTxtbox.Text[i] == NameList.Items[j].ToString()[h] && !list_index.Contains(j))
                        {
                            list_index.Add(j);
                        }
                    }
                }
            }
            NameList.Items.Clear();
            if (list_index.Count > 0)
                for (int i = 0; i < list_index.Count; i++)
                {
                    MessageBox.Show(i.ToString());
                    NameList.Items.Insert(0, WalletForm.WaFo.movmentName[list_index[i]]);
                    //MovmentDateList.Items.Insert(0, WalletForm.WaFo.movmentDate[list_index[i]].ToShortDateString());
                    //AmountList.Items.Insert(0, WalletForm.WaFo.amount[list_index[i]]);
                    //AddDateList.Items.Insert(0, WalletForm.WaFo.historyTime[list_index[i]].ToShortDateString());
                }
            list_index.Clear();
        }
    }
}
