using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace myControl
{
    public partial class ListControl : ListBox
    {
        private int selectedIndex = 0;

        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            try
            {
                if (e == null)
                    return;

                // If this tool is the currently selected tool, draw it with a highlight.
                if (selectedIndex == e.Index)
                {
                    e.Graphics.FillRectangle(Brushes.LightSlateGray, e.Bounds);
                }

                Rectangle StringBounds = new Rectangle(e.Bounds.Location.X + 5, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height);

                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(this.Items[e.Index].ToString(), new Font("宋体", 12, FontStyle.Regular, GraphicsUnit.World), Brushes.Black, StringBounds, format);
                
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            base.OnDrawItem(e);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                if (this.SelectedIndex == -1) return;
                Rectangle lastSelectedBounds = this.GetItemRectangle(0);
                try
                {
                    lastSelectedBounds = this.GetItemRectangle(selectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "错误");
                }

                selectedIndex = this.SelectedIndex;
                //selectedIndex = this.IndexFromPoint(e.X, e.Y); // change our selection
                //this.SelectedIndex = selectedIndex;
                this.Invalidate(lastSelectedBounds); // clear highlight from last selection
                this.Invalidate(this.GetItemRectangle(selectedIndex)); // highlight new one
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"错误");
            }

            base.OnMouseDown(e);
        }

    }
}
