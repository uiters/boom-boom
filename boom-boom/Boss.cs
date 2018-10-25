using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game3
{
    class Boss : Object
    {
        #region Fields
        fMain fBoom;
        Map map;
        int currentIndex = 0;
        Random random = new Random();
        int iMove = 0;
        #endregion
        #region Methods
        public Boss(Point _position) : base(_position)
        {
            Image =game3.Properties.Resources.boss_down_1;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image, new Point(Position.X -8, Position.Y -27));
        }
        
        public int RandomIndex(int exceptIndex)
        {
            Random random = new Random();
            int n = random.Next(0, 3);
            while(n==exceptIndex)
            {
                n = random.Next(0, 3);
            }
            return n;
        }
        public void BossMove(Map _map,fMain _fBoom)
        {
            fBoom = _fBoom;
            map = _map;
            
            switch(currentIndex)
            {
                case 0:
                    {
                        if (IsLimitDown())
                        {
                            if (Position.X % 40 == 0 && (Position.Y - 32) % 40 == 0)
                            {
                                if (!Management.Instance.IsCollision(new Point(Position.X, Position.Y + 40), map))
                                {
                                    Timer downTimer = new Timer();
                                    downTimer.Enabled = true;
                                    downTimer.Interval = 100;
                                    downTimer.Start();
                                    downTimer.Tick += DownTimer_Tick;
                                    if (random.Next(0, 2) ==0)
                                        currentIndex = RandomIndex(0);
                                    else
                                        currentIndex = 0;
                                }
                                else
                                    goto case 1;
                            }
                        }
                        else
                            goto case 1;
                        break;
                    }
                case 1:
                    {
                        if (IsLimitUp())
                        {
                            if (Position.X % 40 == 0 && (Position.Y - 32) % 40 == 0)
                            {
                                if (!Management.Instance.IsCollision(new Point(Position.X, Position.Y - 40), map))
                                {
                                    Timer upTimer = new Timer();
                                    upTimer.Enabled = true;
                                    upTimer.Interval =100;
                                    upTimer.Start();
                                    upTimer.Tick += UpTimer_Tick;
                                    if (random.Next(0, 2) ==0)
                                        currentIndex = RandomIndex(1);
                                    else
                                        currentIndex = 1;
                                }
                                else
                                    goto case 2;
                            }
                        }
                        else
                            goto case 2;
                        break;
                    }
                case 2:
                    {
                        if (IsLimitRight())
                        {
                            if (Position.X % 40 == 0 && (Position.Y - 32) % 40 == 0)
                            {
                                if (!Management.Instance.IsCollision(new Point(Position.X+40, Position.Y), map))
                                {
                                    Timer rightTimer = new Timer();
                                    rightTimer.Enabled = true;
                                    rightTimer.Interval = 100;
                                    rightTimer.Start();
                                    rightTimer.Tick += RightTimer_Tick;
                                    if (random.Next(0, 2) ==0)
                                        currentIndex = RandomIndex(2);
                                    else
                                        currentIndex = 2;
                                }
                                else
                                    goto case 3;
                            }
                        }
                        else
                            goto case 3;
                        break;
                    }
                case 3:
                    {
                        if (IsLimitLeft())
                        {
                            if (Position.X % 40 == 0 && (Position.Y - 32) % 40 == 0)
                            {
                                if (!Management.Instance.IsCollision(new Point(Position.X - 40, Position.Y), map))
                                {
                                    Timer leftTimer = new Timer();
                                    leftTimer.Enabled = true;
                                    leftTimer.Interval =100;
                                    leftTimer.Start();
                                    leftTimer.Tick += LeftTimer_Tick;
                                    if (random.Next(0, 2) ==0)
                                        currentIndex = RandomIndex(3);
                                    else
                                        currentIndex = 3;
                                }
                                else
                                    goto case 0;
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
                BossLeft(iMove++);
                Position = new Point(Position.X - 8, Position.Y);
                fBoom.Invalidate(new Rectangle(new Point(Position.X - 15, Position.Y -40), new Size(100, 100)));
            }
            else
            {
                BossMove(map, fBoom);
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
                BossRight(iMove++);
                Position = new Point(Position.X+8, Position.Y);
                fBoom.Invalidate(new Rectangle(new Point(Position.X - 15, Position.Y - 40), new Size(100, 100)));
            }
            else
            {
                BossMove(map, fBoom);
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
                BossUp(iMove++);
                Position = new Point(Position.X, Position.Y - 8);
                fBoom.Invalidate(new Rectangle(new Point(Position.X - 15, Position.Y - 40), new Size(100, 100)));
            }
            else
            {
                BossMove(map, fBoom);
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
        }

       
        private void DownTimer_Tick(object sender, EventArgs e)
        {
            if (iMove < 5)
            {
                BossDown(iMove++);
                Position = new Point(Position.X, Position.Y + 8);
                fBoom.Invalidate(new Rectangle(new Point(Position.X - 15, Position.Y - 40), new Size(100, 100)));
            }
            else
            {
                BossMove(map, fBoom);
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
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
        public void BoosDie(int index)
        {
            switch(index)
            {
                case 0:
                    {
                        Image = game3.Properties.Resources.boss_die_1;
                        break;
                    }
                case 1:
                    {
                        Image = game3.Properties.Resources.boss_die_2;
                        break;
                    }
                case 2:
                    {
                        Image = game3.Properties.Resources.boss_die_3;
                        break;
                    }
                case 3:
                    {
                        Image =game3.Properties.Resources.boss_die_4;
                        break;
                    }
            }
        }
        public void BoosFeel(int index)
        {
            switch(index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.boss_feel_1;
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.boss_feel_2;
                        break;
                    }
            }
        }
        public void BossDown(int index)
        {
            switch(index)
            {
                case 0:
                    {
                        Image = game3.Properties.Resources.boss_down_2;
                        break;
                    }
                case 1:
                    {
                        Image = game3.Properties.Resources.boss_down_3;
                        break;
                    }
                case 2:
                    {
                        Image = game3.Properties.Resources.boss_down_4;
                        break;
                    }
                case 3:
                    {
                        Image = game3.Properties.Resources.boss_down_5;
                        break;
                    }
                case 4:
                    {
                        Image = game3.Properties.Resources.boss_down_1;
                        break;
                    }
            }
        }
        public void BossUp(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        Image = game3.Properties.Resources.boss_up_2;
                        break;
                    }
                case 1:
                    {
                        Image = game3.Properties.Resources.boss_up_3;
                        break;
                    }
                case 2:
                    {
                        Image = game3.Properties.Resources.boss_up_4;
                        break;
                    }
                case 3:
                    {
                        Image = game3.Properties.Resources.boss_up_5;
                        break;
                    }
                case 4:
                    {
                        Image = game3.Properties.Resources.boss_up_1;
                        break;
                    }
            }
        }
        public void BossLeft(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        Image = game3.Properties.Resources.boss_left_2;
                        break;
                    }
                case 1:
                    {
                        Image = game3.Properties.Resources.boss_left_3;
                        break;
                    }
                case 2:
                    {
                        Image = game3.Properties.Resources.boss_left_4;
                        break;
                    }
                case 3:
                    {
                        Image = game3.Properties.Resources.boss_left_5;
                        break;
                    }
                case 4:
                    {
                        Image = game3.Properties.Resources.boss_left_1;
                        break;
                    }
            }
        }
        public void BossRight(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        Image = game3.Properties.Resources.boss_right_2;
                        break;
                    }
                case 1:
                    {
                        Image = game3.Properties.Resources.boss_right_3;
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.boss_right_4;
                        break;
                    }
                case 3:
                    {
                        Image = game3.Properties.Resources.boss_right_5;
                        break;
                    }
                case 4:
                    {
                        Image = game3.Properties.Resources.boss_right_1;
                        break;
                    }
            }
        }
        #endregion
    }
}
