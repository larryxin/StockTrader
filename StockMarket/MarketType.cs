using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.Market
{
    public enum MarketType
    {
        MARKET_FIRST,
        MARKET_SHANGHAI_A = MARKET_FIRST,
        MARKET_SHANGHAI_B,
        MARKET_SHENZHEN_A,
        MARKET_SHENZHEN_B,
        MARKET_WARRANT,		// 权证
        MARKET_INDEX,			// 指数
        MARKET_MAX,
        MARKET_UNKNOWN = MARKET_MAX,
    };

}
