using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Stock.Trader.WeiTuo;
using Stock.Trader.WeiTuo.HuaTai;

namespace StockTrader
{
    public partial class Form1 : Form
    {
        I_StockTrader trader = null;
        public Form1()
        {
            InitializeComponent();
            trader = new HuaTaiStockTrader();
            trader.Init();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            trader = new HuaTaiStockTrader();
            trader.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trader.SellStock(textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trader.BuyStock(textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trader.CancelStock(textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            trader.GetCashInfo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            trader.PurchaseFundSZ(textBox1.Text, float.Parse(textBox2.Text));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            trader.RedempteFundSZ(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            trader.MergeFundSZ(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            trader.PartFundSZ(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            trader.PurchaseFundSH(textBox1.Text, float.Parse(textBox2.Text));

        }

        private void button14_Click(object sender, EventArgs e)
        {
            trader.RedempteFundSH(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            trader.MergeFundSH(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            trader.PartFundSH(textBox1.Text, int.Parse(textBox3.Text));
        }

    }
}
