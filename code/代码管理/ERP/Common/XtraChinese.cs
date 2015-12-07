using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPrinting.Localization;
using System.Windows.Forms;
using System.Collections;

namespace Common
{
    public class XtraChinese
    {

        #region  汉化xtraGrid部分

        public void chineseXtraGrid(DevExpress.XtraGrid.GridControl xg)
        {
            //汉化MainView
            if (xg.LevelTree.LevelTemplate.GetType().Equals(typeof(DevExpress.XtraGrid.Views.Grid.GridView)))
                chineseView((DevExpress.XtraGrid.Views.Grid.GridView)xg.LevelTree.LevelTemplate);
            //汉化子View,即PartenViews
            enumAllViews(xg.LevelTree.Nodes);
        }

        private void enumAllViews(DevExpress.XtraGrid.GridLevelNodeCollection nodeColl)
        {
            foreach (DevExpress.XtraGrid.GridLevelNode node in nodeColl)
            {
                if (node.LevelTemplate.GetType().Equals(typeof(DevExpress.XtraGrid.Views.Grid.GridView)))
                {
                    chineseView((DevExpress.XtraGrid.Views.Grid.GridView)node.LevelTemplate);
                    if (node.HasChildren)
                        enumAllViews(node.Nodes);
                }
            }
        }

        private void chineseView(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            gv.OptionsView.ShowAutoFilterRow = true;
#if DEBUG
            gv.OptionsView.ShowFilterPanel = true;
#else
     gv.OptionsView.ShowFilterPanel = false; 
#endif
            gv.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 0; //不显示所有记录值
            gv.GroupPanelText = "拖动列头到这里实现分组";
            gv.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(gridView_ShowGridMenu);
            gv.GridMenuItemClick += new DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventHandler(gridView_GridMenuItemClick);
            gv.ShowFilterPopupListBox += new DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventHandler(gridView_ShowFilterPopupListBox);
            gv.CustomFilterDialog += new DevExpress.XtraGrid.Views.Grid.CustomFilterDialogEventHandler(gridView_CustomFilterDialog);
        }

        private void gridView_CustomFilterDialog(object sender, DevExpress.XtraGrid.Views.Grid.CustomFilterDialogEventArgs e)
        {
            DevExpress.XtraGrid.Filter.FilterCustomDialog dlg = new DevExpress.XtraGrid.Filter.FilterCustomDialog(e.Column);
            dlg.Text = "自定义筛选窗口";
            chineseControl(dlg);
            dlg.ShowDialog();
            e.FilterInfo = null;
            e.Handled = true;
        }
        private Control GetChildControlByName(Control.ControlCollection cc, String sname)
        {
            Control cl = null;
            foreach (Control ctrl in cc)
            {
                if ((cl == null) && sname.Equals(ctrl.Name))
                    cl = ctrl;
                else if (ctrl.HasChildren)
                    cl = GetChildControlByName(ctrl.Controls, sname);

                if (cl != null) break;
            }
            return cl;
        }
        private void SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit newc = sender as DevExpress.XtraEditors.ComboBoxEdit;
            DevExpress.XtraEditors.ComboBoxEdit cc = newc.Tag as DevExpress.XtraEditors.ComboBoxEdit;
            cc.SelectedIndex = newc.SelectedIndex;
        }
        private System.Collections.Specialized.ListDictionary filterDic;

        private void chineseControl(Control ctrl)
        {
            if (filterDic == null)
            {
                filterDic = new System.Collections.Specialized.ListDictionary();
                filterDic.Add("", "");
                filterDic.Add("等于=", "equals");
                filterDic.Add("不等于<>", "does not equal");
                filterDic.Add("大于>", "is greater than");
                filterDic.Add("大于或等于>=", "is greater than or equal to");
                filterDic.Add("小于<", "is less than");
                filterDic.Add("小于或等于<=", "is less than or equal to");
                filterDic.Add("空值NULL", "blanks");
                filterDic.Add("非空值Not NULL", "non blanks");
                filterDic.Add("包含Like", "like");
                filterDic.Add("不包含Not Like", "not like");
            }
            Control child = GetChildControlByName(ctrl.Controls, "btnCancel");
            if (child != null)
                child.Text = "取消";
            child = GetChildControlByName(ctrl.Controls, "btnOK");
            if (child != null)
                child.Text = "确定";
            child = GetChildControlByName(ctrl.Controls, "rbOr");
            if (child != null)
                child.Text = "或";
            child = GetChildControlByName(ctrl.Controls, "rbAnd");
            if (child != null)
                child.Text = "与";
            child = GetChildControlByName(ctrl.Controls, "label1");
            if (child != null)
                child.Text = "条件：";
            child = GetChildControlByName(ctrl.Controls, "piFirst");
            if (child != null)
                chineseComboEdit(child);
            child = GetChildControlByName(ctrl.Controls, "piSecond");
            if (child != null)
                chineseComboEdit(child);
        }

