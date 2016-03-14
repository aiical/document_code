using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.Retail.NewComponents;
using System.Drawing;

namespace UFIDA.Retail.VIPCardControl
{
    public class ButtonNormal : KeyboardButton
    {
        // Methods
        public ButtonNormal()
        {
            base.DefaultStartColor = Color.White;
            base.DefaultEndColor = Color.AliceBlue;
            base.Font = new Font("ËÎÌו", 9f);
            base.ShowFocusRectangle = true;
        }
    }


}
