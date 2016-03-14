using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using UFIDA.Retail.Common;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using UFIDA.Retail.Components;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Discount;
using UFIDA.Retail.RetailReceipt.Styles;
using UFIDA.Retail.ReadCardEquipment;
using UFIDA.Retail.TouchKeys;
using System.Text.RegularExpressions;

namespace UFIDA.Retail.VIPCardControl
{
    /// <summary>
    /// frmDiscountCard ��ժҪ˵����
    /// </summary>
    public class frmVipCardCode : System.Windows.Forms.Form
    {
        private Hashtable hashVipConsumerID = new Hashtable();
        private string strVipConsumerID = null;
        private ExTextBox txtVIPCard;
        private ExTextBox txtIntegral;
        private ExTextBox txtConsumerName;
        private IContainer components;
        private bool m_blnOK = false;
        private string m_CheckVipCardCode = "";
        private System.Windows.Forms.Label label1;
        private DataSet objDs = new DataSet();
        private TreeView treeView1;
        private ToolTip toolTip1;
        private int formWidth = 0;
        private RichTextBox label2;
        private GroupBox groupBox1;
        private ExTextBox txtVIPCardClassName;
        private bool isFastFocus = false;
        private ButtonNormal btAdd;
        private ButtonNormal btnOK;
        private ButtonNormal btnCancel;
        private Timer timer1;
        private string VIPCardTypeID = "";
        // public CheckBox chIsZheKouKa;//�ۿ۵ȼ�
        public UFIDA.Retail.Components.ExCheckBox chIsZheKouKa;
        private Label label3;
        public ExCheckBox chbIsPointForSP;
        public ExCheckBox chbIsPointForSD;
        InputDevice id; //add by pj 20130318


        public bool blnOK
        {
            get
            {
                return m_blnOK;
            }
            set
            {
                m_blnOK = value;
            }
        }

        private DateTime repairBillDate = DateTime.MinValue;
        public DateTime RepairBillDate
        {
            set { repairBillDate = value; }
            get { return repairBillDate; }
        }

        //private string vipCardInputMode;

        //public string VipCardInputMode
        //{
        //    get { return vipCardInputMode; }
        //    set { vipCardInputMode = value; }
        //}


        public frmVipCardCode()
        {
            InitializeComponent();
            //VipCardInputMode = Tools.GetStringSysPara("VIPCardUseMode");
            formWidth = this.Width;
            //Modify by pj 20130223 ����VIP����¼��ģʽ����
            //if (VipCardInputMode == "0")
            txtVIPCard.BackText = "<--�ֶ������ɨ�����뿨��";
            //else if (VipCardInputMode == "1")
            //   txtVIPCard.BackText = "<--ɨ�����뿨��"; 

            txtConsumerName.BackText = "<--�������ơ��绰��֤������";
            InitReadEquipment();
            txtIntegral.TextBox.TextAlign = HorizontalAlignment.Right;
            this.txtVIPCard.TextChanged += new CustomEventHandler(txtVIPCard_TextChanged);
            this.txtConsumerName.TextChanged += new CustomEventHandler(txtConsumerName_TextChanged);
        }

        private void txtConsumerName_TextChanged(object sender, gerenalEventAgrs e)
        {
            if (!string.IsNullOrEmpty(strVipConsumerID))
                strVipConsumerID = null;
        }

