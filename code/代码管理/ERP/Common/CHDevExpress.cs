using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraBars.Localization;
//using DevExpress.XtraCharts.Localization;
using DevExpress.XtraEditors.Controls;
//using DevExpress.XtraLayout.Localization;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid.Localization;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraVerticalGrid.Localization;
using DevExpress.XtraBars.Customization;



namespace Common
{
    class Localization
    {
    }


    //XtraGrid
    public class DxperienceXtraGridLocalizationCHS : GridLocalizer
    {

        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.FileIsNotFoundError:
                    return "�ļ�{0}û���ҵ�";

                case GridStringId.ColumnViewExceptionMessage:
                    return "�Ƿ�ȷ���޸ģ�";

                case GridStringId.CustomizationCaption:
                    return "�Զ�����ʾ�ֶ�";

                case GridStringId.CustomizationColumns:
                    return "��";

                case GridStringId.CustomizationBands:
                    return "����";

                case GridStringId.PopupFilterAll:
                    return "(����)";

                case GridStringId.PopupFilterCustom:
                    return "(�Զ���)";

                case GridStringId.PopupFilterBlanks:
                    return "(��ֵ)";

                case GridStringId.PopupFilterNonBlanks:
                    return "(�ǿ�ֵ)";

                case GridStringId.CustomFilterDialogFormCaption:
                    return "�Զ���ɸѡ����";

                case GridStringId.CustomFilterDialogCaption:
                    return "����Ϊ:";

                case GridStringId.CustomFilterDialogRadioAnd:
                    return "����";

                case GridStringId.CustomFilterDialogRadioOr:
                    return "����";

                case GridStringId.CustomFilterDialogOkButton:
                    return "ȷ��(&O)";

                case GridStringId.CustomFilterDialogClearFilter:
                    return "���ɸѡ����(&L)";

                case GridStringId.CustomFilterDialog2FieldCheck:
                    return "�ֶ�";

                case GridStringId.CustomFilterDialogCancelButton:
                    return "ȡ��(&C)";

                case GridStringId.CustomFilterDialogConditionEQU:
                    return "����=";

                case GridStringId.CustomFilterDialogConditionNEQ:
                    return "������<>";

                case GridStringId.CustomFilterDialogConditionGT:
                    return "����>";

                case GridStringId.CustomFilterDialogConditionGTE:
                    return "���ڻ����>=";

                case GridStringId.CustomFilterDialogConditionLT:
                    return "С��<";

                case GridStringId.CustomFilterDialogConditionLTE:
                    return "С�ڻ����<=";

                case GridStringId.CustomFilterDialogConditionBlanks:
                    return "��ֵ";

                case GridStringId.CustomFilterDialogConditionNonBlanks:
                    return "�ǿ�ֵ";

                case GridStringId.CustomFilterDialogConditionLike:
                    return "����";

                case GridStringId.CustomFilterDialogConditionNotLike:
                    return "������";

                case GridStringId.MenuFooterSum:
                    return "�ϼ�";

                case GridStringId.MenuFooterMin:
                    return "��С";

                case GridStringId.MenuFooterMax:
                    return "���";

                case GridStringId.MenuFooterCount:
                    return "����";

                case GridStringId.MenuFooterAverage:
                    return "ƽ��";

                case GridStringId.MenuFooterNone:
                    return "��";

                case GridStringId.MenuFooterSumFormat:
                    return "�ϼ�={0:#.##}";

                case GridStringId.MenuFooterMinFormat:
                    return "��С={0}";

                case GridStringId.MenuFooterMaxFormat:
                    return "���={0}";

                case GridStringId.MenuFooterCountFormat:
                    return "{0}";

                case GridStringId.MenuFooterAverageFormat:
                    return "ƽ��={0:#.##}";

                case GridStringId.MenuColumnSortAscending:
                    return "��������";

                case GridStringId.MenuColumnSortDescending:
                    return "��������";

                case GridStringId.MenuColumnGroup:
                    return "�����з���";

                case GridStringId.MenuColumnUnGroup:
                    return "ȡ������";

                case GridStringId.MenuColumnColumnCustomization:
                    return "��ʾ/�����ֶ�";

                case GridStringId.MenuColumnBestFit:
                    return "�Զ������ֶο��";

                case GridStringId.MenuColumnFilter:
                    return "ɸѡ";

                case GridStringId.MenuColumnClearFilter:
                    return "���ɸѡ����";

                case GridStringId.MenuColumnBestFitAllColumns:
                    return "�Զ����������ֶο��";

                case GridStringId.MenuGroupPanelFullExpand:
                    return "չ��ȫ������";

                case GridStringId.MenuGroupPanelFullCollapse:
                    return "����ȫ������";

                case GridStringId.MenuGroupPanelClearGrouping:
                    return "������з���";

                case GridStringId.PrintDesignerGridView:
                    return "��ӡ����(���ģʽ)";

                case GridStringId.PrintDesignerCardView:
                    return "��ӡ����(��Ƭģʽ)";

                case GridStringId.PrintDesignerBandedView:
                    return "��ӡ����(����ģʽ)";

                case GridStringId.PrintDesignerBandHeader:
                    return "������";

                case GridStringId.MenuColumnGroupBox:
                    return "��ʾ/���ط�����";

                case GridStringId.CardViewNewCard:
                    return "�¿�Ƭ";

                case GridStringId.CardViewQuickCustomizationButton:
                    return "�Զ����ʽ";

                case GridStringId.CardViewQuickCustomizationButtonFilter:
                    return "ɸѡ";

                case GridStringId.CardViewQuickCustomizationButtonSort:
                    return "����:";

                case GridStringId.GridGroupPanelText:
                    return "�϶��б��⵽����з���";

                case GridStringId.GridNewRowText:
                    return "��������";

                case GridStringId.GridOutlookIntervals:
                    return "һ��������;�ϸ���;����ǰ;����ǰ;����;;;;;;;;����;����;����; ;;;;;;;����;���ܺ�;���ܺ�;�¸���;һ����֮��;";

                case GridStringId.PrintDesignerDescription:
                    return "Ϊ��ǰ��ͼ���ò�ͬ�Ĵ�ӡѡ��.";

                case GridStringId.MenuFooterCustomFormat:
                    return "�Զ�={0}";

                case GridStringId.MenuFooterCountGroupFormat:
                    return "����={0}";

