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
using Stock.Market;

namespace Stock.Strategy
{
    ///<summary>定义一个委托类型</summary>
    public delegate void StockRemoveHandler(object sender, string code);
    public delegate void StockAddHandler(object sender, string code);
    
    public interface IStrategy
    {

        /// <summary>定义一个事件</summary>
        event StockRemoveHandler OnStockRemove;
        event StockAddHandler OnStockAdd;

        string Name { get; set; }
        string Description { get; set; }
        bool IsValid { get; set; }
        String[] StockPool { get; }

        /// <summary>
        /// 执行
        /// </summary>
        void Run();

        /// <summary>
        /// 加入策略池关注的股票
        /// </summary>
        /// <param name="code"></param>
        void AddStock(string code);

        /// <summary>
        /// 删除股票
        /// </summary>
        /// <param name="code"></param>
        void RemoveStock(String code);

        /// <summary>
        /// 股票价格发生变化时调用此方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        void OnStockDataChanged(object sender, StockData data);
    }
}