        private void txtVIPCard_TextChanged(object sender, gerenalEventAgrs e)
        {
            if (!string.IsNullOrEmpty(strVipConsumerID))
                strVipConsumerID = null;
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("�²����ޱ�");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVipCardCode));
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVIPCardClassName = new UFIDA.Retail.Components.ExTextBox();
            this.txtVIPCard = new UFIDA.Retail.Components.ExTextBox();
            this.txtIntegral = new UFIDA.Retail.Components.ExTextBox();
            this.txtConsumerName = new UFIDA.Retail.Components.ExTextBox();
            this.btAdd = new UFIDA.Retail.VIPCardControl.ButtonNormal();
            this.btnOK = new UFIDA.Retail.VIPCardControl.ButtonNormal();
            this.btnCancel = new UFIDA.Retail.VIPCardControl.ButtonNormal();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chIsZheKouKa = new UFIDA.Retail.Components.ExCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbIsPointForSP = new UFIDA.Retail.Components.ExCheckBox();
            this.chbIsPointForSD = new UFIDA.Retail.Components.ExCheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 2);
            this.label1.TabIndex = 14;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(10, 14);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "�ڵ�0";
            treeNode1.Text = "�²����ޱ�";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(77, 153);
            this.treeView1.TabIndex = 15;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(97, 14);
            this.label2.Name = "label2";
            this.label2.ReadOnly = true;
            this.label2.Size = new System.Drawing.Size(214, 153);
            this.label2.TabIndex = 17;
            this.label2.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(324, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 173);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // txtVIPCardClassName
            // 
            this.txtVIPCardClassName.AllowChars = "";
            this.txtVIPCardClassName.AllowSpace = false;
            this.txtVIPCardClassName.AutoCaptionWidth = false;
            this.txtVIPCardClassName.AutoTitleWidth = "False";
            this.txtVIPCardClassName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtVIPCardClassName.BackText = null;
            this.txtVIPCardClassName.Caption = "�ͻ�����:";
            this.txtVIPCardClassName.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtVIPCardClassName.ColSpan = 1;
            this.txtVIPCardClassName.DenyChars = "";
            this.txtVIPCardClassName.EnableControl = "True";
            this.txtVIPCardClassName.Enabled = false;
            this.txtVIPCardClassName.InincludedSQL = "";
            this.txtVIPCardClassName.Location = new System.Drawing.Point(14, 95);
            this.txtVIPCardClassName.Name = "txtVIPCardClassName";
            this.txtVIPCardClassName.PasswordChar = "\0";
            this.txtVIPCardClassName.QueryValue = "";
            this.txtVIPCardClassName.Size = new System.Drawing.Size(286, 21);
            this.txtVIPCardClassName.TabIndex = 19;
            this.txtVIPCardClassName.TabStop = false;
            this.txtVIPCardClassName.TextAlign = "left";
            this.txtVIPCardClassName.TextDataType = "text";
            this.txtVIPCardClassName.TextImeMode = "NoControl";
            this.txtVIPCardClassName.TextMaxLen = "100";
            this.txtVIPCardClassName.ToolTips = "�ͻ�����";
            this.txtVIPCardClassName.Validation = false;
            // 
            // txtVIPCard
            // 
            this.txtVIPCard.AllowChars = "";
            this.txtVIPCard.AllowSpace = false;
            this.txtVIPCard.AutoCaptionWidth = false;
            this.txtVIPCard.AutoTitleWidth = "False";
            this.txtVIPCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtVIPCard.BackText = null;
            this.txtVIPCard.Caption = "��    ��:";
            this.txtVIPCard.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtVIPCard.ColSpan = 1;
            this.txtVIPCard.DenyChars = "";
            this.txtVIPCard.EnableControl = "True";
            this.txtVIPCard.InincludedSQL = "";
            this.txtVIPCard.Location = new System.Drawing.Point(14, 11);
            this.txtVIPCard.Name = "txtVIPCard";
            this.txtVIPCard.PasswordChar = "\0";
            this.txtVIPCard.QueryValue = "";
            this.txtVIPCard.Size = new System.Drawing.Size(286, 21);
            this.txtVIPCard.TabIndex = 1;
            this.txtVIPCard.TextAlign = "left";
            this.txtVIPCard.TextDataType = "text";
            this.txtVIPCard.TextImeMode = "NoControl";
            this.txtVIPCard.TextMaxLen = "30";
            this.txtVIPCard.ToolTips = "VIP����:��";
            this.txtVIPCard.Validation = false;
            this.txtVIPCard.Enter += new System.EventHandler(this.txtVIPCard_Enter);
            this.txtVIPCard.Leave += new System.EventHandler(this.txtVIPCard_Leave);
            // 
            // txtIntegral
            // 
            this.txtIntegral.AllowChars = "";
            this.txtIntegral.AllowSpace = false;
            this.txtIntegral.AutoCaptionWidth = false;
            this.txtIntegral.AutoTitleWidth = "False";
            this.txtIntegral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtIntegral.BackText = null;
            this.txtIntegral.Caption = "�������:";
            this.txtIntegral.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtIntegral.ColSpan = 1;
            this.txtIntegral.DenyChars = "";
            this.txtIntegral.EnableControl = "False";
            this.txtIntegral.Enabled = false;
            this.txtIntegral.InincludedSQL = "";
            this.txtIntegral.Location = new System.Drawing.Point(13, 140);
            this.txtIntegral.Name = "txtIntegral";
            this.txtIntegral.PasswordChar = "\0";
            this.txtIntegral.QueryValue = "";
            this.txtIntegral.Size = new System.Drawing.Size(287, 21);
            this.txtIntegral.TabIndex = 5;
            this.txtIntegral.TabStop = false;
            this.txtIntegral.TextAlign = "left";
            this.txtIntegral.TextDataType = "text";
            this.txtIntegral.TextImeMode = "Disable";
            this.txtIntegral.TextMaxLen = "30";
            this.txtIntegral.ToolTips = "�������:��";
            this.txtIntegral.Validation = false;
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.AllowChars = "";
            this.txtConsumerName.AllowSpace = false;
            this.txtConsumerName.AutoCaptionWidth = false;
            this.txtConsumerName.AutoTitleWidth = "False";
            this.txtConsumerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtConsumerName.BackText = null;
            this.txtConsumerName.Caption = "�����ͻ�:";
            this.txtConsumerName.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtConsumerName.ColSpan = 1;
            this.txtConsumerName.DenyChars = "";
            this.txtConsumerName.EnableControl = "True";
            this.txtConsumerName.InincludedSQL = "";
            this.txtConsumerName.Location = new System.Drawing.Point(14, 50);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.PasswordChar = "\0";
            this.txtConsumerName.QueryValue = "";
            this.txtConsumerName.Size = new System.Drawing.Size(286, 21);
            this.txtConsumerName.TabIndex = 4;
            this.txtConsumerName.TextAlign = "left";
            this.txtConsumerName.TextDataType = "text";
            this.txtConsumerName.TextImeMode = "NoControl";
            this.txtConsumerName.TextMaxLen = "30";
            this.txtConsumerName.ToolTips = "�����ͻ�:��";
            this.txtConsumerName.Validation = false;
            this.txtConsumerName.Enter += new System.EventHandler(this.txtConsumerName_Enter);
            this.txtConsumerName.Leave += new System.EventHandler(this.txtConsumerName_Leave);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btAdd.AntiAlias = true;
            this.btAdd.Checked = false;
            this.btAdd.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btAdd.DefaultEndColor = System.Drawing.Color.AliceBlue;
            this.btAdd.DefaultStartColor = System.Drawing.Color.White;
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Font = new System.Drawing.Font("����", 9F);
            this.btAdd.Image = ((System.Drawing.Image)(resources.GetObject("btAdd.Image")));
            this.btAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAdd.Location = new System.Drawing.Point(31, 208);
            this.btAdd.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btAdd.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btAdd.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btAdd.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btAdd.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btAdd.Name = "btAdd";
            this.btAdd.ShowFocusRectangle = true;
            this.btAdd.Size = new System.Drawing.Size(80, 28);
            this.btAdd.TabIndex = 21;
            this.btAdd.Text = "���(&A)";
            this.btAdd.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.VKCode = ((short)(0));
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.AntiAlias = true;
            this.btnOK.Checked = false;
            this.btnOK.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnOK.DefaultEndColor = System.Drawing.Color.AliceBlue;
            this.btnOK.DefaultStartColor = System.Drawing.Color.White;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("����", 9F);
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(117, 208);
            this.btnOK.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnOK.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnOK.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnOK.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnOK.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnOK.Name = "btnOK";
            this.btnOK.ShowFocusRectangle = true;
            this.btnOK.Size = new System.Drawing.Size(80, 28);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "ȷ��(&O)";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.VKCode = ((short)(0));
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.AntiAlias = true;
            this.btnCancel.Checked = false;
            this.btnCancel.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnCancel.DefaultEndColor = System.Drawing.Color.AliceBlue;
            this.btnCancel.DefaultStartColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("����", 9F);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(204, 208);
            this.btnCancel.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnCancel.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnCancel.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnCancel.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnCancel.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowFocusRectangle = true;
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "ȡ��(&C)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.VKCode = ((short)(0));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chIsZheKouKa
            // 
            this.chIsZheKouKa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.chIsZheKouKa.Caption = "�Ƿ�ʹ���ۿۿ�";
            this.chIsZheKouKa.ColSpan = 1;
            this.chIsZheKouKa.EnableControl = "True";
            this.chIsZheKouKa.Location = new System.Drawing.Point(15, 174);
            this.chIsZheKouKa.Name = "chIsZheKouKa";
            this.chIsZheKouKa.QueryValue = "False";
            this.chIsZheKouKa.Size = new System.Drawing.Size(121, 21);
            this.chIsZheKouKa.TabIndex = 25;
            this.chIsZheKouKa.Text = "�Ƿ�ʹ���ۿۿ�";
            this.chIsZheKouKa.TextMaxLen = "";
            this.chIsZheKouKa.ToolTips = "�Ƿ�ʹ���ۿۿ�";
            this.chIsZheKouKa.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.label3.Location = new System.Drawing.Point(13, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 21);
            this.label3.TabIndex = 24;
            // 
            // chbIsPointForSP
            // 
            this.chbIsPointForSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.chbIsPointForSP.Caption = "�����ֻ���ֲ�����";
            this.chbIsPointForSP.ColSpan = 1;
            this.chbIsPointForSP.EnableControl = "True";
            this.chbIsPointForSP.Location = new System.Drawing.Point(15, 201);
            this.chbIsPointForSP.Name = "chbIsPointForSP";
            this.chbIsPointForSP.QueryValue = "False";
            this.chbIsPointForSP.Size = new System.Drawing.Size(199, 21);
            this.chbIsPointForSP.TabIndex = 28;
            this.chbIsPointForSP.Text = "�����ֻ���ֲ�����";
            this.chbIsPointForSP.TextMaxLen = "";
            this.chbIsPointForSP.ToolTips = "�����ֻ���ֲ�����";
            this.chbIsPointForSP.UseVisualStyleBackColor = false;
            this.chbIsPointForSP.Visible = false;
            // 
            // chbIsPointForSD
            // 
            this.chbIsPointForSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.chbIsPointForSD.Caption = "�ֳ��ۿ�ֻ���ֲ�����";
            this.chbIsPointForSD.ColSpan = 1;
            this.chbIsPointForSD.EnableControl = "True";
            this.chbIsPointForSD.Location = new System.Drawing.Point(147, 174);
            this.chbIsPointForSD.Name = "chbIsPointForSD";
            this.chbIsPointForSD.QueryValue = "False";
            this.chbIsPointForSD.Size = new System.Drawing.Size(156, 21);
            this.chbIsPointForSD.TabIndex = 29;
            this.chbIsPointForSD.Text = "�ֳ��ۿ�ֻ���ֲ�����";
            this.chbIsPointForSD.TextMaxLen = "";
            this.chbIsPointForSD.ToolTips = "�ֳ��ۿ�ֻ���ֲ�����";
            this.chbIsPointForSD.UseVisualStyleBackColor = false;
            // 
            // frmVipCardCode
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(315, 243);
            this.ControlBox = false;
            this.Controls.Add(this.chbIsPointForSD);
            this.Controls.Add(this.chbIsPointForSP);
            this.Controls.Add(this.chIsZheKouKa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.txtVIPCardClassName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVIPCard);
            this.Controls.Add(this.txtIntegral);
            this.Controls.Add(this.txtConsumerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVipCardCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIP��";
            this.Load += new System.EventHandler(this.frmVipCardCode_Load);
            this.Shown += new System.EventHandler(this.frmVipCardCode_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVipCardCode_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVipCardCode_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        void frmVipCardCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SysPara.GetBoolean("IsTouchPanel"))
            {
                KeyboardControl.RemoveParentHandle(this.Handle);
                KeyboardControl.SetPosition(KeyBoardPosition.Left);
                //KeyboardControl.OpenKeyboard(Screen.PrimaryScreen.WorkingArea.Width, this.Location.Y, true, InputMode.English);
            }
        }

        void frmVipCardCode_Shown(object sender, EventArgs e)
        {
            if (SysPara.GetBoolean("IsTouchPanel"))
            {
                KeyboardControl.OpenKeyboard(this.Location.X + this.Width, this.Location.Y, true, InputMode.Numeric);
                KeyboardControl.AddParentHandle(this.Handle);
            }
            this.Activate();
            this.txtVIPCard.Focus();
        }
        /// <summary>
        /// 872��ʼ������
        /// </summary>

        /*private void InitForm()
        {
            //string s="<InitParams Type='SQL' Value='select fnarcardtypename as Display,ltrim(str(fdecvipdiscountrate,20,2)) as [Value] from vipcardtype' NoAll='1'/>";
            string s="<InitParams Type='SQL' Value='select fnarcardtypename as Display,fintVIPLevel as [Value] from vipcardtype Where fbitnoused=0 Order by fintVipLevel' />";
            ///
            System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
            doc.LoadXml(s);
            cboVipCardType.InitControl(doc.DocumentElement);
            this.cboVipCardType.comboBoxSelectedIndexChanged += new CustomEventHandler(this.cboVipCardType_comboBoxSelectedIndexChanged);
            txtVipRate.ControlValue =this.cboVipCardType.ControlValue;
            if(cboVipCardType.ListCount>0)
            {
                cboVipCardType.Enabled  = Tools.GetBoolSysPara("ModiVIPLevel");
            }
            else
                cboVipCardType.Enabled  =false;
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            bool isCheckvip =CheckVipCode();
            if (!isCheckvip)
            {
                if (!treeView1.Focused)
                {
                    this.txtVipRate.ControlValue = "";
                    this.cboVipCardType.MyText = "ȫ��";
                    this.txtIntegral.ControlValue = "";
                    this.txtConsumerName.ControlValue = "";
                    m_CheckVipCardCode = txtVIPCard.ControlValue;
                    this.txtVIPCard.Focus();
                    this.txtVIPCard.SelectText();
                }
                return;
            }

            if (this.cboVipCardType.ControlValue == "ȫ��" || this.cboVipCardType.ControlValue == "")
            {
                ItemData.MessageBox("VIP�ۿ�", "VIP0012");
                txtVipRate.ControlValue = "";
                return;
            }

            VipCardCode = txtVIPCard.ControlValue;
            m_CheckVipCardCode = txtVIPCard.ControlValue;

            VipDiscountRate = Convert.ToDouble(this.txtVipRate.ControlValue);
            VipCardType = this.cboVipCardType.MyText;

            System.Text.StringBuilder OutXML = new System.Text.StringBuilder();
            OutXML.Append("<Data VipDiscountRate = '" + this.VipDiscountRate.ToString() + "' ");
            OutXML.Append(" VipCardCode ='" + VipCardCode.ToString() + "' ");
            OutXML.Append(" VIPLevel ='" + VipDiscountRate.ToString() + "'");
            OutXML.Append(" VipDiscountType='" + VipCardType + "'>  ");
            OutXML.Append("</Data>");
            this.Tag = OutXML.ToString();
            blnOK = true;
            this.Close();
        }
         */
        private string billDate = "";//��������
        public string BillDate
        {
            set { billDate = value; }
            get { return billDate; }
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            bool isCheckvip = CheckVipCode();
            if (!isCheckvip)
            {
                if (!treeView1.Focused)
                {
                    this.txtIntegral.ControlValue = "";
                    this.txtConsumerName.ControlValue = "";
                    this.txtVIPCardClassName.ControlValue = "";
                    m_CheckVipCardCode = txtVIPCard.ControlValue;
                    this.txtVIPCard.Focus();
                    this.txtVIPCard.SelectText();
                }
                return;
            }
            string VipCardCode = txtVIPCard.ControlValue;
            m_CheckVipCardCode = txtVIPCard.ControlValue;

            //--872��˿
            if (VIPCardTypeID.Equals(""))
            {
                this.txtVIPCard.Focus();
                this.txtVIPCard.SelectText();
                ItemData.MessageBox("VIP�ۿ�", "VIP0023");//�ۿ���Ϊ��
                return;
            }
            StringBuilder objSql = new StringBuilder();
            objSql.AppendFormat("select fdecvipdiscountrate,fintDiscountModle from vipcardtype where fchrvipcardtypeid='{0}';", VIPCardTypeID);
            objSql.AppendFormat("select fdecVIPSpecialDiscountRate from VIPCardTypeDetail where fchrvipcardtypeid='{0}';", VIPCardTypeID);
            objSql.Append("select * from VIPCardAddPointRule where fchrAddPointRuleID in(");
            objSql.Append("select top 1 fchrAddPointRuleID from VIPCardClass where fchrVIPCardClassID in(");
            objSql.Append("select top 1 fchrVIPCardClassID from VipConsumer where fchrvipconsumerid in(");
            objSql.AppendFormat("Select top 1 fchrvipconsumerid from VipCodeCollate where fchrVipCode='{0}')));", VipCardCode.ToString());
            DataSet objDs = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
            if (objDs.Tables[1].Rows.Count == 0)
            {
                if (objDs.Tables[0].Rows[0][0].ToString().Equals(""))
                {
                    this.txtVIPCard.Focus();
                    this.txtVIPCard.SelectText();
                    ItemData.MessageBox("VIP�ۿ�", "VIP0022");//�ۿ���Ϊ��
                    return;
                }
            }
            if (objDs.Tables[2].Rows.Count == 0)
            {
                ItemData.MessageBox("VIP�ۿ�", "VIP0024");//���ֹ���Ϊ��
                return;
            }
            //--end
            System.Text.StringBuilder OutXML = new System.Text.StringBuilder();
            OutXML.Append(" <Data VipCardCode ='" + VipCardCode.ToString() + "'");
            OutXML.Append("  VipDiscountLevelID ='" + VIPCardTypeID + "'>");
            OutXML.Append("</Data>");
            this.Tag = OutXML.ToString();
            blnOK = true;
            this.Close();
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            blnOK = false;
            this.Close();
        }
        /// <summary>
        /// VIP��֤
        /// </summary>
        private bool VipValidate(string billDate)
        {
            string encryptValue = DESCryptoServiceHelper.Encrypt(this.txtConsumerName.ControlValue.Trim().Replace("'", "''"));
            string decryptValue = this.txtConsumerName.ControlValue.Trim().Replace("'", "''");
            string vipCode = txtVIPCard.ControlValue.Trim().Replace("'", "''");
            if (vipCode.Equals("") && decryptValue.Equals(""))
            {
                ItemData.MessageBox("VIP�ۿ�", "VIP0010");
                return false;
            }
            StringBuilder objSql = new StringBuilder();
            if (!vipCode.Equals(""))
            {
                objSql.Append(" SELECT VipConsumer.fchrvipconsumerid, fchrVIPCardClassID,fdtmStartDate, ");
                objSql.Append(" fdtmEndDate,fbitUse, fdtmStopDate FROM  VipCodeCollate INNER JOIN VipConsumer ON ");
                objSql.Append(" VipCodeCollate.fchrvipconsumerid = VipConsumer.fchrvipconsumerid Where ");
                objSql.AppendFormat(" fchrVipCode ='{0}'", vipCode);
                if (!string.IsNullOrEmpty(strVipConsumerID))
                    objSql.AppendFormat(" AND VipConsumer.fchrvipconsumerid ='{0}'", strVipConsumerID);
                objSql.Append(";");
            }
            if (!decryptValue.Equals(""))
            {
                if (string.IsNullOrEmpty(strVipConsumerID))
                {
                    objSql.AppendFormat("select * from VipConsumer where fnarConsumerName='{0}' Or fnarConsumerName='{1}' ", encryptValue, decryptValue);
                    objSql.AppendFormat(" Or fnarPhone='{0}' Or fnarPhone='{1}' ", encryptValue, decryptValue);
                    objSql.AppendFormat(" Or fnarMobilePhone='{0}' Or fnarMobilePhone='{1}' ", encryptValue, decryptValue);
                    objSql.AppendFormat(" Or fnarcertificatecode='{0}' Or fnarcertificatecode='{1}'; ", encryptValue, decryptValue);
                }
                else
                {
                    objSql.AppendFormat("select * from VipConsumer where (fnarConsumerName='{0}' Or fnarConsumerName='{1}' ", encryptValue, decryptValue);
                    objSql.AppendFormat(" Or fnarPhone='{0}' Or fnarPhone='{1}' ", encryptValue, decryptValue);
                    objSql.AppendFormat(" Or fnarMobilePhone='{0}' Or fnarMobilePhone='{1}' ", encryptValue, decryptValue);
                    objSql.AppendFormat(" Or fnarcertificatecode='{0}' Or fnarcertificatecode='{1}') AND fchrvipconsumerid='{2}'; ", encryptValue, decryptValue, strVipConsumerID);
                }
            }
            //�û��Ƿ����
            DataSet objDs = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
            DataTable objTable = new DataTable();
            if (!vipCode.Equals("") && decryptValue.Equals(""))
            {
                objTable = objDs.Tables[0];
                if (objTable.Rows.Count == 0)
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0015");//�û�����
                    return false;
                }
                string vipcardclassID = Tools.GetStringColumnValue(objTable.Rows[0]["fchrVIPCardClassID"]);
                if (vipcardclassID.Equals(""))
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0020");
                    return false;
                }
                bool returnValue = VipCardValidate(objTable.Rows[0]);
                return returnValue;
            }
            if (vipCode.Equals("") && !decryptValue.Equals(""))
            {
                objTable = objDs.Tables[0];
                if (objTable.Rows.Count == 0)
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0015");//�û�����
                    return false;
                }
                //if (objTable.Rows.Count == 1)
                //{
                //    string vipcardclassID = Tools.GetStringColumnValue(objTable.Rows[0]["fchrVIPCardClassID"]);
                //    if (vipcardclassID.Equals(""))
                //    {
                //        ItemData.MessageBox("VIP�ۿ�", "VIP0020");
                //        return false;
                //    }
                //    string vipConsumerid = Tools.GetStringColumnValue(objTable.Rows[0]["fchrVipConsumerId"]);
                //    string strSQL = string.Format(" select * from VipCodeCollate where fchrvipconsumerid='{0}';", vipConsumerid);
                //    DataTable objTempTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSQL).Tables[0];
                //    if (objTempTable.Rows.Count == 0)
                //    {
                //        ItemData.MessageBox("VIP�ۿ�", "VIP0016");
                //        return false;
                //    }
                //    bool returnValue = VipCardValidate(objTempTable.Rows[0]);
                //    return returnValue;
                //}
                //------------------------8720903001
                // bool isVipCardClassIDErr = false;//�Ƿ��ǿ��ȼ�����
                // bool isVipCardErr = false;//�Ƿ���û�п�
                // string ErrCode = "";
                // bool returnValue = false;
                // for (int i = 0; i < objTable.Rows.Count; i++)
                // {
                //     string vipcardclassID = Tools.GetStringColumnValue(objTable.Rows[i]["fchrVIPCardClassID"]);
                //     if (vipcardclassID.Equals(""))
                //     {
                //         isVipCardClassIDErr = true;
                //         continue;
                //     }
                //     string vipConsumerid = Tools.GetStringColumnValue(objTable.Rows[i]["fchrVipConsumerId"]);
                //     string strSQL = string.Format(" select * from VipCodeCollate where fchrvipconsumerid='{0}';", vipConsumerid);
                //     DataTable objTempTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSQL).Tables[0];
                //     if (objTempTable.Rows.Count == 0)
                //     {
                //         isVipCardErr = true;
                //         continue;
                //     }
                //      returnValue = VipCardValidate(objTempTable.Rows[0],ref ErrCode);
                //     if (returnValue)
                //     {
                //         break;
                //     }
                // }
                // if (!returnValue)
                // {
                //     if (isVipCardClassIDErr)
                //     {
                //         ItemData.MessageBox("VIP�ۿ�", "VIP0008");
                //         return false;
                //     }
                //     if (isVipCardErr)
                //     {
                //         ItemData.MessageBox("VIP�ۿ�", "VIP0016");
                //         return false;
                //     }
                //     if (ErrCode.Equals(""))
                //     {
                //         ItemData.MessageBox("VIP�ۿ�", ErrCode);
                //     }
                // }
                //return returnValue;
                //----------------------end
                return MConsumerValidate(objTable);

            }
            if (!vipCode.Equals("") && !decryptValue.Equals(""))
            {
                DataTable objCTable = objDs.Tables[0];
                DataTable objITable = objDs.Tables[1];
                if (objCTable.Rows.Count == 0 && objITable.Rows.Count == 0)
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0008");
                    return false;
                }
                if (objCTable.Rows.Count > 0)
                {
                    bool returnValue = VipCardValidate(objCTable.Rows[0]);
                    return returnValue;
                }
                if ((objCTable.Rows.Count == 0) && (objITable.Rows.Count > 0))
                {
                    //string vipConsumerid = Tools.GetStringColumnValue(objITable.Rows[0]["fchrVipConsumerId"]);
                    //string strSQL = string.Format(" select * from VipCodeCollate where fchrvipconsumerid='{0}';", vipConsumerid);
                    //DataTable objTempTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSQL).Tables[0];
                    //if (objTempTable.Rows.Count == 0)
                    //{
                    //    ItemData.MessageBox("VIP�ۿ�", "VIP0016");
                    //    return false;
                    //}
                    //bool returnValue = VipCardValidate(objTempTable.Rows[0]);
                    //return returnValue;
                    return MConsumerValidate(objITable);
                }
            }
            return true;
        }
        /// <summary>
        /// �������ͻ�����֤8720903001
        /// </summary>
        private bool MConsumerValidate(DataTable objTable)
        {
            bool isVipCardClassIDErr = false;//�Ƿ��ǿ��ȼ�����
            bool isVipCardErr = false;//�Ƿ���û�п�
            string ErrCode = "";
            bool returnValue = false;
            for (int i = 0; i < objTable.Rows.Count; i++)
            {
                string vipcardclassID = Tools.GetStringColumnValue(objTable.Rows[i]["fchrVIPCardClassID"]);
                if (vipcardclassID.Equals(""))
                {
                    isVipCardClassIDErr = true;
                    continue;
                }
                string vipConsumerid = Tools.GetStringColumnValue(objTable.Rows[i]["fchrVipConsumerId"]);
                string strSQL = string.Format(" select * from VipCodeCollate where fchrvipconsumerid='{0}';", vipConsumerid);
                DataTable objTempTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSQL).Tables[0];
                if (objTempTable.Rows.Count == 0)
                {
                    isVipCardErr = true;
                    continue;
                }
                //����һ�ö࿨���
                for (int j = 0; j < objTempTable.Rows.Count; j++)
                {
                    returnValue = VipCardValidate(objTempTable.Rows[j], ref ErrCode);
                    if (returnValue) break;
                }
                if (returnValue)
                {
                    break;
                }
            }
            if (!returnValue)
            {
                if (isVipCardClassIDErr)
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0008");
                    return false;
                }
                if (isVipCardErr)
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0016");
                    return false;
                }
                if (!ErrCode.Equals(""))
                {
                    ItemData.MessageBox("VIP�ۿ�", ErrCode);
                }
            }
            return returnValue;
        }
        /// <summary>
        /// VIP����֤
        /// </summary>
        private bool VipCardValidate(DataRow objRow, ref string ErrCode)
        {
            bool fbitUse = Tools.GetBoolColumnValue(objRow["fbitUse"].ToString());
            //�Ƿ��Ѿ�ͣ��
            if (!fbitUse)
            {
                ErrCode = "VIP0017";
                return false;
            }
            //VIP��δ����
            if (!objRow["fdtmStartDate"].ToString().Equals(""))
            {
                DateTime fdtmStartDate = Tools.GetDateTime(objRow["fdtmStartDate"].ToString());
                if (fdtmStartDate > Tools.GetDateTime(billDate.Split("".ToCharArray())[0]))
                {
                    ErrCode = "VIP0018";
                    return false;
                }
            }
            //�Ѿ�ʧЧ
            if (!objRow["fdtmEndDate"].ToString().Equals(""))
            {
                DateTime fdtmEndDate = Tools.GetDateTime(objRow["fdtmEndDate"].ToString());
                if (fdtmEndDate <= Tools.GetDateTime(billDate.Split("".ToCharArray())[0]))
                {
                    ErrCode = "VIP0019";
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// VIP����֤
        /// </summary>
        private bool VipCardValidate(DataRow objRow)
        {
            bool fbitUse = Tools.GetBoolColumnValue(objRow["fbitUse"].ToString());
            //�Ƿ��Ѿ�ͣ��
            if (!fbitUse)
            {
                ItemData.MessageBox("VIP�ۿ�", "VIP0017");
                return false;
            }
            //VIP��δ����
            if (!objRow["fdtmStartDate"].ToString().Equals(""))
            {
                DateTime fdtmStartDate = Tools.GetDateTime(objRow["fdtmStartDate"].ToString());
                if (fdtmStartDate > Tools.GetDateTime(billDate.Split("".ToCharArray())[0]))
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0018");
                    return false;
                }
            }
            //�Ѿ�ʧЧ
            if (!objRow["fdtmEndDate"].ToString().Equals(""))
            {
                DateTime fdtmEndDate = Tools.GetDateTime(objRow["fdtmEndDate"].ToString());
                if (fdtmEndDate <= Tools.GetDateTime(billDate.Split("".ToCharArray())[0]))
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0019");
                    return false;
                }
            }
            return true;
        }
        private bool CheckVipCode()
        {
            string encryptValue = DESCryptoServiceHelper.Encrypt(this.txtConsumerName.ControlValue.Trim().Replace("'", "''"));
            string decryptValue = this.txtConsumerName.ControlValue.Trim().Replace("'", "''");
            string vipCode = txtVIPCard.ControlValue.Trim().Replace("'", "''");
            StringBuilder objSql = new StringBuilder();
            if (billDate.Equals(""))//�����������Ϊ��ȡ��������
            {
                billDate = DateTime.Now.ToString();
            }
            bool isSuccess = VipValidate(billDate);
            if (!isSuccess) return isSuccess;

            sl_RetailCommom Retail = new sl_RetailCommom();
            if (string.IsNullOrEmpty(strVipConsumerID))//���strVipConsumerID���У���ʹ��strVipConsumerID����ѯ
            {
                //ʤ�����ο���-�����ǰΪ�ŵ����������ľɿ�����ʱ����Ҫ��ȡ�ɿ��Ŀ���������ۿۼ��� moidify by pj 20131220
                if (!Retail.CheckVIPValid(vipCode) 
                    //&& Retail.CheckVipCodeIsUpgrade(vipCode)
                    )  //����Ǿɿ����Ҹÿͻ����µ�VIP��Ϊ�ŵ��������������£���Ҫִ�����洦����� add by pj 20131223
                {
                    objSql.AppendFormat(" exec sl_proc_QueryVipInfo @BillDate='{0}',@EncryptValue='{1}',@DecryptValue='{2}',@VipCode='{3}'", billDate, encryptValue, decryptValue, vipCode);
                }   
                else
                {
                    objSql.AppendFormat(" exec procQueryVipInfo @BillDate='{0}',@EncryptValue='{1}',@DecryptValue='{2}',@VipCode='{3}'", billDate, encryptValue, decryptValue, vipCode);
                }
            }
            else
            {
                objSql.AppendFormat(@" SELECT dbo.VIPCardClass.fchrVIPCardClassName, dbo.VipConsumer.fchrvipconsumerid, dbo.VipConsumer.fchrVIPCardClassID, 
				                          dbo.VipConsumer.fnarconsumername, dbo.VipConsumer.fnarsex, dbo.VipConsumer.fdtmbirthday, dbo.VipConsumer.fnarcertificatetype, 
				                          dbo.VipConsumer.fnarcertificatecode, dbo.VipConsumer.fnarphone, dbo.VipConsumer.fnarmobilephone, dbo.VipConsumer.fnaremail, 
				                          dbo.VipConsumer.fnaraddress, dbo.VipConsumer.fnarpostalcode, dbo.VipConsumer.fbitExport, dbo.VipConsumer.fbitProvide, 
				                          dbo.VipConsumer.fdtmDate, dbo.VipConsumer.fdtmApplyTime, dbo.VipConsumer.fchrEmployee, dbo.VipConsumer.fchrStoreid, 
				                          dbo.VipConsumer.fchrVIPCusDefine1, dbo.VipConsumer.fchrVIPCusDefine2, dbo.VipConsumer.fchrVIPCusDefine3, dbo.VipConsumer.fchrVIPCusDefine4, 
				                          dbo.VipConsumer.fchrVIPCusDefine5, dbo.VipConsumer.fchrVIPCusDefine6, dbo.VipConsumer.fchrVIPCusDefine7, dbo.VipConsumer.fchrVIPCusDefine8, 
				                          dbo.VipConsumer.fchrVIPCusDefine9, dbo.VipConsumer.fchrVIPCusDefine10, dbo.VipConsumer.fchrVIPCusDefine11, 
				                          dbo.VipConsumer.fchrVIPCusDefine12, dbo.VipConsumer.fchrVIPCusDefine13, dbo.VipConsumer.fchrVIPCusDefine14, 
				                          dbo.VipConsumer.fchrVIPCusDefine15, dbo.VipConsumer.fchrVIPCusDefine16, dbo.VipConsumer.fchrVIPCusDefine17, 
				                          dbo.VipConsumer.fchrVIPCusDefine18, dbo.VipConsumer.fchrVIPCusDefine19, dbo.VipConsumer.fchrVIPCusDefine20, 
				                          dbo.VipConsumer.fchrVIPCusDefine21, dbo.VipConsumer.fchrVIPCusDefine22, dbo.VipConsumer.fchrVIPCusDefine23, 
				                          dbo.VipConsumer.fchrVIPCusDefine24, dbo.VipConsumer.fchrVIPCusDefine25, dbo.VipConsumer.fchrVIPCusDefine26, dbo.VipCodeCollate.fchrVipCode, 
				                          dbo.VipCodeCollate.fdtmEndDate, dbo.VipCodeCollate.fdtmStartDate, dbo.VipCodeCollate.fdtmStopDate, 
				                         (IsNull(fintMinusTotal,0) +IsNull(VipConsumer.fintReturnTotal,0)+IsNull(flotInitialTotal,0)+IsNull(VipConsumer.fintTotal,0)+IsNull(fintInitTotal,0)) as flotPointBalance, 
				                          dbo.VipCodeCollate.fbitUse, dbo.VipCodeCollate.fintLevels, dbo.VIPCardClass.fchrVIPCardTypeID,
				                          dbo.vipcardtype.fdecvipdiscountrate, dbo.vipcardtype.fnarcardtypename
			                        FROM  dbo.VipConsumer INNER JOIN
				                          dbo.VipCodeCollate ON dbo.VipConsumer.fchrvipconsumerid = dbo.VipCodeCollate.fchrvipconsumerid INNER JOIN
				                          dbo.VIPCardClass ON dbo.VipConsumer.fchrVIPCardClassID = dbo.VIPCardClass.fchrVIPCardClassID INNER JOIN
				                          dbo.vipcardtype ON dbo.VIPCardClass.fchrVIPCardTypeID = dbo.vipcardtype.fchrVipCardTypeID
                                   Where 
				                          fbitUse=1 AND cast('{0}' as datetime)  >=fdtmStartDate
				                          AND  cast('{0}' as datetime) <fdtmEndDate and dbo.VipConsumer.fchrvipconsumerid='{1}'", billDate, strVipConsumerID);
                if (!string.IsNullOrEmpty(vipCode))
                {
                    objSql.AppendFormat(" and CHARINDEX('{0}',dbo.VipConsumer.fchrvipcards)>0", vipCode);
                    objSql.AppendFormat(" and dbo.VipCodeCollate.fchrVipCode='{0}' ", vipCode);
                }
            }

            try
            {
                objDs = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
                DataTable objTable = objDs.Tables[0];
                if (objTable.Rows.Count == 1)
                {
                    strVipConsumerID = objTable.Rows[0]["fchrvipconsumerid"].ToString();
                    txtVIPCard.ControlValue = objTable.Rows[0]["fchrVipCode"].ToString();
                    txtConsumerName.ControlValue = objTable.Rows[0]["fnarconsumername"].ToString();
                    txtIntegral.ControlValue = Tools.GetIntColumnValue(objTable.Rows[0]["flotPointBalance"].ToString()).ToString();//�������
                    VIPCardTypeID = objTable.Rows[0]["fchrVIPCardTypeID"].ToString();//�ۿۼ���

                    this.txtVIPCardClassName.ControlValue = Tools.GetStringColumnValue(objTable.Rows[0]["fchrVIPCardClassName"]);
                    if (this.Width.Equals(formWidth * 2))
                    {
                        TreeNode objNode = new TreeNode();
                        string strVipCode = string.Format("{0}", objTable.Rows[0]["fchrVipCode"]);
                        bool isExecuteNode = false;
                        DataRow objRow;
                        for (int i = 0; i < treeView1.Nodes.Count; i++)
                        {
                            objRow = treeView1.Nodes[i].Tag as DataRow;
                            if (strVipCode.Equals(objRow["fchrVipCode"].ToString()))
                            {
                                treeView1.SelectedNode = treeView1.Nodes[i];
                                isExecuteNode = true;
                                break;
                            }
                        }
                        if (!isExecuteNode)
                        {
                            treeView1.Nodes.Clear();
                            objNode = new TreeNode();
                            objNode.Tag = objTable.Rows[0];
                            objNode.Text = string.Format("{0}", objTable.Rows[0]["fchrVipCode"]);
                            treeView1.Nodes.Add(objNode);
                            treeView1.SelectedNode = treeView1.Nodes[0];
                        }
                    }

                    //ʤ����VIP����-���ѿ��� by pj 20131125
                    if (!VIPCardControl.CheckVIPConsume(objTable.Rows[0]["fchrvipconsumerid"].ToString(), objTable.Rows[0]["fchrVipCode"].ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                //strVipConsumerID = null;
                if (objTable.Rows.Count == 0)  //û�в鵽�������
                {
                    if (!this.txtVIPCard.ControlValue.Equals(""))
                    {
                        ItemData.MessageBox("VIP�ۿ�", "VIP0008");//û�в��ҵ�VIP�û�
                    }
                    else
                    {
                        ItemData.MessageBox("VIP�ۿ�", "VIP0021");//VIP�ۿ۵ȼ������ڣ�������ʹ�á�VIP������
                    }
                    return false;
                }
                if (objTable.Rows.Count > 1)  //û�в鵽�������
                {
                    treeView1.Nodes.Clear();
                    TreeNode objNode;
                    this.Width = formWidth * 2;
                    for (int i = 0; i < objTable.Rows.Count; i++)
                    {
                        objNode = new TreeNode();
                        objNode.Tag = objTable.Rows[i];
                        objNode.Text = string.Format("{0}", objTable.Rows[i]["fchrVipCode"]);
                        treeView1.Nodes.Add(objNode);
                    }
                    treeView1.SelectedNode = treeView1.Nodes[0];
                    treeView1.Select();
                    treeView1.Focus();
                    isFastFocus = true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                ItemData.MessageBox("VIP�ۿ�", "VIP0011");
            }
            return false;
        }
        /*872
       private bool CheckVipCode()
       {
           string encryptValue = DESCryptoServiceHelper.Encrypt(this.txtConsumerName.ControlValue.Trim().Replace("'", "''"));
           string decryptValue = this.txtConsumerName.ControlValue.Trim().Replace("'", "''");

           //�Ƿ��Ƕ��û�
           StringBuilder whereValue = new StringBuilder();
           whereValue.AppendFormat(" (VipConsumer.fnarconsumername='{0}') or ", decryptValue);
           whereValue.AppendFormat(" (fnarPhone='{0}') or (fnarPhone='{1}') or ", decryptValue, encryptValue);
           whereValue.AppendFormat(" (fnarMobilePhone='{0}') or (fnarMobilePhone='{1}') or ", decryptValue, encryptValue);
           whereValue.AppendFormat(" (fnarcertificatecode='{0}') or (fnarcertificatecode='{1}') ", decryptValue, encryptValue);
           string strWhere = whereValue.ToString();
           System.Text.StringBuilder objTempSQL = new System.Text.StringBuilder();

           if (this.txtVIPCard.ControlValue.Trim().Equals("") && this.txtConsumerName.ControlValue.Trim().Equals(""))
           {
               return false;
           }
           isFastFocus = false;
           objTempSQL.Append(" select VipCodeCollate.fchrVipConsumerID,vipcardtype.fchrVipcardTypeID,");
           objTempSQL.Append(" vipcardtype.fintVipLevel,vipcardtype.fnarcardtypename,");
           objTempSQL.Append(" VipCodeCollate.finttotal ,VipConsumer.fnarconsumername, ");
           objTempSQL.Append(" VipCodeCollate.fchrVipCode,");
           objTempSQL.Append(" VipConsumer.fnarphone,VipConsumer.fnarmobilephone,VipConsumer.fdtmApplyTime ,VipConsumer.fdtmbirthday,VipConsumer.fnarcertificatecode,");
           objTempSQL.Append(" VipConsumer.fnarsex");
           objTempSQL.Append(" FROM vipcardtype,VipCodeCollate,VipConsumer WHERE vipcardtype.fintVipLevel=VipCodeCollate.fintLevels  and ");
           objTempSQL.Append(" VipCodeCollate. fbitUse=1 AND GETDATE() >=VipCodeCollate.fdtmStartDate AND GETDATE() < VipCodeCollate.fdtmEndDate and ");
           objTempSQL.Append(" (VipConsumer.fchrVipConsumerID =VipCodeCollate.fchrVipConsumerID)  ");

           string strSQL = "";
           //�û�����
           if (!this.txtConsumerName.ControlValue.Trim().Equals(""))
           {
               //string strWhere = whereValue.ToString();
               strSQL = string.Format("select fchrVipConsumerID from dbo.VipConsumer where {0};", strWhere);
               //�û�������ѯ
               strSQL += string.Format(" {0} AND VipCodeCollate.fchrVipConsumerID  in (select fchrvipconsumerid from dbo.VipConsumer where {1}) ;", objTempSQL.ToString(), strWhere);
           }
           else
           {
               strSQL = "select fchrVipConsumerID from dbo.VipConsumer where 1=2;";
               strSQL += string.Format(" {0} AND 1=2;", objTempSQL.ToString());
           }
           //VIP������
           if (!txtVIPCard.ControlValue.Trim().Equals(""))
           {
               strSQL += string.Format(" {0}   AND VipCodeCollate.fchrVipCode ='{1}'  Order by VipCodeCollate.fchrVipCode;", objTempSQL.ToString(), txtVIPCard.ControlValue.Trim().Replace("'", "''"));
           }
           else
           {
               strSQL += string.Format(" {0}  AND 1=2  Order by VipCodeCollate.fchrVipCode;", objTempSQL.ToString());
           }

           try
           {
               objDs = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSQL);
               if (objDs.Tables.Count > 2)
               {
                   //���ж�VIP������
                   if (objDs.Tables[2].Rows.Count == 1)
                   {
                       txtVIPCard.ControlValue = objDs.Tables[2].Rows[0]["fchrVipCode"].ToString();
                       txtConsumerName.ControlValue = objDs.Tables[2].Rows[0]["fnarconsumername"].ToString();
                       txtIntegral.ControlValue = objDs.Tables[2].Rows[0]["finttotal"].ToString();
                       isExecuteSQL = true;
                       if ((!isUpdateLevel) || txtVipRate.ControlValue.Equals(""))
                       {
                           txtVipRate.ControlValue = objDs.Tables[2].Rows[0]["fintVipLevel"].ToString();
                           cboVipCardType.ControlValue = objDs.Tables[2].Rows[0]["fnarcardtypename"].ToString();
                       }
                       if (this.Width.Equals(formWidth * 2))
                       {
                           TreeNode objNode = new TreeNode();
                           string strVipCode = string.Format("{0}", objDs.Tables[2].Rows[0]["fchrVipCode"]);
                           bool isExecuteNode = false;
                           DataRow objRow;
                           for (int i = 0; i < treeView1.Nodes.Count; i++)
                           {
                               objRow = treeView1.Nodes[i].Tag as DataRow;
                               if (strVipCode.Equals(objRow["fchrVipCode"].ToString()))
                               {
                                   treeView1.SelectedNode = treeView1.Nodes[i];
                                   isExecuteNode = true;
                                   break;
                               }
                           }
                           if (!isExecuteNode)
                           {
                               treeView1.Nodes.Clear();
                               objNode = new TreeNode();
                               objNode.Tag = objDs.Tables[2].Rows[0];
                               objNode.Text = string.Format("{0}", objDs.Tables[2].Rows[0]["fchrVipCode"]);
                               treeView1.Nodes.Add(objNode);

                               treeView1.SelectedNode = treeView1.Nodes[0];
                           }
                       }
                       return true;
                   }
                   //û�в鵽�������
                   if (objDs.Tables[0].Rows.Count == 0)
                   {
                       if (!this.txtVIPCard.ControlValue.Equals(""))
                       {
                           ItemData.MessageBox("VIP�ۿ�", "VIP0008");//û�в��ҵ�VIP�û�
                       }
                       else
                       {
                           //string strWhere = string.Format(" (fnarPhone='{0}') or (fnarMobilePhone='{0}') or (fnarcertificatecode='{0}')", this.txtConsumerName.ControlValue.Trim().Replace("'", "''"));
                           ErrDisplayVipConsumer(strWhere);
                       }
                       return false;
                   }
                   if (objDs.Tables[0].Rows.Count >= 1)//ֻ��һ�������û�ʱ
                   {
                       //ֻ��һ�ſ�ʱ
                       if (objDs.Tables[1].Rows.Count == 1)
                       {
                           txtVIPCard.ControlValue = objDs.Tables[1].Rows[0]["fchrVipCode"].ToString();
                           txtConsumerName.ControlValue = objDs.Tables[1].Rows[0]["fnarconsumername"].ToString();
                           txtIntegral.ControlValue = objDs.Tables[1].Rows[0]["finttotal"].ToString();
                           if ((!isUpdateLevel) || txtVipRate.ControlValue.Equals(""))
                           {
                               txtVipRate.ControlValue = objDs.Tables[1].Rows[0]["fintVipLevel"].ToString();
                               cboVipCardType.ControlValue = objDs.Tables[1].Rows[0]["fnarcardtypename"].ToString();
                           }
                           if (this.Width.Equals(formWidth*2))
                           {
                               TreeNode objNode = new TreeNode();
                               string strVipCode = string.Format("{0}", objDs.Tables[1].Rows[0]["fchrVipCode"]);
                               bool isExecuteNode = false;
                               DataRow objRow;
                               for (int i = 0; i < treeView1.Nodes.Count; i++)
                               {
                                   objRow = treeView1.Nodes[i].Tag as DataRow;
                                   if (strVipCode.Equals(objRow["fchrVipCode"].ToString()))
                                   {
                                       treeView1.SelectedNode = treeView1.Nodes[i];
                                       isExecuteNode = true;
                                       break;
                                   }
                               }
                               if (!isExecuteNode)
                               {
                                   treeView1.Nodes.Clear();
                                   objNode = new TreeNode();
                                   objNode.Tag = objDs.Tables[1].Rows[0];
                                   objNode.Text = string.Format("{0}", objDs.Tables[1].Rows[0]["fchrVipCode"]);
                                   treeView1.Nodes.Add(objNode);

                                   treeView1.SelectedNode = treeView1.Nodes[0];
                               }
                           }
                           return true;
                       }
                       else if (objDs.Tables[1].Rows.Count > 1)//�ж��ſ�ʱ
                       {
                           treeView1.Nodes.Clear();
                           TreeNode objNode;
                           this.Width = formWidth * 2;// +this.treeView1.Width + 24;
                           for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                           {
                               objNode = new TreeNode();
                               objNode.Tag = objDs.Tables[1].Rows[i];
                               objNode.Text = string.Format("{0}", objDs.Tables[1].Rows[i]["fchrVipCode"]);
                               treeView1.Nodes.Add(objNode);
                           }
                           treeView1.SelectedNode = treeView1.Nodes[0];
                           treeView1.Select();
                           treeView1.Focus();
                           isFastFocus = true;
                           return false;
                       }
                       else//û�п�ʱ
                       {
                           if (!this.txtVIPCard.ControlValue.Equals(""))
                           {
                               ItemData.MessageBox("VIP�ۿ�", "VIP0008");//û�в��ҵ�VIP�û�
                           }
                           else
                           {
                               //string strWhere = string.Format(" (fnarPhone='{0}') or (fnarMobilePhone='{0}') or (fnarcertificatecode='{0}')", this.txtConsumerName.ControlValue.Trim().Replace("'", "''"));
                               ErrDisplayVipConsumer(strWhere);
                           }
                           return false;
                       }
                   }
                   else//û�п�ʱ
                   {
                       if (!this.txtVIPCard.ControlValue.Equals(""))
                       {
                           ItemData.MessageBox("VIP�ۿ�", "VIP0008");//û�в��ҵ�VIP�û�
                       }
                       else
                       {
                           //string strWhere = string.Format(" (fnarPhone='{0}') or (fnarMobilePhone='{0}') or (fnarcertificatecode='{0}')", this.txtConsumerName.ControlValue.Trim().Replace("'", "''"));
                           ErrDisplayVipConsumer(strWhere);
                       }
                       return false;
                   }

               }
               else
               {
                   ItemData.MessageBox("VIP�ۿ�", "VIP0009");
                   return false;
               }
           }
           catch (Exception ex)
           {
               System.Diagnostics.Debug.Write(ex.Message);
               ItemData.MessageBox("VIP�ۿ�", "VIP0011");
               return false;
           }
       }
       
       private void frmVipCardCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
       {	
           this.txtVIPCard.IsEnterGoNextControl=false;
           switch (e.KeyValue)
           {
               case 27:
                   blnOK = false;
                   this.Close();
                   break;
               case 13:
                   string strExistVIPCode = "";
                   if (this.txtConsumerName.ControlValue.Trim().Equals("") && this.txtVIPCard.ControlValue.Trim().Equals(""))
                   {
                       if (this.ActiveControl == this.txtVIPCard)
                       {
                           txtConsumerName.Focus();
                       }
                       else
                       {
                           btnCancel.Focus();
                       }
                       return;
                   }
                   strExistVIPCode = txtVipRate.ControlValue.Trim();
                   bool isCheckVipCode = CheckVipCode();
                   if (!isCheckVipCode)
                   {
                       if (!treeView1.Focused)
                       {
                           this.txtVipRate.ControlValue = "";
                           this.cboVipCardType.MyText = "ȫ��";
                           this.txtIntegral.ControlValue = "";
                           this.txtConsumerName.ControlValue = "";
                           m_CheckVipCardCode = txtVIPCard.ControlValue;
                           this.txtVIPCard.IsEnterGoNextControl = false;
                           this.txtVIPCard.Focus();
                       }
                       return;
                   }
                   else
                   {
                       m_CheckVipCardCode = txtVIPCard.ControlValue;
                       if (!strExistVIPCode.Equals(""))
                       {
                           VipCardCode = txtVIPCard.ControlValue;
                           m_CheckVipCardCode = txtVIPCard.ControlValue;
                           VipDiscountRate = Convert.ToDouble(this.txtVipRate.ControlValue);
                           VipCardType = this.cboVipCardType.MyText;

                           if (strExistVIPCode.Equals(VipCardCode))
                           {
                               System.Text.StringBuilder OutXML = new System.Text.StringBuilder();
                               OutXML.Append("<Data VipDiscountRate = '" + this.VipDiscountRate.ToString() + "' ");
                               OutXML.Append(" VipCardCode ='" + VipCardCode.ToString() + "' ");
                               OutXML.Append(" VIPLevel ='" + VipDiscountRate.ToString() + "'");
                               OutXML.Append(" VipDiscountType='" + VipCardType + "'>  ");
                               OutXML.Append("</Data>");
                               this.Tag = OutXML.ToString();
                               blnOK = true;
                               this.Close();
                               return;
                           }
                       }
                       if (treeView1.Focused && isFastFocus)
                       {
                           isFastFocus = false;
                           return;
                       }
                       else
                       {
                           btnOK.Select();
                           btnOK.Focus();
                       }
                   }
                   break;
               case 40:
                   if (!treeView1.Focused)
                   {
                       txtConsumerName.Focus();
                   }
                   break;
               case 38:
                   if (!treeView1.Focused)
                   {
                       txtVIPCard.Focus();
                   }
                   break;
           }
       }
        *  private void frmVipCardCode_Load(object sender, EventArgs e)
       {
           this.txtVIPCard.IsEnterGoNextControl = false;
           txtConsumerName.IsEnterGoNextControl = false;
           if (this.Tag != null)
           {
               if (!this.Tag.ToString().Equals(""))
               {
                   if (this.Tag.GetType().Equals(typeof(ArrayList)))
                   {
                       ArrayList objList =  (ArrayList)this.Tag;
                       this.Tag = "";
                       if (cboVipCardType.Enabled)
                       {
                           isUpdateLevel = true;
                       }
                       this.txtVIPCard.ControlValue = objList[0].ToString();
                       this.txtVipRate.ControlValue = objList[1].ToString();
                       this.cboVipCardType.ControlValue = objList[2].ToString();
                       CheckVipCode();
                        
                   }
               }
           }
       }
        */

        private void frmVipCardCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            this.txtVIPCard.IsEnterGoNextControl = false;
            switch (e.KeyValue)
            {
                case 27:
                    blnOK = false;
                    this.Close();
                    break;
                case 13:
                    string strExistVIPCode = "";
                    if (this.txtConsumerName.ControlValue.Trim().Equals("") && this.txtVIPCard.ControlValue.Trim().Equals(""))
                    {
                        if (this.ActiveControl == this.txtVIPCard)
                        {
                            txtConsumerName.Focus();
                        }
                        else
                        {
                            btnCancel.Focus();
                        }
                        return;
                    }
                    bool isCheckVipCode = CheckVipCode();
                    if (!isCheckVipCode)
                    {
                        if (!treeView1.Focused)
                        {
                            this.txtIntegral.ControlValue = "";
                            this.txtConsumerName.ControlValue = "";
                            this.txtVIPCardClassName.ControlValue = "";
                            m_CheckVipCardCode = txtVIPCard.ControlValue;
                            this.txtVIPCard.IsEnterGoNextControl = false;
                            this.txtVIPCard.TextBox.Text = "";
                            this.txtVIPCard.Focus();
                        }
                        return;
                    }
                    else
                    {
                        m_CheckVipCardCode = txtVIPCard.ControlValue;
                        if (!strExistVIPCode.Equals(""))
                        {
                            string VipCardCode = txtVIPCard.ControlValue;
                            m_CheckVipCardCode = txtVIPCard.ControlValue;
                            if (strExistVIPCode.Equals(VipCardCode))
                            {
                                System.Text.StringBuilder OutXML = new System.Text.StringBuilder();
                                OutXML.Append(" <Data VipCardCode ='" + VipCardCode.ToString() + "'");
                                OutXML.Append("  VipDiscountLevelID ='" + VIPCardTypeID + "'>");
                                OutXML.Append("</Data>");
                                this.Tag = OutXML.ToString();
                                blnOK = true;
                                this.Close();
                                return;
                            }
                        }
                        if (treeView1.Focused && isFastFocus)
                        {
                            isFastFocus = false;
                            return;
                        }
                        else
                        {
                            btnOK.Select();
                            btnOK.Focus();
                        }
                    }
                    break;
                case 40:
                    if (!treeView1.Focused)
                    {
                        txtConsumerName.Focus();
                    }
                    break;
                case 38:
                    if (!treeView1.Focused)
                    {
                        txtVIPCard.Focus();
                    }
                    break;
            }
        }
        private void frmVipCardCode_Load(object sender, EventArgs e)
        {
            StringBuilder objSql = new StringBuilder();
            objSql.AppendFormat("select count(fintAutoid) from  Authority where  fchrid='{0}' ", SysPara.GetString("����ԱID"));
            objSql.Append(" and fchrmenuname in(select fchrmenuname from  Menu where fchrmenuname='RM0200');");
            DataSet objDs = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
            DataTable objTable = objDs.Tables[0];
            if (objTable.Rows.Count > 0)
            {
                if (Tools.GetIntColumnValue(objTable.Rows[0][0]) > 0)
                {
                    this.btAdd.Enabled = true;
                }
                else
                {
                    this.btAdd.Enabled = false;
                }
            }
            else
            {
                this.btAdd.Enabled = false;
            }
            this.txtVIPCard.IsEnterGoNextControl = false;
            txtConsumerName.IsEnterGoNextControl = false;
            if (this.Tag != null)
            {
                if (!this.Tag.ToString().Equals(""))
                {
                    if (this.Tag.GetType().Equals(typeof(ArrayList)))
                    {
                        ArrayList objList = (ArrayList)this.Tag;
                        this.Tag = "";
                        string vipcode = objList[0].ToString();
                        this.billDate = objList[1].ToString();
                        if (!vipcode.Equals(""))
                        {
                            this.txtVIPCard.ControlValue = objList[0].ToString();
                            CheckVipCode();
                        }

                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            StringBuilder objInfo = new StringBuilder();
            if (e.Node.Tag == null) return;
            DataRow objRow = e.Node.Tag as DataRow;
            string strTemp = "";
            objInfo.AppendFormat("��    �ţ�{0}\n", objRow["fchrVipCode"].ToString());
            objInfo.AppendFormat("�ͻ����ƣ�{0}\n", objRow["fnarconsumername"].ToString());
            strVipConsumerID = objRow["fchrvipconsumerid"].ToString();
            //strTemp = objRow["fnarsex"].ToString();
            //if (!strTemp.Equals("")) objInfo.AppendFormat("��    ��{0}\n", strTemp);

            //strTemp = objRow["fdtmbirthday"].ToString();
            //if (!strTemp.Equals(""))
            //{
            //    objInfo.AppendFormat("�������ڣ�{0}\n", Convert.ToDateTime(strTemp).ToString(SysPara.FormatDate()));
            //}
            //else
            //{
            //    objInfo.Append("�������ڣ�\n");
            //}

            //strTemp = objRow["fnarcertificatecode"].ToString();
            //if (!strTemp.Equals("")) objInfo.AppendFormat("��Ч֤����{0}\n", strTemp);

            //strTemp = objRow["fnarphone"].ToString();
            //strTemp = DataDecrypt(strTemp);
            //if (!strTemp.Equals("")) objInfo.AppendFormat("�̶��绰��{0}\n", strTemp);

            //strTemp = objRow["fnarmobilephone"].ToString();
            //strTemp = DataDecrypt(strTemp);
            //if (!strTemp.Equals("")) objInfo.AppendFormat("�ƶ��绰��{0}\n", strTemp);

            strTemp = objRow["fdtmApplyTime"].ToString();
            if (!strTemp.Equals(""))
            {
                objInfo.AppendFormat("�������ڣ�{0}\n", Convert.ToDateTime(strTemp).ToString(SysPara.FormatDate()));
            }
            else
            {
                objInfo.Append("�������ڣ�\n");
            }
            strTemp = objRow["fchrVipCode"].ToString();
            objInfo.AppendFormat("�Ƿ����ڱ��꣺{0}\n", IsOwnerStore(strTemp));

            label2.Text = objInfo.ToString();

            txtVIPCard.ControlValue = Tools.GetStringColumnValue(objRow["fchrVipCode"]);
            txtConsumerName.ControlValue = Tools.GetStringColumnValue(objRow["fnarconsumername"]);
            this.txtVIPCardClassName.ControlValue = Tools.GetStringColumnValue(objRow["fchrVIPCardClassName"]);
            txtIntegral.ControlValue = Tools.GetIntColumnValue(objRow["flotPointBalance"]).ToString();
        }
        /// <summary>
        /// ����
        /// </summary>
        private string DataDecrypt(string password)
        {
            string strReturnValue = "";
            try
            {
                strReturnValue = DESCryptoServiceHelper.Decrypt(password);
            }
            catch
            {
                strReturnValue = password;
            }
            return strReturnValue;
        }

        private void txtVIPCard_Enter(object sender, EventArgs e)
        {
            //objToolTip.Show("���뿨�š���", this, txtVIPCard.Width + txtVIPCard.Height/2, txtVIPCard.Location.Y + txtVIPCard.Height);// (this.Location.Y) / 2 - txtVIPCard.Height*3);
        }
        ToolTip objToolTip = new ToolTip();
        private void txtConsumerName_Enter(object sender, EventArgs e)
        {
            //objToolTip.Show("����ͻ����ơ��ƶ��绰���̶��绰��֤�����롭��", this, txtConsumerName.Width + txtConsumerName.Height/2, txtConsumerName.Location.Y + txtConsumerName.Height);// (this.Location.Y) / 2 );
        }

        private void txtVIPCard_Leave(object sender, EventArgs e)
        {
            //objToolTip.Hide(this);
        }

        private void txtConsumerName_Leave(object sender, EventArgs e)
        {
            //objToolTip.Hide(this);
        }

        private string IsOwnerStore(string vipCode)
        {

            string sql = "";
            int count = 0;
            //��ǰvipconsumer�Ƿ������ڱ��ŵ��
            sql = string.Format("select count(*) from VIPConsumer where fchrStoreid in( select fchrStoredefineId from  dbo.StoreDefine) and fchrvipconsumerid in (select fchrvipconsumerid from dbo.VipCodeCollate where fchrvipcode='{0}')", vipCode);

            count = (int)SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql);
            if (count > 0)
            {
                return "��";
            }
            else
            {
                return "��";
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            frmVIPConsumerInfoModify objVIPAdd = new frmVIPConsumerInfoModify();

            objVIPAdd.BillDate = this.repairBillDate;
            objVIPAdd.IsAddConsumer = true;
            objVIPAdd.Text = "���";
            if (objVIPAdd.ShowDialog() == DialogResult.OK)
            {
                this.txtVIPCard.TextBox.Text = objVIPAdd.VIPCode;
                txtConsumerName.TextBox.Text = objVIPAdd.ConsumerName;
                txtVIPCardClassName.TextBox.Text = objVIPAdd.VIPCardClassName;
                txtIntegral.TextBox.Text = "0";
                btnOK.Select();
                btnOK.Focus();
            }
        }

        #region VIPˢ������
        bool isopenReadEquipment = false;
        /// <summary>
        /// ͨ�������ٶȿ����Ƿ�ֻ����¼��
        /// </summary>
        bool OnlyWriteByInPutRate = true;
        /// <summary>
        /// ������Ӧ���ַ�����
        /// </summary>
        string pressTempString = "";
        ReadCardCommon cardcom;
        IReadCardCommon Icardcom;
        bool TimerTranFlag = false;   //��ʱ�������;
        UFIDA.Retail.GatheringReceipt.business.BusinesOperate businesOperate = new UFIDA.Retail.GatheringReceipt.business.BusinesOperate();

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimerTranFlag)
            {
                TimerTranFlag = false;
                ReadCardByEquipment();
            }
        }
        /// <summary>
        /// ͨ���豸������
        /// </summary>
        private void ReadCardByEquipment()
        {
            if (isopenReadEquipment)
            {
                if (Icardcom != null)
                {
                    DateTime beigintime = System.DateTime.Now;
                    string stringcard = Icardcom.GetCardNumb();
                    DateTime endtime = System.DateTime.Now;
                    if (stringcard != "")
                    {
                        if (stringcard != this.txtVIPCard.TextBox.Text)
                        {
                            Icardcom.Equipmentbeep(10);
                            this.txtVIPCard.TextBox.Text = stringcard;
                            CardTextLeaveMethod();
                        }
                    }
                    else
                    {
                        int mintime = endtime.Minute - beigintime.Minute;
                        int smidtime = endtime.Second - beigintime.Second;
                        if (smidtime > 2 || mintime > 1)  //����ʱ�������ʾ
                        {
                            isopenReadEquipment = false;
                            if (DialogResult.Yes == RetailMessageBox.ShowQuestion(this, "ˢ���豸���ÿ�����Ϊ���������⣬���ù���Ա��ݵ�������������ã�", MessageBoxDefaultButton.Button1))
                            {
                                timer1.Enabled = false;
                            }
                        }
                    }
                }
                TimerTranFlag = true;
            }
            else if (!OnlyWriteByInPutRate)
            {
                if (!string.IsNullOrEmpty(pressTempString.Trim()) && pressTempString.Length >= businesOperate.MaxReadLength)
                {
                    this.txtVIPCard.TextBox.Text = pressTempString.Trim();
                    CardTextLeaveMethod();
                }
                pressTempString = "";
                timer1.Enabled = false;      //��ʱ������������ �ȴ�
            }
        }
        public void InitReadEquipment()
        {
            try
            {
                cardcom = new ReadCardCommon();
                Icardcom = cardcom.GetInstanceByProName();
                isopenReadEquipment = Icardcom.OpenEquipment();
                if (isopenReadEquipment) //�������ˢ�����ɹ��򿪼�ʱ���Զ����  ��Ҫ���봥��ˢ����ˢ���豸
                {
                    timer1.Enabled = true;
                    TimerTranFlag = true;
                }
                if (Tools.GetStringSysPara("VIPCardMode") == "1")  //���ƿ��ŵ����뷽ʽ 1Ϊˢ��
                {
                    txtConsumerName.Enabled = false;
                    this.txtConsumerName.TextBox.BackColor = SystemColors.Control;
                    txtConsumerName.BackText = null;

                    //txt_cardcode.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                    if (timer1.Enabled == true)   //����ɹ��򿪴˼�ʱ�����ÿ��Բ������ַ�ʽ��������
                    {
                        txtVIPCard.TextBox.ReadOnly = true;
                    }
                    else
                    {
                        businesOperate.GetReadConfig();
                        this.txtVIPCard.TextBox.BackColor = SystemColors.Control;
                        OnlyWriteByInPutRate = false;

                        //txt_cardcode.TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
                    }
                }

                this.txtVIPCard.TextBox.ContextMenu = new ContextMenu();    //�����Ҽ�
                txtVIPCard.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            }
            catch
            {

            }
        }
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            if (Tools.GetStringSysPara("VIPCardMode") == "1")  //���ƿ��ŵ����뷽ʽ 1Ϊˢ��
            {
                StartTime();
                if (e.KeyChar.ToString() == "\b")
                {
                    return;
                }
                if (e.KeyChar.ToString() == "\r" && pressTempString != "")
                {
                    return;
                }
                else if (GatheringReceipt.business.BusinesOperate.IsNumbOrChart(e.KeyChar.ToString()))  //�ж���������ֺ���ĸ����
                {
                    if (string.IsNullOrEmpty(pressTempString.Trim()))
                    {
                        pressTempString = e.KeyChar.ToString();
                    }
                    else
                    {
                        pressTempString += e.KeyChar.ToString();
                    }
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar.ToString() == "\r" || e.KeyChar.ToString() == "\b")
                {
                    return;
                }
                if (!GatheringReceipt.business.BusinesOperate.IsNumbOrChart(e.KeyChar.ToString()))  //�ж�����������ֺ���ĸ��ֹ����
                {
                    e.Handled = true;
                }
            }

            //if (VipCardInputMode == "1")
            //{
            //    if (GetDateSpan() == 0)
            //        //txtVIPCard.TextBox.Text = "";
            //        e.Handled = true;
            //}
        }

        private void CardTextLeaveMethod()
        {
            frmVipCardCode_KeyDown(this, new KeyEventArgs(Keys.Enter));
        }

        /// <summary>
        /// ��ʼ��ʱ
        /// </summary>
        public void StartTime()
        {
            if (timer1.Enabled)
            {
                return;
            }
            timer1.Enabled = true;
            TimerTranFlag = true;
            timer1.Interval = businesOperate.TimeInterval; //���ʱ����Ϊһ��
        }
        #endregion

        /// <summary>
        /// ��ȡ�����ʱ���
        /// </summary>
        /// <returns></returns>
        private int GetDateSpan()
        {
            DateTime dt = DateTime.Now;  //����һ����Ա�������ڱ���ÿ�ε�ʱ���
            DateTime tempDt = DateTime.Now;          //���水������ʱ�̵�ʱ���
            TimeSpan ts = tempDt.Subtract(dt);     //��ȡʱ����
            //if (ts.Milliseconds > 50)                           //�ж�ʱ���������ʱ��������50���룬��TextBox���
            return Convert.ToInt32(ts.Milliseconds);
        }
    }
}

