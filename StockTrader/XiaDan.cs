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
using System.Linq;
using System.Text;
using Stock.Trader.WeiTuo;
using Stock.Trader.WeiTuo.HuaTai;

namespace Stock.Trader
{
    /// <summary>
    /// 这个类的实例是临界资源，只允许单实例运行
    /// </summary>
    class XiaDan
    {
        #region .ctor()
        private XiaDan()
        {
        }
        #endregion

        private static XiaDan instance = new XiaDan();
        I_StockTrader trader =  new HuaTaiStockTrader();

        public void Init()
        {
            trader.Init();
        }

        public static XiaDan Instance {
            get { return instance; }
        }

        public void BuyStock(String code, float price, int num)
        {
            // TODO: 检查？分钟内是否重复购买
            trader.BuyStock(code, price, num);
            // 保存下单记录到文件
        }

        public void SellStock(String code, float price, int num)
        {
            // TODO: 检查？分钟内是否重复卖出
            trader.SellStock(code, price, num);
            // 保存下单记录到文件
        }

        /// <summary>
        /// 申购基金
        /// </summary>
        /// <param name="code"></param>
        /// <param name="total"></param>
        public void PurchaseFundSZ(String code, float total)
        {
            trader.PurchaseFundSZ(code, total);
        }

        /// <summary>
        /// 赎回基金
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="num">份额</param>
        public void RedempteFundSZ(String code, int num)
        {
            trader.RedempteFundSZ(code, num);
        }

        /// <summary>
        /// 合并子基金
        /// </summary>
        /// <param name="code">母鸡代码</param>
        /// <param name="num">合并数量</param>
        public void MergeFundSZ(String code, int num)
        {
            trader.MergeFundSZ(code, num);
        }

        /// <summary>
        /// 分拆母基金
        /// </summary>
        /// <param name="code">母鸡代码</param>
        /// <param name="num">分拆数量</param>
        public void PartFundSZ(String code, int num)
        {
            trader.PartFundSZ(code, num);
        }

        /// <summary>
        /// 申购基金
        /// </summary>
        /// <param name="code"></param>
        /// <param name="total"></param>
        public void PurchaseFundSH(String code, float total)
        {
            trader.PurchaseFundSH(code, total);
        }

        /// <summary>
        /// 赎回基金
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="num">份额</param>
        public void RedempteFundSH(String code, int num)
        {
            trader.RedempteFundSH(code, num);
        }

        /// <summary>
        /// 合并子基金
        /// </summary>
        /// <param name="code">母鸡代码</param>
        /// <param name="num">合并数量</param>
        public void MergeFundSH(String code, int num)
        {
            trader.MergeFundSH(code, num);
        }

        /// <summary>
        /// 分拆母基金
        /// </summary>
        /// <param name="code">母鸡代码</param>
        /// <param name="num">分拆数量</param>
        public void PartFundSH(String code, int num)
        {
            trader.PartFundSH(code, num);
        }
        /// <summary>
        /// 撤销超时未成交股票
        /// </summary>
        public void CancelTimeoutStock()
        {
            // TODO: 获取未成交数据
            // 检查是否超时，超时就撤销
        }

        /// <summary>
        /// 提交交易记录到服务器
        /// </summary>
        public void CommitRecordToServer()
        {
            // 读取当日的操作日志文件，分析后上传到服务器
        }

        internal void CancelStock(string code, float price, int num)
        {
            trader.CancelStock(code, price, num);
        }

        internal void GetCashInfo()
        {
            trader.GetCashInfo();
        }
    }
}
