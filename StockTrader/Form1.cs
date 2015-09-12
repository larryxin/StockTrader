/*
 * This library is part of OpenCms -
 * the Open Source Content Management System
 *
 * Copyright (c) qiujoe (http://www.github.com/qiujoe)
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * For further information about StockTrader, please see the
 * project website: http://www.github.com/qiujoe/StockTrader
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

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
using Stock.Trader;
using Stock.Strategy;
using Stock.Strategy.Settings;

namespace StockTrader
{
    public partial class Form1 : Form
    {
        XiaDan xiadan = null;
        public Form1()
        {
            InitializeComponent();
            InitStrategyMenu();
            xiadan = XiaDan.Instance;
            xiadan.Init();
        }

        /// <summary>
        /// 初始化右键菜单策略
        /// </summary>
        private void InitStrategyMenu()
        {
            // 从服务器获取策略数据，
            StrategyDesc[] sds = loadStrategyList();

            foreach (var sd in sds)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = sd.name;
                tsmi.Tag = sd;
                tsmi.Click += new EventHandler(AddStrategyToListView);
                this.miFfjjStrategy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                tsmi});
             }
        }

        /// <summary>
        /// 策略的描述
        /// </summary>
        class StrategyDesc
        {
            public String name;
            public String desc;
            public String clazz;
            public int group;
        }

        private StrategyDesc[] loadStrategyList()
        {
            StrategyDesc[] sd = new StrategyDesc[] { new StrategyDesc() };
//            sd[0] = new StrategyDesc();
            sd[0].clazz = "Stock.Strategy.Settings.RotationStrategyForm";
            sd[0].desc = "说明：西胖子轮动策略";
            sd[0].name = "西胖子轮动策略";
            sd[0].group = 0;

            return sd;
        }

        /// <summary>
        /// 加入策略到列表视图。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AddStrategyToListView(object sender, EventArgs e)
        {
            StrategyDesc sd = (StrategyDesc)((ToolStripMenuItem)sender).Tag;

            BaseSettingForm form = new Stock.Strategy.Settings.RotationStrategyForm();

            StrategyManager.Instance.AddMyStrategy(form.Strategy);

            System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem(new string[] {
            sd.name,
            sd.desc}, -1);
            lvi.Group = this.listView1.Groups[sd.group];
            lvi.Tag = form;
            this.listView1.Items.Add(lvi);

        }

        #region 测试下单
        private void button16_Click(object sender, EventArgs e)
        {
            xiadan = XiaDan.Instance;
            xiadan.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xiadan.SellStock(textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xiadan.BuyStock(textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xiadan.CancelStock(textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            xiadan.GetCashInfo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            xiadan.PurchaseFundSZ(textBox1.Text, float.Parse(textBox2.Text));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            xiadan.RedempteFundSZ(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            xiadan.MergeFundSZ(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            xiadan.PartFundSZ(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            xiadan.PurchaseFundSH(textBox1.Text, float.Parse(textBox2.Text));

        }

        private void button14_Click(object sender, EventArgs e)
        {
            xiadan.RedempteFundSH(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            xiadan.MergeFundSH(textBox1.Text, int.Parse(textBox3.Text));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            xiadan.PartFundSH(textBox1.Text, int.Parse(textBox3.Text));
        }
        #endregion

        /// <summary>
        /// 选中item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;
            
            MessageBox.Show("获取" + e.Item.Text + "池子");

            // 获取策略相关的系统推荐池
            // 获取个人池

        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            BaseSettingForm form = (BaseSettingForm)this.listView1.SelectedItems[0].Tag;
            if(form != null)
                form.ShowDialog();
        }

    }
}
