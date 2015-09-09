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
using System.Windows.Forms;

using System.Window;
using System.Runtime.InteropServices;
using System.Threading;

namespace Stock.Trader.WeiTuo.HuaTai
{
    /// <summary>
    /// 华泰的外挂交易接口
    /// </summary>
    public class HuaTaiStockTrader : BaseStockTrader, I_StockTrader
    {
        const int MDI_FRAME = 0xE900;

        #region 各个重要的句柄和基本操作
        IntPtr hWnd;    // 窗口句柄
        IntPtr htvi;    // 功能树形控件句柄

        // 主功能菜单
        int hBuy, hSell, hCancel, hGgt, hSswt, hSjwt, hGzxt, hXgsg, hQuery, hPlxd, hEtfwx, hCnjj, hJjphyw, hQtjy, hYmd, hYzzz, hZqhg, hBjhg, hDzjy, hHbjj, hFezr, hXgmm, hXgkhzl, hZhqxgl;
        // 查询菜单
        int hQueryZjgp, hQueryDrwt, hQueryDrcj, hQueryLscj, hQueryDrzjmx, hQueryLszjmx, hQueryJgd;
        // 其他交易菜单
        int hQtjyQtmm, hQtjyYsyy, hQtjyJcyy, hQtjyXq, hQtjyZzxq, hQtjyGqjlrzyw, hQtjyFjjj, hQtjyWltp, hQtjySzLOFjj;
        // 其他交易-分级基金业务
        int hQtjyFjjjywJjsg, hQtjyFjjjywJjsh, hQtjyFjjjywJjfc, hQtjyFjjjywJjhb, hQtjyFjjjywJjrg;
        // 其他交易-上证LOF基金
        int hQtjySzLOFjjRg, hQtjySzLOFjjSg, hQtjySzLOFjjSh, hQtjySzLOFjjHb, hQtjySzLOFjjFc, hQtjySzLOFjjCd, hQtjySzLOFjjCxdrwt, hQtjySzLOFjjCxdrcj;

        /// <summary>
        /// 获取左侧功能菜单treeview 句柄
        /// </summary>
        /// <returns></returns>
        private IntPtr GetFuncTreeView()
        {
            const int AFX_WND = 0xE900;
            const int HEXIN_SCROLL_WND = 0x0081;
            const int HEXIN_SCROLL_WND_2 = 0x00C8;
            const int FUNC_TREE_VIEW = 0x0081;

            IntPtr h1 = Win32API.GetDlgItem(hWnd, MDI_FRAME);
            h1 = Win32API.GetDlgItem(h1, AFX_WND);
            h1 = Win32API.GetDlgItem(h1, HEXIN_SCROLL_WND);
            h1 = Win32API.GetDlgItem(h1, HEXIN_SCROLL_WND_2);
            h1 = Win32API.GetDlgItem(h1, FUNC_TREE_VIEW);

            return h1;
        }

        /// <summary>
        /// 获取右侧主面板句柄
        /// </summary>
        /// <returns></returns>
        private IntPtr GetDetailPanel()
        {
            const int PANEL_DLG = 0xE901; 
            IntPtr h1 = Win32API.GetDlgItem(hWnd, MDI_FRAME);
            h1 = Win32API.GetDlgItem(h1, PANEL_DLG);

            return h1;
        }

        /// <summary>
        /// 获取持仓列表信息控件
        /// </summary>
        /// <returns></returns>
        private IntPtr GetPositonList()
        {
            const int HEXIN_SCROLL_WND = 0x0417;
            const int HEXIN_SCROLL_WND_2 = 0x00C8;
            const int LIST_VIEW = 0x0417;

            IntPtr h1 = GetDetailPanel();
            h1 = Win32API.GetDlgItem(h1, HEXIN_SCROLL_WND);
            h1 = Win32API.GetDlgItem(h1, HEXIN_SCROLL_WND_2);
            h1 = Win32API.GetDlgItem(h1, LIST_VIEW);

            return h1;
        }

        #region 点击各个功能菜单

