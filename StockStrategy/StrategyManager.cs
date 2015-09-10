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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.Strategy
{
    /// <summary>
    /// 管理策略
    /// </summary>
    public class StrategyManager
    {
        ICollection strategies = new ArrayList();

        /// <summary>
        ///  从服务器端读取所有的策略，生成策略实例
        /// </summary>
        /// <returns></returns>
        public IStrategy[] ReadAllStrategies()
        {
            return null;
        }

        /// <summary>
        /// 从服务器端读取个人用的策略
        /// </summary>
        /// <returns></returns>
        public IStrategy[] ReadMyStrategies()
        {
            return null;
        }

        /// <summary>
        /// 将我的策略保存到服务器
        /// </summary>
        /// <param name="strategy"></param>
        public void SaveMyStrategy(IStrategy strategy)
        {

        }
    }
}
