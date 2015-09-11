using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Stock.Market;
using System.Collections;

namespace Stock.Strategy
{
    class RotationStrategy1 : BaseStrategy
    {
        private ArrayList fundHolders = new ArrayList();

        public override string Name
        {
            get
            {
                return "分级A轮动模型";
            }
            set
            {
            }
        }

        public override string Description
        {
            get
            {
                return "参照西胖子的轮动模型，本着轮动就是收益的目标。建议选择约定收益率一样的分级A 作为轮动标的,流动性非常好的标的。";
            }
            set
            {
            }
        }

        public override void Run()
        {
            // 定时检查是否成功交易(买入卖出)
        }

        private float ComputeYhsyl(String code, float price)
        {
            return 0f;
        }

        public override void OnStockDataChanged(object sender, Stock.Market.StockData data)
        {
            this.stockPool = null;
            string[] top5Funds = null;
            String sellA = null;
            String buyA = null;
            foreach (var item in fundHolders)
            {
                top5Funds.Contains(item);
            }
            
            
            // 计算并保存 隐含收益率，并重新排序分级A，排序结果，去除折价率小于5的品种
            // 隐含收益率的算法

            // 比较持有的仓位A1， A2， A3， A4， A5。 
            // 轮动条件一、考虑卖出排序不在前5的A，买入新进入前5的A
            // 轮动条件二、要交换的A的几点必须大于 N个基点， N 可配置
            // 轮动条件三、重新验证卖一，买一的挂单量和对应的收益率
            // 以上条件满足， 换A

            // 3秒不成交 撤单

        }
    }
}
