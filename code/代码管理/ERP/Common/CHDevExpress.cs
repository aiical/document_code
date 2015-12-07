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
                    return "文件{0}没有找到";

                case GridStringId.ColumnViewExceptionMessage:
                    return "是否确定修改？";

                case GridStringId.CustomizationCaption:
                    return "自定义显示字段";

                case GridStringId.CustomizationColumns:
                    return "列";

                case GridStringId.CustomizationBands:
                    return "分区";

                case GridStringId.PopupFilterAll:
                    return "(所有)";

                case GridStringId.PopupFilterCustom:
                    return "(自定义)";

                case GridStringId.PopupFilterBlanks:
                    return "(空值)";

                case GridStringId.PopupFilterNonBlanks:
                    return "(非空值)";

                case GridStringId.CustomFilterDialogFormCaption:
                    return "自定义筛选条件";

                case GridStringId.CustomFilterDialogCaption:
                    return "条件为:";

                case GridStringId.CustomFilterDialogRadioAnd:
                    return "并且";

                case GridStringId.CustomFilterDialogRadioOr:
                    return "或者";

                case GridStringId.CustomFilterDialogOkButton:
                    return "确定(&O)";

                case GridStringId.CustomFilterDialogClearFilter:
                    return "清除筛选条件(&L)";

                case GridStringId.CustomFilterDialog2FieldCheck:
                    return "字段";

                case GridStringId.CustomFilterDialogCancelButton:
                    return "取消(&C)";

                case GridStringId.CustomFilterDialogConditionEQU:
                    return "等于=";

                case GridStringId.CustomFilterDialogConditionNEQ:
                    return "不等于<>";

                case GridStringId.CustomFilterDialogConditionGT:
                    return "大于>";

                case GridStringId.CustomFilterDialogConditionGTE:
                    return "大于或等于>=";

                case GridStringId.CustomFilterDialogConditionLT:
                    return "小于<";

                case GridStringId.CustomFilterDialogConditionLTE:
                    return "小于或等于<=";

                case GridStringId.CustomFilterDialogConditionBlanks:
                    return "空值";

                case GridStringId.CustomFilterDialogConditionNonBlanks:
                    return "非空值";

                case GridStringId.CustomFilterDialogConditionLike:
                    return "包含";

                case GridStringId.CustomFilterDialogConditionNotLike:
                    return "不包含";

                case GridStringId.MenuFooterSum:
                    return "合计";

                case GridStringId.MenuFooterMin:
                    return "最小";

                case GridStringId.MenuFooterMax:
                    return "最大";

                case GridStringId.MenuFooterCount:
                    return "计数";

                case GridStringId.MenuFooterAverage:
                    return "平均";

                case GridStringId.MenuFooterNone:
                    return "空";

                case GridStringId.MenuFooterSumFormat:
                    return "合计={0:#.##}";

                case GridStringId.MenuFooterMinFormat:
                    return "最小={0}";

                case GridStringId.MenuFooterMaxFormat:
                    return "最大={0}";

                case GridStringId.MenuFooterCountFormat:
                    return "{0}";

                case GridStringId.MenuFooterAverageFormat:
                    return "平均={0:#.##}";

                case GridStringId.MenuColumnSortAscending:
                    return "升序排序";

                case GridStringId.MenuColumnSortDescending:
                    return "降序排序";

                case GridStringId.MenuColumnGroup:
                    return "按此列分组";

                case GridStringId.MenuColumnUnGroup:
                    return "取消分组";

                case GridStringId.MenuColumnColumnCustomization:
                    return "显示/隐藏字段";

                case GridStringId.MenuColumnBestFit:
                    return "自动调整字段宽度";

                case GridStringId.MenuColumnFilter:
                    return "筛选";

                case GridStringId.MenuColumnClearFilter:
                    return "清除筛选条件";

                case GridStringId.MenuColumnBestFitAllColumns:
                    return "自动调整所有字段宽度";

                case GridStringId.MenuGroupPanelFullExpand:
                    return "展开全部分组";

                case GridStringId.MenuGroupPanelFullCollapse:
                    return "收缩全部分组";

                case GridStringId.MenuGroupPanelClearGrouping:
                    return "清除所有分组";

                case GridStringId.PrintDesignerGridView:
                    return "打印设置(表格模式)";

                case GridStringId.PrintDesignerCardView:
                    return "打印设置(卡片模式)";

                case GridStringId.PrintDesignerBandedView:
                    return "打印设置(区域模式)";

                case GridStringId.PrintDesignerBandHeader:
                    return "区标题";

                case GridStringId.MenuColumnGroupBox:
                    return "显示/隐藏分组区";

                case GridStringId.CardViewNewCard:
                    return "新卡片";

                case GridStringId.CardViewQuickCustomizationButton:
                    return "自定义格式";

                case GridStringId.CardViewQuickCustomizationButtonFilter:
                    return "筛选";

                case GridStringId.CardViewQuickCustomizationButtonSort:
                    return "排序:";

                case GridStringId.GridGroupPanelText:
                    return "拖动列标题到这进行分组";

                case GridStringId.GridNewRowText:
                    return "新增资料";

                case GridStringId.GridOutlookIntervals:
                    return "一个月以上;上个月;三周前;两周前;上周;;;;;;;;昨天;今天;明天; ;;;;;;;下周;两周后;三周后;下个月;一个月之后;";

                case GridStringId.PrintDesignerDescription:
                    return "为当前视图设置不同的打印选项.";

                case GridStringId.MenuFooterCustomFormat:
                    return "自定={0}";

                case GridStringId.MenuFooterCountGroupFormat:
                    return "计数={0}";

               // case GridStringId.MenuColumnClearSorting:
                //    return "清除排序";
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
                    return "新增或删除按钮(&A)";

                case BarString.ResetBar:
                    return "是否确实要重置对 '{0}' 工具栏所作的修改？";

                case BarString.ResetBarCaption:
                    return "自定义";

                case BarString.ResetButton:
                    return "重设工具栏(&R)";

                case BarString.CustomizeButton:
                    return "自定义(&C)...";

                case BarString.ToolBarMenu:
                    return "重设(&R)$删除(&D)$!命名(&N)$!标准(&L)$总使用文字(&T)$在菜单中只用文字(&O)$图像与文本(&A)$!开始一组(&G)$常用的(&M)";

                case BarString.ToolbarNameCaption:
                    return "工具栏名称(&T):";

                case BarString.NewToolbarCaption:
                    return "新建工具栏";

                case BarString.NewToolbarCustomNameFormat:
                    return "自定义 {0}";

                case BarString.RenameToolbarCaption:
                    return "重新命名";

                case BarString.CustomizeWindowCaption:
                    return "自定义";

                case BarString.MenuAnimationSystem:
                    return "(系统默认)";

                case BarString.MenuAnimationNone:
                    return "空";

                case BarString.MenuAnimationSlide:
                    return "滚动";

                case BarString.MenuAnimationFade:
                    return "减弱";

                case BarString.MenuAnimationUnfold:
                    return "展开";

                case BarString.MenuAnimationRandom:
                    return "随机";
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
                    return "级联 ";

                case ChartStringId.PalettePrefix:
                    return "调色板 ";

                case ChartStringId.ArgumentMember:
                    return "参数";

                case ChartStringId.ValueMember:
                    return "值";

                case ChartStringId.LowValueMember:
                    return "低";

                case ChartStringId.HighValueMember:
                    return "高";

                case ChartStringId.OpenValueMember:
                    return "开启";

                case ChartStringId.CloseValueMember:
                    return "关闭";

                case ChartStringId.DefaultDataFilterName:
                    return "数据筛选";

                case ChartStringId.DefaultChartTitle:
                    return "图表标题";

                case ChartStringId.MsgSeriesViewDoesNotExist:
                    return "{0}级联视图不存在。";

                case ChartStringId.MsgEmptyArrayOfValues:
                    return "数组值为空。";

                case ChartStringId.MsgItemNotInCollection:
                    return "此聚集不能包含指定项。";

                case ChartStringId.MsgIncorrectValue:
                    return "Incorrect value \"{0}\" for the argument \"{1}\".";

                case ChartStringId.MsgIncompatiblePointType:
                    return "The type of the \"{0}\" point isn't compatible with the {1} scale.";

                case ChartStringId.MsgIncompatibleArgumentDataMember:
                    return "The type of the \"{0}\" argument data member isn't compatible with the {1} scale.";

                case ChartStringId.MsgDesignTimeOnlySetting:
                    return "此属性不能设置运行时间。";

                case ChartStringId.MsgInvalidDataSource:
                    return "无效的数据源类型(不支持接口实施)";

                case ChartStringId.MsgIncorrectDataMember:
                    return "The datasource doesn't contain a datamember with the \"{0}\" name.";

                case ChartStringId.MsgInvalidColorEachValue:
                    return "This view assumes that the ColorEach property is always set to \"{0}\".";

                case ChartStringId.MsgInvalidSortingKey:
                    return "不能设置排序关键词的值为 {0}";

                case ChartStringId.MsgInvalidFilterCondition:
                    return "条件 {0} 不能适用于 \"{1}\" 数据";

                case ChartStringId.MsgIncorrectDataAdapter:
                    return "{0} 对象不是数据适配器";

                case ChartStringId.MsgDataSnapshot:
                    return "The data snapshot is complete. All series data now statically persist in the chart. Note, this also means that the chart is now in unbound mode.";

                case ChartStringId.MsgModifyDefaultPaletteError:
                    return "调色板是默认的，于是不能被修改";

                case ChartStringId.MsgAddExistingPaletteError:
                    return "{0} 调色板已经存在于储存裤中";

                case ChartStringId.MsgInternalPropertyChangeError:
                    return "此属性仅仅在内部使用，你不允许改变它的值";

                case ChartStringId.MsgPaletteNotFound:
                    return "图表不能包含 {0} 调色板";

                case ChartStringId.MsgLabelSettingRuntimeError:
                    return "\"标签\"属性不能设置运行时间";

                case ChartStringId.MsgPointOptionsSettingRuntimeError:
                    return "\"点选项\"属性不能设置运行时间";

                case ChartStringId.MsgIncorrectMinValueOfAxisRange:
                    return "坐标范围的最小值应该小于最大值 ({0})";

                case ChartStringId.MsgIncorrectMaxValueOfAxisRange:
                    return "坐标范围的最大值应该大于最小值 ({0})";

                case ChartStringId.MsgIncorrectNumericPrecision:
                    return "精确度应该大于等于0";

                case ChartStringId.MsgIncorrectAxisThickness:
                    return "坐标宽度应该大于0";

                case ChartStringId.MsgIncorrectAxisIndent:
                    return "坐标缩进应该大于等于0";

                case ChartStringId.MsgIncorrectBarWidth:
                    return "条宽应该大于等于0";

                case ChartStringId.MsgIncorrectBorderThickness:
                    return "边框宽度应该大于0";

                case ChartStringId.MsgIncorrectChartTitleIndent:
                    return "标题缩进应该大于等于0小于1000";

                case ChartStringId.MsgIncorrectLegendMarkerSize:
                    return "图例大小应该大于0小于1000";

                case ChartStringId.MsgIncorrectLegendSpacingVertical:
                    return "图例垂直间距应该大于等于0小于1000";

                case ChartStringId.MsgIncorrectLegendSpacingHorizontal:
                    return "图例水平间距应该大于等于0小于1000";

                case ChartStringId.MsgIncorrectMarkerSize:
                    return "标记大小应该大于1";

                case ChartStringId.MsgIncorrectMarkerStarPointCount:
                    return "点的数目应该大于3小于101";

                case ChartStringId.MsgIncorrectPieSeriesLabelColumnIndent:
                    return "柱型图缩进应该大于等于0";

                case ChartStringId.MsgIncorrectPercentPrecision:
                    return "百分比的精确度应该大于0";

                case ChartStringId.MsgIncorrectSeriesLabelLineLength:
                    return "线条长度应该大于等于0小于1000";

                case ChartStringId.MsgIncorrectStripMinLimit:
                    return "条最小界限应该小于最大界限";

                case ChartStringId.MsgIncorrectStripMaxLimit:
                    return "条最大界限应该大于最小界限";

                case ChartStringId.MsgIncorrectLineThickness:
                    return "线条宽度应该大于0";

                case ChartStringId.MsgIncorrectShadowSize:
                    return "阴影大小应该大于0";

                case ChartStringId.MsgIncorrectTickmarkThickness:
                    return "刻度线宽度应该大于0";

                case ChartStringId.MsgIncorrectTickmarkLength:
                    return "刻度线长度应该大于0";

                case ChartStringId.MsgIncorrectTickmarkMinorCount:
                    return "刻度线较小的数目应该大于0小于100";

                case ChartStringId.MsgIncorrectTickmarkMinorThickness:
                    return "刻度线较小的宽度应该大于0";

                case ChartStringId.MsgIncorrectTickmarkMinorLength:
                    return "刻度线较小的长度应该大于0";

                case ChartStringId.MsgIncorrectPercentValue:
                    return "百分率应该大于等于0小于等于100";

                case ChartStringId.MsgIncorrectSimpleDiagramDimension:
                    return "简单图表的尺寸应该大于0小于100";

                case ChartStringId.MsgIncorrectStockLevelLineLengthValue:
                    return "股票的水平线长度应该大于等于0";

                case ChartStringId.MsgIncorrectReductionColorValue:
                    return "降低颜色值不能为空";

                case ChartStringId.MsgIncorrectLabelAngle:
                    return "标签的角度应该大于等于-360小于等于360";

                case ChartStringId.MsgIncorrectImageBounds:
                    return "不能创建图像为指定的大小";

                case ChartStringId.MsgInternalFile:
                    return "指定的文件是此工程的内部文件不能被使用";

                case ChartStringId.MsgIncorrectUseImageProperty:
                    return "图像属性不能使用在Web图表控件，请使用图像URL属性代替";

                case ChartStringId.MsgIncorrectUseImageUrlProperty:
                    return "图像URL属性只能使用在Web图表控件，请使用图像属性代替";

                case ChartStringId.MsgEmptyArgument:
                    return "参数不能为空。";

                case ChartStringId.MsgIncorrectImageFormat:
                    return "不能导出图表为指定的图像格式";

                case ChartStringId.MsgIncorrectValueDataMemberCount:
                    return "必须指定当前级联视图 {0} 数据项值。";

                case ChartStringId.MsgPaletteEditingIsntAllowed:
                    return "编辑不允许！";

                case ChartStringId.MsgPaletteDoubleClickToEdit:
                    return "双击进行编辑...";

                case ChartStringId.MsgInvalidPaletteName:
                    return "Can't add a palette which has an empty name (\"\") to the palette repository. Please, specify a name for the palette.";

                case ChartStringId.VerbAbout:
                    return "关于";

                case ChartStringId.VerbAboutDescription:
                    return "在XtraCharts显示基本信息";

                case ChartStringId.VerbPopulate:
                    return "填充";

                case ChartStringId.VerbPopulateDescription:
                    return "填充图表数据源";

                case ChartStringId.VerbClearDataSource:
                    return "清除数据源";

                case ChartStringId.VerbClearDataSourceDescription:
                    return "清除图表数据源";

                case ChartStringId.VerbDataSnapshot:
                    return "数据抽点打印";

                case ChartStringId.VerbDataSnapshotDescription:
                    return "从图表范围数据源复制数据和拆分数据源。";

                case ChartStringId.VerbSeries:
                    return "级联...";

                case ChartStringId.VerbSeriesDescription:
                    return "打开编辑聚集级联";

                case ChartStringId.VerbEditPalettes:
                    return "编辑调色板...";

                case ChartStringId.VerbEditPalettesDescription:
                    return "打开编辑调色板。";

                case ChartStringId.VerbWizard:
                    return "向导...";

                case ChartStringId.VerbWizardDescription:
                    return "运行图表向导，允许编辑哪个图表属性。";

                case ChartStringId.PieIncorrectValuesText:
                    return "饼图不能描绘负数。所有的值必须大于等于0。";

                case ChartStringId.FontFormat:
                    return "{0}, {1}pt, {2}";

                case ChartStringId.TrnSeriesChanged:
                    return "级联更改";

                case ChartStringId.TrnDataFiltersChanged:
                    return "数据筛选更改";

                case ChartStringId.TrnValueDataMembersChanged:
                    return "数据项值更改";

                case ChartStringId.TrnChartTitlesChanged:
                    return "图表标题更改";

                case ChartStringId.TrnPalettesChanged:
                    return "调色板更改";

                case ChartStringId.TrnConstantLinesChanged:
                    return "不变行更改";

                case ChartStringId.TrnStripsChanged:
                    return "条更改";

                case ChartStringId.TrnCustomAxisLabelChanged:
                    return "自定坐标更改";

                case ChartStringId.TrnChartWizard:
                    return "图表向导设置应用";

                case ChartStringId.TrnSeriesDeleted:
                    return "删除级联";

                case ChartStringId.TrnChartTitleDeleted:
                    return "删除图表标题";

                case ChartStringId.TrnConstantLineDeleted:
                    return "删除不变行";

                case ChartStringId.AxisXDefaultTitle:
                    return "坐标参数";

                case ChartStringId.AxisYDefaultTitle:
                    return "坐标值";

                case ChartStringId.MenuItemAdd:
                    return "新增";

                case ChartStringId.MenuItemInsert:
                    return "插入";

                case ChartStringId.MenuItemDelete:
                    return "删除";

                case ChartStringId.MenuItemClear:
                    return "清除";

                case ChartStringId.MenuItemMoveUp:
                    return "往上移";

                case ChartStringId.MenuItemMoveDown:
                    return "往下移";

                case ChartStringId.WizBarSeriesLabelPositionTop:
                    return "顶端";

                case ChartStringId.WizBarSeriesLabelPositionCenter:
                    return "居中";

                case ChartStringId.WizPieSeriesLabelPositionInside:
                    return "里面";

                case ChartStringId.WizPieSeriesLabelPositionOutside:
                    return "外面";

                case ChartStringId.WizPieSeriesLabelPositionTwoColumns:
                    return "两列";

                case ChartStringId.WizBoundSeries:
                    return "级联约束";

                case ChartStringId.WizSeriesLabelDefaultText:
                    return "<空>";

                case ChartStringId.WizAddProjectDataSource:
                    return "新增数据源...";

                case ChartStringId.WizNullDataSourceConfirmation:
                    return "在设置数据源为空后，所有的约束级联信息将丢失。你确定要继续？";

                case ChartStringId.WizCurrentAppearance:
                    return "当前外观";

                case ChartStringId.WizNoSuitableData:
                    return "没有数据适合于产生点级联";

                case ChartStringId.SvnSideBySideBar:
                    return "柱形图";

                case ChartStringId.SvnStackedBar:
                    return "横条图";

                case ChartStringId.SvnFullStackedBar:
                    return "100%堆叠柱形图";

                case ChartStringId.SvnPie:
                    return "饼图";

                case ChartStringId.SvnPoint:
                    return "泡泡图";

                case ChartStringId.SvnLine:
                    return "折线线";

                case ChartStringId.SvnStepLine:
                    return "分段折线图";

                case ChartStringId.SvnStock:
                    return "股票图(最高-最低-收盘)";

                case ChartStringId.SvnCandleStick:
                    return "股票图(开盘-最高-最低-收盘)";
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
                    return "错误";

                case StringId.InvalidValueText:
                    return "无效的值";

                case StringId.CheckChecked:
                    return "选中";

                case StringId.CheckUnchecked:
                    return "未选中";

                case StringId.CheckIndeterminate:
                    return "未选择";

                case StringId.DateEditToday:
                    return "今天";

                case StringId.DateEditClear:
                    return "清除";

                case StringId.OK:
                    return "确定(&O)";

                case StringId.Cancel:
                    return "取消(&C)";

                case StringId.NavigatorFirstButtonHint:
                    return "第一条";

                case StringId.NavigatorPreviousButtonHint:
                    return "上一条";

                case StringId.NavigatorPreviousPageButtonHint:
                    return "上一页";

                case StringId.NavigatorNextButtonHint:
                    return "下一条";

                case StringId.NavigatorNextPageButtonHint:
                    return "下一页";

                case StringId.NavigatorLastButtonHint:
                    return "最后一条";

                case StringId.NavigatorAppendButtonHint:
                    return "添加";

                case StringId.NavigatorRemoveButtonHint:
                    return "删除";

                case StringId.NavigatorEditButtonHint:
                    return "编辑";

                case StringId.NavigatorEndEditButtonHint:
                    return "结束编辑";

                case StringId.NavigatorCancelEditButtonHint:
                    return "取消编辑";

                case StringId.NavigatorTextStringFormat:
                    return "记录{0}/{1}";

                case StringId.PictureEditMenuCut:
                    return "剪贴";

                case StringId.PictureEditMenuCopy:
                    return "复制";

                case StringId.PictureEditMenuPaste:
                    return "粘贴";

                case StringId.PictureEditMenuDelete:
                    return "删除";

                case StringId.PictureEditMenuLoad:
                    return "读取";

                case StringId.PictureEditMenuSave:
                    return "保存";

                case StringId.PictureEditOpenFileFilter:
                    return "Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon Files (*.ico)|*.ico|All Picture Files |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|All Files |*.*";

                case StringId.PictureEditSaveFileFilter:
                    return "Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg)|*.jpg";

                case StringId.PictureEditOpenFileTitle:
                    return "打开";

                case StringId.PictureEditSaveFileTitle:
                    return "另存为";

                case StringId.PictureEditOpenFileError:
                    return "错误的图片格式";

                case StringId.PictureEditOpenFileErrorCaption:
                    return "打开错误";

                case StringId.LookUpEditValueIsNull:
                    return "[无数据]";

                case StringId.LookUpInvalidEditValueType:
                    return "无效的数据类型";

                case StringId.LookUpColumnDefaultName:
                    return "名称";

                case StringId.MaskBoxValidateError:
                    return "输入数值不完整. 是否须要修改?\r\n\r\n是 - 回到编辑模式以修改数值.\r\n否 - 保持原来数值.\r\n取消 - 回复原来数值.\r\n";

                case StringId.UnknownPictureFormat:
                    return "不明图片格式";

                case StringId.DataEmpty:
                    return "无图像";

                case StringId.NotValidArrayLength:
                    return "无效的数组长度.";

                case StringId.ImagePopupEmpty:
                    return "(空)";

                case StringId.ImagePopupPicture:
                    return "(图片)";

                case StringId.ColorTabCustom:
                    return "自定";

                case StringId.ColorTabWeb:
                    return "网络";

                case StringId.ColorTabSystem:
                    return "系统";

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
                    return "计算错误";

                case StringId.TabHeaderButtonPrev:
                    return "向左滚动";

                case StringId.TabHeaderButtonNext:
                    return "向右滚动";

                case StringId.TabHeaderButtonClose:
                    return "关闭";

                case StringId.XtraMessageBoxOkButtonText:
                    return "确定(&O)";

                case StringId.XtraMessageBoxCancelButtonText:
                    return "取消(&C)";

                case StringId.XtraMessageBoxYesButtonText:
                    return "是(&Y)";

                case StringId.XtraMessageBoxNoButtonText:
                    return "否(&N)";

                case StringId.XtraMessageBoxAbortButtonText:
                    return "中断(&A)";

                case StringId.XtraMessageBoxRetryButtonText:
                    return "重试(&R)";

                case StringId.XtraMessageBoxIgnoreButtonText:
                    return "忽略(&I)";

                case StringId.TextEditMenuUndo:
                    return "撤消(&U)";

                case StringId.TextEditMenuCut:
                    return "剪贴(&T)";

                case StringId.TextEditMenuCopy:
                    return "复制(&C)";

                case StringId.TextEditMenuPaste:
                    return "粘贴(&P)";

                case StringId.TextEditMenuDelete:
                    return "删除(&D)";

                case StringId.TextEditMenuSelectAll:
                    return "全选(&A)";
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

