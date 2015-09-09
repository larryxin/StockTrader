using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Trader.WeiTuo;

namespace Stock.Trader
{
    /// <summary>
    /// 这个类的实例是临界资源
    /// </summary>
    class XiaDan
    {
        #region .ctor()
        private XiaDan()
        {
        }
        #endregion

        private static XiaDan instance = new XiaDan();
        I_StockTrader trader;

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
        public void PurchaseFund(String code, float total)
        {
        }

        /// <summary>
        /// 赎回基金
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="num">份额</param>
        public void RedempteFund(String code, int num)
        {
        }

        /// <summary>
        /// 合并子基金
        /// </summary>
        /// <param name="code">母鸡代码</param>
        /// <param name="num">合并数量</param>
        public void MergeFund(String code, int num)
        {
        }

        /// <summary>
        /// 分拆母基金
        /// </summary>
        /// <param name="code">母鸡代码</param>
        /// <param name="num">分拆数量</param>
        public void PartFund(String code, int num)
        {
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
    }
}