        private void chineseComboEdit(Control ctrl)
        {
            DevExpress.XtraEditors.ComboBoxEdit newc = new DevExpress.XtraEditors.ComboBoxEdit();
            newc.Name = ctrl.Name + "clone";
            ctrl.Parent.Controls.Add(newc);
            newc.Location = ctrl.Location;
            newc.Size = ctrl.Size;
            ctrl.Visible = false;
            newc.Tag = ctrl;
            newc.Visible = true;
            DevExpress.XtraEditors.Controls.ComboBoxItemCollection coll = newc.Properties.Items;
            foreach (DictionaryEntry de in filterDic)
            {
                coll.Add(de.Key);
            }
            newc.SelectedIndex = (ctrl as DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex;
            newc.SelectedIndexChanged += new System.EventHandler(SelectedIndexChanged);
        }

        private void gridView_ShowFilterPopupListBox(object sender, DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs e)
        {
            for (int i = 0; i < e.ComboBox.Items.Count; i++)
            {
                object item = e.ComboBox.Items[i];
                if (item is DevExpress.XtraGrid.Views.Grid.FilterItem && ((DevExpress.XtraGrid.Views.Grid.FilterItem)item).Value is DevExpress.XtraGrid.Views.Grid.FilterItem)
                {
                    object itemValue2 = ((DevExpress.XtraGrid.Views.Grid.FilterItem)((DevExpress.XtraGrid.Views.Grid.FilterItem)item).Value).Value;

                    if (itemValue2 is Int32)
                    {
                        switch (Convert.ToInt32(itemValue2))
                        {
                            case 0:
                                (e.ComboBox.Items[i] as DevExpress.XtraGrid.Views.Grid.FilterItem).Text = "所有";
                                break;
                            case 1:
                                (e.ComboBox.Items[i] as DevExpress.XtraGrid.Views.Grid.FilterItem).Text = "自定义";
                                break;
                            case 2:
                                (e.ComboBox.Items[i] as DevExpress.XtraGrid.Views.Grid.FilterItem).Text = "空值";
                                break;
                            case 3:
                                (e.ComboBox.Items[i] as DevExpress.XtraGrid.Views.Grid.FilterItem).Text = "非空值";
                                break;
                        }
                    }
                }
            }
        }

        private void gridView_GridMenuItemClick(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventArgs e)
        {
            //汉化xtraGrid的统计菜单格式      
            if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Summary) return;

            String strFormat = e.SummaryFormat;
            int equInx = strFormat.IndexOf("=");
            if (equInx > 0)
            {
                strFormat = e.DXMenuItem.Caption + strFormat.Substring(equInx);
                e.SummaryFormat = strFormat;
            }
        }
        private void gridView_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {

            //------------------------------------------------------------------------------------------------------------//

            //这段代码是我专用于给xtrGrid加一个点中空地方时显示的菜单，我在这里加入了它的打印功能
            if (e.Menu == null)
            {

                /*
                    if(e.HitInfo.InRow == false && (sender is DevExpress.XtraGrid.Views.Grid.GridView))
                    {
                     gCExport = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).GridControl;               
                     Point pt = e.Point;
                     pt.X = pt.X + gCExport.Location.X;
                     pt.Y = pt.Y + gCExport.Location.Y;
                     popupMenu1.ShowPopup(gCExport.PointToScreen(pt));     
                    }        

                */
                return;
            }

            //------------------------------------------------------------------------------------------------------------//
            //汉化xtraGrid的菜单
            System.Collections.Specialized.ListDictionary ld = new System.Collections.Specialized.ListDictionary();
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterSum, "总和");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterMin, "最小值");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterMax, "最大值");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterCount, "数量");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterAverage, "平均值");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterNone, "无");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnSortAscending, "上升排序");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnSortDescending, "下降排序");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup, "分组");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnUnGroup, "取消分组");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization, "自定义");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit, "最佳宽度");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFilter, "过滤");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnClearFilter, "清除过滤");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns, "所有列最佳宽度");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelFullExpand, "全部展开");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelFullCollapse, "全部收缩");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelClearGrouping, "清除分组");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox, "窗口式分组");

            foreach (DevExpress.Utils.Menu.DXMenuItem item in e.Menu.Items)
            {
                Object val = ld[item.Tag];
                if (val != null)
                    item.Caption = val.ToString();

            }
		}

   //XtraPrinting
	public class DxperienceXtraPrintingLocalizationCHS : PreviewLocalizer
	{
		public override string GetLocalizedString(PreviewStringId id)
		{  
			switch (id)
			{
				case PreviewStringId.Button_Cancel:
					return "取消";

				case PreviewStringId.Button_Ok:
                    return "确定";

                case PreviewStringId.Button_Help:
                    return "帮助";

                case PreviewStringId.Button_Apply:
                    return "应用";

                case PreviewStringId.PreviewForm_Caption:
                    return "预览";

                case PreviewStringId.TB_TTip_Customize:
                    return "自定义";

                case PreviewStringId.TB_TTip_Print:
					return "打印";

                case PreviewStringId.TB_TTip_PrintDirect:
                    return "直接打印";

                case PreviewStringId.TB_TTip_PageSetup:
                    return "页面设置";

				case PreviewStringId.TB_TTip_Magnifier:
                    return "放大/缩小";

                case PreviewStringId.TB_TTip_ZoomIn:
					return "放大";

                case PreviewStringId.TB_TTip_ZoomOut:
					return "缩小";

                case PreviewStringId.TB_TTip_Zoom:
					return "缩放";

                case PreviewStringId.TB_TTip_Search:
					return "搜索";

                case PreviewStringId.TB_TTip_FirstPage:
					return "首页";

                case PreviewStringId.TB_TTip_PreviousPage:
					return "上一页";

                case PreviewStringId.TB_TTip_NextPage:
					return "下一页";

                case PreviewStringId.TB_TTip_LastPage:
					return "尾页";

                case PreviewStringId.TB_TTip_MultiplePages:
					return "多页";

				case PreviewStringId.TB_TTip_Backgr:
                    return "背景色";

				case PreviewStringId.TB_TTip_Close:
					return "退出";

                case PreviewStringId.TB_TTip_EditPageHF:
					return "页眉页脚";

				case PreviewStringId.TB_TTip_HandTool:
                    return "手掌工具";

                case PreviewStringId.TB_TTip_Export:
					return "导出文件...";

                case PreviewStringId.TB_TTip_Send:
                    return "发送e-mail...";

                case PreviewStringId.TB_TTip_Map:
                    return "文档视图";

				case PreviewStringId.TB_TTip_Watermark:
                    return "水印";

                case PreviewStringId.MenuItem_PdfDocument:
					return "PDF文件";
				/*
				case PreviewStringId.MenuItem_PageLayout:
					return "页面布置(&P)";
				  */
                case PreviewStringId.MenuItem_TxtDocument:
					return "Text文件";

                case PreviewStringId.MenuItem_GraphicDocument:
					return "图片文件";

                case PreviewStringId.MenuItem_CsvDocument:
					return "CSV文件";

                case PreviewStringId.MenuItem_MhtDocument:
					return "MHT文件";

                case PreviewStringId.MenuItem_XlsDocument:
					return "Excel文件";

                case PreviewStringId.MenuItem_RtfDocument:
					return "Rich Text文件";

                case PreviewStringId.MenuItem_HtmDocument:
					return "HTML文件";

                case PreviewStringId.SaveDlg_FilterBmp:
					return "BMP Bitmap Format";

                case PreviewStringId.SaveDlg_FilterGif:
					return "GIF Graphics Interchange Format";

                case PreviewStringId.SaveDlg_FilterJpeg:
					return "JPEG File Interchange Format";

                case PreviewStringId.SaveDlg_FilterPng:
					return "PNG Portable Network Graphics Format";

                case PreviewStringId.SaveDlg_FilterTiff:
					return "TIFF Tag Image File Format";

				case PreviewStringId.SaveDlg_FilterEmf:
                    return "EMF Enhanced Windows Metafile";

                case PreviewStringId.SaveDlg_FilterWmf:
					return "WMF Windows Metafile";

				case PreviewStringId.SB_TotalPageNo:
                    return "总页码:";

                case PreviewStringId.SB_CurrentPageNo:
					return "目前页码:";

				case PreviewStringId.SB_ZoomFactor:
                    return "缩放系数:";

                case PreviewStringId.SB_PageNone:
					return "无";

				case PreviewStringId.SB_PageInfo:
                    return "{0}/{1}";

				case PreviewStringId.MPForm_Lbl_Pages:
					return "页";

				case PreviewStringId.Msg_EmptyDocument:
					return "此文件没有页面.";

				case PreviewStringId.Msg_CreatingDocument:
					return "正在生成文件...";
			   /*
				case PreviewStringId.Msg_UnavailableNetPrinter:
					return "网络打印机无法使用.";
				*/
				case PreviewStringId.Msg_NeedPrinter:
					return "没有安装打印机.";

				case PreviewStringId.Msg_WrongPrinter:
					return "无效的打印机名称.请检查打印机的设置是否正确.";

				case PreviewStringId.Msg_WrongPageSettings:
					return "打印机不支持所选的纸张大小.\n是否继续打印？";

                case PreviewStringId.Msg_CustomDrawWarning:
					return "警告！";

				case PreviewStringId.Msg_PageMarginsWarning:
                    return "一个或以上的边界超出了打印范围.是否继续？";

				case PreviewStringId.Msg_IncorrectPageRange:
					return "设置的页边界不正确";

                case PreviewStringId.Msg_FontInvalidNumber:
                    return "字体大小不能为0或负数";

                case PreviewStringId.Msg_NotSupportedFont:
                    return "这种字体不被支持";
				/*
				case PreviewStringId.Msg_IncorrectZoomFactor:
					return "数字必须在 {0} 与 {1} 之间。";

				case PreviewStringId.Msg_InvalidMeasurement:
					return "不规范";
                 */
				case PreviewStringId.Margin_Inch:
					return "英寸";

				case PreviewStringId.Margin_Millimeter:
                    return "毫米";

                case PreviewStringId.Margin_TopMargin:
					return "上边界";

				case PreviewStringId.Margin_BottomMargin:
                    return "下边界";

				case PreviewStringId.Margin_LeftMargin:
					return "左边界";

				case PreviewStringId.Margin_RightMargin:
					return "右边界";

				case PreviewStringId.ScrollingInfo_Page:
					return "页";

				case PreviewStringId.WMForm_PictureDlg_Title:
					return "选择图片";

				case PreviewStringId.WMForm_ImageStretch:
					return "伸展";

                case PreviewStringId.WMForm_ImageClip:
					return "剪辑";

				case PreviewStringId.WMForm_ImageZoom:
                    return "缩放";

                case PreviewStringId.WMForm_Watermark_Asap:
					return "ASAP";

				case PreviewStringId.WMForm_Watermark_Confidential:
                    return "CONFIDENTIAL";

                case PreviewStringId.WMForm_Watermark_Copy:
					return "COPY";

				case PreviewStringId.WMForm_Watermark_DoNotCopy:
					return "DO NOT COPY";

				case PreviewStringId.WMForm_Watermark_Draft:
					return "DRAFT";

				case PreviewStringId.WMForm_Watermark_Evaluation:
					return "EVALUATION";

				case PreviewStringId.WMForm_Watermark_Original:
					return "ORIGINAL";

				case PreviewStringId.WMForm_Watermark_Personal:
					return "PERSONAL";

				case PreviewStringId.WMForm_Watermark_Sample:
					return "SAMPLE";

				case PreviewStringId.WMForm_Watermark_TopSecret:
					return "TOP SECRET";

				case PreviewStringId.WMForm_Watermark_Urgent:
					return "URGENT";

                case PreviewStringId.WMForm_Direction_Horizontal:
                    return "横向";

                case PreviewStringId.WMForm_Direction_Vertical:
                    return "纵向";

                case PreviewStringId.WMForm_Direction_BackwardDiagonal:
                    return "反向倾斜";

                case PreviewStringId.WMForm_Direction_ForwardDiagonal:
					return "正向倾斜";

				case PreviewStringId.WMForm_VertAlign_Bottom:
					return "底端";

                case PreviewStringId.WMForm_VertAlign_Middle:
					return "中间";

				case PreviewStringId.WMForm_VertAlign_Top:
                    return "顶端";

                case PreviewStringId.WMForm_HorzAlign_Left:
					return "靠左";

				case PreviewStringId.WMForm_HorzAlign_Center:
                    return "置中";

                case PreviewStringId.WMForm_HorzAlign_Right:
					return "靠右";

				case PreviewStringId.WMForm_ZOrderRgrItem_InFront:
                    return "在前面";

                case PreviewStringId.WMForm_ZOrderRgrItem_Behind:
					return "在后面";

				case PreviewStringId.WMForm_PageRangeRgrItem_All:
                    return "全部";

                case PreviewStringId.WMForm_PageRangeRgrItem_Pages:
					return "页码";

				case PreviewStringId.SaveDlg_Title:
					return "另存为";

				case PreviewStringId.SaveDlg_FilterPdf:
					return "PDF文件";

				case PreviewStringId.SaveDlg_FilterTxt:
					return "Txt文件";

				case PreviewStringId.SaveDlg_FilterCsv:
					return "CSV文件";

				case PreviewStringId.SaveDlg_FilterMht:
					return "MHT文件";

				case PreviewStringId.SaveDlg_FilterXls:
					return "Excel文件";

				case PreviewStringId.SaveDlg_FilterRtf:
                    return "Rtf文件";

                case PreviewStringId.SaveDlg_FilterHtm:
					return "HTML文件";

				case PreviewStringId.MenuItem_File:
                    return "文件(&F)";

                case PreviewStringId.MenuItem_View:
					return "视图(&V)";

				case PreviewStringId.MenuItem_Background:
                    return "背景(&B)";

                case PreviewStringId.MenuItem_PageSetup:
					return "页面设置(&U)";

				case PreviewStringId.MenuItem_Print:
                    return "打印(&P)...";

                case PreviewStringId.MenuItem_PrintDirect:
					return "直接打印(&R)";

				case PreviewStringId.MenuItem_Export:
                    return "导出(&E)";

                case PreviewStringId.MenuItem_Send:
					return "发送(&D)";

				case PreviewStringId.MenuItem_Exit:
					return "退出(&X)";

				case PreviewStringId.MenuItem_ViewToolbar:
					return "工具栏(&T)";

				case PreviewStringId.MenuItem_ViewStatusbar:
					return "状态栏(&S)";
			   /*
				case PreviewStringId.MenuItem_ViewContinuous:
					return "连续";
                 
				case PreviewStringId.MenuItem_ViewFacing:
					return "对页";
			   */
				case PreviewStringId.MenuItem_BackgrColor:
                    return "颜色(&C)...";

				case PreviewStringId.MenuItem_Watermark:
                    return "水印(&W)...";
				/*
				case PreviewStringId.MenuItem_ZoomPageWidth:
					return "页宽";
                
				case PreviewStringId.MenuItem_ZoomTextWidth:
					return "整页";
				*/
				case PreviewStringId.PageInfo_PageNumber:
                    return "[Page #]";

                case PreviewStringId.PageInfo_PageNumberOfTotal:
					return "[Page # of Pages #]";

                case PreviewStringId.PageInfo_PageDate:
                    return "[Date Printed]";

                case PreviewStringId.PageInfo_PageTime:
                    return "[Time Printed]";

				case PreviewStringId.PageInfo_PageUserName:
                    return "[User Name]";

                case PreviewStringId.EMail_From:
					return "From";
			   /*
				case PreviewStringId.BarText_Toolbar:
					return "工具栏";
               
				case PreviewStringId.BarText_MainMenu:
					return "主菜单";
				 
				case PreviewStringId.BarText_StatusBar:
					return "状态栏";
				*/
			}
			return base.GetLocalizedString(id);
		}
		public override string Language
		{
			get
			{
				return "简体中文";
			}
		}

    }


        #endregion

    }
}