        private void ClickSellTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hSell);
        }

        private void ClickBuyTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hBuy);
        }

        private void ClickCancelTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hCancel);
        }

        private void ClickQueryTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQueryZjgp);
        }

        private void ClickSzSgjjTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQtjyFjjjywJjsg);
        }

        private void ClickSzShjjTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQtjyFjjjywJjsh);
        }

        private void ClickSzHbjjTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQtjyFjjjywJjhb);
        }

        private void ClickSzFcjjTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQtjyFjjjywJjfc);
        }

        private void ClickShSgjjTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQtjySzLOFjjSg);
        }

        private void ClickShShjjTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQtjySzLOFjjSh);
        }

        private void ClickShHbjjTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQtjySzLOFjjHb);
        }

        private void ClickShFcjjTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQtjySzLOFjjFc);
        }


        #endregion

        #region init handler

        private void InitQtjySzLOFjjFuncHandler()
        {
            hQtjySzLOFjjRg = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_CHILD, hQtjySzLOFjj);
            hQtjySzLOFjjSg = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjySzLOFjjRg);
            hQtjySzLOFjjSh = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjySzLOFjjSg);
            hQtjySzLOFjjHb = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjySzLOFjjSh);
            hQtjySzLOFjjFc = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjySzLOFjjHb);
            hQtjySzLOFjjCd = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjySzLOFjjFc);
            hQtjySzLOFjjCxdrwt = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjySzLOFjjCd);
            hQtjySzLOFjjCxdrcj = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjySzLOFjjCxdrwt);
        }

        private void InitQtjyFjjjFuncHandler()
        {
            hQtjyFjjjywJjsg = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_CHILD, hQtjyFjjj);
            hQtjyFjjjywJjsh = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyFjjjywJjsg);
            hQtjyFjjjywJjfc = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyFjjjywJjsh);
            hQtjyFjjjywJjhb = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyFjjjywJjfc);
            hQtjyFjjjywJjrg = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyFjjjywJjhb);
        }

        private void InitQtjyFuncHandler()
        {
            hQtjyQtmm = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_CHILD, hQtjy);
            hQtjyYsyy = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyQtmm);
            hQtjyJcyy = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyYsyy);
            hQtjyXq = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyJcyy);
            hQtjyZzxq = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyXq);
            hQtjyGqjlrzyw = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyZzxq);
            hQtjyFjjj = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyGqjlrzyw);
            hQtjyWltp = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyFjjj);
            hQtjySzLOFjj = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjyWltp);
        }

        private void InitQueryFuncHandler()
        {
            hQueryZjgp = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_CHILD, hQuery);
            hQueryDrwt = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryZjgp);
            hQueryDrcj = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryDrwt);
            hQueryLscj = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryDrcj);
            hQueryDrzjmx = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryLscj);
            hQueryLszjmx = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryDrzjmx);
            hQueryJgd = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryLszjmx);
        }

        private void InitMainFuncHandler()
        {
            hBuy = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_ROOT, 0);
            hSell = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hBuy);
            hCancel = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hSell);
            hGgt = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hCancel);
            hSswt = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hGgt);
            hSjwt = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hSswt);
            hGzxt = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hSjwt);
            hXgsg = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hGzxt);
            hQuery = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hXgsg);
            hPlxd = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQuery);
            hEtfwx = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hPlxd);
            hCnjj = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hEtfwx);
            hJjphyw = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hCnjj);
            hQtjy = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hJjphyw);
            hYmd = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQtjy);
            hYzzz = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hYmd);
            hZqhg = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hYzzz);
            hBjhg = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hZqhg);
            hDzjy = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hBjhg);
            hHbjj = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hDzjy);
            hFezr = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hHbjj);
            hXgmm = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hFezr);
            hXgkhzl = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hXgmm);
            hZhqxgl = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hXgkhzl);
        }

        #endregion
        #endregion

        #region 接口实现

        /// <summary>
        /// 检测
        /// </summary>
        public void Init()
        {
            hWnd = Win32API.FindWindow(null, @"网上股票交易系统5.0");

            htvi = GetFuncTreeView();

            // 配置各个操作的句柄
            InitMainFuncHandler();

            // 查询功能树的句柄
            InitQueryFuncHandler();

            // 其他交易           
            InitQtjyFuncHandler();

            // 其他交易-分级基金业务
            InitQtjyFjjjFuncHandler();

            // 其他交易-上证LOF基金
            InitQtjySzLOFjjFuncHandler();

        }
        
        public void SellStock(string code, float price, int num)
        {
            ClickSellTreeViewItem();

            const int BUY_TXT_CODE = 0x0408;
            const int BUY_TXT_PRICE = 0x0409;
            const int BUY_TXT_NUM = 0x040A;
            const int BUY_BTN_OK = 0x3EE;

            // 设定代码,价格,数量
            IntPtr hPanel = GetDetailPanel();
            IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, price.ToString());
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_NUM);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, num.ToString());

            // 点击买入按钮
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
        }

        public void BuyStock(string code, float price, int num)
        {
            const int BUY_TXT_CODE = 0x0408;
            const int BUY_TXT_PRICE = 0x0409;
            const int BUY_TXT_NUM = 0x040A;
            const int BUY_BTN_OK = 0x3EE;

            ClickBuyTreeViewItem();

            // 设定代码,价格,数量
            IntPtr hPanel = GetDetailPanel();
            IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, price.ToString());
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_NUM);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, num.ToString());

            // 点击买入按钮
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
        }

        public void CancelStock(String code, float price, int num)
        {
            ClickCancelTreeViewItem();
        }

        public void Keep()
        {
            throw new NotImplementedException();
        }

        public void GetStockPositionList()
        {
            throw new NotImplementedException();
        }

        public void GetCashInfo()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQueryZjgp);

            // TODO:发送复制命令,这里不能正常复制
            IntPtr list = GetPositonList();
            Win32API.SendMessage(list, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(list, Win32Code.WM_LBUTTONUP, 0, 0);
            Win32API.SendMessage(list, Win32Code.WM_SETFOCUS, 0, 0);
            //Win32API.SendMessage(list, Win32Code.WM_RENDERFORMAT, Win32Code.CF_UNICODETEXT, 0);

            // Win32API.SendMessage(new IntPtr(0x00270bb2), Win32Code.WM_RENDERFORMAT, Win32Code.CF_UNICODETEXT, 0);

            Win32API.SendMessage(list, Win32Code.WM_KEYDOWN, Win32Code.VK_CONTROL, 0);
            Win32API.SendMessage(list, Win32Code.WM_KEYDOWN, Win32Code.VK_C, 0);
            Win32API.SendMessage(list, Win32Code.WM_CHAR, Win32Code.VK_C, 0);
            Win32API.SendMessage(list, Win32Code.WM_KEYUP, Win32Code.VK_C, 0);
            Win32API.SendMessage(list, Win32Code.WM_KEYUP, Win32Code.VK_CONTROL, 0);

        }

        public void GetTransactionInfo()
        {
            throw new NotImplementedException();
        }

        public void PurchaseFundSZ(string code, float total)
        {
            const int BUY_TXT_CODE = 0x0408;
            const int BUY_TXT_PRICE = 0x040A;
            const int BUY_BTN_OK = 0x3EE;

            ClickSzSgjjTreeViewItem();

            IntPtr hPanel = GetDetailPanel();
            IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);

            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, total.ToString());

            // 点击按钮
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
        }

        public void RedempteFundSZ(string code, int num)
        {
            ClickSzShjjTreeViewItem();
            
            const int BUY_TXT_CODE = 0x0408;
            const int BUY_TXT_PRICE = 0x040A;
            const int BUY_BTN_OK = 0x3EE;

            IntPtr hPanel = GetDetailPanel();
            IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);

            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, num.ToString());

            // 点击按钮
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
        }

        public void MergeFundSZ(string code, int num)
        {
            ClickSzHbjjTreeViewItem();

            const int BUY_TXT_CODE = 0x0408;
            const int BUY_TXT_PRICE = 0x040A;
            const int BUY_BTN_OK = 0x3EE;

            IntPtr hPanel = GetDetailPanel();
            IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);

            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, num.ToString());

            // 点击按钮
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
        }

        public void PartFundSZ(string code, int num)
        {
            ClickSzFcjjTreeViewItem();

            const int BUY_TXT_CODE = 0x0408;
            const int BUY_TXT_PRICE = 0x040A;
            const int BUY_BTN_OK = 0x3EE;

            IntPtr hPanel = GetDetailPanel();
            IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);

            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, num.ToString());

            // 点击按钮
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
        }

        public void PurchaseFundSH(string code, float total)
        {
            ClickShSgjjTreeViewItem();
            const int BUY_TXT_CODE = 0x0408;
            const int BUY_TXT_PRICE = 0x040A;
            const int BUY_BTN_OK = 0x3EE;

            IntPtr hPanel = GetDetailPanel();
            IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);

            hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
            Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, total.ToString());

            // 点击按钮
            hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
        }

        public void RedempteFundSH(string code, int num)
        {
            ClickShShjjTreeViewItem();
        }

        public void MergeFundSH(string code, int num)
        {
            ClickShHbjjTreeViewItem();
        }

        public void PartFundSH(string code, int num)
        {
            ClickShFcjjTreeViewItem();
        }

        #endregion

    }
}
