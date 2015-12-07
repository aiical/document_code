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

        #region  ����xtraGrid����

        public void chineseXtraGrid(DevExpress.XtraGrid.GridControl xg)
        {
            //����MainView
            if (xg.LevelTree.LevelTemplate.GetType().Equals(typeof(DevExpress.XtraGrid.Views.Grid.GridView)))
                chineseView((DevExpress.XtraGrid.Views.Grid.GridView)xg.LevelTree.LevelTemplate);
            //������View,��PartenViews
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
            gv.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 0; //����ʾ���м�¼ֵ
            gv.GroupPanelText = "�϶���ͷ������ʵ�ַ���";
            gv.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(gridView_ShowGridMenu);
            gv.GridMenuItemClick += new DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventHandler(gridView_GridMenuItemClick);
            gv.ShowFilterPopupListBox += new DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventHandler(gridView_ShowFilterPopupListBox);
            gv.CustomFilterDialog += new DevExpress.XtraGrid.Views.Grid.CustomFilterDialogEventHandler(gridView_CustomFilterDialog);
        }

        private void gridView_CustomFilterDialog(object sender, DevExpress.XtraGrid.Views.Grid.CustomFilterDialogEventArgs e)
        {
            DevExpress.XtraGrid.Filter.FilterCustomDialog dlg = new DevExpress.XtraGrid.Filter.FilterCustomDialog(e.Column);
            dlg.Text = "�Զ���ɸѡ����";
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
                filterDic.Add("����=", "equals");
                filterDic.Add("������<>", "does not equal");
                filterDic.Add("����>", "is greater than");
                filterDic.Add("���ڻ����>=", "is greater than or equal to");
                filterDic.Add("С��<", "is less than");
                filterDic.Add("С�ڻ����<=", "is less than or equal to");
                filterDic.Add("��ֵNULL", "blanks");
                filterDic.Add("�ǿ�ֵNot NULL", "non blanks");
                filterDic.Add("����Like", "like");
                filterDic.Add("������Not Like", "not like");
            }
            Control child = GetChildControlByName(ctrl.Controls, "btnCancel");
            if (child != null)
                child.Text = "ȡ��";
            child = GetChildControlByName(ctrl.Controls, "btnOK");
            if (child != null)
                child.Text = "ȷ��";
            child = GetChildControlByName(ctrl.Controls, "rbOr");
            if (child != null)
                child.Text = "��";
            child = GetChildControlByName(ctrl.Controls, "rbAnd");
            if (child != null)
                child.Text = "��";
            child = GetChildControlByName(ctrl.Controls, "label1");
            if (child != null)
                child.Text = "������";
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
                                (e.ComboBox.Items[i] as DevExpress.XtraGrid.Views.Grid.FilterItem).Text = "����";
                                break;
                            case 1:
                                (e.ComboBox.Items[i] as DevExpress.XtraGrid.Views.Grid.FilterItem).Text = "�Զ���";
                                break;
                            case 2:
                                (e.ComboBox.Items[i] as DevExpress.XtraGrid.Views.Grid.FilterItem).Text = "��ֵ";
                                break;
                            case 3:
                                (e.ComboBox.Items[i] as DevExpress.XtraGrid.Views.Grid.FilterItem).Text = "�ǿ�ֵ";
                                break;
                        }
                    }
                }
            }
        }

        private void gridView_GridMenuItemClick(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventArgs e)
        {
            //����xtraGrid��ͳ�Ʋ˵���ʽ      
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

            //��δ�������ר���ڸ�xtrGrid��һ�����пյط�ʱ��ʾ�Ĳ˵�������������������Ĵ�ӡ����
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
            //����xtraGrid�Ĳ˵�
            System.Collections.Specialized.ListDictionary ld = new System.Collections.Specialized.ListDictionary();
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterSum, "�ܺ�");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterMin, "��Сֵ");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterMax, "���ֵ");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterCount, "����");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterAverage, "ƽ��ֵ");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuFooterNone, "��");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnSortAscending, "��������");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnSortDescending, "�½�����");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup, "����");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnUnGroup, "ȡ������");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization, "�Զ���");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit, "��ѿ��");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFilter, "����");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnClearFilter, "�������");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns, "��������ѿ��");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelFullExpand, "ȫ��չ��");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelFullCollapse, "ȫ������");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelClearGrouping, "�������");
            ld.Add(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox, "����ʽ����");

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
					return "ȡ��";

				case PreviewStringId.Button_Ok:
                    return "ȷ��";

                case PreviewStringId.Button_Help:
                    return "����";

                case PreviewStringId.Button_Apply:
                    return "Ӧ��";

                case PreviewStringId.PreviewForm_Caption:
                    return "Ԥ��";

                case PreviewStringId.TB_TTip_Customize:
                    return "�Զ���";

                case PreviewStringId.TB_TTip_Print:
					return "��ӡ";

                case PreviewStringId.TB_TTip_PrintDirect:
                    return "ֱ�Ӵ�ӡ";

                case PreviewStringId.TB_TTip_PageSetup:
                    return "ҳ������";

				case PreviewStringId.TB_TTip_Magnifier:
                    return "�Ŵ�/��С";

                case PreviewStringId.TB_TTip_ZoomIn:
					return "�Ŵ�";

                case PreviewStringId.TB_TTip_ZoomOut:
					return "��С";

                case PreviewStringId.TB_TTip_Zoom:
					return "����";

                case PreviewStringId.TB_TTip_Search:
					return "����";

                case PreviewStringId.TB_TTip_FirstPage:
					return "��ҳ";

                case PreviewStringId.TB_TTip_PreviousPage:
					return "��һҳ";

                case PreviewStringId.TB_TTip_NextPage:
					return "��һҳ";

                case PreviewStringId.TB_TTip_LastPage:
					return "βҳ";

                case PreviewStringId.TB_TTip_MultiplePages:
					return "��ҳ";

				case PreviewStringId.TB_TTip_Backgr:
                    return "����ɫ";

				case PreviewStringId.TB_TTip_Close:
					return "�˳�";

                case PreviewStringId.TB_TTip_EditPageHF:
					return "ҳüҳ��";

				case PreviewStringId.TB_TTip_HandTool:
                    return "���ƹ���";

                case PreviewStringId.TB_TTip_Export:
					return "�����ļ�...";

                case PreviewStringId.TB_TTip_Send:
                    return "����e-mail...";

                case PreviewStringId.TB_TTip_Map:
                    return "�ĵ���ͼ";

				case PreviewStringId.TB_TTip_Watermark:
                    return "ˮӡ";

                case PreviewStringId.MenuItem_PdfDocument:
					return "PDF�ļ�";
				/*
				case PreviewStringId.MenuItem_PageLayout:
					return "ҳ�沼��(&P)";
				  */
                case PreviewStringId.MenuItem_TxtDocument:
					return "Text�ļ�";

                case PreviewStringId.MenuItem_GraphicDocument:
					return "ͼƬ�ļ�";

                case PreviewStringId.MenuItem_CsvDocument:
					return "CSV�ļ�";

                case PreviewStringId.MenuItem_MhtDocument:
					return "MHT�ļ�";

                case PreviewStringId.MenuItem_XlsDocument:
					return "Excel�ļ�";

                case PreviewStringId.MenuItem_RtfDocument:
					return "Rich Text�ļ�";

                case PreviewStringId.MenuItem_HtmDocument:
					return "HTML�ļ�";

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
                    return "��ҳ��:";

                case PreviewStringId.SB_CurrentPageNo:
					return "Ŀǰҳ��:";

				case PreviewStringId.SB_ZoomFactor:
                    return "����ϵ��:";

                case PreviewStringId.SB_PageNone:
					return "��";

				case PreviewStringId.SB_PageInfo:
                    return "{0}/{1}";

				case PreviewStringId.MPForm_Lbl_Pages:
					return "ҳ";

				case PreviewStringId.Msg_EmptyDocument:
					return "���ļ�û��ҳ��.";

				case PreviewStringId.Msg_CreatingDocument:
					return "���������ļ�...";
			   /*
				case PreviewStringId.Msg_UnavailableNetPrinter:
					return "�����ӡ���޷�ʹ��.";
				*/
				case PreviewStringId.Msg_NeedPrinter:
					return "û�а�װ��ӡ��.";

				case PreviewStringId.Msg_WrongPrinter:
					return "��Ч�Ĵ�ӡ������.�����ӡ���������Ƿ���ȷ.";

				case PreviewStringId.Msg_WrongPageSettings:
					return "��ӡ����֧����ѡ��ֽ�Ŵ�С.\n�Ƿ������ӡ��";

                case PreviewStringId.Msg_CustomDrawWarning:
					return "���棡";

				case PreviewStringId.Msg_PageMarginsWarning:
                    return "һ�������ϵı߽糬���˴�ӡ��Χ.�Ƿ������";

				case PreviewStringId.Msg_IncorrectPageRange:
					return "���õ�ҳ�߽粻��ȷ";

                case PreviewStringId.Msg_FontInvalidNumber:
                    return "�����С����Ϊ0����";

                case PreviewStringId.Msg_NotSupportedFont:
                    return "�������岻��֧��";
				/*
				case PreviewStringId.Msg_IncorrectZoomFactor:
					return "���ֱ����� {0} �� {1} ֮�䡣";

				case PreviewStringId.Msg_InvalidMeasurement:
					return "���淶";
                 */
				case PreviewStringId.Margin_Inch:
					return "Ӣ��";

				case PreviewStringId.Margin_Millimeter:
                    return "����";

                case PreviewStringId.Margin_TopMargin:
					return "�ϱ߽�";

				case PreviewStringId.Margin_BottomMargin:
                    return "�±߽�";

				case PreviewStringId.Margin_LeftMargin:
					return "��߽�";

				case PreviewStringId.Margin_RightMargin:
					return "�ұ߽�";

				case PreviewStringId.ScrollingInfo_Page:
					return "ҳ";

				case PreviewStringId.WMForm_PictureDlg_Title:
					return "ѡ��ͼƬ";

				case PreviewStringId.WMForm_ImageStretch:
					return "��չ";

                case PreviewStringId.WMForm_ImageClip:
					return "����";

				case PreviewStringId.WMForm_ImageZoom:
                    return "����";

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
                    return "����";

                case PreviewStringId.WMForm_Direction_Vertical:
                    return "����";

                case PreviewStringId.WMForm_Direction_BackwardDiagonal:
                    return "������б";

                case PreviewStringId.WMForm_Direction_ForwardDiagonal:
					return "������б";

				case PreviewStringId.WMForm_VertAlign_Bottom:
					return "�׶�";

                case PreviewStringId.WMForm_VertAlign_Middle:
					return "�м�";

				case PreviewStringId.WMForm_VertAlign_Top:
                    return "����";

                case PreviewStringId.WMForm_HorzAlign_Left:
					return "����";

				case PreviewStringId.WMForm_HorzAlign_Center:
                    return "����";

                case PreviewStringId.WMForm_HorzAlign_Right:
					return "����";

				case PreviewStringId.WMForm_ZOrderRgrItem_InFront:
                    return "��ǰ��";

                case PreviewStringId.WMForm_ZOrderRgrItem_Behind:
					return "�ں���";

				case PreviewStringId.WMForm_PageRangeRgrItem_All:
                    return "ȫ��";

                case PreviewStringId.WMForm_PageRangeRgrItem_Pages:
					return "ҳ��";

				case PreviewStringId.SaveDlg_Title:
					return "���Ϊ";

				case PreviewStringId.SaveDlg_FilterPdf:
					return "PDF�ļ�";

				case PreviewStringId.SaveDlg_FilterTxt:
					return "Txt�ļ�";

				case PreviewStringId.SaveDlg_FilterCsv:
					return "CSV�ļ�";

				case PreviewStringId.SaveDlg_FilterMht:
					return "MHT�ļ�";

				case PreviewStringId.SaveDlg_FilterXls:
					return "Excel�ļ�";

				case PreviewStringId.SaveDlg_FilterRtf:
                    return "Rtf�ļ�";

                case PreviewStringId.SaveDlg_FilterHtm:
					return "HTML�ļ�";

				case PreviewStringId.MenuItem_File:
                    return "�ļ�(&F)";

                case PreviewStringId.MenuItem_View:
					return "��ͼ(&V)";

				case PreviewStringId.MenuItem_Background:
                    return "����(&B)";

                case PreviewStringId.MenuItem_PageSetup:
					return "ҳ������(&U)";

				case PreviewStringId.MenuItem_Print:
                    return "��ӡ(&P)...";

                case PreviewStringId.MenuItem_PrintDirect:
					return "ֱ�Ӵ�ӡ(&R)";

				case PreviewStringId.MenuItem_Export:
                    return "����(&E)";

                case PreviewStringId.MenuItem_Send:
					return "����(&D)";

				case PreviewStringId.MenuItem_Exit:
					return "�˳�(&X)";

				case PreviewStringId.MenuItem_ViewToolbar:
					return "������(&T)";

				case PreviewStringId.MenuItem_ViewStatusbar:
					return "״̬��(&S)";
			   /*
				case PreviewStringId.MenuItem_ViewContinuous:
					return "����";
                 
				case PreviewStringId.MenuItem_ViewFacing:
					return "��ҳ";
			   */
				case PreviewStringId.MenuItem_BackgrColor:
                    return "��ɫ(&C)...";

				case PreviewStringId.MenuItem_Watermark:
                    return "ˮӡ(&W)...";
				/*
				case PreviewStringId.MenuItem_ZoomPageWidth:
					return "ҳ��";
                
				case PreviewStringId.MenuItem_ZoomTextWidth:
					return "��ҳ";
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
					return "������";
               
				case PreviewStringId.BarText_MainMenu:
					return "���˵�";
				 
				case PreviewStringId.BarText_StatusBar:
					return "״̬��";
				*/
			}
			return base.GetLocalizedString(id);
		}
		public override string Language
		{
			get
			{
				return "��������";
			}
		}

    }


        #endregion

    }
}
