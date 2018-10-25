using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game3
{
    class MiniBoss : Object
    {
        #region Fields
        private bool isMove;
        #endregion
        #region Properties
        public bool IsMove { get => isMove; set => isMove = value; }
        #endregion
        #region Methods
        public MiniBoss(Point _position) : base(_position)
        {
            Image =game3.Properties.Resources.miniboss_down_1;
            IsMove = true;
        }
        public MiniBoss(Point _position, Bitmap _image) : base(_position, _image) { }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image, new Rectangle(new Point(Position.X-5, Position.Y), new Size(40,60)));
        }
        fMain fBoom;
        Map map;
        Random random = new Random();
        int currentIndex = 0;
        public int RandomIndex(int exceptIndex)
        {
            int n = random.Next(0, 3);
            while (n == exceptIndex)
            {
                n = random.Next(0, 3);
            }
            return n;
        }
        #region Move
        public void MiniBossMove(Map _map, fMain _fBoom)
        {
            fBoom = _fBoom;
            map = _map;
            if (IsMove)
                switch (currentIndex)
                {
                    case 0:
                        {
                            if (IsLowerLimit())
                            {
                                if (Position.X % 40 == 0 && (Position.Y - 28) % 40 == 0)
                                {
                                    if (!Management.Instance.IsCollision(new Point(Position.X, Position.Y + 40 + 4), map))
                                    {
                                        Timer downTimer = new Timer();
                                        downTimer.Enabled = true;
                                        downTimer.Interval = 125;
                                        downTimer.Start();
                                        downTimer.Tick += DownTimer_Tick;
                                        if (random.Next(0, 2) == 1)
                                            currentIndex = RandomIndex(0);
                                        else
                                            currentIndex = 0;
                                    }
                                    else
                                    {
                                        goto case 1;
                                    }
                                }
                            }
                            else
                                goto case 1;
                            break;
                        }
                    case 1:
                        {
                            if (IsUpperLimit())
                            {
                                if (Position.X % 40 == 0 && (Position.Y - 28) % 40 == 0)
                                {
                                    if (!Management.Instance.IsCollision(new Point(Position.X, Position.Y - 40 + 4), map))
                                    {
                                        Timer upTimer = new Timer();
                                        upTimer.Enabled = true;
                                        upTimer.Interval = 125;
                                        upTimer.Start();
                                        upTimer.Tick += UpTimer_Tick;
                                        if (random.Next(0, 2) == 1)
                                            currentIndex = RandomIndex(1);
                                        else
                                            currentIndex = 1;
                                    }
                                    else
                                    {
                                        goto case 2;
                                    }
                                }
                            }
                            else
                                goto case 2;
                            break;
                        }
                    case 2:
                        {
                            if (IsRightLimit())
                            {
                                if (Position.X % 40 == 0 && (Position.Y - 28) % 40 == 0)
                                {
                                    if (!Management.Instance.IsCollision(new Point(Position.X + 40, Position.Y + 4), map))
                                    {
                                        Timer rightTimer = new Timer();
                                        rightTimer.Enabled = true;
                                        rightTimer.Interval = 125;
                                        rightTimer.Start();
                                        rightTimer.Tick += RightTimer_Tick;
                                        if (random.Next(0, 2) == 1)
                                            currentIndex = RandomIndex(2);
                                        else
                                            currentIndex = 2;
                                    }
                                    else
                                    {
                                        goto case 3;
                                    }
                                }
                            }
                            else
                                goto case 3;
                            break;
                        }
                    case 3:
                        {
                            if (IsLeftLimit())
                            {
                                if (Position.X % 40 == 0 && (Position.Y - 28) % 40 == 0)
                                {
                                    if (!Management.Instance.IsCollision(new Point(Position.X - 40, Position.Y + 4), map))
                                    {
                                        Timer leftTimer = new Timer();
                                        leftTimer.Enabled = true;
                                        leftTimer.Interval = 125;
                                        leftTimer.Start();
                                        leftTimer.Tick += LeftTimer_Tick;
                                        if (random.Next(0, 2) == 1)
                                            currentIndex = RandomIndex(3);
                                        else
                                            currentIndex = 3;
                                    }
                                    else
                                    {
                                        goto case 0;
                                    }
                                }
                            }
                            else
                                goto case 0;
                            break;
                        }
                }
        }
        
        private void LeftTimer_Tick(object sender, EventArgs e)
        {
            if (iMove < 5)
            {
                MiniBossLeft(iMove++);
                Position = new Point(Position.X - 8, Position.Y);
                fBoom.Invalidate(new Rectangle(Position.X - 15, Position.Y - 40,100, 100));
            }
            else
            {
                MiniBossMove(map, fBoom);
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
        }

        private void RightTimer_Tick(object sender, EventArgs e)
        {
            if (iMove < 5)
            {
                MiniBossRight(iMove++);
                Position = new Point(Position.X + 8, Position.Y);
                fBoom.Invalidate(new Rectangle(Position.X - 15, Position.Y - 40, 100, 100));
            }
            else
            {
                MiniBossMove(map, fBoom);
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
        }

        private void UpTimer_Tick(object sender, EventArgs e)
        {
            if (iMove < 5)
            {
                MiniBossUp(iMove++);
                Position = new Point(Position.X, Position.Y - 8);
                fBoom.Invalidate(new Rectangle(Position.X - 15, Position.Y - 40, 100, 100));
            }
            else
            {
                MiniBossMove(map, fBoom);
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
        }

        int iMove = 0;


        private void DownTimer_Tick(object sender, EventArgs e)
        {
            if (iMove < 5)
            {
                MiniBossDown(iMove++);
                Position = new Point(Position.X, Position.Y + 8);
                fBoom.Invalidate(new Rectangle(Position.X - 15, Position.Y - 40,100, 100));
            }
            else
            {
                MiniBossMove(map, fBoom);
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
        }
        #endregion
        #region LimitMove
        public bool IsLowerLimit()
        {
            if (Position.Y < 312-40)
                return true;
            return false;
        }
        public bool IsUpperLimit()
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
        #region Animation
        public void MiniBossDown(int index)
        {
          
            switch (index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.miniboss_down_2;
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.miniboss_down_3;
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.miniboss_down_4;
                        break;
                    }
                case 3:
                    {
                        Image =game3.Properties.Resources.miniboss_down_5;
                        break;
                    }
                case 4:
                    {
                        Image =game3.Properties.Resources.miniboss_down_1;
                        break;
                    }
            }
        }
        public void MiniBossUp(int index)
        {
      
            switch (index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.miniboss_up_2;
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.miniboss_up_3;
                        break;
                    }
                case 2:
                    {

                        Image =game3.Properties.Resources.miniboss_up_4;
                        break;
                    }
                case 3:
                    {

                        Image =game3.Properties.Resources.miniboss_up_5;
                        break;
                    }
                case 4:
                    {

                        Image =game3.Properties.Resources.miniboss_up_1;
                        break;
                    }
            }
        }
        public void MiniBossRight(int index)
        {
          
            switch (index)
            {
                case 0:
                    {

                        Image =game3.Properties.Resources.miniboss_right_2;
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.miniboss_right_3;
                        break;
                    }
                case 2:
                    {
   
                        Image =game3.Properties.Resources.miniboss_right_4;
                        break;
                    }
                case 3:
                    {

                        Image =game3.Properties.Resources.miniboss_right_5;
                        break;
                    }
                case 4:
                    {
   
                        Image =game3.Properties.Resources.miniboss_right_1;
                        break;
                    }
            }
        }
        public void MiniBossLeft(int index)
        {
            
            switch (index)
            {
                case 0:
                    {

                        Image =game3.Properties.Resources.miniboss_left_2;
                        break;
                    }
                case 1:
                    {
   
                        Image =game3.Properties.Resources.miniboss_left_3;
                        break;
                    }
                case 2:
                    {
   
                        Image =game3.Properties.Resources.miniboss_left_4;
                        break;
                    }
                case 3:
                    {

                        Image =game3.Properties.Resources.miniboss_left_5;
                        break;
                    }
                case 4:
                    {
    
                        Image =game3.Properties.Resources.miniboss_left_1;
                        break;
                    }
            }
        }
        #endregion
    }
    #endregion
}
