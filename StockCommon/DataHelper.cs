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

namespace StockCommon
{
    /// <summary>
    ///  用于将股票数据和服务器端同步
    /// </summary>
    public class DataHelper
    {
        /// <summary>
        /// 获取系统池
        /// </summary>
        /// <param name="id">策略编号</param>
        public void RetrieveSystemStockPool(int id)
        {
        }

        /// <summary>
        /// 获取个人池
        /// </summary>
        /// <param name="id">策略编号</param>
        /// <param name="user"></param>
        public void RetrievePersonalStockPool(int id, int user)
        {
        }

        /// <summary>
        /// 增加个人池中的股票
        /// </summary>
        /// <param name="id">策略编号</param>
        /// <param name="user"></param>
        /// <param name="code"></param>
        public void AddStock(int id, int user, String code)
        {
        }

        /// <summary>
        /// 删除个人池中的股票
        /// </summary>
        /// <param name="id">策略编号</param>
        /// <param name="user"></param>
        /// <param name="code"></param>
        public void DeleteStock(int id, int user, String code)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="code"></param>
        /// <param name="price"></param>
        /// <param name="num"></param>
        public void AddTradeRecord(int user, String code, float price, int num)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        /// <param name="num"></param>
        public void AddStockHolderRecord(int user, String code, float cost, int num)
        {
        }

    }
}
