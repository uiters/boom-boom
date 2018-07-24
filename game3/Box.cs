using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game3
{
    class Box:Object
    {
        #region Methods
        public Box(Point _position, Bitmap _image) : base(_position, _image) { }
        public Box(Point _position) : base(_position) { }
        public void Box_1()
        {
            Image = game3.Properties.Resources.box_1;
        }
        public void Box_2()
        {
            Image = game3.Properties.Resources.box_2;
        }
        public void Box_3()
        {
            Image = game3.Properties.Resources.box_3;
        }
        public void Box_4()
        {
            Image = game3.Properties.Resources.box_4;
        }
        #endregion
    }
}
