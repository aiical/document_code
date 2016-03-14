using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmPrint : Form {
        private string cCode = string.Empty;
        //private string cType = string.Empty;//单据类型
        //private string conStr = string.Empty;
        //private string cUserId = string.Empty;
        //private string printTemplateType = string.Empty;
        //private int printId = -1;

        private string cType = string.Empty;//单据类型
        private string conStr = string.Empty;
        private string cUserId = string.Empty;
        private string printTemplateType = string.Empty;
        private int printId = -1;
        public frmPrint(string _cCode, string _cType, string _conStr, int _printId, string _cUserId)
        {
            InitializeComponent();
            cCode = _cCode;
            cType = _cType;
            conStr = _conStr;
            //printTemplateType = _printTemplateType;
            printId = _printId;
            cUserId = _cUserId;
        }

        public frmPrint(string _cCode) {
            InitializeComponent();
            cCode = _cCode;
        }
        public frmPrint() {
            InitializeComponent();
        }

        private void frmOutRdRecord_Load(object sender, EventArgs e) {
            string path = Application.ExecutablePath;
            path = path.Substring(0, path.LastIndexOf("\\") + 1) + @"rdlcTemplate";

            if (cType == "店存入库单")
            {
                CreatePrintReport(string.Format(@"{0}\TemplateInvForIn.rdlc", path), string.Format(@"{0}\TemplateInvForIn.rdlc", path));
                InitRefresh(string.Format(@"{0}\TemplateInvForIn.rdlc", path));
            }
            else if (cType == "店存出库单")
            {
                CreatePrintReport(string.Format(@"{0}\TemplateInvForOut.rdlc", path), string.Format(@"{0}\TemplateInvForOut.rdlc", path));
                InitRefresh(string.Format(@"{0}\TemplateInvForOut.rdlc", path));
            }
            else if (cType == "借出单")
            {
                CreatePrintReport(string.Format(@"{0}\TemplateInvForJC.rdlc", path), string.Format(@"{0}\TemplateInvForJC.rdlc", path));
                InitRefresh(string.Format(@"{0}\TemplateInvForJC.rdlc", path));
            }
            else if (cType == "归还单")
            {
                CreatePrintReport(string.Format(@"{0}\TemplateInvForGH.rdlc", path), string.Format(@"{0}\TemplateInvForGH.rdlc", path));
                InitRefresh(string.Format(@"{0}\TemplateInvForGH.rdlc", path));
            }
        }

        /// <summary>
        /// 获取字段语句
        /// </summary>
        /// <returns></returns>
        //private string GetSelCmd(XmlDocument doc) {
        //    XmlNodeList nodeList = doc.SelectNodes("Page//PageHeader//ReportItems");
        //    string selCmd = "";
        //    for (int i = 0; i < nodeList.Count; i++) {

        //        if (nodeList[i].SelectNodes("//DataSource")[i].Attributes.Count > 0) {
        //            string tableName = nodeList[i].SelectNodes("//DataSource")[i].InnerText.Trim();
        //            string disName = nodeList[i].SelectNodes("//DataSource")[i].Attributes["Name"].InnerText.Trim();
        //            string Code = nodeList[i].SelectNodes("//DataSource")[i].Attributes["Code"].InnerText.Trim();
        //            string relation = nodeList[i].SelectNodes("//DataSource")[i].Attributes["relation"].InnerText;
        //            if (!string.IsNullOrEmpty(relation)) {
        //                relation = relation.Replace("'", "''") + " and ";
        //            }
        //            selCmd += string.Format("(select top 1 {0} from {1} where {2} {3}={4}.{5}) as {5}"
        //                , disName, tableName, relation, Code, nodeList[i].SelectNodes("//TxtPara")[i].Attributes["tableName"].InnerText.Trim()
        //                , nodeList[i].SelectNodes("//TxtPara")[i].InnerText.Trim()) + ",";
        //        } else {
        //            selCmd += nodeList[i].SelectNodes("//TxtPara")[i].InnerText.Trim() + ",";
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(selCmd)) {
        //        selCmd = selCmd.Substring(0, selCmd.Length - 1);
        //    }
        //    return selCmd;
        //}

        private DataTable GetBody(DataTable dtBody) {
            for (int i = 1; i <= 35; i++) {
                if (!dtBody.Columns.Contains("cFree" + i)) {
                    dtBody.Columns.Add("cFree" + i, typeof(decimal));
                }
            }
            double iSum = 0;
            foreach (DataRow dr in dtBody.Rows) {
                iSum = 0;
                foreach (DataColumn dc in dtBody.Columns) {
                    if (!Convert.IsDBNull(dr[dc.ColumnName]) && !dc.ColumnName.Equals("cFree35") && !dc.ColumnName.Equals("type")) {
                        if (dc.DataType == typeof(System.Decimal) || dc.DataType == typeof(System.Int32)) {
                            iSum += Convert.ToDouble(dr[dc.ColumnName]);
                        }
                    }
                }
                dr["cFree35"] = iSum;
            }
            #region 分组排序
            string groupfile = System.Windows.Forms.Application.StartupPath + @"\rdlcTemplate\GroupType.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(groupfile);
            string type = doc.SelectSingleNode("GroupType").Attributes["type"].InnerText.Trim();
            if (type == "1") {
                XmlNodeList nodelist = doc.SelectNodes("GroupType//groupCode");
                for (int i = 0; i < nodelist.Count; i++) {
                    string lblText = nodelist[i].InnerText.Trim();
                    foreach (DataRow dr in dtBody.Rows) {
                        foreach (string s in lblText.Split(',')) {
                            if (string.IsNullOrEmpty(s)) continue;
                            if (Convert.ToString(dr["cInvCCode"]).Equals(s)) {
                                dr["cInvCCode"] = nodelist[i].Attributes["name"].InnerText;
                            }
                        }
                    }
                }
            }
            #endregion

            #region 分组类型小计
            dtBody.DefaultView.Sort = "cInvCCode";
            this.dataGridView1.DataSource = dtBody;
            dataGridView1.AllowUserToAddRows = false;

            DataTable dtTemp = dtBody.Clone();

            string cInvCode = string.Empty;
            DataRow drNew = null;
            DataRow sumRow = dtTemp.NewRow();
            sumRow["cInvCode"] = "合计";
            sumRow["cInvCCode"] = "走走";
            foreach (DataGridViewRow dr in dataGridView1.Rows) {
                DataRow row = dtTemp.NewRow();
                if (!cInvCode.Equals(Convert.ToString(dr.Cells["cInvCCode"].Value))) {
                    cInvCode = Convert.ToString(dr.Cells["cInvCCode"].Value);
                    if (drNew != null) {
                        dtTemp.Rows.Add(drNew);
                    }
                    drNew = dtTemp.NewRow();
                    drNew["cInvCCode"] = dr.Cells["cInvCCode"].Value;
                    drNew["cInvCode"] = "类型小计";
                    foreach (DataGridViewColumn cl in dataGridView1.Columns) {
                        if (!Convert.IsDBNull(dr.Cells[cl.Name].Value) && dr.Cells[cl.Name].Value != null) {
                            if ((cl.ValueType == typeof(System.Decimal) || cl.ValueType == typeof(System.Int32))) {
                                if (cl.Name.Equals("cFree35")) {
                                    double cfree = Convert.IsDBNull(drNew[cl.Name]) ? 0 : Convert.ToDouble(drNew[cl.Name]);

                                    drNew[cl.Name] = cfree + Convert.ToDouble(dr.Cells[cl.Name].Value);
                                }
                                double sum = Convert.IsDBNull(sumRow[cl.Name]) ? 0 : Convert.ToDouble(sumRow[cl.Name]);
                                sumRow[cl.Name] = sum + Convert.ToDouble(dr.Cells[cl.Name].Value);
                            }
                            row[cl.Name] = dr.Cells[cl.Name].Value;
                        }
                    }
                    dtTemp.Rows.Add(row);
                } else {
                    foreach (DataGridViewColumn cl in dataGridView1.Columns) {
                        if (!Convert.IsDBNull(dr.Cells[cl.Name].Value) && dr.Cells[cl.Name].Value != null) {
                            if ((cl.ValueType == typeof(System.Decimal) || cl.ValueType == typeof(System.Int32))) {
                                if (cl.Name.Equals("cFree35")) {
                                    double cfree = Convert.IsDBNull(drNew[cl.Name]) ? 0 : Convert.ToDouble(drNew[cl.Name]);
                                    drNew[cl.Name] = cfree + Convert.ToDouble(dr.Cells[cl.Name].Value);
                                }
                                double sum = Convert.IsDBNull(sumRow[cl.Name]) ? 0 : Convert.ToDouble(sumRow[cl.Name]);
                                sumRow[cl.Name] = sum + Convert.ToDouble(dr.Cells[cl.Name].Value);

                            }
                            row[cl.Name] = dr.Cells[cl.Name].Value;
                        }
                    }
                    dtTemp.Rows.Add(row);
                }
            }

            if (drNew != null) {
                dtTemp.Rows.Add(drNew);
            }
            if (sumRow != null) {
                dtTemp.Rows.Add(sumRow);
            }
            dtTemp.DefaultView.Sort = "cInvCCode";

            #endregion
            return dtTemp;
        }

        //private void InitData() {

        //    if (string.IsNullOrEmpty(cType) || string.IsNullOrEmpty(cCode)) {
        //        MessageBox.Show("单据号或单据类型不能为空!");
        //        return;
        //    }

        //    string file1 = string.Empty;
        //    string XMLFile1 = System.Windows.Forms.Application.StartupPath + @"\EAI\SL\Xml\" + cType + ".xml";
        //    if (!File.Exists(XMLFile1)) {
        //        MessageBox.Show("所选择的打印配置模板不存在!");
        //        return;
        //    }
        //    object isFontBold = false;
        //    SqlConnection con = new SqlConnection(conStr);
        //    try {
        //        con.Open();
        //        SqlCommand cmd = con.CreateCommand();

        //        cmd.CommandText = string.Format("select FontBold from sl_PrintRight where printID={0} and cUserId='{1}' and isnull(cVouchType,'')='{2}'"
        //                                        , printId, cUserId, cType);
        //        cmd.CommandType = CommandType.Text;
        //        isFontBold = cmd.ExecuteScalar();
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message);
        //    } finally {
        //        con.Close();
        //        con = null;
        //    }
        //    if (cType == "0324") {
        //        printTemplateType = "rpTranVouch";
        //    }
        //    if (Convert.ToBoolean(Convert.ToInt32(isFontBold))) {
        //        printTemplateType = printTemplateType + "FontBold";
        //    }
        //    string rpTemp = System.Windows.Forms.Application.StartupPath + @"\EAI\SL\rdlcTemplate\" + printTemplateType + ".rdlc";
        //    if (!File.Exists(rpTemp)) {
        //        MessageBox.Show("所选择的打印模板不存在!");
        //        return;
        //    }
        //    int isZhiHuo = 0;
        //    if (cType == "0324") {

        //        file1 = System.Windows.Forms.Application.StartupPath + @"\EAI\SL\rdlcTemplate\" + printTemplateType + ".rdlc";
        //    } else {

        //        string rootPath = System.Windows.Forms.Application.StartupPath + @"\EAI\SL\" + printId + "\\" + cUserId;
        //        file1 = @"\rp" + printTemplateType + cType.Trim() + ".rdlc";
        //        if (!Directory.Exists(rootPath)) {
        //            Directory.CreateDirectory(rootPath);
        //        }
        //        file1 = rootPath + file1;
        //        if (cType == "0302" && (printTemplateType == "TemplateInv" || printTemplateType == "TemplateInvFontBold")) { //执行打印执货
        //            isZhiHuo = 1;
        //        } 
        //    }
        //    if (File.Exists(file1)) {
        //        InitRefresh(file1, XMLFile1, isZhiHuo);

        //    } else {
        //        CreatePrintReport(file1, XMLFile1, rpTemp);
        //        InitRefresh(file1, XMLFile1, isZhiHuo);
        //    }
        //}

        public DataSet RefreshPrint(string cCode) {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(SysPara.ConnectionString);
            try {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = string.Format("exec sl_proc_GetRdVouchPrintData @fchrCode='{0}',@cVouchType = '{1}'"
                                                , cCode, cType);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                    da.Fill(ds);
                }

                cmd.Dispose();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                con.Close();
                con = null;
            }
            return ds;
        }

        /// <summary>
        /// 生成打印报表
        /// </summary>
        /// <param name="rpTemplate"></param>
        /// <param name="rpTemp"></param>
        /// <param name="conStr"></param>
        private void CreatePrintReport(string rpTemplate, string rpTemp)
        {
            #region 生成打印报表

            try
            {
                //string strConst = " <Style>\r\n<FontFamily>宋体</FontFamily>\r\n<FontSize>10pt</FontSize>\r\n<PaddingLeft>2pt</PaddingLeft>\r\n<PaddingRight>2pt</PaddingRight>\r\n<PaddingBottom>2pt</PaddingBottom>\r\n</Style>\r\n";

                //XmlDocument doc = new XmlDocument();
                //doc.Load(XMLFile1);

                //string strHander = doc.SelectSingleNode("Page//PageHeader").Attributes["Name"].InnerText;
                //StringBuilder sbPageHander = new StringBuilder();

                //sbPageHander.Append(" <PageHeader>\r\n<PrintOnFirstPage>true</PrintOnFirstPage>\r\n<PrintOnLastPage>true</PrintOnLastPage>\r\n<ReportItems>\r\n");
                //StringBuilder sbPara = new StringBuilder();
                //sbPara.Append("<ReportParameters>\r\n");

                //sbPageHander.AppendFormat("<Textbox Name=\"txtDate\">\r\n<Top>0.4cm</Top>\r\n<Width>7.25cm</Width>\r\n<Style>\r\n<FontFamily>宋体</FontFamily>\r\n<FontSize>9pt</FontSize>\r\n<PaddingLeft>2pt</PaddingLeft>\r\n<PaddingRight>2pt</PaddingRight>\r\n<PaddingTop>2pt</PaddingTop>\r\n<PaddingBottom>2pt</PaddingBottom>\r\n</Style>\r\n<CanGrow>true</CanGrow>\r\n<Left>0.25cm</Left>\r\n <Height>0.5cm</Height>\r\n<Value>=\"打印日期：\" &amp;Globals.ExecutionTime</Value>\r\n</Textbox>\r\n"
                //                         + "<Textbox Name=\"txtPageHander\">\r\n<Top>0.1cm</Top>\r\n<Width>8.25cm</Width>\r\n<CanGrow>true</CanGrow>\r\n<Left>7cm</Left>\r\n<Height>0.8cm</Height>\r\n<Value>{0}</Value>\r\n <Style> \r\n<FontFamily>宋体</FontFamily>\r\n<FontSize>16pt</FontSize>\r\n<FontWeight>700</FontWeight>\r\n<TextAlign>Center</TextAlign>\r\n<PaddingLeft>2pt</PaddingLeft>\r\n<PaddingRight>2pt</PaddingRight>\r\n<PaddingTop>2pt</PaddingTop>\r\n<PaddingBottom>2pt</PaddingBottom> \r\n</Style>\r\n</Textbox>\r\n"
                //                         + "<Textbox Name=\"txtPageNum\">\r\n<Top>0.4cm</Top>\r\n<Width>3.25cm</Width>\r\n<Style>\r\n<FontFamily>宋体</FontFamily>\r\n<FontSize>9pt</FontSize>\r\n<PaddingLeft>2pt</PaddingLeft>\r\n<PaddingRight>2pt</PaddingRight>\r\n<PaddingTop>2pt</PaddingTop>\r\n<PaddingBottom>2pt</PaddingBottom>\r\n</Style>\r\n<CanGrow>true</CanGrow>\r\n<Left>19cm</Left>\r\n <Height>0.5cm</Height>\r\n<Value>=\"第\"&amp; Globals.PageNumber &amp; \"页/共\" &amp; Globals.TotalPages &amp; \"页\"</Value>\r\n</Textbox>\r\n", strHander);
                //double dTop = 1;
                //double Top = 0.5;
                //int index = 0;
                //StringBuilder sbHander = new StringBuilder();
                //StringBuilder sbmter = new StringBuilder();
                //int j = 0;
                //int n = -1;
                double hHeight = 0;
                //string selCmd = string.Empty;
                //string sRemarkText = string.Empty;
                //string sRemarkPara = string.Empty;
                //XmlNodeList nodeList = doc.SelectNodes("Page//PageHeader//ReportItems");
                //for (int i = 0; i < nodeList.Count; i++)
                //{
                //    string lblText = nodeList[i].SelectNodes("//LblText")[i].InnerText.Trim();

                //    string lblPara = nodeList[i].SelectNodes("//TxtPara")[i].InnerText.Trim();
                //    if (lblText.Replace(" ", "").Equals("备注"))
                //    {
                //        sRemarkText = lblText;
                //        sRemarkPara = lblPara;
                //        continue;
                //    }
                //    if (i % 4 == 0)
                //    {
                //        n++;
                //        j = 0;
                //    }
                //    double lLeft = 0.25 + ((2 + 5 - 1.25) * j);
                //    hHeight = dTop + (Top * n);
                //    sbHander.AppendFormat("<Textbox Name=\"txt{0}\">\r\n<Top>{1}cm</Top>\r\n<Width>6cm</Width>\r\n<ZIndex>{2}</ZIndex>\r\n<Left>{3}cm</Left>\r\n<Height>0.5cm</Height>\r\n<Value>=\"{4}：\"&amp; Parameters!{0}.Value</Value>{5}\r\n</Textbox>\r\n"
                //      , lblPara, hHeight, index, lLeft, lblText, strConst);
                //    sbmter.AppendFormat("<ReportParameter Name=\"{0}\">\r\n<DataType>String</DataType>\r\n<AllowBlank>true</AllowBlank>\r\n<Prompt>{1}</Prompt>\r\n</ReportParameter>\r\n", lblPara, lblText);
                //    j++;
                //}
                //hHeight = dTop + (Top * (n + 1));

                //sbHander.AppendFormat("<Textbox Name=\"txt{0}\">\r\n<Top>{1}cm</Top>\r\n<Width>23.25cm</Width>\r\n<ZIndex>{2}</ZIndex>\r\n<Left>{3}cm</Left>\r\n<Height>0.5cm</Height>\r\n<Value>=\"{4}：\"&amp; Parameters!{0}.Value</Value>{5}\r\n</Textbox>\r\n"
                //     , sRemarkPara, hHeight, index, 0.25, sRemarkText, strConst);
                //sbmter.AppendFormat("<ReportParameter Name=\"{0}\">\r\n<DataType>String</DataType>\r\n<AllowBlank>true</AllowBlank>\r\n<Prompt>{1}</Prompt>\r\n</ReportParameter>\r\n", sRemarkPara, sRemarkText);

                //sbPageHander.Append(sbHander);
                //sbPageHander.AppendFormat("</ReportItems>\r\n<Height>{0}cm</Height>\r\n</PageHeader>", hHeight + 0.5);
                //sbPara.Append(sbmter);
                //sbPara.Append("</ReportParameters>\r\n");

                Guid DataSourceId = Guid.NewGuid();
                Guid ReportId = Guid.NewGuid();
                StreamReader srReader = null;
                StringBuilder sb = new StringBuilder();
                try
                {
                    srReader = new StreamReader(rpTemp);
                    sb.Append(srReader.ReadToEnd());
                }
                catch
                {
                }
                finally
                {
                    srReader.Close();
                }

                //sb = sb.Replace("00000000-0000-0000-0000-000000000000", DataSourceId.ToString()).Replace("00000000-0000-0000-0000-000000000001", ReportId.ToString());
                DataSet dsPrint = new DataSet();
                SqlConnection con = new SqlConnection(conStr);
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = string.Format("select * from sl_PrintRight where printID={0} and cUserId='{1}' and cVouchType='{2}'", printId, cUserId, cType);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPrint);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    con = null;
                }

                string pageWith = Convert.ToString(dsPrint.Tables[0].Rows[0]["PageWidth"]) + "cm";
                string pageHeight = Convert.ToString(dsPrint.Tables[0].Rows[0]["PageHeight"]) + "cm";
                string InteractiveHeight = Convert.ToString(dsPrint.Tables[0].Rows[0]["InteractiveHeight"]) + "cm";
                string InteractiveWidth = Convert.ToString(dsPrint.Tables[0].Rows[0]["InteractiveWidth"]) + "cm";
                double TopMargin = hHeight + Convert.ToDouble(dsPrint.Tables[0].Rows[0]["TopMargin"]);
                TopMargin = TopMargin <= 0 ? 0 : TopMargin;
                string BottomMargin = Convert.ToString(dsPrint.Tables[0].Rows[0]["BottomMargin"]) + "cm";
                string LeftMargin = Convert.ToString(dsPrint.Tables[0].Rows[0]["LeftMargin"]) + "cm";
                string RightMargin = Convert.ToString(dsPrint.Tables[0].Rows[0]["RightMargin"]) + "cm";
                string PageSize = Convert.ToString(dsPrint.Tables[0].Rows[0]["PageSize"]);
                string RowHeight = Convert.ToString(dsPrint.Tables[0].Rows[0]["RowHeight"]) + "cm";

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(sb.ToString());

                XmlNamespaceManager xnm = new XmlNamespaceManager(xmldoc.NameTable);
                xnm.AddNamespace("mxh", "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");

                if(xmldoc.SelectSingleNode(@"/mxh:Report/mxh:PageHeight",xnm) != null)
                xmldoc.SelectSingleNode(@"/mxh:Report/mxh:PageHeight",xnm).InnerText = pageHeight;
                if(xmldoc.SelectSingleNode(@"/mxh:Report/mxh:PageWidth",xnm) != null)
                    xmldoc.SelectSingleNode(@"/mxh:Report/mxh:PageWidth", xnm).InnerText = pageWith;
                if(xmldoc.SelectSingleNode(@"/mxh:Report/mxh:TopMargin",xnm) != null)
                    xmldoc.SelectSingleNode(@"/mxh:Report/mxh:TopMargin", xnm).InnerText = TopMargin.ToString() + "cm";
                if(xmldoc.SelectSingleNode(@"/mxh:Report/mxh:BottomMargin",xnm) != null)
                    xmldoc.SelectSingleNode(@"/mxh:Report/mxh:BottomMargin", xnm).InnerText = BottomMargin;
                if(xmldoc.SelectSingleNode(@"/mxh:Report/mxh:LeftMargin",xnm) != null)
                    xmldoc.SelectSingleNode(@"/mxh:Report/mxh:LeftMargin", xnm).InnerText = LeftMargin;
                if(xmldoc.SelectSingleNode(@"/mxh:Report/mxh:RightMargin",xnm) != null)
                    xmldoc.SelectSingleNode(@"/mxh:Report/mxh:RightMargin", xnm).InnerText = RightMargin;
                if(xmldoc.SelectSingleNode(@"/mxh:Report/mxh:InteractiveHeight",xnm) != null)
                    xmldoc.SelectSingleNode(@"/mxh:Report/mxh:InteractiveHeight", xnm).InnerText = InteractiveHeight;
                if(xmldoc.SelectSingleNode(@"/mxh:Report/mxh:InteractiveWidth",xnm) != null)
                    xmldoc.SelectSingleNode(@"/mxh:Report/mxh:InteractiveWidth", xnm).InnerText = InteractiveWidth;
                //RowNumberSize
                //if (xmldoc.SelectSingleNode(@"/mxh:Report/mxh:Body/mxh:ReportItems/mxh:Table/mxh:TableGroups/mxh:TableGroup/mxh:Grouping/mxh:GroupExpressions/mxh:GroupExpression", xnm) != null)
                //    xmldoc.SelectSingleNode(@"/mxh:Report/mxh:Body/mxh:ReportItems/mxh:Table/mxh:TableGroups/mxh:TableGroup/mxh:Grouping/mxh:GroupExpressions/mxh:GroupExpression", xnm).InnerText = PageSize;

                //sb = sb.Replace("PageHeightcm", pageHeight).Replace("PageWidthcm", pageWith);
                //sb = sb.Replace("TopMargincm", TopMargin + "cm").Replace("BottomMargincm", BottomMargin);
                //sb = sb.Replace("LeftMargincm", LeftMargin).Replace("RightMargincm", RightMargin);
                //sb = sb.Replace("InteractiveHeightcm", InteractiveHeight).Replace("InteractiveWidthcm", InteractiveWidth);
                //sb = sb.Replace("PageSize", PageSize);
                //sb = sb.Replace("RowNumberSize", PageSize);
                //sb = sb.Replace("RowHeightcm", RowHeight);

                //sb.Replace("</Report>", sbPara.ToString() + sbPageHander.ToString() + "\r\n</Report>");

                sb.Length = 0;
                sb.Append(xmldoc.InnerXml);
                if (File.Exists(rpTemplate))
                    File.Delete(rpTemplate);
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(rpTemplate, true);
                    sw.Write(sb);
                }
                catch
                {

                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void InitRefresh(string PrnTempPath)
        {
            try
            {
                DataSet ds = RefreshPrint(cCode);
                if (ds == null || ds.Tables.Count < 0) return;
                if (ds.Tables[0] == null || ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("表体数据不能为空!");
                    return;
                }
                if (ds.Tables[1] == null || ds.Tables[1].Rows.Count <= 0)
                {
                    MessageBox.Show("表头数据不能为空!");
                    return;
                }

                DataTable dtHander = ds.Tables[1];
                DataTable dtBody = GetBody(ds.Tables[0]);

                string fchrCode = string.Empty;
                   
                    
                //rvTemp.LocalReport.ReportPath = file1;
                //rvTemp.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TempSource", dtBody));

                this.reportViewer1.LocalReport.ReportPath = PrnTempPath;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TempSource", dtBody));
                //添加表头参数值
                List<Microsoft.Reporting.WinForms.ReportParameter> list = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fchrCode", dtHander.Rows[0]["fchrCode"].ToString()));
                list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fdtmDate", Convert.ToDateTime(dtHander.Rows[0]["fdtmDate"].ToString()).ToString("yyyy-MM-dd")));
                if (cType == "店存入库单" || cType == "店存出库单")
                {
                    list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fchrEmployeeName", GetEmployeeInfo("fchrEmployeeName", dtHander.Rows[0]["fchrEmployeeID"].ToString())));

                    if (cType == "店存入库单")
                    {
                        list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fchrOutWhName", dtHander.Rows[0]["fchrWhName"].ToString()));
                    }
                    else if (cType == "店存出库单")
                    {
                        list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fchrOutType", dtHander.Rows[0]["fchrOutVouchTypeName"].ToString()));
                        list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fchrInWhName", dtHander.Rows[0]["fchrWhName"].ToString()));
                    }
                }

                if (cType == "归还单")
                {
                    list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fchrSourceCode", dtHander.Rows[0]["fchrSourceCode"].ToString()));
                }

                list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fchrMaker", dtHander.Rows[0]["fchrMaker"].ToString()));
                list.Add(new Microsoft.Reporting.WinForms.ReportParameter("fchrMemo", dtHander.Rows[0]["fchrMemo"].ToString()));
                this.reportViewer1.LocalReport.SetParameters(list);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取门店营业员信息
        /// </summary>
        /// <param name="returnField"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string GetEmployeeInfo(string returnField,string ID)
        {
            string sql = string.Empty;
            string returnvalue = "";
            if (!string.IsNullOrEmpty(ID))
            {
                sql = string.Format(@"select {0} from Employee
                      where fchrEmployeeID = '{1}'", returnField, ID);
                returnvalue = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql).ToString();
            }

            return returnvalue;
        }
    }
}
