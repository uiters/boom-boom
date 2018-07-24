using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game3
{
    class Background:Object
    {
        #region Methods
        public Background(Point _position, Bitmap _image) : base(_position, _image) { }
        public Background(Point _position) : base(_position) { }

        public void Background1()
        {
            Image =game3.Properties.Resources.background;
        }
        public void Background2()
        {
            Image = game3.Properties.Resources.background_2;
        }
        public void Street_1()
        {
            Image =game3.Properties.Resources.street_1;
        }
        public void Street_2()
        {
            Image =game3.Properties.Resources.street_2;
        }
        public void Street_3()
        {
            Image =game3.Properties.Resources.street_3;
        }
        #endregion
    }
}
