using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game3
{
    class Item : Object
    {
        #region Methods
        public Item(Point _position) : base(_position)
        {
        }
        public Item(Point _position, Bitmap _image) : base(_position, _image)
        {
        }
        public override void Draw(Graphics graphics)
        {
            if(Image!=null)
            {
                if(Image.Tag.ToString()=="coin")
                    graphics.DrawImage(Image, new Rectangle(Position, new Size(35,58)));
                else
                    graphics.DrawImage(Image, new Rectangle(Position, new Size(30, 30)));
            }
        }
        public void Coin(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        Image = game3.Properties.Resources.coin1;
                        Image.Tag = "coin";
                        break;
                    }
                case 1:
                    {
                        Image = game3.Properties.Resources.coin2;
                        Image.Tag = "coin";
                        break;
                    }
                case 2:
                    {
                        Image = game3.Properties.Resources.coin3;
                        Image.Tag = "coin";
                        break;
                    }
                case 3:
                    {
                        Image = game3.Properties.Resources.coin4;
                        Image.Tag = "coin";
                        break;
                    }
                case 4:
                    {
                        Image = game3.Properties.Resources.coin5;
                        Image.Tag = "coin";
                        break;
                    }
                case 5:
                    {
                        Image = game3.Properties.Resources.coin6;
                        Image.Tag = "coin";
                        break;
                    }
                case 6:
                    {
                        Image = game3.Properties.Resources.coin7;
                        Image.Tag = "coin";
                        break;
                    }
                case 7:
                    {
                        Image = game3.Properties.Resources.coin8;
                        Image.Tag = "coin";
                        break;
                    }
            }
        }
        public void Item1()
        {
            Image = game3.Properties.Resources.item1;
            Image.Tag = "item";
        }
        public void Item2()
        {
 
            Image = game3.Properties.Resources.item2;
            Image.Tag = "item";
        }
        public void Item3()
        {
            Image = game3.Properties.Resources.item3;
            Image.Tag = "item";
        }
        #endregion
    }
}