/*
    //XtraLayout
    public class DxperienceXtraLayoutLocalizationCHS : LayoutLocalizer
    {
        public override string GetLocalizedString(LayoutStringId id)
        {
            switch (id)
            {
                case LayoutStringId.CustomizationParentName:
                    return "自定义";

                case LayoutStringId.DefaultItemText:
                    return "项目";

                case LayoutStringId.DefaultActionText:
                    return "默认方式";

                case LayoutStringId.DefaultEmptyText:
                    return "无";

                case LayoutStringId.LayoutItemDescription:
                    return "版面";

                case LayoutStringId.LayoutGroupDescription:
                    return "版面分组";

                case LayoutStringId.TabbedGroupDescription:
                    return "版面标签组";

                case LayoutStringId.LayoutControlDescription:
                    return "版面控件";

                case LayoutStringId.CustomizationFormTitle:
                    return "自定义";

                case LayoutStringId.HiddenItemsPageTitle:
                    return "隐藏项目";

                case LayoutStringId.TreeViewPageTitle:
                    return "版面视图";

                case LayoutStringId.RenameSelected:
                    return "重命名";

                case LayoutStringId.HideItemMenutext:
                    return "隐藏项目";

                case LayoutStringId.LockItemSizeMenuText:
                    return "锁定项目大小";

                case LayoutStringId.UnLockItemSizeMenuText:
                    return "解开锁定项目大小";

                case LayoutStringId.GroupItemsMenuText:
                    return "分组";

                case LayoutStringId.UnGroupItemsMenuText:
                    return "取消分组";

                case LayoutStringId.CreateTabbedGroupMenuText:
                    return "创建标签";

                case LayoutStringId.AddTabMenuText:
                    return "新增标签";

                case LayoutStringId.UnGroupTabbedGroupMenuText:
                    return "移除标签";

                case LayoutStringId.TreeViewRootNodeName:
                    return "根目录";

                case LayoutStringId.ShowCustomizationFormMenuText:
                    return "显示自定义窗体";

                case LayoutStringId.HideCustomizationFormMenuText:
                    return "隐藏自定义窗体";

                case LayoutStringId.EmptySpaceItemDefaultText:
                    return "空项";

                case LayoutStringId.ControlGroupDefaultText:
                    return "组";

                case LayoutStringId.EmptyRootGroupText:
                    return "拖动到这";

                case LayoutStringId.EmptyTabbedGroupText:
                    return "拖动分组到标题区";

                case LayoutStringId.ResetLayoutMenuText:
                    return "重置版面";

                case LayoutStringId.RenameMenuText:
                    return "重命名";

                case LayoutStringId.TextPositionMenuText:
                    return "文本位置";

                case LayoutStringId.TextPositionLeftMenuText:
                    return "左";

                case LayoutStringId.TextPositionRightMenuText:
                    return "右";

                case LayoutStringId.TextPositionTopMenuText:
                    return "上";

                case LayoutStringId.TextPositionBottomMenuText:
                    return "下";

                case LayoutStringId.ShowTextMenuItem:
                    return "显示文本";

                case LayoutStringId.LockSizeMenuItem:
                    return "锁定大小";

                case LayoutStringId.LockWidthMenuItem:
                    return "锁定宽度";

                case LayoutStringId.LockHeightMenuItem:
                    return "锁定高度";
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
*/

    //XtraNavBar
    public class DxperienceXtraNavBarLocalizationCHS : NavBarLocalizer
    {
        public override string GetLocalizedString(NavBarStringId id)
        {
            switch (id)
            {
                case NavBarStringId.NavPaneMenuShowMoreButtons:
                    return "显示更多的按钮(&M)";

                case NavBarStringId.NavPaneMenuShowFewerButtons:
                    return "显示较少的按钮(&F)";

                case NavBarStringId.NavPaneMenuAddRemoveButtons:
                    return "添加或删除按钮(&A)";

                case NavBarStringId.NavPaneChevronHint:
                    return "配置按钮";
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
                    return "拖动行至此";

                case PivotGridStringId.ColumnHeadersCustomization:
                    return "拖动列至此";

                case PivotGridStringId.FilterHeadersCustomization:
                    return "拖动筛选字段至此";

                case PivotGridStringId.DataHeadersCustomization:
                    return "拖动数据项至此";

               // case PivotGridStringId.RowArea:
               //     return "行区";

               // case PivotGridStringId.ColumnArea:
               //     return "列区";

              //  case PivotGridStringId.FilterArea:
               //     return "筛选区";

             //   case PivotGridStringId.DataArea:
             //       return "数据区";

                case PivotGridStringId.FilterShowAll:
                    return "显示全部";

                case PivotGridStringId.FilterShowBlanks:
                    return "显示空白";

                case PivotGridStringId.CustomizationFormCaption:
                    return "PivotGrid字段列表";

                case PivotGridStringId.CustomizationFormText:
                    return "拖动数据项至PivotGrid";

                case PivotGridStringId.CustomizationFormAddTo:
                    return "添加到";

                case PivotGridStringId.Total:
                    return "合计";

                case PivotGridStringId.GrandTotal:
                    return "总计";

                case PivotGridStringId.TotalFormat:
                    return "{0} 合计";

                case PivotGridStringId.TotalFormatCount:
                    return "{0} 计数";

                case PivotGridStringId.TotalFormatSum:
                    return "{0} 总数";

                case PivotGridStringId.TotalFormatMin:
                    return "{0} 最小";

                case PivotGridStringId.TotalFormatMax:
                    return "{0} 最大";

                case PivotGridStringId.TotalFormatAverage:
                    return "{0} 平均";

                case PivotGridStringId.TotalFormatStdDev:
                    return "{0} 标准差估计";

                case PivotGridStringId.TotalFormatStdDevp:
                    return "{0} 扩展标准差";

                case PivotGridStringId.TotalFormatVar:
                    return "{0} 变异数估计";

                case PivotGridStringId.TotalFormatVarp:
                    return "{0} 扩展变异数";

                case PivotGridStringId.TotalFormatCustom:
                    return "{0} 自定义";

                case PivotGridStringId.PrintDesignerPageOptions:
                    return "选项";

                case PivotGridStringId.PrintDesignerPageBehavior:
                    return "状态";

                case PivotGridStringId.PrintDesignerCategoryDefault:
                    return "默认";

                case PivotGridStringId.PrintDesignerCategoryLines:
                    return "线";

                case PivotGridStringId.PrintDesignerCategoryHeaders:
                    return "标题";

                case PivotGridStringId.PrintDesignerHorizontalLines:
                    return "水平线";

                case PivotGridStringId.PrintDesignerVerticalLines:
                    return "垂直线";

                case PivotGridStringId.PrintDesignerFilterHeaders:
                    return "筛选标题";

                case PivotGridStringId.PrintDesignerDataHeaders:
                    return "数据标题";

                case PivotGridStringId.PrintDesignerColumnHeaders:
                    return "列标题";

                case PivotGridStringId.PrintDesignerRowHeaders:
                    return "行标题";

                case PivotGridStringId.PrintDesignerUsePrintAppearance:
                    return "使用打印版面";

                case PivotGridStringId.PopupMenuRefreshData:
                    return "更新数据";

                case PivotGridStringId.PopupMenuHideField:
                    return "隐藏";

                case PivotGridStringId.PopupMenuShowFieldList:
                    return "显示字段列表";

                case PivotGridStringId.PopupMenuHideFieldList:
                    return "隐藏字段列表";

                case PivotGridStringId.PopupMenuFieldOrder:
                    return "排序";

                case PivotGridStringId.PopupMenuMovetoBeginning:
                    return "移到开头";

                case PivotGridStringId.PopupMenuMovetoLeft:
                    return "移到左边";

                case PivotGridStringId.PopupMenuMovetoRight:
                    return "移到右边";

                case PivotGridStringId.PopupMenuMovetoEnd:
                    return "移到最后";

                case PivotGridStringId.PopupMenuCollapse:
                    return "收缩";

                case PivotGridStringId.PopupMenuExpand:
                    return "展开";

                case PivotGridStringId.PopupMenuCollapseAll:
                    return "全部收缩";

                case PivotGridStringId.PopupMenuExpandAll:
                    return "全部展开";

                case PivotGridStringId.DataFieldCaption:
                    return "数据";

                case PivotGridStringId.TopValueOthersRow:
                    return "其它";
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

                case PreviewStringId.MenuItem_PageLayout:
                    return "页面布置(&P)";

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

                case PreviewStringId.Msg_UnavailableNetPrinter:
                    return "网络打印机无法使用.";

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

                //case PreviewStringId.Msg_IncorrectZoomFactor:
                //    return "数字必须在 {0} 与 {1} 之间。";

               // case PreviewStringId.Msg_InvalidMeasurement:
                 //   return "不规范";

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

                case PreviewStringId.MenuItem_ViewContinuous:
                    return "连续";

                case PreviewStringId.MenuItem_ViewFacing:
                    return "对页";

                case PreviewStringId.MenuItem_BackgrColor:
                    return "颜色(&C)...";

                case PreviewStringId.MenuItem_Watermark:
                    return "水印(&W)...";

                case PreviewStringId.MenuItem_ZoomPageWidth:
                    return "页宽";

                case PreviewStringId.MenuItem_ZoomTextWidth:
                    return "整页";

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
                //    return "工具栏";

               // case PreviewStringId.BarText_MainMenu:
               //     return "主菜单";

               // case PreviewStringId.BarText_StatusBar:
               //     return "状态栏";
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


    //XtraReports
    public class DxperienceXtraReportsLocalizationCHS : ReportLocalizer
    {
        public override string GetLocalizedString(ReportStringId id)
        {
            switch (id)
            {
                case ReportStringId.Msg_FileNotFound:
                    return "文件没有找到";

                case ReportStringId.Msg_WrongReportClassName:
                    return "一个错误发生在并行化期间 - 可能是报表类名错误";

                case ReportStringId.Msg_CreateReportInstance:
                    return "您试图打开一个不同类型的报表来编辑。\r\n是否确定建立实例？";

                case ReportStringId.Msg_FileCorrupted:
                    return "不能加载报表，文件可能被破坏或者报表组件丢失。";

                //case ReportStringId.Msg_FileContentCorrupted:
                  //  return "不能加载报表布局，文件可能损坏或包含错误的信息。";

                case ReportStringId.Msg_IncorrectArgument:
                    return "参数值输入不正确";

                case ReportStringId.Msg_InvalidMethodCall:
                    return "对象的当前状态下不能调用此方法";

                case ReportStringId.Msg_ScriptError:
                    return "在脚本中发现错误：\r\n{0}";

                case ReportStringId.Msg_ScriptExecutionError:
                    return "在脚本执行过程中发现错误 {0}:\r\n {1}\r\n过程 {0} 被运行，将不能再被调用。";

                case ReportStringId.Msg_InvalidReportSource:
                    return "无法设置原报表";

                case ReportStringId.Msg_IncorrectBandType:
                    return "无效的带型";

                case ReportStringId.Msg_InvPropName:
                    return "无效的属性名";

                case ReportStringId.Msg_CantFitBarcodeToControlBounds:
                    return "条形码控件的边界太小";

                case ReportStringId.Msg_InvalidBarcodeText:
                    return "在文本中有无效的字符";

                case ReportStringId.Msg_InvalidBarcodeTextFormat:
                    return "无效的文本格式";

                case ReportStringId.Msg_CreateSomeInstance:
                    return "在窗体中不能建立两个实例类。";

                case ReportStringId.Msg_DontSupportMulticolumn:
                    return "详细报表不支持多字段。";

                case ReportStringId.Msg_FillDataError:
                    return "数据加载时发生错误。错误为：";

                case ReportStringId.Msg_CyclicBoormarks:
                    return "报表循环书签";

                case ReportStringId.Msg_LargeText:
                    return "文本太长";

                //case ReportStringId.Msg_ScriptingPermissionErrorMessage:
                 //   return "在此报表不允许运行脚本。\n\n信息:\n\n{0}";

                //case ReportStringId.Msg_ScriptingErrorTitle:
                //    return "脚本错误";

                case ReportStringId.Cmd_InsertDetailReport:
                    return "插入详细报表";

                case ReportStringId.Cmd_InsertUnboundDetailReport:
                    return "非绑定";

                case ReportStringId.Cmd_ViewCode:
                    return "检视代码";

                case ReportStringId.Cmd_BringToFront:
                    return "移到最上层";

                case ReportStringId.Cmd_SendToBack:
                    return "移到最下层";

                case ReportStringId.Cmd_AlignToGrid:
                    return "对齐网格线";

                case ReportStringId.Cmd_TopMargin:
                    return "顶端边缘";

                case ReportStringId.Cmd_BottomMargin:
                    return "底端边缘";

                case ReportStringId.Cmd_ReportHeader:
                    return "报表首";

                case ReportStringId.Cmd_ReportFooter:
                    return "报表尾";

                case ReportStringId.Cmd_PageHeader:
                    return "页首";

                case ReportStringId.Cmd_PageFooter:
                    return "页尾";

                case ReportStringId.Cmd_GroupHeader:
                    return "群组首";

                case ReportStringId.Cmd_GroupFooter:
                    return "群组尾";

                case ReportStringId.Cmd_Detail:
                    return "详细";

                case ReportStringId.Cmd_DetailReport:
                    return "详细报表";

                case ReportStringId.Cmd_RtfClear:
                    return "清除";

                case ReportStringId.Cmd_RtfLoad:
                    return "加载文件...";

                case ReportStringId.Cmd_TableInsert:
                    return "插入(&I)";

                case ReportStringId.Cmd_TableInsertRowAbove:
                    return "上行(&A)";

                case ReportStringId.Cmd_TableInsertRowBelow:
                    return "下行(&B)";

                case ReportStringId.Cmd_TableInsertColumnToLeft:
                    return "左列(&L)";

                case ReportStringId.Cmd_TableInsertColumnToRight:
                    return "右列(&R)";

                case ReportStringId.Cmd_TableInsertCell:
                    return "单元格(&C)";

                case ReportStringId.Cmd_TableDelete:
                    return "删除(&L)";

                case ReportStringId.Cmd_TableDeleteRow:
                    return "行(&R)";

                case ReportStringId.Cmd_TableDeleteColumn:
                    return "列(&C)";

                case ReportStringId.Cmd_TableDeleteCell:
                    return "单元格(&L)";

                case ReportStringId.Cmd_Cut:
                    return "剪贴";

                case ReportStringId.Cmd_Copy:
                    return "复制";

                case ReportStringId.Cmd_Paste:
                    return "粘贴";

                case ReportStringId.Cmd_Delete:
                    return "删除";

                case ReportStringId.Cmd_Properties:
                    return "属性";

                case ReportStringId.Cmd_InsertBand:
                    return "插入区段";

                case ReportStringId.CatLayout:
                    return "布局";

                case ReportStringId.CatAppearance:
                    return "版面";

                case ReportStringId.CatData:
                    return "数据";

                case ReportStringId.CatBehavior:
                    return "状态";

                case ReportStringId.CatNavigation:
                    return "导航";

                case ReportStringId.CatPageSettings:
                    return "页面设置";

                //case ReportStringId.CatUserDesigner:
                //    return "用户设计";

                case ReportStringId.BandDsg_QuantityPerPage:
                    return "一个页面集合";

                case ReportStringId.BandDsg_QuantityPerReport:
                    return "一个报表集合";

                case ReportStringId.UD_ReportDesigner:
                    return "XtraReport设计";

                case ReportStringId.UD_Msg_ReportChanged:
                    return "报表内容已被修改，是否须要储存？";

                case ReportStringId.UD_TTip_FileOpen:
                    return "打开文件";

                case ReportStringId.UD_TTip_FileSave:
                    return "保存文件";

                case ReportStringId.UD_TTip_EditCut:
                    return "剪贴";

                case ReportStringId.UD_TTip_EditCopy:
                    return "复制";

                case ReportStringId.UD_TTip_EditPaste:
                    return "粘贴";

                case ReportStringId.UD_TTip_Undo:
                    return "撤消";

                case ReportStringId.UD_TTip_Redo:
                    return "恢复";

                case ReportStringId.UD_TTip_AlignToGrid:
                    return "对齐网格线";

                case ReportStringId.UD_TTip_AlignLeft:
                    return "对齐主控项的左缘";

                case ReportStringId.UD_TTip_AlignVerticalCenters:
                    return "对齐主控项的水平中央";

                case ReportStringId.UD_TTip_AlignRight:
                    return "对齐主控项的右缘";

                case ReportStringId.UD_TTip_AlignTop:
                    return "对齐主控项的上缘";

                case ReportStringId.UD_TTip_AlignHorizontalCenters:
                    return "对齐主控项的垂直中间";

                case ReportStringId.UD_TTip_AlignBottom:
                    return "对齐主控项的下缘";

                case ReportStringId.UD_TTip_SizeToControlWidth:
                    return "设置成相同宽度";

                case ReportStringId.UD_TTip_SizeToGrid:
                    return "依网格线调整大小";

                case ReportStringId.UD_TTip_SizeToControlHeight:
                    return "设置成相同高度";

                case ReportStringId.UD_TTip_SizeToControl:
                    return "设置成相同大小";

                case ReportStringId.UD_TTip_HorizSpaceMakeEqual:
                    return "将水平间距设成相等";

                case ReportStringId.UD_TTip_HorizSpaceIncrease:
                    return "增加水平间距";

                case ReportStringId.UD_TTip_HorizSpaceDecrease:
                    return "减少水平间距";

                case ReportStringId.UD_TTip_HorizSpaceConcatenate:
                    return "移除水平间距";

                case ReportStringId.UD_TTip_VertSpaceMakeEqual:
                    return "将垂直间距设为相等";

                case ReportStringId.UD_TTip_VertSpaceIncrease:
                    return "增加垂直间距";

                case ReportStringId.UD_TTip_VertSpaceDecrease:
                    return "减少垂直间距";

                case ReportStringId.UD_TTip_VertSpaceConcatenate:
                    return "移除垂直间距";

                case ReportStringId.UD_TTip_CenterHorizontally:
                    return "水平置中";

                case ReportStringId.UD_TTip_CenterVertically:
                    return "垂直置中";

                case ReportStringId.UD_TTip_BringToFront:
                    return "移到最上层";

                case ReportStringId.UD_TTip_SendToBack:
                    return "移到最下层";

                case ReportStringId.UD_TTip_FormatBold:
                    return "粗体";

                case ReportStringId.UD_TTip_FormatItalic:
                    return "斜体";

                case ReportStringId.UD_TTip_FormatUnderline:
                    return "下划线";

                case ReportStringId.UD_TTip_FormatAlignLeft:
                    return "左对齐";

                case ReportStringId.UD_TTip_FormatCenter:
                    return "居中";

                case ReportStringId.UD_TTip_FormatAlignRight:
                    return "右对齐";

                case ReportStringId.UD_TTip_FormatFontName:
                    return "字体";

                case ReportStringId.UD_TTip_FormatFontSize:
                    return "大小";

                case ReportStringId.UD_TTip_FormatForeColor:
                    return "前景颜色";

                case ReportStringId.UD_TTip_FormatBackColor:
                    return "背景颜色";

                case ReportStringId.UD_TTip_FormatJustify:
                    return "两端对齐";

                case ReportStringId.UD_FormCaption:
                    return "XtraReport设计";

                case ReportStringId.VS_XtraReportsToolboxCategoryName:
                    return "Developer Express: 报表";

                case ReportStringId.UD_XtraReportsToolboxCategoryName:
                    return "标准控制";

                //case ReportStringId.UD_XtraReportsPointerItemCaption:
                  //  return "指针";

                case ReportStringId.Verb_EditBands:
                    return "编辑区域...";

                case ReportStringId.Verb_EditGroupFields:
                    return "编辑组字段...";

                case ReportStringId.Verb_Import:
                    return "导入...";

                case ReportStringId.Verb_Save:
                    return "保存...";

                case ReportStringId.Verb_About:
                    return "关于...";

                case ReportStringId.Verb_RTFClear:
                    return "清除";

                case ReportStringId.Verb_RTFLoad:
                    return "加载文件...";

                case ReportStringId.Verb_FormatString:
                    return "格式化字符串...";

                case ReportStringId.Verb_SummaryWizard:
                    return "总结...";

                case ReportStringId.Verb_ReportWizard:
                    return "向导...";

                case ReportStringId.Verb_Insert:
                    return "插入...";

                case ReportStringId.Verb_Delete:
                    return "删除...";

                case ReportStringId.Verb_Bind:
                    return "赋值";

               // case ReportStringId.Verb_EditText:
               //     return "文本编辑";

                case ReportStringId.FSForm_Lbl_Category:
                    return "类别";

                case ReportStringId.FSForm_Lbl_Prefix:
                    return "上标";

                case ReportStringId.FSForm_Lbl_Suffix:
                    return "下标";

                case ReportStringId.FSForm_Lbl_CustomGeneral:
                    return "一般格式不包含特殊数字格式";

                case ReportStringId.FSForm_GrBox_Sample:
                    return "范例";

                case ReportStringId.FSForm_Tab_StandardTypes:
                    return "标准类型";

                case ReportStringId.FSForm_Tab_Custom:
                    return "自定义";

                case ReportStringId.FSForm_Msg_BadSymbol:
                    return "损坏的符号";

                case ReportStringId.FSForm_Btn_Delete:
                    return "删除";

                case ReportStringId.BCForm_Lbl_Property:
                    return "属性";

                case ReportStringId.BCForm_Lbl_Binding:
                    return "结合";

                case ReportStringId.SSForm_Caption:
                    return "式样单编辑";

                case ReportStringId.SSForm_Btn_Close:
                    return "关闭";

                case ReportStringId.SSForm_Msg_NoStyleSelected:
                    return "没有式样被选中";

                case ReportStringId.SSForm_Msg_MoreThanOneStyle:
                    return "你选择了多过一个以上的式样";

                case ReportStringId.SSForm_Msg_SelectedStylesText:
                    return "被选中的式样...";

                case ReportStringId.SSForm_Msg_StyleSheetError:
                    return "StyleSheet错误";

                case ReportStringId.SSForm_Msg_InvalidFileFormat:
                    return "无效的文件格式";

                case ReportStringId.SSForm_Msg_StyleNamePreviewPostfix:
                    return " 式样";

                case ReportStringId.SSForm_Msg_FileFilter:
                    return "Report StyleSheet files (*.repss)|*.repss|All files (*.*)|*.*";

                case ReportStringId.SSForm_TTip_AddStyle:
                    return "添加式样";

                case ReportStringId.SSForm_TTip_RemoveStyle:
                    return "移除式样";

                case ReportStringId.SSForm_TTip_ClearStyles:
                    return "清除式样";

                case ReportStringId.SSForm_TTip_PurgeStyles:
                    return "清除式样";

                case ReportStringId.SSForm_TTip_SaveStyles:
                    return "保存式样到文件";

                case ReportStringId.SSForm_TTip_LoadStyles:
                    return "从文件中读入式样";

                case ReportStringId.FindForm_Msg_FinishedSearching:
                    return "搜索文件完成";

                case ReportStringId.FindForm_Msg_TotalFound:
                    return "合计查找:";

                case ReportStringId.RepTabCtl_HtmlView:
                    return "HTML视图";

                case ReportStringId.RepTabCtl_Preview:
                    return "预览";

                case ReportStringId.RepTabCtl_Designer:
                    return "设计";

                case ReportStringId.PanelDesignMsg:
                    return "在此可放置不同控件";

                case ReportStringId.MultiColumnDesignMsg1:
                    return "重复列之间的空位";

                case ReportStringId.MultiColumnDesignMsg2:
                    return "控件位置不正确，将会导致打印错误";

                // case ReportStringId.UD_Group_File:
                //    return "文件(&F)";

              //  case ReportStringId.UD_Group_Edit:
               //     return "编辑(&E)";

               // case ReportStringId.UD_Group_View:
               //     return "视图(&V)";

               // case ReportStringId.UD_Group_Format:
               //     return "格式(&R)";

              //  case ReportStringId.UD_Group_Font:
               //     return "字体(&F)";

              //  case ReportStringId.UD_Group_Justify:
               //     return "两端对齐(&J)";

              //  case ReportStringId.UD_Group_Align:
              //      return "对齐(&A)";

                //case ReportStringId.UD_Group_MakeSameSize:
                //    return "设置成相同大小(M)";

                //case ReportStringId.UD_Group_HorizontalSpacing:
                //    return "水平间距(&H)";

                //case ReportStringId.UD_Group_VerticalSpacing:
                //    return "垂直间距(&V)";

                //case ReportStringId.UD_Group_CenterInForm:
                //    return "对齐窗体中央(&C)";

                //case ReportStringId.UD_Group_Order:
                //    return "顺序(&O)";

                //case ReportStringId.UD_Group_ToolbarsList:
                //    return "工具栏(&T)";

                //case ReportStringId.UD_Group_DockPanelsList:
                //    return "窗口(&W)";

                //case ReportStringId.UD_Capt_MainMenuName:
                //    return "主菜单";

                //case ReportStringId.UD_Capt_ToolbarName:
                //    return "工具栏";

                //case ReportStringId.UD_Capt_LayoutToolbarName:
                //    return "布局工具栏";

                //case ReportStringId.UD_Capt_FormattingToolbarName:
                //    return "格式工具栏";

                //case ReportStringId.UD_Capt_StatusBarName:
                //    return "状态栏";

                //case ReportStringId.UD_Capt_NewReport:
                //    return "新增(&N)";

                //case ReportStringId.UD_Capt_NewWizardReport:
                //    return "向导(&W)";

                //case ReportStringId.UD_Capt_OpenFile:
                //    return "开启(&O)";

                //case ReportStringId.UD_Capt_SaveFile:
                //    return "保存(&S)";

                //case ReportStringId.UD_Capt_SaveFileAs:
                //    return "另存为(&A)...";

                //case ReportStringId.UD_Capt_Exit:
                //    return "结束(&X)";

                //case ReportStringId.UD_Capt_Cut:
                //    return "剪切(&T)";

                //case ReportStringId.UD_Capt_Copy:
                //    return "复制(&C)";

                //case ReportStringId.UD_Capt_Paste:
                //    return "粘贴(&P)";

                //case ReportStringId.UD_Capt_Delete:
                //    return "删除(&D)";

                //case ReportStringId.UD_Capt_SelectAll:
                //    return "全选(&A)";

                //case ReportStringId.UD_Capt_Undo:
                //    return "复原(&U)";

                //case ReportStringId.UD_Capt_Redo:
                //    return "重复(&R)";

                //case ReportStringId.UD_Capt_ForegroundColor:
                //    return "前景色(&E)";

                //case ReportStringId.UD_Capt_BackGroundColor:
                //    return "背景色(&K)";

                //case ReportStringId.UD_Capt_FontBold:
                //    return "粗体(&B)";

                //case ReportStringId.UD_Capt_FontItalic:
                //    return "斜体(&I)";

                //case ReportStringId.UD_Capt_FontUnderline:
                //    return "底线(&U)";

                //case ReportStringId.UD_Capt_JustifyLeft:
                //    return "靠左(&L)";

                //case ReportStringId.UD_Capt_JustifyCenter:
                //    return "居中(&C)";

                //case ReportStringId.UD_Capt_JustifyRight:
                //    return "靠右(&R)";

                //case ReportStringId.UD_Capt_JustifyJustify:
                //    return "两端对齐(&J)";

                //case ReportStringId.UD_Capt_AlignLefts:
                //    return "左(&L)";

                //case ReportStringId.UD_Capt_AlignCenters:
                //    return "置中(&C)";

                //case ReportStringId.UD_Capt_AlignRights:
                //    return "右(&R)";

                //case ReportStringId.UD_Capt_AlignTops:
                //    return "上(&T)";

                //case ReportStringId.UD_Capt_AlignMiddles:
                //    return "中间(&M)";

                //case ReportStringId.UD_Capt_AlignBottoms:
                //    return "下(&B)";

                //case ReportStringId.UD_Capt_AlignToGrid:
                //    return "网格线(&G)";

                //case ReportStringId.UD_Capt_MakeSameSizeWidth:
                //    return "宽度(&W)";

                //case ReportStringId.UD_Capt_MakeSameSizeSizeToGrid:
                //    return "依网格线调整大小(&D)";

                //case ReportStringId.UD_Capt_MakeSameSizeHeight:
                //    return "高度(&H)";

                //case ReportStringId.UD_Capt_MakeSameSizeBoth:
                //    return "两者(&B)";

                //case ReportStringId.UD_Capt_SpacingMakeEqual:
                //    return "设成相等(&E)";

                //case ReportStringId.UD_Capt_SpacingIncrease:
                //    return "增加(&I)";

                //case ReportStringId.UD_Capt_SpacingDecrease:
                //    return "减少(&D)";

                //case ReportStringId.UD_Capt_SpacingRemove:
                //    return "移除(&R)";

                //case ReportStringId.UD_Capt_CenterInFormHorizontally:
                //    return "水平(&H)";

                //case ReportStringId.UD_Capt_CenterInFormVertically:
                //    return "垂直(&V)";

                //case ReportStringId.UD_Capt_OrderBringToFront:
                //    return "提到最上层(&B)";

                //case ReportStringId.UD_Capt_OrderSendToBack:
                //    return "移到最下层(&S)";

                //case ReportStringId.UD_Hint_NewReport:
                //    return "创建新报表";

                //case ReportStringId.UD_Hint_NewWizardReport:
                //    return "用向导创建新报表";

                //case ReportStringId.UD_Hint_OpenFile:
                //    return "打开报表";

                //case ReportStringId.UD_Hint_SaveFile:
                //    return "储存报表";

                //case ReportStringId.UD_Hint_SaveFileAs:
                //    return "另起新名储存报表";

                //case ReportStringId.UD_Hint_Exit:
                //    return "关闭设计师";

                //case ReportStringId.UD_Hint_Cut:
                //    return "删除控件和复制到剪贴板";

                //case ReportStringId.UD_Hint_Copy:
                //    return "复制控件到剪贴板";

                //case ReportStringId.UD_Hint_Paste:
                //    return "从剪贴板添加控件";

                //case ReportStringId.UD_Hint_Delete:
                //    return "删除控件";

                //case ReportStringId.UD_Hint_SelectAll:
                //    return "全选";

                //case ReportStringId.UD_Hint_Undo:
                //    return "复原最后操作";

                //case ReportStringId.UD_Hint_Redo:
                //    return "重复最后操作";

                //case ReportStringId.UD_Hint_ForegroundColor:
                //    return "设置前景色";

                //case ReportStringId.UD_Hint_BackGroundColor:
                //    return "设置背景色";

                //case ReportStringId.UD_Hint_FontBold:
                //    return "粗体";

                //case ReportStringId.UD_Hint_FontItalic:
                //    return "斜体";

                //case ReportStringId.UD_Hint_FontUnderline:
                //    return "底线";

                //case ReportStringId.UD_Hint_JustifyLeft:
                //    return "靠左";

                //case ReportStringId.UD_Hint_JustifyCenter:
                //    return "居中";

                //case ReportStringId.UD_Hint_JustifyRight:
                //    return "靠右";

                //case ReportStringId.UD_Hint_JustifyJustify:
                //    return "两端对齐";

                //case ReportStringId.UD_Hint_AlignLefts:
                //    return "被选控件左对齐";

                //case ReportStringId.UD_Hint_AlignCenters:
                //    return "被选纵向控件居中对齐";

                //case ReportStringId.UD_Hint_AlignRights:
                //    return "被选控件右对齐";

                //case ReportStringId.UD_Hint_AlignTops:
                //    return "被选控件上对齐";

                //case ReportStringId.UD_Hint_AlignMiddles:
                //    return "被选横向控件居中对齐";

                //case ReportStringId.UD_Hint_AlignBottoms:
                //    return "被选控件下对齐";

                //case ReportStringId.UD_Hint_AlignToGrid:
                //    return "被选控件依线格对齐";

                //case ReportStringId.UD_Hint_MakeSameSizeWidth:
                //    return "被选控件设置成相同宽度";

                //case ReportStringId.UD_Hint_MakeSameSizeSizeToGrid:
                //    return "被选控件依线格调整大小";

                //case ReportStringId.UD_Hint_MakeSameSizeHeight:
                //    return "被选控件设置成相同高度";

                //case ReportStringId.UD_Hint_MakeSameSizeBoth:
                //    return "被选控件设置成相同大小";

                //case ReportStringId.UD_Hint_SpacingMakeEqual:
                //    return "被选控件间距设成相等";

                //case ReportStringId.UD_Hint_SpacingIncrease:
                //    return "增加被选控件的间距";

                //case ReportStringId.UD_Hint_SpacingDecrease:
                //    return "减少被选控件的间距";

                //case ReportStringId.UD_Hint_SpacingRemove:
                //    return "移除被选控件的间距";

                //case ReportStringId.UD_Hint_CenterInFormHorizontally:
                //    return "被选控件水平对齐窗体中央";

                //case ReportStringId.UD_Hint_CenterInFormVertically:
                //    return "被选控件垂直对齐窗体中央";

                //case ReportStringId.UD_Hint_OrderBringToFront:
                //    return "被选控件提到最上层";

                //case ReportStringId.UD_Hint_OrderSendToBack:
                //    return "被选控件提到最下层";

                //case ReportStringId.UD_Hint_ViewBars:
                //    return "显示/隐藏{0}";

                //case ReportStringId.UD_Hint_ViewDockPanels:
                //    return "显示/隐藏 {0} 窗口";

                //case ReportStringId.UD_Hint_ViewTabs:
                //    return "转到 {0} 标签";

                //case ReportStringId.UD_Title_FieldList:
                //    return "字段清单";

                //case ReportStringId.UD_Title_ReportExplorer:
                //    return "报表资源管理器";

                //case ReportStringId.UD_Title_PropertyGrid:
                //    return "属性";

                //case ReportStringId.UD_Title_ToolBox:
                //    return "工具箱";

                //case ReportStringId.STag_Name_Text:
                //    return "文本";

                //case ReportStringId.STag_Name_DataBinding:
                //    return "数据连接";

                //case ReportStringId.STag_Name_FormatString:
                //    return "字符串格式";

                //case ReportStringId.STag_Name_ForeColor:
                //    return "前景色";

                //case ReportStringId.STag_Name_BackColor:
                //    return "背景色";

                //case ReportStringId.STag_Name_Font:
                //    return "字体";

                //case ReportStringId.STag_Name_LineDirection:
                //    return "线条方向";

                //case ReportStringId.STag_Name_LineStyle:
                //    return "线条样式";

                //case ReportStringId.STag_Name_LineWidth:
                //    return "线条宽度";

                //case ReportStringId.STag_Name_CanGrow:
                //    return "增长";

                //case ReportStringId.STag_Name_CanShrink:
                //    return "收缩";

                //case ReportStringId.STag_Name_Multiline:
                //    return "多线";

                //case ReportStringId.STag_Name_Summary:
                //    return "摘要";

                //case ReportStringId.STag_Name_Symbology:
                //    return "符号";

                //case ReportStringId.STag_Name_Module:
                //    return "模块数";

                //case ReportStringId.STag_Name_ShowText:
                //    return "显示文本";

                //case ReportStringId.STag_Name_SegmentWidth:
                //    return "分段宽度";

                //case ReportStringId.STag_Name_Checked:
                //    return "选中";

                //case ReportStringId.STag_Name_Image:
                //    return "图像";

                //case ReportStringId.STag_Name_ImageUrl:
                //    return "图像位置(URL)";

                //case ReportStringId.STag_Name_ImageSizing:
                //    return "图象尺寸";

                //case ReportStringId.STag_Name_ReportSource:
                //    return "报表来源";

                //case ReportStringId.STag_Name_PreviewRowCount:
                //    return "预览行数";

                //case ReportStringId.STag_Name_ShrinkSubReportIconArea:
                //    return "收缩子报表的图标区域";

                //case ReportStringId.STag_Name_PageInfo:
                //    return "页码信息";

                //case ReportStringId.STag_Name_StartPageNumber:
                //    return "起始页码";

                //case ReportStringId.STag_Name_Format:
                //    return "格式";

                //case ReportStringId.STag_Name_KeepTogether:
                //    return "保持一致";

                //case ReportStringId.STag_Name_Bands:
                //    return "区";

                //case ReportStringId.STag_Name_Height:
                //    return "高度";

                //case ReportStringId.STag_Name_RepeatEveryPage:
                //    return "重复每个页面";

                //case ReportStringId.STag_Name_PrintAtBottom:
                //    return "打印在底端";

                //case ReportStringId.STag_Name_GroupFields:
                //    return "群组区段";

                //case ReportStringId.STag_Name_SortFields:
                //    return "排序字段";

                //case ReportStringId.STag_Name_GroupUnion:
                //    return "群组并集";

                //case ReportStringId.STag_Name_Level:
                //    return "层次";

                //case ReportStringId.STag_Name_ColumnMode:
                //    return "列模式";

                //case ReportStringId.STag_Name_ColumnCount:
                //    return "列计算";

                //case ReportStringId.STag_Name_ColumnWidth:
                //    return "列宽";

                //case ReportStringId.STag_Name_ColumnSpacing:
                //    return "列距";

                //case ReportStringId.STag_Name_Direction:
                //    return "汇总数据位置";

                //case ReportStringId.STag_Name_Watermark:
                //    return "水印";

                //case ReportStringId.STag_Name_ReportUnit:
                //    return "报表单元";

                //case ReportStringId.STag_Name_DataSource:
                //    return "数据来源";

                //case ReportStringId.STag_Name_DataMember:
                //    return "数据项";

                //case ReportStringId.STag_Name_DataAdapter:
                //    return "数据适配器";
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
                    return "'{0}' 相对于 '{1}' 不是一个有效的数值.";

                case SchedulerStringId.Msg_InvalidDayOfWeekForDailyRecurrence:
                    return "Invalid day of week for a daily recurrence. Only WeekDays.EveryDay, WeekDays.WeekendDays and WeekDays.WorkDays are valid in this context.";

                case SchedulerStringId.Msg_InternalError:
                    return "内部错误!";

                case SchedulerStringId.Msg_NoMappingForObject:
                    return "对象 \r\n {0} 未定义相关的 Mappings.";

                case SchedulerStringId.Msg_XtraSchedulerNotAssigned:
                    return "SchedulerStorage 控件未加入 ScheulerControl 当中";

                case SchedulerStringId.Msg_InvalidTimeOfDayInterval:
                    return "无效的时段";

                case SchedulerStringId.Msg_OverflowTimeOfDayInterval:
                    return "无效的数值. 数值必须少于或相等于一天.";

                case SchedulerStringId.Msg_LoadCollectionFromXml:
                    return "加载XML项目时, 日志表必须是在非绑定模式";

                case SchedulerStringId.AppointmentLabel_None:
                    return "无";

                case SchedulerStringId.AppointmentLabel_Important:
                    return "重要";

                case SchedulerStringId.AppointmentLabel_Business:
                    return "商务";

                case SchedulerStringId.AppointmentLabel_Personal:
                    return "个人";

                case SchedulerStringId.AppointmentLabel_Vacation:
                    return "休假";

                case SchedulerStringId.AppointmentLabel_MustAttend:
                    return "必须出席";

                case SchedulerStringId.AppointmentLabel_TravelRequired:
                    return "旅游需求";

                case SchedulerStringId.AppointmentLabel_NeedsPreparation:
                    return "需要准备";

                case SchedulerStringId.AppointmentLabel_Birthday:
                    return "生日";

                case SchedulerStringId.AppointmentLabel_Anniversary:
                    return "周年纪念";

                case SchedulerStringId.AppointmentLabel_PhoneCall:
                    return "通话";

                case SchedulerStringId.Msg_InvalidEndDate:
                    return "完成时间不能早于开始时间";

                case SchedulerStringId.Caption_Appointment:
                    return "{0} - 约会";

                case SchedulerStringId.Caption_Event:
                    return "{0} - 要事";

                case SchedulerStringId.Caption_UntitledAppointment:
                    return "未命名";

                case SchedulerStringId.Caption_WeekDaysEveryDay:
                    return "日";

                case SchedulerStringId.Caption_WeekDaysWeekendDays:
                    return "周末";

                case SchedulerStringId.Caption_WeekDaysWorkDays:
                    return "工作日";

                case SchedulerStringId.Caption_WeekOfMonthFirst:
                    return "第一周";

                case SchedulerStringId.Caption_WeekOfMonthSecond:
                    return "第二周";

                case SchedulerStringId.Caption_WeekOfMonthThird:
                    return "第三周";

                case SchedulerStringId.Caption_WeekOfMonthFourth:
                    return "第四周";

                case SchedulerStringId.Caption_WeekOfMonthLast:
                    return "最后一周";

                case SchedulerStringId.Msg_InvalidDayCount:
                    return "无法计算日子. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidDayCountValue:
                    return "无法计算日子. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidWeekCount:
                    return "无法计算周期. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidWeekCountValue:
                    return "无法计算周期. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidMonthCount:
                    return "无法计算月份. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidMonthCountValue:
                    return "无法计算月份. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidYearCount:
                    return "无法计算年份. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidYearCountValue:
                    return "无法计算年份. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidOccurrencesCount:
                    return "无法计算周期次数. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidOccurrencesCountValue:
                    return "无法计算周期次数. 请输入正确数值.";

                case SchedulerStringId.Msg_InvalidDayNumber:
                    return "日数输入无效. 日数必须是 1 至 {0} 之间的数值.";

                case SchedulerStringId.Msg_InvalidDayNumberValue:
                    return "日数输入无效. 日数必须是 1 至 {0} 之间的数值.";

                case SchedulerStringId.Msg_WarningDayNumber:
                    return "有些月份少于 {0} 天. 周期将排在这月份的最后一天.";

                case SchedulerStringId.Msg_InvalidDayOfWeek:
                    return "没有日子被选择. 请最少选择一个日子.";

                case SchedulerStringId.MenuCmd_OpenAppointment:
                    return "开(&O)";

                case SchedulerStringId.MenuCmd_PrintAppointment:
                    return "打印(&P)";

                case SchedulerStringId.MenuCmd_DeleteAppointment:
                    return "删除(&D)";

                case SchedulerStringId.MenuCmd_EditSeries:
                    return "编辑级联(&E)";

                case SchedulerStringId.MenuCmd_RestoreOccurrence:
                    return "回复默认状态(&R)";

                case SchedulerStringId.MenuCmd_NewAppointment:
                    return "新约会(&O)";

                case SchedulerStringId.MenuCmd_NewAllDayEvent:
                    return "新增全天要事(&E)";

                case SchedulerStringId.MenuCmd_NewRecurringAppointment:
                    return "新周期性约会(&A)";

                case SchedulerStringId.MenuCmd_NewRecurringEvent:
                    return "新周期性要事(&V)";

                case SchedulerStringId.MenuCmd_GotoThisDay:
                    return "今天(&D)";

                case SchedulerStringId.MenuCmd_GotoToday:
                    return "今天(&D)";

                case SchedulerStringId.MenuCmd_GotoDate:
                    return "到指定日期(&E)...";

                case SchedulerStringId.MenuCmd_OtherSettings:
                    return "其它设置(&I)...";

                case SchedulerStringId.MenuCmd_CustomizeCurrentView:
                    return "自定义当前视图(&C)...";

                case SchedulerStringId.MenuCmd_CustomizeTimeRuler:
                    return "变更时区...";

                case SchedulerStringId.MenuCmd_5Minutes:
                    return "5分钟";

                case SchedulerStringId.MenuCmd_6Minutes:
                    return "6分钟";

                case SchedulerStringId.MenuCmd_10Minutes:
                    return "10分钟";

                case SchedulerStringId.MenuCmd_15Minutes:
                    return "15分钟";

                case SchedulerStringId.MenuCmd_20Minutes:
                    return "20分钟";

                case SchedulerStringId.MenuCmd_30Minutes:
                    return "30分钟";

                case SchedulerStringId.MenuCmd_60Minutes:
                    return "60分钟";

                case SchedulerStringId.MenuCmd_SwitchViewMenu:
                    return "改变视图";

                case SchedulerStringId.MenuCmd_SwitchToDayView:
                    return "天(&D)";

                case SchedulerStringId.MenuCmd_SwitchToWorkWeekView:
                    return "工作周(&R)";

                case SchedulerStringId.MenuCmd_SwitchToWeekView:
                    return "星期(&W)";

                case SchedulerStringId.MenuCmd_SwitchToMonthView:
                    return "月(&M)";

                case SchedulerStringId.MenuCmd_ShowTimeAs:
                    return "显示时间为(&S)";

                case SchedulerStringId.MenuCmd_Free:
                    return "空闲(&F)";

                case SchedulerStringId.MenuCmd_Busy:
                    return "忙碌(&B)";

                case SchedulerStringId.MenuCmd_Tentative:
                    return "暂定(&T)";

                case SchedulerStringId.MenuCmd_OutOfOffice:
                    return "不在办公室(&O)";

                case SchedulerStringId.MenuCmd_LabelAs:
                    return "标注(&L)";

                case SchedulerStringId.MenuCmd_AppointmentLabelNone:
                    return "无(&N)";

                case SchedulerStringId.MenuCmd_AppointmentLabelImportant:
                    return "重要(&I)";

                case SchedulerStringId.MenuCmd_AppointmentLabelBusiness:
                    return "商务(&B)";

                case SchedulerStringId.MenuCmd_AppointmentLabelPersonal:
                    return "个人(P)";

                case SchedulerStringId.MenuCmd_AppointmentLabelVacation:
                    return "休假(&V)";

                case SchedulerStringId.MenuCmd_AppointmentLabelMustAttend:
                    return "必须出席(&A)";

                case SchedulerStringId.MenuCmd_AppointmentLabelTravelRequired:
                    return "旅游需求(&T)";

                case SchedulerStringId.MenuCmd_AppointmentLabelNeedsPreparation:
                    return "需要准备(&N)";

                case SchedulerStringId.MenuCmd_AppointmentLabelBirthday:
                    return "生日(&B)";

                case SchedulerStringId.MenuCmd_AppointmentLabelAnniversary:
                    return "周年纪念(&A)";

                case SchedulerStringId.MenuCmd_AppointmentLabelPhoneCall:
                    return "通话(&P)";

                case SchedulerStringId.MenuCmd_AppointmentMove:
                    return "移除(&V)";

                case SchedulerStringId.MenuCmd_AppointmentCopy:
                    return "复制(&C)";

                case SchedulerStringId.MenuCmd_AppointmentCancel:
                    return "取消(&A)";

                case SchedulerStringId.Caption_5Minutes:
                    return "5分钟";

                case SchedulerStringId.Caption_6Minutes:
                    return "6分钟";

                case SchedulerStringId.Caption_10Minutes:
                    return "10分钟";

                case SchedulerStringId.Caption_15Minutes:
                    return "15分钟";

                case SchedulerStringId.Caption_20Minutes:
                    return "20分钟";

                case SchedulerStringId.Caption_30Minutes:
                    return "30分钟";

                case SchedulerStringId.Caption_60Minutes:
                    return "60分钟";

                case SchedulerStringId.Caption_Free:
                    return "空闲";

                case SchedulerStringId.Caption_Busy:
                    return "忙碌";

                case SchedulerStringId.Caption_Tentative:
                    return "暂定";

                case SchedulerStringId.Caption_OutOfOffice:
                    return "不在办公室";

                case SchedulerStringId.ViewDisplayName_Day:
                    return "日行事历";

                case SchedulerStringId.ViewDisplayName_WorkDays:
                    return "工作周行事历";

                case SchedulerStringId.ViewDisplayName_Week:
                    return "周行事历";

                case SchedulerStringId.ViewDisplayName_Month:
                    return "月行事历";

                case SchedulerStringId.Abbr_MinutesShort1:
                    return "分";

                case SchedulerStringId.Abbr_MinutesShort2:
                    return "分";

                case SchedulerStringId.Abbr_Minute:
                    return "分钟";

                case SchedulerStringId.Abbr_Minutes:
                    return "分钟";

                case SchedulerStringId.Abbr_HoursShort:
                    return "小时";

                case SchedulerStringId.Abbr_Hour:
                    return "小时";

                case SchedulerStringId.Abbr_Hours:
                    return "小时";

                case SchedulerStringId.Abbr_DaysShort:
                    return "日";

                case SchedulerStringId.Abbr_Day:
                    return "日";

                case SchedulerStringId.Abbr_Days:
                    return "日";

                case SchedulerStringId.Abbr_WeeksShort:
                    return "周";

                case SchedulerStringId.Abbr_Week:
                    return "周";

                case SchedulerStringId.Abbr_Weeks:
                    return "周";

                case SchedulerStringId.Abbr_Month:
                    return "月份";

                case SchedulerStringId.Abbr_Months:
                    return "月份";

                case SchedulerStringId.Abbr_Year:
                    return "年";

                case SchedulerStringId.Abbr_Years:
                    return "年";

                case SchedulerStringId.Caption_Reminder:
                    return "{0} 提示";

                case SchedulerStringId.Caption_Reminders:
                    return "{0} 提示";

                case SchedulerStringId.Caption_StartTime:
                    return "开始时间: {0}";

                case SchedulerStringId.Caption_NAppointmentsAreSelected:
                    return "{0} 约会被选择";

                case SchedulerStringId.Format_TimeBeforeStart:
                    return "未开始前 {0}";

                case SchedulerStringId.Msg_Conflict:
                    return "一项被修改的约会跟其它一项或多项的约会出现冲突.";

                case SchedulerStringId.Msg_InvalidAppointmentDuration:
                    return "无效的约会时段. 请重新输入.";

                case SchedulerStringId.Msg_InvalidReminderTimeBeforeStart:
                    return "无效的提醒时间. 请重新输入.";

                case SchedulerStringId.TextDuration_FromTo:
                    return "由 {0} 至 {1}";

                case SchedulerStringId.TextDuration_FromForDays:
                    return "由 {0} 至 {1} ";

                case SchedulerStringId.TextDuration_FromForDaysHours:
                    return "由 {0} 至 {1} {2}";

                case SchedulerStringId.TextDuration_FromForDaysMinutes:
                    return "由 {0} 至 {1} {3}";

                case SchedulerStringId.TextDuration_FromForDaysHoursMinutes:
                    return "由 {0} 至 {1} {2} {3}";

                case SchedulerStringId.TextDuration_ForPattern:
                    return "{0} {1}";

                case SchedulerStringId.TextDailyPatternString_EveryDay:
                    return "每 {0} {1}";

                case SchedulerStringId.TextDailyPatternString_EveryDays:
                    return "每 {0} {1} {2}";

                case SchedulerStringId.TextDailyPatternString_EveryWeekDay:
                    return "每个工作天 {0}";

                case SchedulerStringId.TextDailyPatternString_EveryWeekend:
                    return "每个周末 {0}";

                case SchedulerStringId.TextWeekly_1Day:
                    return "{0}";

                case SchedulerStringId.TextWeekly_2Day:
                    return "{0} 及 {1}";

                case SchedulerStringId.TextWeekly_3Day:
                    return "{0}, {1}, 及 {2}";

                case SchedulerStringId.TextWeekly_4Day:
                    return "{0}, {1}, {2}, 及 {3}";

                case SchedulerStringId.TextWeekly_5Day:
                    return "{0}, {1}, {2}, {3}, 及 {4}";

                case SchedulerStringId.TextWeekly_6Day:
                    return "{0}, {1}, {2}, {3}, {4}, 及 {5}";

                case SchedulerStringId.TextWeekly_7Day:
                    return "{0}, {1}, {2}, {3}, {4}, {5}, 及 {6}";

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
                    return "全天";

                case SchedulerStringId.Caption_PleaseSeeAbove:
                    return "请看上文";

                case SchedulerStringId.Caption_RecurrenceSubject:
                    return "主旨:";

                case SchedulerStringId.Caption_RecurrenceLocation:
                    return "地点:";

                case SchedulerStringId.Caption_RecurrenceStartTime:
                    return "开始:";

                case SchedulerStringId.Caption_RecurrenceEndTime:
                    return "结束:";

                case SchedulerStringId.Caption_RecurrenceShowTimeAs:
                    return "显示时间为:";

                case SchedulerStringId.Caption_Recurrence:
                    return "周期性:";

                case SchedulerStringId.Caption_RecurrencePattern:
                    return "循环模式";

                case SchedulerStringId.Caption_NoneRecurrence:
                    return "(无)";

                case SchedulerStringId.MemoPrintDateFormat:
                    return "{0} {1} {2}";

                case SchedulerStringId.Caption_EmptyResource:
                    return "任何";

                case SchedulerStringId.Caption_DailyPrintStyle:
                    return "日样式";

                case SchedulerStringId.Caption_WeeklyPrintStyle:
                    return "周样式";

                case SchedulerStringId.Caption_MonthlyPrintStyle:
                    return "月样式";

                case SchedulerStringId.Caption_TrifoldPrintStyle:
                    return "三重样式";

                case SchedulerStringId.Caption_CalendarDetailsPrintStyle:
                    return "月历细明样式";

                case SchedulerStringId.Caption_MemoPrintStyle:
                    return "备忘录样式";

                case SchedulerStringId.Caption_ColorConverterFullColor:
                    return "全彩";

                case SchedulerStringId.Caption_ColorConverterGrayScale:
                    return "灰阶";

                case SchedulerStringId.Caption_ColorConverterBlackAndWhite:
                    return "纯黑白";

                case SchedulerStringId.Caption_ResourceNone:
                    return "(无)";

                case SchedulerStringId.Caption_ResourceAll:
                    return "(所有)";

                case SchedulerStringId.PrintPageSetupFormatTabControlCustomizeShading:
                    return "<自定义...>";

                case SchedulerStringId.PrintPageSetupFormatTabControlSizeAndFontName:
                    return "{0} pt. {1}";

                case SchedulerStringId.PrintRangeControlInvalidDate:
                    return "结束日期必须大于或等于开始日期";

                case SchedulerStringId.PrintCalendarDetailsControlDayPeriod:
                    return "日";

                case SchedulerStringId.PrintCalendarDetailsControlWeekPeriod:
                    return "周";

                case SchedulerStringId.PrintCalendarDetailsControlMonthPeriod:
                    return "月份";

                case SchedulerStringId.PrintMonthlyOptControlOnePagePerMonth:
                    return "1页每月";

                case SchedulerStringId.PrintMonthlyOptControlTwoPagesPerMonth:
                    return "2页每月";

                case SchedulerStringId.PrintTimeIntervalControlInvalidDuration:
                    return "时段必须不大于天和大于0";

                case SchedulerStringId.PrintTimeIntervalControlInvalidStartEndTime:
                    return "结束时间必须大于开始时间";

                case SchedulerStringId.PrintTriFoldOptControlDailyCalendar:
                    return "日历";

                case SchedulerStringId.PrintTriFoldOptControlWeeklyCalendar:
                    return "周历";

                case SchedulerStringId.PrintTriFoldOptControlMonthlyCalendar:
                    return "月历";

                case SchedulerStringId.PrintWeeklyOptControlOneWeekPerPage:
                    return "1页每周";

                case SchedulerStringId.PrintWeeklyOptControlTwoWeekPerPage:
                    return "2页每周";

                case SchedulerStringId.PrintPageSetupFormCaption:
                    return "打印选项: {0}";

                case SchedulerStringId.PrintMoreItemsMsg:
                    return "更多项目...";

                //case SchedulerStringId.PrintNoPrintersInstalled:
                //    return "没有安装打印机";

                //case SchedulerStringId.Caption_IncreaseVisibleResourcesCount:
                //    return "增加可见的资源计数";

                //case SchedulerStringId.Caption_DecreaseVisibleResourcesCount:
                //    return "减少可见的资源计数";
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
                    return "合计";

                case TreeListStringId.MenuFooterMin:
                    return "最小值";

                case TreeListStringId.MenuFooterMax:
                    return "最大值";

                case TreeListStringId.MenuFooterCount:
                    return "计数";

                case TreeListStringId.MenuFooterAverage:
                    return "平均";

                case TreeListStringId.MenuFooterNone:
                    return "无";

                case TreeListStringId.MenuFooterAllNodes:
                    return "全部节点";

                case TreeListStringId.MenuFooterSumFormat:
                    return "合计={0:#.##}";

                case TreeListStringId.MenuFooterMinFormat:
                    return "最小值={0}";

                case TreeListStringId.MenuFooterMaxFormat:
                    return "最大值={0}";

                case TreeListStringId.MenuFooterCountFormat:
                    return "{0}";

                case TreeListStringId.MenuFooterAverageFormat:
                    return "平均值={0:#.##}";

                case TreeListStringId.MenuColumnSortAscending:
                    return "升序排序";

                case TreeListStringId.MenuColumnSortDescending:
                    return "降序排序";

                case TreeListStringId.MenuColumnColumnCustomization:
                    return "列选择";

                case TreeListStringId.MenuColumnBestFit:
                    return "最佳匹配";

                case TreeListStringId.MenuColumnBestFitAllColumns:
                    return "最佳匹配 (所有列)";

                case TreeListStringId.ColumnCustomizationText:
                    return "自定显示字段";

                case TreeListStringId.ColumnNamePrefix:
                    return "列名首标";

                case TreeListStringId.PrintDesignerHeader:
                    return "打印设置";

                case TreeListStringId.PrintDesignerDescription:
                    return "为当前的树状列表设置不同的打印选项.";

                case TreeListStringId.InvalidNodeExceptionText:
                    return "是否确定要修改？";

                case TreeListStringId.MultiSelectMethodNotSupported:
                    return "OptionsBehavior.MultiSelect未激活时，指定方法不能工作.";
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
                    return "自定义";

                case VGridStringId.RowCustomizationNewCategoryFormText:
                    return "新增类别";

                case VGridStringId.RowCustomizationNewCategoryFormLabelText:
                    return "标题";

                case VGridStringId.RowCustomizationNewCategoryText:
                    return "新增...";

                case VGridStringId.RowCustomizationDeleteCategoryText:
                    return "删除...";

                case VGridStringId.RowCustomizationTabPageCategoriesText:
                    return "类别";

                case VGridStringId.RowCustomizationTabPageRowsText:
                    return "行";

                case VGridStringId.InvalidRecordExceptionText:
                    return "是否确定修改？";

                case VGridStringId.StyleCreatorName:
                    return "自定义式样";
            }
            return base.GetLocalizedString(id);
        }

    }


}

