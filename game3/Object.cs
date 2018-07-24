using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game3
{
    class Object
    {
        #region Fields
        private Point position;
        private Bitmap image;
        #endregion
        #region Methods
        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public Bitmap Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }
        public Object(Point _position)
        {
            Position = _position;
        }
        public Object(Point _position, Bitmap _image)
        {
            Position = _position;
            Image = _image;
        }
        ~Object()
        {
            Image = null;
        }
        public virtual void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image, Position);
        }
        public Point ConvertToPoint(int index)
        {
            Point point = new Point((index % 9) * 40 + 40, (index / 9) * 40 + 32 + 40);
            return point;
        }
        public int ConvertToIndex(Point point)
        {
            return ((point.Y - 72) / 40) * 9 + (point.X - 40) / 40;
        }
        #endregion
    }
}
