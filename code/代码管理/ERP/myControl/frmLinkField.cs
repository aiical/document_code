using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myControl
{
    public partial class frmLinkField : Form
    {
        public Hashtable htFields;

        public frmLinkField()
        {
            InitializeComponent();
        }

        private void SetFields()
        {
            if (htFields != null)
            {
                foreach (DictionaryEntry de in htFields)
                {
                    int intRow = GridField.Rows.Add();
                    GridField.Rows[intRow].Cells["F_Source"].Value = de.Key;
                    GridField.Rows[intRow].Cells["F_Des"].Value = de.Value;
                }

            }
            else
                htFields = new Hashtable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSource.Text == "")
            {
                MessageBox.Show("源字段不能为空!","提示");
                txtSource.Focus();
                return;
            }

            if (txtDes.Text == "")
            {
                MessageBox.Show("目标字段不能为空!", "提示");
                txtDes.Focus();
                return;
            }
            int intRow = GridField.Rows.Add();
            GridField.Rows[intRow].Cells["F_Source"].Value = txtSource.Text;
            GridField.Rows[intRow].Cells["F_Des"].Value = txtDes.Text;
            txtSource.Text = "";
            txtDes.Text = "";
            txtSource.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            GridField.Rows.Remove(GridField.CurrentRow);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (htFields != null)  
                htFields.Clear();

            foreach (DataGridViewRow dvRow in GridField.Rows)
            {
                htFields.Add(dvRow.Cells["F_Source"].Value, dvRow.Cells["F_Des"].Value);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void frmLinkField_Shown(object sender, EventArgs e)
        {
            SetFields();
        }
    }
}
