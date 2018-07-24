using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game3
{
    class Bomb:Object
    {
        #region Fields
        private int index;
        private bool isDraw;
        private bool isBang;
        #endregion
        #region Properties
        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }
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
        public bool IsBang
        {
            get
            {
                return isBang;
            }

            set
            {
                isBang = value;
            }
        }
        #endregion
        #region Methods
        public Bomb(Point _position) : base(_position) { }
        public override void Draw(Graphics graphics)
        {
            if(IsDraw)
            graphics.DrawImage(Image, new Point(Position.X - 3, Position.Y - 5));
        }
        public void FirstBomb(int index)
        {
            switch (index)
            {
                case 0:
                    {
               
                        Image = game3.Properties.Resources.bomb_1;
                        break;
                    }
                case 1:
                    {

                        Image =game3.Properties.Resources.bomb_2;
                        break;
                    }
                case 2:
                    {

                        Image =game3.Properties.Resources.bomb_3;
                        break;
                    }
                case 3:
                    {

                        Image =game3.Properties.Resources.bomb_4;
                        break;
                    }
            }
        }
        public void DrawBombBang(Graphics graphics)
        {
            graphics.DrawImage(game3.Properties.Resources.bombbang_center, Position);
            graphics.DrawImage(game3.Properties.Resources.bombbang_top, new Point(Position.X, Position.Y - 40));
            graphics.DrawImage(game3.Properties.Resources.bombbang_bottom, new Point(Position.X, Position.Y + 40));
            graphics.DrawImage(game3.Properties.Resources.bombbang_left, new Point(Position.X-40, Position.Y));
            graphics.DrawImage(game3.Properties.Resources.bombbang_right, new Point(Position.X + 40, Position.Y));
        }
        public bool IsLimitDown()
        {
            if (Position.Y < 312)
                return true;
            return false;
        }
        public bool IsLimitUp()
        {
            if (Position.Y > 72)
                return true;
            return false;
        }
        public bool IsLimitLeft()
        {
            if (Position.X > 40)
                return true;
            return false;
        }
        public bool IsLimitRight()
        {
            if (Position.X < 360)
                return true;
            return false;
        }
        #endregion
    }
}
