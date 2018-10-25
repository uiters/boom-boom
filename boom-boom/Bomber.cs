using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game3
{
    class Bomber:Object
    {
        #region Fields
        private bool isDraw;
        #endregion
        #region Properties
        public bool IsDraw
        {
            get
            {
                return isDraw;
            }

            set
            {
                isDraw = value;
            }
        }
        #endregion
        #region Methods
        public Bomber(Point position):base(position)
        {
            Image= game3.Properties.Resources.bomber_down1;
            Image.Tag = "bomber_down1";
        }
        public override void Draw(Graphics graphics)
        {
            if(IsDraw)
            {
                if (Image.Tag.ToString() == "feel_11" || Image.Tag.ToString() == "feel_12")
                    graphics.DrawImage(Image, new Point(Position.X - 13, Position.Y - 38));
                else
                    if (Image.Tag.ToString() == "die_1" || Image.Tag.ToString() == "die_2")
                    graphics.DrawImage(Image, new Point(Position.X - 8, Position.Y - 26));
                else
                    if (Image.Tag.ToString() == "die_3" || Image.Tag.ToString() == "die_4"|| Image.Tag.ToString() == "die_5" || Image.Tag.ToString() == "die_6")
                    graphics.DrawImage(Image, new Point(Position.X -8, Position.Y -18));//18
                else
                graphics.DrawImage(Image, new Point(Position.X - 13, Position.Y - 32));
            }
        }
        public void BomberDown(int index)
        {
           
            switch (index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.bomber_down2;
                        Image.Tag = "bomber_down2";
                        break;
                    }
                case 1:
                    {

                        Image =game3.Properties.Resources.bomber_down3;
                        Image.Tag = "bomber_down3";
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.bomber_down4;
                        Image.Tag = "bomber_down4";
                        break;
                    }
                case 3:
                    {
                        Image =game3.Properties.Resources.bomber_down5;
                        Image.Tag = "bomber_down5";
                        break;
                    }
                case 4:
                    {
                        Image =game3.Properties.Resources.bomber_down1;
                        Image.Tag = "bomber_down1";
                        break;
                    }
            }
        }
        public void BomberUp(int index)
        {
           
            switch (index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.bomber_up2;
                        Image.Tag = "bomber_up2";
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.bomber_up3;
                        Image.Tag = "bomber_up3";
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.bomber_up4;
                        Image.Tag = "bomber_up4";
                        break;
                    }
                case 3:
                    {
                        Image =game3.Properties.Resources.bomber_up5;
                        Image.Tag = "bomber_up5";
                        break;
                    }
                case 4:
                    {
                        Image =game3.Properties.Resources.bomber_up1;
                        Image.Tag = "bomber_up1";
                        break;
                    }
            }
        }
        public void BomberRight(int index)
        {
         
            switch (index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.bomber_right2;
                        Image.Tag = "bomber_right2";
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.bomber_right3;
                        Image.Tag = "bomber_right3";
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.bomber_right4;
                        Image.Tag = "bomber_right4";
                        break;
                    }
                case 3:
                    {
                        Image =game3.Properties.Resources.bomber_right5;
                        Image.Tag = "bomber_right5";
                        break;
                    }
                case 4:
                    {
                        Image =game3.Properties.Resources.bomber_right1;
                        Image.Tag = "bomber_right1";
                        break;
                    }
            }
        }
        public void BomberLeft(int index)
        {
           
            switch (index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.bomber_left2;
                        Image.Tag = "bomber_left2";
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.bomber_left3;
                        Image.Tag = "bomber_left3";
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.bomber_left4;
                        Image.Tag = "bomber_left4";
                        break;
                    }
                case 3:
                    {
                        Image =game3.Properties.Resources.bomber_left5;
                        Image.Tag = "bomber_left5";
                        break;
                    }
                case 4:
                    {
                        Image =game3.Properties.Resources.bomber_left1;
                        Image.Tag = "bomber_left1";
                        break;
                    }
            }
        }
        public void Feel(int index)
        {
           
            switch (index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.feel_11;
                        Image.Tag = "feel_11";
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.feel_12;
                        Image.Tag = "feel_12";
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.bomber_down1;
                        Image.Tag = "bomber_down1";
                        break;
                    }
            }
        }
        public void Die(int index)
        {

            switch (index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.Die_1;
                        Image.Tag = "die_1";
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.Die_2;
                        Image.Tag = "die_2";
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.die_3;
                        Image.Tag = "die_3";
                        break;
                    }
                case 3:
                    {
                        Image =game3.Properties.Resources.die_4;
                        Image.Tag = "die_4";
                        break;
                    }
                case 4:
                    {
                        Image =game3.Properties.Resources.die_5;
                        Image.Tag = "die_5";
                        break;
                    }
                case 5:
                    {
                        Image =game3.Properties.Resources.die_6;
                        Image.Tag = "die_6";
                        break;
                    }
            }
        }
        public bool IsUpperLimit()
        {
            if (Position.Y < 312)
                return true;
            return false;
        }
        public bool IsLowerLimit()
        {
            if (Position.Y > 72)
                return true;
            return false;
        }
        public bool IsLeftLimit()
        {
            if (Position.X > 40)
                return true;
            return false;
        }
        public bool IsRightLimit()
        {
            if (Position.X < 360)
                return true;
            return false;
        }
        #endregion
    }
}
