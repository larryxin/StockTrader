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
using Stock.Strategy;

namespace Stock.Strategy
{
    public abstract class BaseStrategy : IStrategy
    {
        private bool isValid;
        protected ICollection<string> stockPool;

        #region 实现接口

        public event StockRemoveHandler OnStockRemove;
        public event StockAddHandler OnStockAdd;

        public abstract void Run();
        public abstract void OnStockDataChanged(object sender, Stock.Market.StockData data);


        public void AddStock(string code)
        {
            if (OnStockAdd != null)
                OnStockAdd(this, code);
        }

        public void RemoveStock(string code)
        {
            if (OnStockRemove != null)
                OnStockRemove(this, code);
        }

        public abstract string Name
        {
            get;
            set;
        }

        public abstract string Description
        {
            get;
            set;
        }
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        public String[] StockPool
        {
            get
            {
                return this.stockPool.ToArray<String>();
            }
        }

        #endregion


    }
}
