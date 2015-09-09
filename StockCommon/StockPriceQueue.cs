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
using System.Collections;

namespace Stock.Market
{
    /// <summary>
    /// 股票价格队列, 当价格发生变动时,发送给观察者
    /// </summary>
    public class StockDataQueue
    {
        ///<summary>定义一个委托类型</summary>
        public delegate void StockDataChangeHandler(object sender, StockData data);
 
         /// <summary>定义一个事件</summary>
        public event StockDataChangeHandler OnStockDataChange;

        private StockData lastData;
        private Queue<StockData> queue;

        public StockData LastData
        {
            get { return lastData; }
            set { lastData = value; }
        }

        public void Enqueue(StockData obj)
        {
            queue.Enqueue(obj);
            if (OnStockDataChange != null)
            {
                OnStockDataChange(this, obj);
            }
        }

        public StockData Dequeue()
        {
            return queue.Dequeue();
        }
    }
}