               // case GridStringId.MenuColumnClearSorting:
                //    return "�������";
            }
            return base.GetLocalizedString(id);
        }
    }


    //XtraBars
    public class DxperienceXtraBarsLocalizationCHS : BarLocalizer
    {
        public override string GetLocalizedString(BarString id)
        {
            switch (id)
            {
                case BarString.None:
                    return "";

                case BarString.AddOrRemove:
                    return "������ɾ����ť(&A)";

                case BarString.ResetBar:
                    return "�Ƿ�ȷʵҪ���ö� '{0}' �������������޸ģ�";

                case BarString.ResetBarCaption:
                    return "�Զ���";

                case BarString.ResetButton:
                    return "���蹤����(&R)";

                case BarString.CustomizeButton:
                    return "�Զ���(&C)...";

                case BarString.ToolBarMenu:
                    return "����(&R)$ɾ��(&D)$!����(&N)$!��׼(&L)$��ʹ������(&T)$�ڲ˵���ֻ������(&O)$ͼ�����ı�(&A)$!��ʼһ��(&G)$���õ�(&M)";

                case BarString.ToolbarNameCaption:
                    return "����������(&T):";

                case BarString.NewToolbarCaption:
                    return "�½�������";

                case BarString.NewToolbarCustomNameFormat:
                    return "�Զ��� {0}";

                case BarString.RenameToolbarCaption:
                    return "��������";

                case BarString.CustomizeWindowCaption:
                    return "�Զ���";

                case BarString.MenuAnimationSystem:
                    return "(ϵͳĬ��)";

                case BarString.MenuAnimationNone:
                    return "��";

                case BarString.MenuAnimationSlide:
                    return "����";

                case BarString.MenuAnimationFade:
                    return "����";

                case BarString.MenuAnimationUnfold:
                    return "չ��";

                case BarString.MenuAnimationRandom:
                    return "���";
            }
            return base.GetLocalizedString(id);
        }




    }

    /*
    //XtraCharts
    public class DxperienceXtraChartsLocalizationCHS : ChartLocalizer
    {
        public override string GetLocalizedString(ChartStringId id)
        {
            switch (id)
            {
                case ChartStringId.SeriesPrefix:
                    return "���� ";

                case ChartStringId.PalettePrefix:
                    return "��ɫ�� ";

                case ChartStringId.ArgumentMember:
                    return "����";

                case ChartStringId.ValueMember:
                    return "ֵ";

                case ChartStringId.LowValueMember:
                    return "��";

                case ChartStringId.HighValueMember:
                    return "��";

                case ChartStringId.OpenValueMember:
                    return "����";

                case ChartStringId.CloseValueMember:
                    return "�ر�";

                case ChartStringId.DefaultDataFilterName:
                    return "����ɸѡ";

                case ChartStringId.DefaultChartTitle:
                    return "ͼ�����";

                case ChartStringId.MsgSeriesViewDoesNotExist:
                    return "{0}������ͼ�����ڡ�";

                case ChartStringId.MsgEmptyArrayOfValues:
                    return "����ֵΪ�ա�";

                case ChartStringId.MsgItemNotInCollection:
                    return "�˾ۼ����ܰ���ָ���";

                case ChartStringId.MsgIncorrectValue:
                    return "Incorrect value \"{0}\" for the argument \"{1}\".";

                case ChartStringId.MsgIncompatiblePointType:
                    return "The type of the \"{0}\" point isn't compatible with the {1} scale.";

                case ChartStringId.MsgIncompatibleArgumentDataMember:
                    return "The type of the \"{0}\" argument data member isn't compatible with the {1} scale.";

                case ChartStringId.MsgDesignTimeOnlySetting:
                    return "�����Բ�����������ʱ�䡣";

                case ChartStringId.MsgInvalidDataSource:
                    return "��Ч������Դ����(��֧�ֽӿ�ʵʩ)";

                case ChartStringId.MsgIncorrectDataMember:
                    return "The datasource doesn't contain a datamember with the \"{0}\" name.";

                case ChartStringId.MsgInvalidColorEachValue:
                    return "This view assumes that the ColorEach property is always set to \"{0}\".";

                case ChartStringId.MsgInvalidSortingKey:
                    return "������������ؼ��ʵ�ֵΪ {0}";

                case ChartStringId.MsgInvalidFilterCondition:
                    return "���� {0} ���������� \"{1}\" ����";

                case ChartStringId.MsgIncorrectDataAdapter:
                    return "{0} ����������������";

                case ChartStringId.MsgDataSnapshot:
                    return "The data snapshot is complete. All series data now statically persist in the chart. Note, this also means that the chart is now in unbound mode.";

                case ChartStringId.MsgModifyDefaultPaletteError:
                    return "��ɫ����Ĭ�ϵģ����ǲ��ܱ��޸�";

                case ChartStringId.MsgAddExistingPaletteError:
                    return "{0} ��ɫ���Ѿ������ڴ������";

                case ChartStringId.MsgInternalPropertyChangeError:
                    return "�����Խ������ڲ�ʹ�ã��㲻����ı�����ֵ";

                case ChartStringId.MsgPaletteNotFound:
                    return "ͼ���ܰ��� {0} ��ɫ��";

                case ChartStringId.MsgLabelSettingRuntimeError:
                    return "\"��ǩ\"���Բ�����������ʱ��";

                case ChartStringId.MsgPointOptionsSettingRuntimeError:
                    return "\"��ѡ��\"���Բ�����������ʱ��";

                case ChartStringId.MsgIncorrectMinValueOfAxisRange:
                    return "���귶Χ����СֵӦ��С�����ֵ ({0})";

                case ChartStringId.MsgIncorrectMaxValueOfAxisRange:
                    return "���귶Χ�����ֵӦ�ô�����Сֵ ({0})";

                case ChartStringId.MsgIncorrectNumericPrecision:
                    return "��ȷ��Ӧ�ô��ڵ���0";

                case ChartStringId.MsgIncorrectAxisThickness:
                    return "������Ӧ�ô���0";

                case ChartStringId.MsgIncorrectAxisIndent:
                    return "��������Ӧ�ô��ڵ���0";

                case ChartStringId.MsgIncorrectBarWidth:
                    return "����Ӧ�ô��ڵ���0";

                case ChartStringId.MsgIncorrectBorderThickness:
                    return "�߿���Ӧ�ô���0";

                case ChartStringId.MsgIncorrectChartTitleIndent:
                    return "��������Ӧ�ô��ڵ���0С��1000";

                case ChartStringId.MsgIncorrectLegendMarkerSize:
                    return "ͼ����СӦ�ô���0С��1000";

                case ChartStringId.MsgIncorrectLegendSpacingVertical:
                    return "ͼ����ֱ���Ӧ�ô��ڵ���0С��1000";

                case ChartStringId.MsgIncorrectLegendSpacingHorizontal:
                    return "ͼ��ˮƽ���Ӧ�ô��ڵ���0С��1000";

                case ChartStringId.MsgIncorrectMarkerSize:
                    return "��Ǵ�СӦ�ô���1";

                case ChartStringId.MsgIncorrectMarkerStarPointCount:
                    return "�����ĿӦ�ô���3С��101";

                case ChartStringId.MsgIncorrectPieSeriesLabelColumnIndent:
                    return "����ͼ����Ӧ�ô��ڵ���0";

                case ChartStringId.MsgIncorrectPercentPrecision:
                    return "�ٷֱȵľ�ȷ��Ӧ�ô���0";

                case ChartStringId.MsgIncorrectSeriesLabelLineLength:
                    return "��������Ӧ�ô��ڵ���0С��1000";

                case ChartStringId.MsgIncorrectStripMinLimit:
                    return "����С����Ӧ��С��������";

                case ChartStringId.MsgIncorrectStripMaxLimit:
                    return "��������Ӧ�ô�����С����";

                case ChartStringId.MsgIncorrectLineThickness:
                    return "�������Ӧ�ô���0";

                case ChartStringId.MsgIncorrectShadowSize:
                    return "��Ӱ��СӦ�ô���0";

                case ChartStringId.MsgIncorrectTickmarkThickness:
                    return "�̶��߿��Ӧ�ô���0";

                case ChartStringId.MsgIncorrectTickmarkLength:
                    return "�̶��߳���Ӧ�ô���0";

                case ChartStringId.MsgIncorrectTickmarkMinorCount:
                    return "�̶��߽�С����ĿӦ�ô���0С��100";

                case ChartStringId.MsgIncorrectTickmarkMinorThickness:
                    return "�̶��߽�С�Ŀ��Ӧ�ô���0";

                case ChartStringId.MsgIncorrectTickmarkMinorLength:
                    return "�̶��߽�С�ĳ���Ӧ�ô���0";

                case ChartStringId.MsgIncorrectPercentValue:
                    return "�ٷ���Ӧ�ô��ڵ���0С�ڵ���100";

                case ChartStringId.MsgIncorrectSimpleDiagramDimension:
                    return "��ͼ��ĳߴ�Ӧ�ô���0С��100";

                case ChartStringId.MsgIncorrectStockLevelLineLengthValue:
                    return "��Ʊ��ˮƽ�߳���Ӧ�ô��ڵ���0";

                case ChartStringId.MsgIncorrectReductionColorValue:
                    return "������ɫֵ����Ϊ��";

                case ChartStringId.MsgIncorrectLabelAngle:
                    return "��ǩ�ĽǶ�Ӧ�ô��ڵ���-360С�ڵ���360";

                case ChartStringId.MsgIncorrectImageBounds:
                    return "���ܴ���ͼ��Ϊָ���Ĵ�С";

                case ChartStringId.MsgInternalFile:
                    return "ָ�����ļ��Ǵ˹��̵��ڲ��ļ����ܱ�ʹ��";

                case ChartStringId.MsgIncorrectUseImageProperty:
                    return "ͼ�����Բ���ʹ����Webͼ��ؼ�����ʹ��ͼ��URL���Դ���";

                case ChartStringId.MsgIncorrectUseImageUrlProperty:
                    return "ͼ��URL����ֻ��ʹ����Webͼ��ؼ�����ʹ��ͼ�����Դ���";

                case ChartStringId.MsgEmptyArgument:
                    return "��������Ϊ�ա�";

                case ChartStringId.MsgIncorrectImageFormat:
                    return "���ܵ���ͼ��Ϊָ����ͼ���ʽ";

                case ChartStringId.MsgIncorrectValueDataMemberCount:
                    return "����ָ����ǰ������ͼ {0} ������ֵ��";

                case ChartStringId.MsgPaletteEditingIsntAllowed:
                    return "�༭������";

                case ChartStringId.MsgPaletteDoubleClickToEdit:
                    return "˫�����б༭...";

                case ChartStringId.MsgInvalidPaletteName:
                    return "Can't add a palette which has an empty name (\"\") to the palette repository. Please, specify a name for the palette.";

                case ChartStringId.VerbAbout:
                    return "����";

                case ChartStringId.VerbAboutDescription:
                    return "��XtraCharts��ʾ������Ϣ";

                case ChartStringId.VerbPopulate:
                    return "���";

                case ChartStringId.VerbPopulateDescription:
                    return "���ͼ������Դ";

                case ChartStringId.VerbClearDataSource:
                    return "�������Դ";

                case ChartStringId.VerbClearDataSourceDescription:
                    return "���ͼ������Դ";

                case ChartStringId.VerbDataSnapshot:
                    return "���ݳ���ӡ";

                case ChartStringId.VerbDataSnapshotDescription:
                    return "��ͼ��Χ����Դ�������ݺͲ������Դ��";

                case ChartStringId.VerbSeries:
                    return "����...";

                case ChartStringId.VerbSeriesDescription:
                    return "�򿪱༭�ۼ�����";

                case ChartStringId.VerbEditPalettes:
                    return "�༭��ɫ��...";

                case ChartStringId.VerbEditPalettesDescription:
                    return "�򿪱༭��ɫ�塣";

                case ChartStringId.VerbWizard:
                    return "��...";

                case ChartStringId.VerbWizardDescription:
                    return "����ͼ���򵼣�����༭�ĸ�ͼ�����ԡ�";

                case ChartStringId.PieIncorrectValuesText:
                    return "��ͼ������渺�������е�ֵ������ڵ���0��";

                case ChartStringId.FontFormat:
                    return "{0}, {1}pt, {2}";

                case ChartStringId.TrnSeriesChanged:
                    return "��������";

                case ChartStringId.TrnDataFiltersChanged:
                    return "����ɸѡ����";

                case ChartStringId.TrnValueDataMembersChanged:
                    return "������ֵ����";

                case ChartStringId.TrnChartTitlesChanged:
                    return "ͼ��������";

                case ChartStringId.TrnPalettesChanged:
                    return "��ɫ�����";

                case ChartStringId.TrnConstantLinesChanged:
                    return "�����и���";

                case ChartStringId.TrnStripsChanged:
                    return "������";

                case ChartStringId.TrnCustomAxisLabelChanged:
                    return "�Զ��������";

                case ChartStringId.TrnChartWizard:
                    return "ͼ��������Ӧ��";

                case ChartStringId.TrnSeriesDeleted:
                    return "ɾ������";

                case ChartStringId.TrnChartTitleDeleted:
                    return "ɾ��ͼ�����";

                case ChartStringId.TrnConstantLineDeleted:
                    return "ɾ��������";

                case ChartStringId.AxisXDefaultTitle:
                    return "�������";

                case ChartStringId.AxisYDefaultTitle:
                    return "����ֵ";

                case ChartStringId.MenuItemAdd:
                    return "����";

                case ChartStringId.MenuItemInsert:
                    return "����";

                case ChartStringId.MenuItemDelete:
                    return "ɾ��";

                case ChartStringId.MenuItemClear:
                    return "���";

                case ChartStringId.MenuItemMoveUp:
                    return "������";

                case ChartStringId.MenuItemMoveDown:
                    return "������";

                case ChartStringId.WizBarSeriesLabelPositionTop:
                    return "����";

                case ChartStringId.WizBarSeriesLabelPositionCenter:
                    return "����";

                case ChartStringId.WizPieSeriesLabelPositionInside:
                    return "����";

                case ChartStringId.WizPieSeriesLabelPositionOutside:
                    return "����";

                case ChartStringId.WizPieSeriesLabelPositionTwoColumns:
                    return "����";

                case ChartStringId.WizBoundSeries:
                    return "����Լ��";

                case ChartStringId.WizSeriesLabelDefaultText:
                    return "<��>";

                case ChartStringId.WizAddProjectDataSource:
                    return "��������Դ...";

                case ChartStringId.WizNullDataSourceConfirmation:
                    return "����������ԴΪ�պ����е�Լ��������Ϣ����ʧ����ȷ��Ҫ������";

                case ChartStringId.WizCurrentAppearance:
                    return "��ǰ���";

                case ChartStringId.WizNoSuitableData:
                    return "û�������ʺ��ڲ����㼶��";

                case ChartStringId.SvnSideBySideBar:
                    return "����ͼ";

                case ChartStringId.SvnStackedBar:
                    return "����ͼ";

                case ChartStringId.SvnFullStackedBar:
                    return "100%�ѵ�����ͼ";

                case ChartStringId.SvnPie:
                    return "��ͼ";

                case ChartStringId.SvnPoint:
                    return "����ͼ";

                case ChartStringId.SvnLine:
                    return "������";

                case ChartStringId.SvnStepLine:
                    return "�ֶ�����ͼ";

                case ChartStringId.SvnStock:
                    return "��Ʊͼ(���-���-����)";

                case ChartStringId.SvnCandleStick:
                    return "��Ʊͼ(����-���-���-����)";
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
*/

    //XtraEditors
    public class DxperienceXtraEditorsLocalizationCHS : Localizer
    {
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.None:
                    return "";

                case StringId.CaptionError:
                    return "����";

                case StringId.InvalidValueText:
                    return "��Ч��ֵ";

                case StringId.CheckChecked:
                    return "ѡ��";

                case StringId.CheckUnchecked:
                    return "δѡ��";

                case StringId.CheckIndeterminate:
                    return "δѡ��";

                case StringId.DateEditToday:
                    return "����";

                case StringId.DateEditClear:
                    return "���";

                case StringId.OK:
                    return "ȷ��(&O)";

                case StringId.Cancel:
                    return "ȡ��(&C)";

                case StringId.NavigatorFirstButtonHint:
                    return "��һ��";

                case StringId.NavigatorPreviousButtonHint:
                    return "��һ��";

                case StringId.NavigatorPreviousPageButtonHint:
                    return "��һҳ";

                case StringId.NavigatorNextButtonHint:
                    return "��һ��";

                case StringId.NavigatorNextPageButtonHint:
                    return "��һҳ";

                case StringId.NavigatorLastButtonHint:
                    return "���һ��";

                case StringId.NavigatorAppendButtonHint:
                    return "���";

                case StringId.NavigatorRemoveButtonHint:
                    return "ɾ��";

                case StringId.NavigatorEditButtonHint:
                    return "�༭";

                case StringId.NavigatorEndEditButtonHint:
                    return "�����༭";

                case StringId.NavigatorCancelEditButtonHint:
                    return "ȡ���༭";

                case StringId.NavigatorTextStringFormat:
                    return "��¼{0}/{1}";

                case StringId.PictureEditMenuCut:
                    return "����";

                case StringId.PictureEditMenuCopy:
                    return "����";

                case StringId.PictureEditMenuPaste:
                    return "ճ��";

                case StringId.PictureEditMenuDelete:
                    return "ɾ��";

                case StringId.PictureEditMenuLoad:
                    return "��ȡ";

                case StringId.PictureEditMenuSave:
                    return "����";

                case StringId.PictureEditOpenFileFilter:
                    return "Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon Files (*.ico)|*.ico|All Picture Files |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|All Files |*.*";

                case StringId.PictureEditSaveFileFilter:
                    return "Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg)|*.jpg";

                case StringId.PictureEditOpenFileTitle:
                    return "��";

                case StringId.PictureEditSaveFileTitle:
                    return "���Ϊ";

                case StringId.PictureEditOpenFileError:
                    return "�����ͼƬ��ʽ";

                case StringId.PictureEditOpenFileErrorCaption:
                    return "�򿪴���";

                case StringId.LookUpEditValueIsNull:
                    return "[������]";

                case StringId.LookUpInvalidEditValueType:
                    return "��Ч����������";

                case StringId.LookUpColumnDefaultName:
                    return "����";

                case StringId.MaskBoxValidateError:
                    return "������ֵ������. �Ƿ���Ҫ�޸�?\r\n\r\n�� - �ص��༭ģʽ���޸���ֵ.\r\n�� - ����ԭ����ֵ.\r\nȡ�� - �ظ�ԭ����ֵ.\r\n";

                case StringId.UnknownPictureFormat:
                    return "����ͼƬ��ʽ";

                case StringId.DataEmpty:
                    return "��ͼ��";

                case StringId.NotValidArrayLength:
                    return "��Ч�����鳤��.";

                case StringId.ImagePopupEmpty:
                    return "(��)";

                case StringId.ImagePopupPicture:
                    return "(ͼƬ)";

                case StringId.ColorTabCustom:
                    return "�Զ�";

                case StringId.ColorTabWeb:
                    return "����";

                case StringId.ColorTabSystem:
                    return "ϵͳ";

                case StringId.CalcButtonMC:
                    return "MC";

                case StringId.CalcButtonMR:
                    return "MR";

                case StringId.CalcButtonMS:
                    return "MS";

                case StringId.CalcButtonMx:
                    return "M+";

                case StringId.CalcButtonSqrt:
                    return "sqrt";

                case StringId.CalcButtonBack:
                    return "Back";

                case StringId.CalcButtonCE:
                    return "CE";

                case StringId.CalcButtonC:
                    return "C";

                case StringId.CalcError:
                    return "�������";

                case StringId.TabHeaderButtonPrev:
                    return "�������";

                case StringId.TabHeaderButtonNext:
                    return "���ҹ���";

                case StringId.TabHeaderButtonClose:
                    return "�ر�";

                case StringId.XtraMessageBoxOkButtonText:
                    return "ȷ��(&O)";

                case StringId.XtraMessageBoxCancelButtonText:
                    return "ȡ��(&C)";

                case StringId.XtraMessageBoxYesButtonText:
                    return "��(&Y)";

                case StringId.XtraMessageBoxNoButtonText:
                    return "��(&N)";

                case StringId.XtraMessageBoxAbortButtonText:
                    return "�ж�(&A)";

                case StringId.XtraMessageBoxRetryButtonText:
                    return "����(&R)";

                case StringId.XtraMessageBoxIgnoreButtonText:
                    return "����(&I)";

                case StringId.TextEditMenuUndo:
                    return "����(&U)";

                case StringId.TextEditMenuCut:
                    return "����(&T)";

                case StringId.TextEditMenuCopy:
                    return "����(&C)";

                case StringId.TextEditMenuPaste:
                    return "ճ��(&P)";

                case StringId.TextEditMenuDelete:
                    return "ɾ��(&D)";

                case StringId.TextEditMenuSelectAll:
                    return "ȫѡ(&A)";
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

/*
    //XtraLayout
    public class DxperienceXtraLayoutLocalizationCHS : LayoutLocalizer
    {
        public override string GetLocalizedString(LayoutStringId id)
        {
            switch (id)
            {
                case LayoutStringId.CustomizationParentName:
                    return "�Զ���";

                case LayoutStringId.DefaultItemText:
                    return "��Ŀ";

                case LayoutStringId.DefaultActionText:
                    return "Ĭ�Ϸ�ʽ";

                case LayoutStringId.DefaultEmptyText:
                    return "��";

                case LayoutStringId.LayoutItemDescription:
                    return "����";

                case LayoutStringId.LayoutGroupDescription:
                    return "�������";

                case LayoutStringId.TabbedGroupDescription:
                    return "�����ǩ��";

                case LayoutStringId.LayoutControlDescription:
                    return "����ؼ�";

                case LayoutStringId.CustomizationFormTitle:
                    return "�Զ���";

                case LayoutStringId.HiddenItemsPageTitle:
                    return "������Ŀ";

                case LayoutStringId.TreeViewPageTitle:
                    return "������ͼ";

                case LayoutStringId.RenameSelected:
                    return "������";

                case LayoutStringId.HideItemMenutext:
                    return "������Ŀ";

                case LayoutStringId.LockItemSizeMenuText:
                    return "������Ŀ��С";

                case LayoutStringId.UnLockItemSizeMenuText:
                    return "�⿪������Ŀ��С";

                case LayoutStringId.GroupItemsMenuText:
                    return "����";

                case LayoutStringId.UnGroupItemsMenuText:
                    return "ȡ������";

                case LayoutStringId.CreateTabbedGroupMenuText:
                    return "������ǩ";

                case LayoutStringId.AddTabMenuText:
                    return "������ǩ";

                case LayoutStringId.UnGroupTabbedGroupMenuText:
                    return "�Ƴ���ǩ";

                case LayoutStringId.TreeViewRootNodeName:
                    return "��Ŀ¼";

                case LayoutStringId.ShowCustomizationFormMenuText:
                    return "��ʾ�Զ��崰��";

                case LayoutStringId.HideCustomizationFormMenuText:
                    return "�����Զ��崰��";

                case LayoutStringId.EmptySpaceItemDefaultText:
                    return "����";

                case LayoutStringId.ControlGroupDefaultText:
                    return "��";

                case LayoutStringId.EmptyRootGroupText:
                    return "�϶�����";

                case LayoutStringId.EmptyTabbedGroupText:
                    return "�϶����鵽������";

                case LayoutStringId.ResetLayoutMenuText:
                    return "���ð���";

                case LayoutStringId.RenameMenuText:
                    return "������";

                case LayoutStringId.TextPositionMenuText:
                    return "�ı�λ��";

                case LayoutStringId.TextPositionLeftMenuText:
                    return "��";

                case LayoutStringId.TextPositionRightMenuText:
                    return "��";

                case LayoutStringId.TextPositionTopMenuText:
                    return "��";

                case LayoutStringId.TextPositionBottomMenuText:
                    return "��";

                case LayoutStringId.ShowTextMenuItem:
                    return "��ʾ�ı�";

                case LayoutStringId.LockSizeMenuItem:
                    return "������С";

                case LayoutStringId.LockWidthMenuItem:
                    return "�������";

                case LayoutStringId.LockHeightMenuItem:
                    return "�����߶�";
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
*/

    //XtraNavBar
    public class DxperienceXtraNavBarLocalizationCHS : NavBarLocalizer
    {
        public override string GetLocalizedString(NavBarStringId id)
        {
            switch (id)
            {
                case NavBarStringId.NavPaneMenuShowMoreButtons:
                    return "��ʾ����İ�ť(&M)";

                case NavBarStringId.NavPaneMenuShowFewerButtons:
                    return "��ʾ���ٵİ�ť(&F)";

                case NavBarStringId.NavPaneMenuAddRemoveButtons:
                    return "��ӻ�ɾ����ť(&A)";

                case NavBarStringId.NavPaneChevronHint:
                    return "���ð�ť";
            }
            return base.GetLocalizedString(id);
        }
    }


    //XtraPivotGrid
    public class DxperienceXtraPivotGridLocalizationCHS : PivotGridLocalizer
    {
        public override string GetLocalizedString(PivotGridStringId id)
        {
            switch (id)
            {
                case PivotGridStringId.RowHeadersCustomization:
                    return "�϶�������";

                case PivotGridStringId.ColumnHeadersCustomization:
                    return "�϶�������";

                case PivotGridStringId.FilterHeadersCustomization:
                    return "�϶�ɸѡ�ֶ�����";

                case PivotGridStringId.DataHeadersCustomization:
                    return "�϶�����������";

               // case PivotGridStringId.RowArea:
               //     return "����";

               // case PivotGridStringId.ColumnArea:
               //     return "����";

              //  case PivotGridStringId.FilterArea:
               //     return "ɸѡ��";

             //   case PivotGridStringId.DataArea:
             //       return "������";

                case PivotGridStringId.FilterShowAll:
                    return "��ʾȫ��";

                case PivotGridStringId.FilterShowBlanks:
                    return "��ʾ�հ�";

                case PivotGridStringId.CustomizationFormCaption:
                    return "PivotGrid�ֶ��б�";

                case PivotGridStringId.CustomizationFormText:
                    return "�϶���������PivotGrid";

                case PivotGridStringId.CustomizationFormAddTo:
                    return "��ӵ�";

                case PivotGridStringId.Total:
                    return "�ϼ�";

                case PivotGridStringId.GrandTotal:
                    return "�ܼ�";

                case PivotGridStringId.TotalFormat:
                    return "{0} �ϼ�";

                case PivotGridStringId.TotalFormatCount:
                    return "{0} ����";

                case PivotGridStringId.TotalFormatSum:
                    return "{0} ����";

                case PivotGridStringId.TotalFormatMin:
                    return "{0} ��С";

                case PivotGridStringId.TotalFormatMax:
                    return "{0} ���";

                case PivotGridStringId.TotalFormatAverage:
                    return "{0} ƽ��";

                case PivotGridStringId.TotalFormatStdDev:
                    return "{0} ��׼�����";

                case PivotGridStringId.TotalFormatStdDevp:
                    return "{0} ��չ��׼��";

                case PivotGridStringId.TotalFormatVar:
                    return "{0} ����������";

                case PivotGridStringId.TotalFormatVarp:
                    return "{0} ��չ������";

                case PivotGridStringId.TotalFormatCustom:
                    return "{0} �Զ���";

                case PivotGridStringId.PrintDesignerPageOptions:
                    return "ѡ��";

                case PivotGridStringId.PrintDesignerPageBehavior:
                    return "״̬";

                case PivotGridStringId.PrintDesignerCategoryDefault:
                    return "Ĭ��";

                case PivotGridStringId.PrintDesignerCategoryLines:
                    return "��";

                case PivotGridStringId.PrintDesignerCategoryHeaders:
                    return "����";

                case PivotGridStringId.PrintDesignerHorizontalLines:
                    return "ˮƽ��";

                case PivotGridStringId.PrintDesignerVerticalLines:
                    return "��ֱ��";

                case PivotGridStringId.PrintDesignerFilterHeaders:
                    return "ɸѡ����";

                case PivotGridStringId.PrintDesignerDataHeaders:
                    return "���ݱ���";

                case PivotGridStringId.PrintDesignerColumnHeaders:
                    return "�б���";

                case PivotGridStringId.PrintDesignerRowHeaders:
                    return "�б���";

                case PivotGridStringId.PrintDesignerUsePrintAppearance:
                    return "ʹ�ô�ӡ����";

                case PivotGridStringId.PopupMenuRefreshData:
                    return "��������";

                case PivotGridStringId.PopupMenuHideField:
                    return "����";

                case PivotGridStringId.PopupMenuShowFieldList:
                    return "��ʾ�ֶ��б�";

                case PivotGridStringId.PopupMenuHideFieldList:
                    return "�����ֶ��б�";

                case PivotGridStringId.PopupMenuFieldOrder:
                    return "����";

                case PivotGridStringId.PopupMenuMovetoBeginning:
                    return "�Ƶ���ͷ";

                case PivotGridStringId.PopupMenuMovetoLeft:
                    return "�Ƶ����";

                case PivotGridStringId.PopupMenuMovetoRight:
                    return "�Ƶ��ұ�";

                case PivotGridStringId.PopupMenuMovetoEnd:
                    return "�Ƶ����";

                case PivotGridStringId.PopupMenuCollapse:
                    return "����";

                case PivotGridStringId.PopupMenuExpand:
                    return "չ��";

                case PivotGridStringId.PopupMenuCollapseAll:
                    return "ȫ������";

                case PivotGridStringId.PopupMenuExpandAll:
                    return "ȫ��չ��";

                case PivotGridStringId.DataFieldCaption:
                    return "����";

                case PivotGridStringId.TopValueOthersRow:
                    return "����";
            }
            return base.GetLocalizedString(id);
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

                case PreviewStringId.MenuItem_PageLayout:
                    return "ҳ�沼��(&P)";

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

                case PreviewStringId.Msg_UnavailableNetPrinter:
                    return "�����ӡ���޷�ʹ��.";

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

                //case PreviewStringId.Msg_IncorrectZoomFactor:
                //    return "���ֱ����� {0} �� {1} ֮�䡣";

               // case PreviewStringId.Msg_InvalidMeasurement:
                 //   return "���淶";

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

                case PreviewStringId.MenuItem_ViewContinuous:
                    return "����";

                case PreviewStringId.MenuItem_ViewFacing:
                    return "��ҳ";

                case PreviewStringId.MenuItem_BackgrColor:
                    return "��ɫ(&C)...";

                case PreviewStringId.MenuItem_Watermark:
                    return "ˮӡ(&W)...";

                case PreviewStringId.MenuItem_ZoomPageWidth:
                    return "ҳ��";

                case PreviewStringId.MenuItem_ZoomTextWidth:
                    return "��ҳ";

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

                //case PreviewStringId.BarText_Toolbar:
                //    return "������";

               // case PreviewStringId.BarText_MainMenu:
               //     return "���˵�";

               // case PreviewStringId.BarText_StatusBar:
               //     return "״̬��";
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


    //XtraReports
    public class DxperienceXtraReportsLocalizationCHS : ReportLocalizer
    {
        public override string GetLocalizedString(ReportStringId id)
        {
            switch (id)
            {
                case ReportStringId.Msg_FileNotFound:
                    return "�ļ�û���ҵ�";

                case ReportStringId.Msg_WrongReportClassName:
                    return "һ���������ڲ��л��ڼ� - �����Ǳ�����������";

                case ReportStringId.Msg_CreateReportInstance:
                    return "����ͼ��һ����ͬ���͵ı������༭��\r\n�Ƿ�ȷ������ʵ����";

                case ReportStringId.Msg_FileCorrupted:
                    return "���ܼ��ر����ļ����ܱ��ƻ����߱��������ʧ��";

                //case ReportStringId.Msg_FileContentCorrupted:
                  //  return "���ܼ��ر����֣��ļ������𻵻�����������Ϣ��";

                case ReportStringId.Msg_IncorrectArgument:
                    return "����ֵ���벻��ȷ";

                case ReportStringId.Msg_InvalidMethodCall:
                    return "����ĵ�ǰ״̬�²��ܵ��ô˷���";

                case ReportStringId.Msg_ScriptError:
                    return "�ڽű��з��ִ���\r\n{0}";

                case ReportStringId.Msg_ScriptExecutionError:
                    return "�ڽű�ִ�й����з��ִ��� {0}:\r\n {1}\r\n���� {0} �����У��������ٱ����á�";

                case ReportStringId.Msg_InvalidReportSource:
                    return "�޷�����ԭ����";

                case ReportStringId.Msg_IncorrectBandType:
                    return "��Ч�Ĵ���";

                case ReportStringId.Msg_InvPropName:
                    return "��Ч��������";

                case ReportStringId.Msg_CantFitBarcodeToControlBounds:
                    return "������ؼ��ı߽�̫С";

                case ReportStringId.Msg_InvalidBarcodeText:
                    return "���ı�������Ч���ַ�";

                case ReportStringId.Msg_InvalidBarcodeTextFormat:
                    return "��Ч���ı���ʽ";

                case ReportStringId.Msg_CreateSomeInstance:
                    return "�ڴ����в��ܽ�������ʵ���ࡣ";

                case ReportStringId.Msg_DontSupportMulticolumn:
                    return "��ϸ����֧�ֶ��ֶΡ�";

                case ReportStringId.Msg_FillDataError:
                    return "���ݼ���ʱ�������󡣴���Ϊ��";

                case ReportStringId.Msg_CyclicBoormarks:
                    return "����ѭ����ǩ";

                case ReportStringId.Msg_LargeText:
                    return "�ı�̫��";

                //case ReportStringId.Msg_ScriptingPermissionErrorMessage:
                 //   return "�ڴ˱����������нű���\n\n��Ϣ:\n\n{0}";

                //case ReportStringId.Msg_ScriptingErrorTitle:
                //    return "�ű�����";

                case ReportStringId.Cmd_InsertDetailReport:
                    return "������ϸ����";

                case ReportStringId.Cmd_InsertUnboundDetailReport:
                    return "�ǰ�";

                case ReportStringId.Cmd_ViewCode:
                    return "���Ӵ���";

                case ReportStringId.Cmd_BringToFront:
                    return "�Ƶ����ϲ�";

                case ReportStringId.Cmd_SendToBack:
                    return "�Ƶ����²�";

                case ReportStringId.Cmd_AlignToGrid:
                    return "����������";

                case ReportStringId.Cmd_TopMargin:
                    return "���˱�Ե";

                case ReportStringId.Cmd_BottomMargin:
                    return "�׶˱�Ե";

                case ReportStringId.Cmd_ReportHeader:
                    return "������";

                case ReportStringId.Cmd_ReportFooter:
                    return "����β";

                case ReportStringId.Cmd_PageHeader:
                    return "ҳ��";

                case ReportStringId.Cmd_PageFooter:
                    return "ҳβ";

                case ReportStringId.Cmd_GroupHeader:
                    return "Ⱥ����";

                case ReportStringId.Cmd_GroupFooter:
                    return "Ⱥ��β";

                case ReportStringId.Cmd_Detail:
                    return "��ϸ";

                case ReportStringId.Cmd_DetailReport:
                    return "��ϸ����";

                case ReportStringId.Cmd_RtfClear:
                    return "���";

                case ReportStringId.Cmd_RtfLoad:
                    return "�����ļ�...";

                case ReportStringId.Cmd_TableInsert:
                    return "����(&I)";

                case ReportStringId.Cmd_TableInsertRowAbove:
                    return "����(&A)";

                case ReportStringId.Cmd_TableInsertRowBelow:
                    return "����(&B)";

                case ReportStringId.Cmd_TableInsertColumnToLeft:
                    return "����(&L)";

                case ReportStringId.Cmd_TableInsertColumnToRight:
                    return "����(&R)";

                case ReportStringId.Cmd_TableInsertCell:
                    return "��Ԫ��(&C)";

                case ReportStringId.Cmd_TableDelete:
                    return "ɾ��(&L)";

                case ReportStringId.Cmd_TableDeleteRow:
                    return "��(&R)";

                case ReportStringId.Cmd_TableDeleteColumn:
                    return "��(&C)";

                case ReportStringId.Cmd_TableDeleteCell:
                    return "��Ԫ��(&L)";

                case ReportStringId.Cmd_Cut:
                    return "����";

                case ReportStringId.Cmd_Copy:
                    return "����";

                case ReportStringId.Cmd_Paste:
                    return "ճ��";

                case ReportStringId.Cmd_Delete:
                    return "ɾ��";

                case ReportStringId.Cmd_Properties:
                    return "����";

                case ReportStringId.Cmd_InsertBand:
                    return "��������";

                case ReportStringId.CatLayout:
                    return "����";

                case ReportStringId.CatAppearance:
                    return "����";

                case ReportStringId.CatData:
                    return "����";

                case ReportStringId.CatBehavior:
                    return "״̬";

                case ReportStringId.CatNavigation:
                    return "����";

                case ReportStringId.CatPageSettings:
                    return "ҳ������";

                //case ReportStringId.CatUserDesigner:
                //    return "�û����";

                case ReportStringId.BandDsg_QuantityPerPage:
                    return "һ��ҳ�漯��";

                case ReportStringId.BandDsg_QuantityPerReport:
                    return "һ��������";

                case ReportStringId.UD_ReportDesigner:
                    return "XtraReport���";

                case ReportStringId.UD_Msg_ReportChanged:
                    return "���������ѱ��޸ģ��Ƿ���Ҫ���棿";

                case ReportStringId.UD_TTip_FileOpen:
                    return "���ļ�";

                case ReportStringId.UD_TTip_FileSave:
                    return "�����ļ�";

                case ReportStringId.UD_TTip_EditCut:
                    return "����";

                case ReportStringId.UD_TTip_EditCopy:
                    return "����";

                case ReportStringId.UD_TTip_EditPaste:
                    return "ճ��";

                case ReportStringId.UD_TTip_Undo:
                    return "����";

                case ReportStringId.UD_TTip_Redo:
                    return "�ָ�";

                case ReportStringId.UD_TTip_AlignToGrid:
                    return "����������";

                case ReportStringId.UD_TTip_AlignLeft:
                    return "�������������Ե";

                case ReportStringId.UD_TTip_AlignVerticalCenters:
                    return "�����������ˮƽ����";

                case ReportStringId.UD_TTip_AlignRight:
                    return "�������������Ե";

                case ReportStringId.UD_TTip_AlignTop:
                    return "�������������Ե";

                case ReportStringId.UD_TTip_AlignHorizontalCenters:
                    return "����������Ĵ�ֱ�м�";

                case ReportStringId.UD_TTip_AlignBottom:
                    return "�������������Ե";

                case ReportStringId.UD_TTip_SizeToControlWidth:
                    return "���ó���ͬ���";

                case ReportStringId.UD_TTip_SizeToGrid:
                    return "�������ߵ�����С";

                case ReportStringId.UD_TTip_SizeToControlHeight:
                    return "���ó���ͬ�߶�";

                case ReportStringId.UD_TTip_SizeToControl:
                    return "���ó���ͬ��С";

                case ReportStringId.UD_TTip_HorizSpaceMakeEqual:
                    return "��ˮƽ���������";

                case ReportStringId.UD_TTip_HorizSpaceIncrease:
                    return "����ˮƽ���";

                case ReportStringId.UD_TTip_HorizSpaceDecrease:
                    return "����ˮƽ���";

                case ReportStringId.UD_TTip_HorizSpaceConcatenate:
                    return "�Ƴ�ˮƽ���";

                case ReportStringId.UD_TTip_VertSpaceMakeEqual:
                    return "����ֱ�����Ϊ���";

                case ReportStringId.UD_TTip_VertSpaceIncrease:
                    return "���Ӵ�ֱ���";

                case ReportStringId.UD_TTip_VertSpaceDecrease:
                    return "���ٴ�ֱ���";

                case ReportStringId.UD_TTip_VertSpaceConcatenate:
                    return "�Ƴ���ֱ���";

                case ReportStringId.UD_TTip_CenterHorizontally:
                    return "ˮƽ����";

                case ReportStringId.UD_TTip_CenterVertically:
                    return "��ֱ����";

                case ReportStringId.UD_TTip_BringToFront:
                    return "�Ƶ����ϲ�";

                case ReportStringId.UD_TTip_SendToBack:
                    return "�Ƶ����²�";

                case ReportStringId.UD_TTip_FormatBold:
                    return "����";

                case ReportStringId.UD_TTip_FormatItalic:
                    return "б��";

                case ReportStringId.UD_TTip_FormatUnderline:
                    return "�»���";

                case ReportStringId.UD_TTip_FormatAlignLeft:
                    return "�����";

                case ReportStringId.UD_TTip_FormatCenter:
                    return "����";

                case ReportStringId.UD_TTip_FormatAlignRight:
                    return "�Ҷ���";

                case ReportStringId.UD_TTip_FormatFontName:
                    return "����";

                case ReportStringId.UD_TTip_FormatFontSize:
                    return "��С";

                case ReportStringId.UD_TTip_FormatForeColor:
                    return "ǰ����ɫ";

                case ReportStringId.UD_TTip_FormatBackColor:
                    return "������ɫ";

                case ReportStringId.UD_TTip_FormatJustify:
                    return "���˶���";

                case ReportStringId.UD_FormCaption:
                    return "XtraReport���";

                case ReportStringId.VS_XtraReportsToolboxCategoryName:
                    return "Developer Express: ����";

                case ReportStringId.UD_XtraReportsToolboxCategoryName:
                    return "��׼����";

                //case ReportStringId.UD_XtraReportsPointerItemCaption:
                  //  return "ָ��";

                case ReportStringId.Verb_EditBands:
                    return "�༭����...";

                case ReportStringId.Verb_EditGroupFields:
                    return "�༭���ֶ�...";

                case ReportStringId.Verb_Import:
                    return "����...";

                case ReportStringId.Verb_Save:
                    return "����...";

                case ReportStringId.Verb_About:
                    return "����...";

                case ReportStringId.Verb_RTFClear:
                    return "���";

                case ReportStringId.Verb_RTFLoad:
                    return "�����ļ�...";

                case ReportStringId.Verb_FormatString:
                    return "��ʽ���ַ���...";

                case ReportStringId.Verb_SummaryWizard:
                    return "�ܽ�...";

                case ReportStringId.Verb_ReportWizard:
                    return "��...";

                case ReportStringId.Verb_Insert:
                    return "����...";

                case ReportStringId.Verb_Delete:
                    return "ɾ��...";

                case ReportStringId.Verb_Bind:
                    return "��ֵ";

               // case ReportStringId.Verb_EditText:
               //     return "�ı��༭";

                case ReportStringId.FSForm_Lbl_Category:
                    return "���";

                case ReportStringId.FSForm_Lbl_Prefix:
                    return "�ϱ�";

                case ReportStringId.FSForm_Lbl_Suffix:
                    return "�±�";

                case ReportStringId.FSForm_Lbl_CustomGeneral:
                    return "һ���ʽ�������������ָ�ʽ";

                case ReportStringId.FSForm_GrBox_Sample:
                    return "����";

                case ReportStringId.FSForm_Tab_StandardTypes:
                    return "��׼����";

                case ReportStringId.FSForm_Tab_Custom:
                    return "�Զ���";

                case ReportStringId.FSForm_Msg_BadSymbol:
                    return "�𻵵ķ���";

                case ReportStringId.FSForm_Btn_Delete:
                    return "ɾ��";

                case ReportStringId.BCForm_Lbl_Property:
                    return "����";

                case ReportStringId.BCForm_Lbl_Binding:
                    return "���";

                case ReportStringId.SSForm_Caption:
                    return "ʽ�����༭";

                case ReportStringId.SSForm_Btn_Close:
                    return "�ر�";

                case ReportStringId.SSForm_Msg_NoStyleSelected:
                    return "û��ʽ����ѡ��";

                case ReportStringId.SSForm_Msg_MoreThanOneStyle:
                    return "��ѡ���˶��һ�����ϵ�ʽ��";

                case ReportStringId.SSForm_Msg_SelectedStylesText:
                    return "��ѡ�е�ʽ��...";

                case ReportStringId.SSForm_Msg_StyleSheetError:
                    return "StyleSheet����";

                case ReportStringId.SSForm_Msg_InvalidFileFormat:
                    return "��Ч���ļ���ʽ";

                case ReportStringId.SSForm_Msg_StyleNamePreviewPostfix:
                    return " ʽ��";

                case ReportStringId.SSForm_Msg_FileFilter:
                    return "Report StyleSheet files (*.repss)|*.repss|All files (*.*)|*.*";

                case ReportStringId.SSForm_TTip_AddStyle:
                    return "���ʽ��";

                case ReportStringId.SSForm_TTip_RemoveStyle:
                    return "�Ƴ�ʽ��";

                case ReportStringId.SSForm_TTip_ClearStyles:
                    return "���ʽ��";

                case ReportStringId.SSForm_TTip_PurgeStyles:
                    return "���ʽ��";

                case ReportStringId.SSForm_TTip_SaveStyles:
                    return "����ʽ�����ļ�";

                case ReportStringId.SSForm_TTip_LoadStyles:
                    return "���ļ��ж���ʽ��";

                case ReportStringId.FindForm_Msg_FinishedSearching:
                    return "�����ļ����";

                case ReportStringId.FindForm_Msg_TotalFound:
                    return "�ϼƲ���:";

                case ReportStringId.RepTabCtl_HtmlView:
                    return "HTML��ͼ";

                case ReportStringId.RepTabCtl_Preview:
                    return "Ԥ��";

                case ReportStringId.RepTabCtl_Designer:
                    return "���";

                case ReportStringId.PanelDesignMsg:
                    return "�ڴ˿ɷ��ò�ͬ�ؼ�";

                case ReportStringId.MultiColumnDesignMsg1:
                    return "�ظ���֮��Ŀ�λ";

                case ReportStringId.MultiColumnDesignMsg2:
                    return "�ؼ�λ�ò���ȷ�����ᵼ�´�ӡ����";

                // case ReportStringId.UD_Group_File:
                //    return "�ļ�(&F)";

              //  case ReportStringId.UD_Group_Edit:
               //     return "�༭(&E)";

               // case ReportStringId.UD_Group_View:
               //     return "��ͼ(&V)";

               // case ReportStringId.UD_Group_Format:
               //     return "��ʽ(&R)";

              //  case ReportStringId.UD_Group_Font:
               //     return "����(&F)";

              //  case ReportStringId.UD_Group_Justify:
               //     return "���˶���(&J)";

              //  case ReportStringId.UD_Group_Align:
              //      return "����(&A)";

                //case ReportStringId.UD_Group_MakeSameSize:
                //    return "���ó���ͬ��С(M)";

                //case ReportStringId.UD_Group_HorizontalSpacing:
                //    return "ˮƽ���(&H)";

                //case ReportStringId.UD_Group_VerticalSpacing:
                //    return "��ֱ���(&V)";

                //case ReportStringId.UD_Group_CenterInForm:
                //    return "���봰������(&C)";

                //case ReportStringId.UD_Group_Order:
                //    return "˳��(&O)";

                //case ReportStringId.UD_Group_ToolbarsList:
                //    return "������(&T)";

                //case ReportStringId.UD_Group_DockPanelsList:
                //    return "����(&W)";

                //case ReportStringId.UD_Capt_MainMenuName:
                //    return "���˵�";

                //case ReportStringId.UD_Capt_ToolbarName:
                //    return "������";

                //case ReportStringId.UD_Capt_LayoutToolbarName:
                //    return "���ֹ�����";

                //case ReportStringId.UD_Capt_FormattingToolbarName:
                //    return "��ʽ������";

                //case ReportStringId.UD_Capt_StatusBarName:
                //    return "״̬��";

                //case ReportStringId.UD_Capt_NewReport:
                //    return "����(&N)";

                //case ReportStringId.UD_Capt_NewWizardReport:
                //    return "��(&W)";

                //case ReportStringId.UD_Capt_OpenFile:
                //    return "����(&O)";

                //case ReportStringId.UD_Capt_SaveFile:
                //    return "����(&S)";

                //case ReportStringId.UD_Capt_SaveFileAs:
                //    return "���Ϊ(&A)...";

                //case ReportStringId.UD_Capt_Exit:
                //    return "����(&X)";

                //case ReportStringId.UD_Capt_Cut:
                //    return "����(&T)";

                //case ReportStringId.UD_Capt_Copy:
                //    return "����(&C)";

                //case ReportStringId.UD_Capt_Paste:
                //    return "ճ��(&P)";

                //case ReportStringId.UD_Capt_Delete:
                //    return "ɾ��(&D)";

                //case ReportStringId.UD_Capt_SelectAll:
                //    return "ȫѡ(&A)";

                //case ReportStringId.UD_Capt_Undo:
                //    return "��ԭ(&U)";

                //case ReportStringId.UD_Capt_Redo:
                //    return "�ظ�(&R)";

                //case ReportStringId.UD_Capt_ForegroundColor:
                //    return "ǰ��ɫ(&E)";

                //case ReportStringId.UD_Capt_BackGroundColor:
                //    return "����ɫ(&K)";

                //case ReportStringId.UD_Capt_FontBold:
                //    return "����(&B)";

                //case ReportStringId.UD_Capt_FontItalic:
                //    return "б��(&I)";

                //case ReportStringId.UD_Capt_FontUnderline:
                //    return "����(&U)";

                //case ReportStringId.UD_Capt_JustifyLeft:
                //    return "����(&L)";

                //case ReportStringId.UD_Capt_JustifyCenter:
                //    return "����(&C)";

                //case ReportStringId.UD_Capt_JustifyRight:
                //    return "����(&R)";

                //case ReportStringId.UD_Capt_JustifyJustify:
                //    return "���˶���(&J)";

                //case ReportStringId.UD_Capt_AlignLefts:
                //    return "��(&L)";

                //case ReportStringId.UD_Capt_AlignCenters:
                //    return "����(&C)";

                //case ReportStringId.UD_Capt_AlignRights:
                //    return "��(&R)";

                //case ReportStringId.UD_Capt_AlignTops:
                //    return "��(&T)";

                //case ReportStringId.UD_Capt_AlignMiddles:
                //    return "�м�(&M)";

                //case ReportStringId.UD_Capt_AlignBottoms:
                //    return "��(&B)";

                //case ReportStringId.UD_Capt_AlignToGrid:
                //    return "������(&G)";

                //case ReportStringId.UD_Capt_MakeSameSizeWidth:
                //    return "���(&W)";

                //case ReportStringId.UD_Capt_MakeSameSizeSizeToGrid:
                //    return "�������ߵ�����С(&D)";

                //case ReportStringId.UD_Capt_MakeSameSizeHeight:
                //    return "�߶�(&H)";

                //case ReportStringId.UD_Capt_MakeSameSizeBoth:
                //    return "����(&B)";

                //case ReportStringId.UD_Capt_SpacingMakeEqual:
                //    return "������(&E)";

                //case ReportStringId.UD_Capt_SpacingIncrease:
                //    return "����(&I)";

                //case ReportStringId.UD_Capt_SpacingDecrease:
                //    return "����(&D)";

                //case ReportStringId.UD_Capt_SpacingRemove:
                //    return "�Ƴ�(&R)";

                //case ReportStringId.UD_Capt_CenterInFormHorizontally:
                //    return "ˮƽ(&H)";

                //case ReportStringId.UD_Capt_CenterInFormVertically:
                //    return "��ֱ(&V)";

                //case ReportStringId.UD_Capt_OrderBringToFront:
                //    return "�ᵽ���ϲ�(&B)";

                //case ReportStringId.UD_Capt_OrderSendToBack:
                //    return "�Ƶ����²�(&S)";

                //case ReportStringId.UD_Hint_NewReport:
                //    return "�����±���";

                //case ReportStringId.UD_Hint_NewWizardReport:
                //    return "���򵼴����±���";

                //case ReportStringId.UD_Hint_OpenFile:
                //    return "�򿪱���";

                //case ReportStringId.UD_Hint_SaveFile:
                //    return "���汨��";

                //case ReportStringId.UD_Hint_SaveFileAs:
                //    return "�����������汨��";

                //case ReportStringId.UD_Hint_Exit:
                //    return "�ر����ʦ";

                //case ReportStringId.UD_Hint_Cut:
                //    return "ɾ���ؼ��͸��Ƶ�������";

                //case ReportStringId.UD_Hint_Copy:
                //    return "���ƿؼ���������";

                //case ReportStringId.UD_Hint_Paste:
                //    return "�Ӽ�������ӿؼ�";

                //case ReportStringId.UD_Hint_Delete:
                //    return "ɾ���ؼ�";

                //case ReportStringId.UD_Hint_SelectAll:
                //    return "ȫѡ";

                //case ReportStringId.UD_Hint_Undo:
                //    return "��ԭ������";

                //case ReportStringId.UD_Hint_Redo:
                //    return "�ظ�������";

                //case ReportStringId.UD_Hint_ForegroundColor:
                //    return "����ǰ��ɫ";

                //case ReportStringId.UD_Hint_BackGroundColor:
                //    return "���ñ���ɫ";

                //case ReportStringId.UD_Hint_FontBold:
                //    return "����";

                //case ReportStringId.UD_Hint_FontItalic:
                //    return "б��";

                //case ReportStringId.UD_Hint_FontUnderline:
                //    return "����";

                //case ReportStringId.UD_Hint_JustifyLeft:
                //    return "����";

                //case ReportStringId.UD_Hint_JustifyCenter:
                //    return "����";

                //case ReportStringId.UD_Hint_JustifyRight:
                //    return "����";

                //case ReportStringId.UD_Hint_JustifyJustify:
                //    return "���˶���";

                //case ReportStringId.UD_Hint_AlignLefts:
                //    return "��ѡ�ؼ������";

                //case ReportStringId.UD_Hint_AlignCenters:
                //    return "��ѡ����ؼ����ж���";

                //case ReportStringId.UD_Hint_AlignRights:
                //    return "��ѡ�ؼ��Ҷ���";

                //case ReportStringId.UD_Hint_AlignTops:
                //    return "��ѡ�ؼ��϶���";

                //case ReportStringId.UD_Hint_AlignMiddles:
                //    return "��ѡ����ؼ����ж���";

                //case ReportStringId.UD_Hint_AlignBottoms:
                //    return "��ѡ�ؼ��¶���";

                //case ReportStringId.UD_Hint_AlignToGrid:
                //    return "��ѡ�ؼ����߸����";

                //case ReportStringId.UD_Hint_MakeSameSizeWidth:
                //    return "��ѡ�ؼ����ó���ͬ���";

                //case ReportStringId.UD_Hint_MakeSameSizeSizeToGrid:
                //    return "��ѡ�ؼ����߸������С";

                //case ReportStringId.UD_Hint_MakeSameSizeHeight:
                //    return "��ѡ�ؼ����ó���ͬ�߶�";

                //case ReportStringId.UD_Hint_MakeSameSizeBoth:
                //    return "��ѡ�ؼ����ó���ͬ��С";

                //case ReportStringId.UD_Hint_SpacingMakeEqual:
                //    return "��ѡ�ؼ����������";

                //case ReportStringId.UD_Hint_SpacingIncrease:
                //    return "���ӱ�ѡ�ؼ��ļ��";

                //case ReportStringId.UD_Hint_SpacingDecrease:
                //    return "���ٱ�ѡ�ؼ��ļ��";

                //case ReportStringId.UD_Hint_SpacingRemove:
                //    return "�Ƴ���ѡ�ؼ��ļ��";

                //case ReportStringId.UD_Hint_CenterInFormHorizontally:
                //    return "��ѡ�ؼ�ˮƽ���봰������";

                //case ReportStringId.UD_Hint_CenterInFormVertically:
                //    return "��ѡ�ؼ���ֱ���봰������";

                //case ReportStringId.UD_Hint_OrderBringToFront:
                //    return "��ѡ�ؼ��ᵽ���ϲ�";

                //case ReportStringId.UD_Hint_OrderSendToBack:
                //    return "��ѡ�ؼ��ᵽ���²�";

                //case ReportStringId.UD_Hint_ViewBars:
                //    return "��ʾ/����{0}";

                //case ReportStringId.UD_Hint_ViewDockPanels:
                //    return "��ʾ/���� {0} ����";

                //case ReportStringId.UD_Hint_ViewTabs:
                //    return "ת�� {0} ��ǩ";

                //case ReportStringId.UD_Title_FieldList:
                //    return "�ֶ��嵥";

                //case ReportStringId.UD_Title_ReportExplorer:
                //    return "������Դ������";

                //case ReportStringId.UD_Title_PropertyGrid:
                //    return "����";

                //case ReportStringId.UD_Title_ToolBox:
                //    return "������";

                //case ReportStringId.STag_Name_Text:
                //    return "�ı�";

                //case ReportStringId.STag_Name_DataBinding:
                //    return "��������";

                //case ReportStringId.STag_Name_FormatString:
                //    return "�ַ�����ʽ";

                //case ReportStringId.STag_Name_ForeColor:
                //    return "ǰ��ɫ";

                //case ReportStringId.STag_Name_BackColor:
                //    return "����ɫ";

                //case ReportStringId.STag_Name_Font:
                //    return "����";

                //case ReportStringId.STag_Name_LineDirection:
                //    return "��������";

                //case ReportStringId.STag_Name_LineStyle:
                //    return "������ʽ";

                //case ReportStringId.STag_Name_LineWidth:
                //    return "�������";

                //case ReportStringId.STag_Name_CanGrow:
                //    return "����";

                //case ReportStringId.STag_Name_CanShrink:
                //    return "����";

                //case ReportStringId.STag_Name_Multiline:
                //    return "����";

                //case ReportStringId.STag_Name_Summary:
                //    return "ժҪ";

                //case ReportStringId.STag_Name_Symbology:
                //    return "����";

                //case ReportStringId.STag_Name_Module:
                //    return "ģ����";

                //case ReportStringId.STag_Name_ShowText:
                //    return "��ʾ�ı�";

                //case ReportStringId.STag_Name_SegmentWidth:
                //    return "�ֶο��";

                //case ReportStringId.STag_Name_Checked:
                //    return "ѡ��";

                //case ReportStringId.STag_Name_Image:
                //    return "ͼ��";

                //case ReportStringId.STag_Name_ImageUrl:
                //    return "ͼ��λ��(URL)";

                //case ReportStringId.STag_Name_ImageSizing:
                //    return "ͼ��ߴ�";

                //case ReportStringId.STag_Name_ReportSource:
                //    return "������Դ";

                //case ReportStringId.STag_Name_PreviewRowCount:
                //    return "Ԥ������";

                //case ReportStringId.STag_Name_ShrinkSubReportIconArea:
                //    return "�����ӱ����ͼ������";

                //case ReportStringId.STag_Name_PageInfo:
                //    return "ҳ����Ϣ";

                //case ReportStringId.STag_Name_StartPageNumber:
                //    return "��ʼҳ��";

                //case ReportStringId.STag_Name_Format:
                //    return "��ʽ";

                //case ReportStringId.STag_Name_KeepTogether:
                //    return "����һ��";

                //case ReportStringId.STag_Name_Bands:
                //    return "��";

                //case ReportStringId.STag_Name_Height:
                //    return "�߶�";

                //case ReportStringId.STag_Name_RepeatEveryPage:
                //    return "�ظ�ÿ��ҳ��";

                //case ReportStringId.STag_Name_PrintAtBottom:
                //    return "��ӡ�ڵ׶�";

                //case ReportStringId.STag_Name_GroupFields:
                //    return "Ⱥ������";

                //case ReportStringId.STag_Name_SortFields:
                //    return "�����ֶ�";

                //case ReportStringId.STag_Name_GroupUnion:
                //    return "Ⱥ�鲢��";

                //case ReportStringId.STag_Name_Level:
                //    return "���";

                //case ReportStringId.STag_Name_ColumnMode:
                //    return "��ģʽ";

                //case ReportStringId.STag_Name_ColumnCount:
                //    return "�м���";

                //case ReportStringId.STag_Name_ColumnWidth:
                //    return "�п�";

                //case ReportStringId.STag_Name_ColumnSpacing:
                //    return "�о�";

                //case ReportStringId.STag_Name_Direction:
                //    return "��������λ��";

                //case ReportStringId.STag_Name_Watermark:
                //    return "ˮӡ";

                //case ReportStringId.STag_Name_ReportUnit:
                //    return "����Ԫ";

                //case ReportStringId.STag_Name_DataSource:
                //    return "������Դ";

                //case ReportStringId.STag_Name_DataMember:
                //    return "������";

                //case ReportStringId.STag_Name_DataAdapter:
                //    return "����������";
            }
            return base.GetLocalizedString(id);
        }

    }



    //XtraScheduler
    public class DxperienceXtraSchedulerLocalizationCHS : SchedulerLocalizer
    {
        public override string GetLocalizedString(SchedulerStringId id)
        {
            switch (id)
            {
                case SchedulerStringId.Msg_IsNotValid:
                    return "'{0}' ����� '{1}' ����һ����Ч����ֵ.";

                case SchedulerStringId.Msg_InvalidDayOfWeekForDailyRecurrence:
                    return "Invalid day of week for a daily recurrence. Only WeekDays.EveryDay, WeekDays.WeekendDays and WeekDays.WorkDays are valid in this context.";

                case SchedulerStringId.Msg_InternalError:
                    return "�ڲ�����!";

                case SchedulerStringId.Msg_NoMappingForObject:
                    return "���� \r\n {0} δ������ص� Mappings.";

                case SchedulerStringId.Msg_XtraSchedulerNotAssigned:
                    return "SchedulerStorage �ؼ�δ���� ScheulerControl ����";

                case SchedulerStringId.Msg_InvalidTimeOfDayInterval:
                    return "��Ч��ʱ��";

                case SchedulerStringId.Msg_OverflowTimeOfDayInterval:
                    return "��Ч����ֵ. ��ֵ�������ڻ������һ��.";

                case SchedulerStringId.Msg_LoadCollectionFromXml:
                    return "����XML��Ŀʱ, ��־��������ڷǰ�ģʽ";

                case SchedulerStringId.AppointmentLabel_None:
                    return "��";

                case SchedulerStringId.AppointmentLabel_Important:
                    return "��Ҫ";

                case SchedulerStringId.AppointmentLabel_Business:
                    return "����";

                case SchedulerStringId.AppointmentLabel_Personal:
                    return "����";

                case SchedulerStringId.AppointmentLabel_Vacation:
                    return "�ݼ�";

                case SchedulerStringId.AppointmentLabel_MustAttend:
                    return "�����ϯ";

                case SchedulerStringId.AppointmentLabel_TravelRequired:
                    return "��������";

                case SchedulerStringId.AppointmentLabel_NeedsPreparation:
                    return "��Ҫ׼��";

                case SchedulerStringId.AppointmentLabel_Birthday:
                    return "����";

                case SchedulerStringId.AppointmentLabel_Anniversary:
                    return "�������";

                case SchedulerStringId.AppointmentLabel_PhoneCall:
                    return "ͨ��";

                case SchedulerStringId.Msg_InvalidEndDate:
                    return "���ʱ�䲻�����ڿ�ʼʱ��";

                case SchedulerStringId.Caption_Appointment:
                    return "{0} - Լ��";

                case SchedulerStringId.Caption_Event:
                    return "{0} - Ҫ��";

                case SchedulerStringId.Caption_UntitledAppointment:
                    return "δ����";

                case SchedulerStringId.Caption_WeekDaysEveryDay:
                    return "��";

                case SchedulerStringId.Caption_WeekDaysWeekendDays:
                    return "��ĩ";

                case SchedulerStringId.Caption_WeekDaysWorkDays:
                    return "������";

                case SchedulerStringId.Caption_WeekOfMonthFirst:
                    return "��һ��";

                case SchedulerStringId.Caption_WeekOfMonthSecond:
                    return "�ڶ���";

                case SchedulerStringId.Caption_WeekOfMonthThird:
                    return "������";

                case SchedulerStringId.Caption_WeekOfMonthFourth:
                    return "������";

                case SchedulerStringId.Caption_WeekOfMonthLast:
                    return "���һ��";

                case SchedulerStringId.Msg_InvalidDayCount:
                    return "�޷���������. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidDayCountValue:
                    return "�޷���������. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidWeekCount:
                    return "�޷���������. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidWeekCountValue:
                    return "�޷���������. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidMonthCount:
                    return "�޷������·�. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidMonthCountValue:
                    return "�޷������·�. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidYearCount:
                    return "�޷��������. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidYearCountValue:
                    return "�޷��������. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidOccurrencesCount:
                    return "�޷��������ڴ���. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidOccurrencesCountValue:
                    return "�޷��������ڴ���. ��������ȷ��ֵ.";

                case SchedulerStringId.Msg_InvalidDayNumber:
                    return "����������Ч. ���������� 1 �� {0} ֮�����ֵ.";

                case SchedulerStringId.Msg_InvalidDayNumberValue:
                    return "����������Ч. ���������� 1 �� {0} ֮�����ֵ.";

                case SchedulerStringId.Msg_WarningDayNumber:
                    return "��Щ�·����� {0} ��. ���ڽ��������·ݵ����һ��.";

                case SchedulerStringId.Msg_InvalidDayOfWeek:
                    return "û�����ӱ�ѡ��. ������ѡ��һ������.";

                case SchedulerStringId.MenuCmd_OpenAppointment:
                    return "����(&O)";

                case SchedulerStringId.MenuCmd_PrintAppointment:
                    return "��ӡ(&P)";

                case SchedulerStringId.MenuCmd_DeleteAppointment:
                    return "ɾ��(&D)";

                case SchedulerStringId.MenuCmd_EditSeries:
                    return "�༭����(&E)";

                case SchedulerStringId.MenuCmd_RestoreOccurrence:
                    return "�ظ�Ĭ��״̬(&R)";

                case SchedulerStringId.MenuCmd_NewAppointment:
                    return "��Լ��(&O)";

                case SchedulerStringId.MenuCmd_NewAllDayEvent:
                    return "����ȫ��Ҫ��(&E)";

                case SchedulerStringId.MenuCmd_NewRecurringAppointment:
                    return "��������Լ��(&A)";

                case SchedulerStringId.MenuCmd_NewRecurringEvent:
                    return "��������Ҫ��(&V)";

                case SchedulerStringId.MenuCmd_GotoThisDay:
                    return "����(&D)";

                case SchedulerStringId.MenuCmd_GotoToday:
                    return "����(&D)";

                case SchedulerStringId.MenuCmd_GotoDate:
                    return "��ָ������(&E)...";

                case SchedulerStringId.MenuCmd_OtherSettings:
                    return "��������(&I)...";

                case SchedulerStringId.MenuCmd_CustomizeCurrentView:
                    return "�Զ��嵱ǰ��ͼ(&C)...";

                case SchedulerStringId.MenuCmd_CustomizeTimeRuler:
                    return "���ʱ��...";

                case SchedulerStringId.MenuCmd_5Minutes:
                    return "5����";

                case SchedulerStringId.MenuCmd_6Minutes:
                    return "6����";

                case SchedulerStringId.MenuCmd_10Minutes:
                    return "10����";

                case SchedulerStringId.MenuCmd_15Minutes:
                    return "15����";

                case SchedulerStringId.MenuCmd_20Minutes:
                    return "20����";

                case SchedulerStringId.MenuCmd_30Minutes:
                    return "30����";

                case SchedulerStringId.MenuCmd_60Minutes:
                    return "60����";

                case SchedulerStringId.MenuCmd_SwitchViewMenu:
                    return "�ı���ͼ";

                case SchedulerStringId.MenuCmd_SwitchToDayView:
                    return "��(&D)";

                case SchedulerStringId.MenuCmd_SwitchToWorkWeekView:
                    return "������(&R)";

                case SchedulerStringId.MenuCmd_SwitchToWeekView:
                    return "����(&W)";

                case SchedulerStringId.MenuCmd_SwitchToMonthView:
                    return "��(&M)";

                case SchedulerStringId.MenuCmd_ShowTimeAs:
                    return "��ʾʱ��Ϊ(&S)";

                case SchedulerStringId.MenuCmd_Free:
                    return "����(&F)";

                case SchedulerStringId.MenuCmd_Busy:
                    return "æµ(&B)";

                case SchedulerStringId.MenuCmd_Tentative:
                    return "�ݶ�(&T)";

                case SchedulerStringId.MenuCmd_OutOfOffice:
                    return "���ڰ칫��(&O)";

                case SchedulerStringId.MenuCmd_LabelAs:
                    return "��ע(&L)";

                case SchedulerStringId.MenuCmd_AppointmentLabelNone:
                    return "��(&N)";

                case SchedulerStringId.MenuCmd_AppointmentLabelImportant:
                    return "��Ҫ(&I)";

                case SchedulerStringId.MenuCmd_AppointmentLabelBusiness:
                    return "����(&B)";

                case SchedulerStringId.MenuCmd_AppointmentLabelPersonal:
                    return "����(P)";

                case SchedulerStringId.MenuCmd_AppointmentLabelVacation:
                    return "�ݼ�(&V)";

                case SchedulerStringId.MenuCmd_AppointmentLabelMustAttend:
                    return "�����ϯ(&A)";

                case SchedulerStringId.MenuCmd_AppointmentLabelTravelRequired:
                    return "��������(&T)";

                case SchedulerStringId.MenuCmd_AppointmentLabelNeedsPreparation:
                    return "��Ҫ׼��(&N)";

                case SchedulerStringId.MenuCmd_AppointmentLabelBirthday:
                    return "����(&B)";

                case SchedulerStringId.MenuCmd_AppointmentLabelAnniversary:
                    return "�������(&A)";

                case SchedulerStringId.MenuCmd_AppointmentLabelPhoneCall:
                    return "ͨ��(&P)";

                case SchedulerStringId.MenuCmd_AppointmentMove:
                    return "�Ƴ�(&V)";

                case SchedulerStringId.MenuCmd_AppointmentCopy:
                    return "����(&C)";

                case SchedulerStringId.MenuCmd_AppointmentCancel:
                    return "ȡ��(&A)";

                case SchedulerStringId.Caption_5Minutes:
                    return "5����";

                case SchedulerStringId.Caption_6Minutes:
                    return "6����";

                case SchedulerStringId.Caption_10Minutes:
                    return "10����";

                case SchedulerStringId.Caption_15Minutes:
                    return "15����";

                case SchedulerStringId.Caption_20Minutes:
                    return "20����";

                case SchedulerStringId.Caption_30Minutes:
                    return "30����";

                case SchedulerStringId.Caption_60Minutes:
                    return "60����";

                case SchedulerStringId.Caption_Free:
                    return "����";

                case SchedulerStringId.Caption_Busy:
                    return "æµ";

                case SchedulerStringId.Caption_Tentative:
                    return "�ݶ�";

                case SchedulerStringId.Caption_OutOfOffice:
                    return "���ڰ칫��";

                case SchedulerStringId.ViewDisplayName_Day:
                    return "��������";

                case SchedulerStringId.ViewDisplayName_WorkDays:
                    return "������������";

                case SchedulerStringId.ViewDisplayName_Week:
                    return "��������";

                case SchedulerStringId.ViewDisplayName_Month:
                    return "��������";

                case SchedulerStringId.Abbr_MinutesShort1:
                    return "��";

                case SchedulerStringId.Abbr_MinutesShort2:
                    return "��";

                case SchedulerStringId.Abbr_Minute:
                    return "����";

                case SchedulerStringId.Abbr_Minutes:
                    return "����";

                case SchedulerStringId.Abbr_HoursShort:
                    return "Сʱ";

                case SchedulerStringId.Abbr_Hour:
                    return "Сʱ";

                case SchedulerStringId.Abbr_Hours:
                    return "Сʱ";

                case SchedulerStringId.Abbr_DaysShort:
                    return "��";

                case SchedulerStringId.Abbr_Day:
                    return "��";

                case SchedulerStringId.Abbr_Days:
                    return "��";

                case SchedulerStringId.Abbr_WeeksShort:
                    return "��";

                case SchedulerStringId.Abbr_Week:
                    return "��";

                case SchedulerStringId.Abbr_Weeks:
                    return "��";

                case SchedulerStringId.Abbr_Month:
                    return "�·�";

                case SchedulerStringId.Abbr_Months:
                    return "�·�";

                case SchedulerStringId.Abbr_Year:
                    return "��";

                case SchedulerStringId.Abbr_Years:
                    return "��";

                case SchedulerStringId.Caption_Reminder:
                    return "{0} ��ʾ";

                case SchedulerStringId.Caption_Reminders:
                    return "{0} ��ʾ";

                case SchedulerStringId.Caption_StartTime:
                    return "��ʼʱ��: {0}";

                case SchedulerStringId.Caption_NAppointmentsAreSelected:
                    return "{0} Լ�ᱻѡ��";

                case SchedulerStringId.Format_TimeBeforeStart:
                    return "δ��ʼǰ {0}";

                case SchedulerStringId.Msg_Conflict:
                    return "һ��޸ĵ�Լ�������һ�������Լ����ֳ�ͻ.";

                case SchedulerStringId.Msg_InvalidAppointmentDuration:
                    return "��Ч��Լ��ʱ��. ����������.";

                case SchedulerStringId.Msg_InvalidReminderTimeBeforeStart:
                    return "��Ч������ʱ��. ����������.";

                case SchedulerStringId.TextDuration_FromTo:
                    return "�� {0} �� {1}";

                case SchedulerStringId.TextDuration_FromForDays:
                    return "�� {0} �� {1} ";

                case SchedulerStringId.TextDuration_FromForDaysHours:
                    return "�� {0} �� {1} {2}";

                case SchedulerStringId.TextDuration_FromForDaysMinutes:
                    return "�� {0} �� {1} {3}";

                case SchedulerStringId.TextDuration_FromForDaysHoursMinutes:
                    return "�� {0} �� {1} {2} {3}";

                case SchedulerStringId.TextDuration_ForPattern:
                    return "{0} {1}";

                case SchedulerStringId.TextDailyPatternString_EveryDay:
                    return "ÿ {0} {1}";

                case SchedulerStringId.TextDailyPatternString_EveryDays:
                    return "ÿ {0} {1} {2}";

                case SchedulerStringId.TextDailyPatternString_EveryWeekDay:
                    return "ÿ�������� {0}";

                case SchedulerStringId.TextDailyPatternString_EveryWeekend:
                    return "ÿ����ĩ {0}";

                case SchedulerStringId.TextWeekly_1Day:
                    return "{0}";

                case SchedulerStringId.TextWeekly_2Day:
                    return "{0} �� {1}";

                case SchedulerStringId.TextWeekly_3Day:
                    return "{0}, {1}, �� {2}";

                case SchedulerStringId.TextWeekly_4Day:
                    return "{0}, {1}, {2}, �� {3}";

                case SchedulerStringId.TextWeekly_5Day:
                    return "{0}, {1}, {2}, {3}, �� {4}";

                case SchedulerStringId.TextWeekly_6Day:
                    return "{0}, {1}, {2}, {3}, {4}, �� {5}";

                case SchedulerStringId.TextWeekly_7Day:
                    return "{0}, {1}, {2}, {3}, {4}, {5}, �� {6}";

                case SchedulerStringId.TextWeeklyPatternString_EveryWeek:
                    return "every {2} {3}";

                case SchedulerStringId.TextWeeklyPatternString_EveryWeeks:
                    return "every {0} {1} on {2} {3}";

                case SchedulerStringId.TextMonthlyPatternString_SubPattern:
                    return "of every {0} {1} {2}";

                case SchedulerStringId.TextYearlyPattern_YearString1:
                    return "every {0} {1} {4}";

                case SchedulerStringId.TextYearlyPattern_YearString2:
                    return "the {0} {1} of {2} {5}";

                case SchedulerStringId.TextYearlyPattern_YearsString1:
                    return "{0} {1} of every {2} {3} {4}";

                case SchedulerStringId.TextYearlyPattern_YearsString2:
                    return "the {0} {1} of {2} every {3} {4} {5}";

                case SchedulerStringId.Caption_AllDay:
                    return "ȫ��";

                case SchedulerStringId.Caption_PleaseSeeAbove:
                    return "�뿴����";

                case SchedulerStringId.Caption_RecurrenceSubject:
                    return "��ּ:";

                case SchedulerStringId.Caption_RecurrenceLocation:
                    return "�ص�:";

                case SchedulerStringId.Caption_RecurrenceStartTime:
                    return "��ʼ:";

                case SchedulerStringId.Caption_RecurrenceEndTime:
                    return "����:";

                case SchedulerStringId.Caption_RecurrenceShowTimeAs:
                    return "��ʾʱ��Ϊ:";

                case SchedulerStringId.Caption_Recurrence:
                    return "������:";

                case SchedulerStringId.Caption_RecurrencePattern:
                    return "ѭ��ģʽ";

                case SchedulerStringId.Caption_NoneRecurrence:
                    return "(��)";

                case SchedulerStringId.MemoPrintDateFormat:
                    return "{0} {1} {2}";

                case SchedulerStringId.Caption_EmptyResource:
                    return "�κ�";

                case SchedulerStringId.Caption_DailyPrintStyle:
                    return "����ʽ";

                case SchedulerStringId.Caption_WeeklyPrintStyle:
                    return "����ʽ";

                case SchedulerStringId.Caption_MonthlyPrintStyle:
                    return "����ʽ";

                case SchedulerStringId.Caption_TrifoldPrintStyle:
                    return "������ʽ";

                case SchedulerStringId.Caption_CalendarDetailsPrintStyle:
                    return "����ϸ����ʽ";

                case SchedulerStringId.Caption_MemoPrintStyle:
                    return "����¼��ʽ";

                case SchedulerStringId.Caption_ColorConverterFullColor:
                    return "ȫ��";

                case SchedulerStringId.Caption_ColorConverterGrayScale:
                    return "�ҽ�";

                case SchedulerStringId.Caption_ColorConverterBlackAndWhite:
                    return "���ڰ�";

                case SchedulerStringId.Caption_ResourceNone:
                    return "(��)";

                case SchedulerStringId.Caption_ResourceAll:
                    return "(����)";

                case SchedulerStringId.PrintPageSetupFormatTabControlCustomizeShading:
                    return "<�Զ���...>";

                case SchedulerStringId.PrintPageSetupFormatTabControlSizeAndFontName:
                    return "{0} pt. {1}";

                case SchedulerStringId.PrintRangeControlInvalidDate:
                    return "�������ڱ�����ڻ���ڿ�ʼ����";

                case SchedulerStringId.PrintCalendarDetailsControlDayPeriod:
                    return "��";

                case SchedulerStringId.PrintCalendarDetailsControlWeekPeriod:
                    return "��";

                case SchedulerStringId.PrintCalendarDetailsControlMonthPeriod:
                    return "�·�";

                case SchedulerStringId.PrintMonthlyOptControlOnePagePerMonth:
                    return "1ҳÿ��";

                case SchedulerStringId.PrintMonthlyOptControlTwoPagesPerMonth:
                    return "2ҳÿ��";

                case SchedulerStringId.PrintTimeIntervalControlInvalidDuration:
                    return "ʱ�α��벻������ʹ���0";

                case SchedulerStringId.PrintTimeIntervalControlInvalidStartEndTime:
                    return "����ʱ�������ڿ�ʼʱ��";

                case SchedulerStringId.PrintTriFoldOptControlDailyCalendar:
                    return "����";

                case SchedulerStringId.PrintTriFoldOptControlWeeklyCalendar:
                    return "����";

                case SchedulerStringId.PrintTriFoldOptControlMonthlyCalendar:
                    return "����";

                case SchedulerStringId.PrintWeeklyOptControlOneWeekPerPage:
                    return "1ҳÿ��";

                case SchedulerStringId.PrintWeeklyOptControlTwoWeekPerPage:
                    return "2ҳÿ��";

                case SchedulerStringId.PrintPageSetupFormCaption:
                    return "��ӡѡ��: {0}";

                case SchedulerStringId.PrintMoreItemsMsg:
                    return "������Ŀ...";

                //case SchedulerStringId.PrintNoPrintersInstalled:
                //    return "û�а�װ��ӡ��";

                //case SchedulerStringId.Caption_IncreaseVisibleResourcesCount:
                //    return "���ӿɼ�����Դ����";

                //case SchedulerStringId.Caption_DecreaseVisibleResourcesCount:
                //    return "���ٿɼ�����Դ����";
            }
            return base.GetLocalizedString(id);
        }

    }



    //XtraTreeList
    public class DxperienceXtraTreeListLocalizationCHS : TreeListLocalizer
    {
        public override string GetLocalizedString(TreeListStringId id)
        {
            string text1 = string.Empty;
            switch (id)
            {
                case TreeListStringId.MenuFooterSum:
                    return "�ϼ�";

                case TreeListStringId.MenuFooterMin:
                    return "��Сֵ";

                case TreeListStringId.MenuFooterMax:
                    return "���ֵ";

                case TreeListStringId.MenuFooterCount:
                    return "����";

                case TreeListStringId.MenuFooterAverage:
                    return "ƽ��";

                case TreeListStringId.MenuFooterNone:
                    return "��";

                case TreeListStringId.MenuFooterAllNodes:
                    return "ȫ���ڵ�";

                case TreeListStringId.MenuFooterSumFormat:
                    return "�ϼ�={0:#.##}";

                case TreeListStringId.MenuFooterMinFormat:
                    return "��Сֵ={0}";

                case TreeListStringId.MenuFooterMaxFormat:
                    return "���ֵ={0}";

                case TreeListStringId.MenuFooterCountFormat:
                    return "{0}";

                case TreeListStringId.MenuFooterAverageFormat:
                    return "ƽ��ֵ={0:#.##}";

                case TreeListStringId.MenuColumnSortAscending:
                    return "��������";

                case TreeListStringId.MenuColumnSortDescending:
                    return "��������";

                case TreeListStringId.MenuColumnColumnCustomization:
                    return "��ѡ��";

                case TreeListStringId.MenuColumnBestFit:
                    return "���ƥ��";

                case TreeListStringId.MenuColumnBestFitAllColumns:
                    return "���ƥ�� (������)";

                case TreeListStringId.ColumnCustomizationText:
                    return "�Զ���ʾ�ֶ�";

                case TreeListStringId.ColumnNamePrefix:
                    return "�����ױ�";

                case TreeListStringId.PrintDesignerHeader:
                    return "��ӡ����";

                case TreeListStringId.PrintDesignerDescription:
                    return "Ϊ��ǰ����״�б����ò�ͬ�Ĵ�ӡѡ��.";

                case TreeListStringId.InvalidNodeExceptionText:
                    return "�Ƿ�ȷ��Ҫ�޸ģ�";

                case TreeListStringId.MultiSelectMethodNotSupported:
                    return "OptionsBehavior.MultiSelectδ����ʱ��ָ���������ܹ���.";
            }
            return base.GetLocalizedString(id);
        }

    }



    //XtraVertical
    public class DxperienceXtraVerticalGridLocalizationCHS : VGridLocalizer
    {
        public override string GetLocalizedString(VGridStringId id)
        {
            string text1 = string.Empty;
            switch (id)
            {
                case VGridStringId.RowCustomizationText:
                    return "�Զ���";

                case VGridStringId.RowCustomizationNewCategoryFormText:
                    return "�������";

                case VGridStringId.RowCustomizationNewCategoryFormLabelText:
                    return "����";

                case VGridStringId.RowCustomizationNewCategoryText:
                    return "����...";

                case VGridStringId.RowCustomizationDeleteCategoryText:
                    return "ɾ��...";

                case VGridStringId.RowCustomizationTabPageCategoriesText:
                    return "���";

                case VGridStringId.RowCustomizationTabPageRowsText:
                    return "��";

                case VGridStringId.InvalidRecordExceptionText:
                    return "�Ƿ�ȷ���޸ģ�";

                case VGridStringId.StyleCreatorName:
                    return "�Զ���ʽ��";
            }
            return base.GetLocalizedString(id);
        }

    }


}

