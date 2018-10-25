using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game3
{
    class Management
    {
        #region Fields
        private static Management instance;
        private int score;
        private int heart;
        private Sound gameMusic = new Sound();
        private fMain fBoom;
        private Timer feelTimer;
        private bool checkCollisionBomber = true;
        private Point newPosition;
        private bool checkGhostBomber = true;
        private int firstAmountMiniBoss;
        private int iBomberGhost = 0;
        private int iBomberDie = 0;
        private int i = 0;
        private bool checkScore = true;
        private fMain boom;
        private Map Map;
        private int iCoinTimer = 0;
        #endregion
        #region Properties
        internal static Management Instance
        {
            get
            {
                if (instance == null)
                    instance = new Management();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public int Score { get => score; set => score = value; }
        public int Heart { get => heart; set => heart = value; }
        #endregion
        #region Methods
        public Point ConvertToPoint(int index)
        {
            Point point = new Point((index % 9) * 40 + 40, (index / 9) * 40 + 32 + 40);
            return point;
        }
        public int ConvertToIndex(Point point)
        {
            return ((point.Y - 72) / 40) * 9 + (point.X - 40) / 40;
        }
        public bool IsCollision(Point position,Map map)
        {
            //Barrier
            foreach (Barrier item in map.ListBarrier)
            {
                //Map1
                if (new Point(item.Position.X, item.Position.Y + 7) == position)
                    return true;
                if (new Point(item.Position.X, item.Position.Y + 23) == position)
                    return true;
                if (new Point(item.Position.X-1, item.Position.Y+15) == position)
                    return true;
                if (new Point(item.Position.X-1, item.Position.Y +19) == position)
                    return true;
               
                //Map2
                if (new Point(item.Position.X, item.Position.Y +30) == position)
                    return true;
                if (new Point(item.Position.X, item.Position.Y + 17) == position)
                        return true;
            }
            //Box
            foreach (Box item in map.ListBox)
            {
                if (new Point(item.Position.X, item.Position.Y + 4) == position)
                        return true;
            }
            return false;
        }
        public void CollisionBomber(Point _newPosition,Point position, List<Bomb> bombs, Bomber bomber,fMain _fBoom,Timer _feelTimer,List<MiniBoss> miniBosses,Map map)
        {
            fBoom = _fBoom;
            feelTimer = _feelTimer;
            newPosition = _newPosition;
            foreach (Bomb bomb in bombs)
            {
                if (bomb.IsBang)
                {
                    int x = bomb.Position.X - position.X;
                    int y = bomb.Position.Y - position.Y;
                    if (x < 0) x = -x;
                    if (y < 0) y = -y;
                    if ((x == 0 && y <= 40)||(y==0 && x<=40))
                    {
                        feelTimer.Stop();
                        if (checkCollisionBomber)
                        {
                            gameMusic.Bomber_Die();

                            Timer bomberDieTimer = new Timer
                            {
                                Interval = 100,
                                Enabled = true
                            };
                            bomberDieTimer.Start();
                            bomberDieTimer.Tag = bomber;
                            bomberDieTimer.Tick += BomberDieTimer_Tick;
                            bomber.Die(0);
                            checkCollisionBomber = false;
                            break;
                        }
                    }
                }
            }

            foreach (MiniBoss item in miniBosses)
            {
                int x = position.X;
                int y = position.Y;
                int x1 = x + 32;
                int y1 = y + 32;
                if ((item.Position.X >= x && item.Position.X <= x1 &&item.Position.Y+20==y)||( item.Position.Y+20 >= y && item.Position.Y+20 <= y1 && item.Position.X == x))
                {
                    if (checkGhostBomber)
                    {
                        gameMusic.Bomber_Die();

                        checkGhostBomber = false;
                        Timer bomberGhostTimer = new Timer();
                        bomberGhostTimer.Interval = 100;
                        bomberGhostTimer.Enabled = true;
                        bomberGhostTimer.Start();
                        bomberGhostTimer.Tag = bomber;
                        bomber.Die(2);
                        bomberGhostTimer.Tick += BomberGhostTimer_Tick;
                    }
                    break;
                }
            }
            foreach (Item item in map.ListItem.ToList())
            {
                if (position == item.Position)
                {
                    map.ListItem.Remove(item);
                    gameMusic.Item();
                    Score += 500;
                    break;
                }
            }
        }
        public void DestroyObject(Bomb bomb, Map map, fMain fBoom)
        {
            boom = fBoom;
            if (checkScore)
            {
                firstAmountMiniBoss = map.ListMiniBoss.Count();
                checkScore = false;
            }
            List<Point> listBombPosition = new List<Point>
            {
                new Point(bomb.Position.X, bomb.Position.Y)
            };
            if (bomb.IsLimitLeft()) listBombPosition.Add(new Point(bomb.Position.X - 40, bomb.Position.Y));
            if (bomb.IsLimitRight()) listBombPosition.Add(new Point(bomb.Position.X + 40, bomb.Position.Y));
            if (bomb.IsLimitDown()) listBombPosition.Add(new Point(bomb.Position.X, bomb.Position.Y + 40));
            if (bomb.IsLimitUp()) listBombPosition.Add(new Point(bomb.Position.X, bomb.Position.Y - 40));

            foreach (Barrier item in map.ListBarrier.ToList())
            {
                foreach (Point position in listBombPosition)
                {
                    if (new Point(item.Position.X + 4, item.Position.Y + 25) == position)
                    {
                        map.ListBarrier.Remove(item);
                        item.Image.Dispose();
                    }
                }
            }
            foreach (Box item in map.ListBox.ToList())
            {
                foreach (Point position in listBombPosition)
                {
                    if (new Point(item.Position.X, item.Position.Y + 4) == position)
                    {
                        CreateItem(map, position);
                        map.ListBox.Remove(item);
                        item.Image.Dispose();
                    }
                }
            }
            foreach (MiniBoss item in map.ListMiniBoss.ToList())
            {
                //foreach (Point position in listBombPosition)
                //{
                Point position = bomb.Position;
                int x = item.Position.X - position.X;
                int y = item.Position.Y + 4 - position.Y;
                if (x < 0) x = -x;
                if (y < 0) y = -y;
                if ((x == 0 && y <= 40) || (y == 0 && x <= 40))
                {
                    gameMusic.Boss_Die();
                    map.ListMiniBoss.Remove(item);
                    item.Image.Dispose();
                    Score = (firstAmountMiniBoss - map.ListMiniBoss.Count) * 200;
                    //break;
                }
                //}
            }

        }
        public void CollisionTree_2(Point position, Map map, Bomber bomber, List<Bomb> bombs)
        {
            foreach (Barrier item in map.ListBarrier)
            {
                if (item.Image.Tag.ToString() == "tree_25" || item.Image.Tag.ToString() == "tree_21" || item.Image.Tag.ToString() == "tree_23" || item.Image.Tag.ToString() == "tree_24" || item.Image.Tag.ToString() == "tree_22")
                {
                    #region bomber
                    if (new Point(item.Position.X + 4, item.Position.Y + 25) == position)
                    {
                        bomber.IsDraw = false;
                        Timer timer = new Timer();
                        timer.Tag = item;
                        timer.Enabled = true;
                        timer.Interval = 40;
                        timer.Start();
                        timer.Tick += Timer_Tick;
                        break;
                    }
                    else
                    {
                        item.Tree2(4);
                        bomber.IsDraw = true;
                    }
                    #endregion
                    #region bomb
                    foreach (Bomb bomb in bombs)
                    {
                        if (new Point(item.Position.X + 4, item.Position.Y + 25) == bomb.Position)
                        {
                            bomb.IsDraw = false;
                            break;
                        }
                    }
                    #endregion
                }
            }
        }
        public void CreateItem(Map map, Point position)
        {
            Map = map;
            Random random = new Random();
            if (random.Next(0, 2) == 1)
            {
                int n = random.Next(0, 4);
                Item item = new Item(position);
                switch (n)
                {
                    case 0:
                        {
                            Timer coinTimer = new Timer
                            {
                                Interval = 100,
                                Enabled = true,
                                Tag = item
                            };
                            coinTimer.Start();
                            coinTimer.Tick += CoinTimer_Tick;
                            item.Coin(7);
                            break;
                        }
                    case 1:
                        {
                            item.Item2();
                            break;
                        }
                    case 2:
                        {
                            item.Item3();
                            break;
                        }
                    case 3:
                        {
                            item.Item1();
                            break;
                        }
                }
                map.ListItem.Add(item);
            }
        }
        public bool IsExistsCoin(Item coin)
        {
            foreach (Item item in Map.ListItem.ToList())
            {
                if (coin.Position == item.Position)
                    return true;
            }
            return false;
        }
        #endregion
        #region Animation
        private void BomberGhostTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            Bomber bomber = timer.Tag as Bomber;
            if (iBomberGhost < 20)
            {

                bomber.Die(iBomberGhost%4+2);
                iBomberGhost++;
                fBoom.KeyPreview = false;
                feelTimer.Stop();

            }
            else
            {
                Heart--;
                if (Heart < 0) Heart = 3;
                iBomberDie = 0;

                checkGhostBomber = true;
                fBoom.KeyPreview = true;
                feelTimer.Start();
                iBomberGhost = 0;
                timer.Stop();
                timer.Dispose();
                bomber.BomberDown(4);
                fBoom.Invalidate(new Rectangle(bomber.Position.X - 13, bomber.Position.Y - 36,100, 100));
                bomber.Position = newPosition;
            }
            fBoom.Invalidate(new Rectangle(bomber.Position.X - 13, bomber.Position.Y - 36,100, 100));
        }
        
        private void BomberDieTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            Bomber bomber = timer.Tag as Bomber;
            if(iBomberDie<10)
            {
                bomber.Die(iBomberDie % 2);
                iBomberDie++;
                fBoom.KeyPreview = false;
                feelTimer.Stop();
            }
            else
            {
                if (iBomberDie < 20)
                {
                    bomber.Die(iBomberDie % 4 + 2);
                    iBomberDie++;
                    fBoom.KeyPreview = false;
                    feelTimer.Stop();
                }
                else
                {
                    Heart--;
                    if (Heart < 0) Heart = 3;
                    iBomberDie = 0;
                    checkCollisionBomber = true;
                    timer.Stop();
                    timer.Dispose();
                    bomber.BomberDown(4);
                    fBoom.KeyPreview = true;
                    feelTimer.Start();
                    fBoom.Invalidate(new Rectangle(bomber.Position.X - 13, bomber.Position.Y - 36, 100, 100));
                    bomber.Position = newPosition;
                }
            }
            fBoom.Invalidate(new Rectangle(bomber.Position.X-13, bomber.Position.Y -36, 100, 100));
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            Barrier barrier = timer.Tag as Barrier;
            if (i<5)
            {
                barrier.Tree2(i++);
            }
            else
            {
                barrier.Tree2(4);
                i = 0;
                timer.Stop();
            }
        }

        private void CoinTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            Item item = timer.Tag as Item;
            if (iCoinTimer <= 7)
            {
                item.Coin(iCoinTimer++);
                boom.Invalidate(new Rectangle(item.Position.X,item.Position.Y,100, 100));
            }
            else
            {
                if(IsExistsCoin(item))
                iCoinTimer = 0;
                else
                {
                    timer.Stop();
                    timer.Dispose();
                }
            }
        }
        #endregion

    }
}
