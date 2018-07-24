using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace game3
{
    public partial class fMain : Form
    {
        #region Fields
        Timer GCTimer;
        Sound backgroundMusic;
        Sound gameMusic;
        Timer systemTimer;
        Bomber bomber;
        Map map;
        List<Bomb> bombs;
        int amountBomb;
        Timer feelTimer;
        Boss boss;
        #endregion
        #region Methods
        public fMain()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            GCTimer = new Timer
            {
                Enabled = true,
                Interval = 10000
            };
            GCTimer.Start();
            GCTimer.Tick += GCTimer_Tick;

            backgroundMusic = new Sound();
            backgroundMusic.Menu();
            backgroundMusic.Repeat();
            backgroundMusic.SetVolumn(75);

            gameMusic = new Sound();

            map = new Map();
            
            bombs = new List<Bomb>();
            
            boss = new Boss(Management.Instance.ConvertToPoint(23));

            lblHightScore.Visible = Score1.Visible = Score3.Visible = Score2.Visible =false;
            pictureBox.Visible = false;
            pictureBox.SendToBack();
            this.BackgroundImage = game3.Properties.Resources.background_play;

            LoadMap();
        }
        public void LoadMap()
        {
            systemTimer = new Timer
            {
                Enabled = true,
                Interval = 10
            };
            systemTimer.Start();
            systemTimer.Tick += SystemTimer_Tick;

            feelTimer = new Timer
            {
                Enabled = true,
                Interval = 70
            };
            feelTimer.Start();
            feelTimer.Tick += FeelTimer_Tick;

            amountBomb =3;

            Management.Instance.Heart = 3;
            Management.Instance.Score = 0;

            map.CreateMap1();
            bomber = new Bomber(Management.Instance.ConvertToPoint(58))
            {
                IsDraw = true
            };

            this.Refresh();
        }
        #region HeartAndScore
        bool checkInitHeart = true;
        bool checkAddScore = true;
        public void GetHeartAndScore()
        {
            if (checkInitHeart)
            {
                Management.Instance.Heart = 3;
                checkInitHeart = false;
            }
            int heart = Management.Instance.Heart;
            switch (heart)
            {
                case 0:
                    {
                        heart1.Visible = heart2.Visible = heart3.Visible = false;
                        //if (checkAddScore)
                        //{
                        //    backgroundMusic.Pause();
                        //    ClearData();
                        //    LoadMap();
                        //    checkAddScore = !checkAddScore;
                        //    fAddScore fAddScore = new fAddScore(int.Parse(Score.Text) + Management.Instance.Heart * 1000);
                        //    fAddScore.ShowDialog();
                        //    this.Show();

                        //    backgroundMusic.Menu();
                        //    this.KeyPreview = false;
                        //    btnPlay.Iconimage = game3.Properties.Resources.play;
                        //    btnPlay.Text = "     Play";
                        //    checkPlay = !checkPlay;
                        //}
                        break;
                    }
                case 1:
                    {
                        heart1.Visible = true;
                        heart2.Visible = heart3.Visible = false;
                        break;
                    }
                case 2:
                    {
                        heart1.Visible = heart2.Visible = true;
                        heart3.Visible = false;
                        break;
                    }
                case 3:
                    {
                        heart1.Visible = heart2.Visible = heart3.Visible = true;
                        break;
                    }
            }
            Score.Text = Management.Instance.Score.ToString();
        }
        public void AddScore()
        {
            if (map.ListMiniBoss.Count == 0 || Management.Instance.Heart == 0)
            {
                if (checkAddScore)
                {
                    backgroundMusic.Pause();
                    checkAddScore = !checkAddScore;
                    StopMiniBoss();
                    Random random = new Random();
                    int bonus = random.Next(1000, 2000);
                    fAddScore fAddScore = new fAddScore(int.Parse(Score.Text) + Management.Instance.Heart * 1000 + bonus);
                    fAddScore.ShowDialog();
                    ClearData();
                    LoadMap();
                    
                    checkAddScore = !checkAddScore;
                    backgroundMusic.Menu();
                    this.KeyPreview = false;
                    btnPlay.Iconimage = game3.Properties.Resources.play;
                    btnPlay.Text = "     Play";
                    checkPlay = !checkPlay;
                }
            }
        }
        public void LoadHightScore()
        {
            Score1.Text = game3.Properties.Settings.Default.Name1 + ": " + game3.Properties.Settings.Default.Score1.ToString();
            Score2.Text = game3.Properties.Settings.Default.Name2 + ": " + game3.Properties.Settings.Default.Score2.ToString();
            Score3.Text = game3.Properties.Settings.Default.Name3 + ": " + game3.Properties.Settings.Default.Score3.ToString();
        }
        #endregion
        public void ClearData()
        {
            map.ListBackground.Clear();
            map.ListBox.Clear();
            map.ListBarrier.Clear();
            map.ListMiniBoss.Clear();
            map.ListItem.Clear();
            bombs.Clear();
            bomber.IsDraw = false;

            feelTimer.Stop();
            systemTimer.Stop();
            //feelTimer.Dispose();
            //systemTimer.Dispose();
            GC.Collect();
        }
        public void StopMiniBoss()
        {
            foreach (MiniBoss item in map.ListMiniBoss.ToList())
            {
                item.IsMove = false;
            }
        }
        public void PlayMiniBoss()
        {
            foreach (MiniBoss item in map.ListMiniBoss.ToList())
            {
                item.IsMove = true;
            }
        }
        #region Draw map
        public void DrawTarget1(Graphics graphics, object[] arrayComponent)
        {
            int indexBomber = Management.Instance.ConvertToIndex(bomber.Position);
            for (int i = 0; i < indexBomber; i++)
            {
                Object component = arrayComponent[i] as Object;
                if (component != null)
                    component.Draw(graphics);
            }
            bomber.Draw(graphics);
            if (bombs != null)
                foreach (Bomb item in bombs)
                {
                    if (item.Image != null)
                        item.Draw(graphics);
                }
            if (bombs.Count > 0)
                foreach (Bomb item in bombs)
                {
                    if (checkBombBang[item.Index])
                        item.DrawBombBang(graphics);
                }
            for (int i = indexBomber; i < arrayComponent.Count(); i++)
            {
                Object component = arrayComponent[i] as Object;
                if (component != null)
                    component.Draw(graphics);
            }
            
        }
        public void DrawTarget2(Graphics graphics,object[] arrayComponent)
        {
            //typeTarget : 0-Bomber, 1-Boss , 2-MiniBoss
            int indexBomber = Management.Instance.ConvertToIndex(bomber.Position);
            int indexBoss = Management.Instance.ConvertToIndex(boss.Position);
            int indexMin,indexMax;
            bool checkIndex = false;
            if(indexBomber<indexBoss)
            {
                checkIndex = true;
                indexMin = indexBomber;
                indexMax = indexBoss;
            }
            else
            {
                checkIndex = false;
                indexMin = indexBoss;
                indexMax = indexBomber;
            }
            for (int i = 0; i <indexMin; i++)
            {
                Object component = arrayComponent[i] as Object;
                if (component != null)
                {
                    component.Draw(graphics);
                }
            }
            if (checkIndex)
                bomber.Draw(graphics);
            else
                boss.Draw(graphics);

            if (bombs != null)
                foreach (Bomb item in bombs)
                {
                    if (item.Image != null)
                        item.Draw(graphics);
                }
            if (bombs.Count > 0)
                foreach (Bomb item in bombs)
                {
                    if (checkBombBang[item.Index])
                        item.DrawBombBang(graphics);
                }

            for (int i = indexMin; i < indexMax; i++)
            {
                if (arrayComponent[i] is Object component)
                    component.Draw(graphics);
            }
            if (checkIndex)
                boss.Draw(graphics);
            else
                bomber.Draw(graphics);
            for (int i =indexMax; i < arrayComponent.Count(); i++)
            {
                if (arrayComponent[i] is Object component)
                    component.Draw(graphics);
            }
            
        }
        public void DrawMap1(Graphics graphics)
        {
            object[] arrayComponent = new object[63];
            #region map
            if (map.ListBox != null)
                foreach (Box item in map.ListBox)
                {
                    arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X, item.Position.Y + 4))] = item;
                }
            if (map.ListBarrier != null)
                foreach (Barrier item in map.ListBarrier)
                {
                    if (item.Image.Tag.ToString() == "barrier_1")
                        arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X, item.Position.Y + 7))] = item;
                    
                    if (item.Image.Tag.ToString() == "barrier_3" || item.Image.Tag.ToString() == "barrier_2")
                        arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X, item.Position.Y + 23))] = item;

                    if (item.Image.Tag.ToString() == "tree_4")
                        arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X-1, item.Position.Y + 15))] = item;

                    if (item.Image.Tag.ToString() == "tree_5")
                        arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X-1, item.Position.Y + 19))] = item;
            //khi vẽ phải cập nhật lại position theo control
                }
            #endregion

            #region draw
            DrawTarget1(graphics, arrayComponent);
            #endregion
        }
        public void DrawMap2(Graphics graphics)
        {
            object[] arrayComponent = new object[63];
            #region map
            if (map.ListBox != null)
                foreach (Box item in map.ListBox)
                {
                    arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X, item.Position.Y + 4))] = item;
                }

            if (map.ListBarrier != null)
                foreach (Barrier item in map.ListBarrier)
                {
                    // Đối vs Barier là House
                    if (item.Image.Tag.ToString() == "house_1" || item.Image.Tag.ToString() == "house_2" || item.Image.Tag.ToString() == "house_3")
                        arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X, item.Position.Y + 17))] = item;
                    //Barrier là tree1
                    if (item.Image.Tag.ToString() == "tree_1")
                        arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X, item.Position.Y + 30))] = item;
                    if (item.Image.Tag.ToString() == "tree_25" || item.Image.Tag.ToString() == "tree_21" || item.Image.Tag.ToString() == "tree_23" || item.Image.Tag.ToString() == "tree_24" || item.Image.Tag.ToString() == "tree_22")
                        arrayComponent[Management.Instance.ConvertToIndex(new Point(item.Position.X + 4, item.Position.Y + 25))] = item;
                    //khi vẽ phải cập nhật lại position theo control
                }
            #endregion

            #region draw
            DrawTarget2(graphics, arrayComponent);
            #endregion
        }
        #endregion
        #endregion
        #region KeyDown
        private void fBoom_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.S:
                    {
                        if(checkMove)
                        {
                            Timer downTimer = new Timer();
                            downTimer.Enabled = true;
                            downTimer.Interval =20;
                            downTimer.Start();
                            downTimer.Tick += DownTimer_Tick;
                            iFeel = -20;
                            feelTimer.Stop();
                        }
                        break;
                    }
                case Keys.W:
                    {
                        if (checkMove)
                        {
                            Timer upTimer = new Timer();
                            upTimer.Enabled = true;
                            upTimer.Interval =20;
                            upTimer.Start();
                            upTimer.Tick += UpTimer_Tick;
                            iFeel = -20;
                            feelTimer.Stop();
                        }
                        break;
                    }
                case Keys.D:
                    {
                        if (checkMove)
                        {
                            Timer rightTimer = new Timer();
                            rightTimer.Enabled = true;
                            rightTimer.Interval =20;
                            rightTimer.Start();
                            rightTimer.Tick += RightTimer_Tick;
                            iFeel = -20;
                            feelTimer.Stop();
                        }
                        break;
                    }
                case Keys.A:
                    {
                        if (checkMove)
                        {
                            Timer leftTimer = new Timer();
                            leftTimer.Enabled = true;
                            leftTimer.Interval = 20;
                            leftTimer.Start();
                            leftTimer.Tick += LeftTimer_Tick;
                            iFeel = -20;
                            feelTimer.Stop();
                        }
                        break;
                    }
                case Keys.Space:
                    {
                        if (bombs.Count < amountBomb)
                        {
                            if (index < amountBomb)
                            {
                                bool check = false;
                                foreach (Bomb item in bombs)
                                {
                                    if(item.Position==bomber.Position)
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                                if (!check)
                                {
                                    if (bomber.Position.X % 40 == 0 && (bomber.Position.Y - 32) % 40 == 0)
                                    {
                                        gameMusic.NewBomb();

                                        Bomb bomb = new Bomb(bomber.Position);
                                        bomb.IsDraw = true;
                                        bomb.IsBang = false;
                                        bomb.Index = index;
                                        bombs.Add(bomb);

                                        Timer bombTimer = new Timer();
                                        bombTimer.Tag = bomb;
                                        bombTimer.Enabled = true;
                                        bombTimer.Tag = bomb;
                                        bombTimer.Interval = 100;
                                        bombTimer.Start();
                                        bombTimer.Tick += BombTimer_Tick;
                                        if (index < amountBomb - 1)
                                            index++;
                                        else
                                            index = 0;
                                    }
                                }
                                feelTimer.Stop();
                            }   
                        }
                        break;
                    }
            }
        }
        #endregion
        #region Bomb bang
        int index =0;
        int[] iBomb = {0,0,0,0};
        bool[] checkBombBang = { false, false, false, false };
        private void BombTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            Bomb bomb = timer.Tag as Bomb;
            if (iBomb[bomb.Index] < 30)
                {
                    bomb.FirstBomb(iBomb[bomb.Index] % 4);
                if (iBomb[bomb.Index]==28)
                    bomb.IsBang = true;
                iBomb[bomb.Index]++;
                }
                else
                {
                //bomb.IsBang = true;
                checkBombBang[bomb.Index] = true;
                Timer bombBangTimer = new Timer
                {
                    Enabled = true,
                    Tag = timer.Tag,
                    Interval = 100
                };
                bombBangTimer.Start();
                bombBangTimer.Tick += BombBangTimer_Tick;

                iBomb[bomb.Index] = 0;
                timer.Stop();
                timer.Dispose();
            }
            this.Invalidate(new Rectangle(bomb.Position.X - 40, bomb.Position.Y - 5 - 40,200, 200));
        }
        private void BombBangTimer_Tick(object sender, EventArgs e)
        {
            gameMusic.Bomb_Bang();

            Timer timer = sender as Timer;
            Bomb bomb = timer.Tag as Bomb;
            Management.Instance.DestroyObject(bomb, map,this);

            checkBombBang[bomb.Index] =false;
            this.Invalidate(new Rectangle(bomb.Position.X - 40, bomb.Position.Y - 5 - 40,200, 200));
            bombs.Remove(bomb);
            bomb.Image.Dispose();
            timer.Stop();
            timer.Dispose();
        }
        #endregion
        #region Animation
        bool checkMove =true;
        private void LeftTimer_Tick(object sender, EventArgs e)
        {
            if (iMove < 5)
            {
                bomber.BomberLeft(iMove++);
                if (bomber.IsLeftLimit())
                {
                    if(bomber.Position.X%40==0&&(bomber.Position.Y-32)%40==0)
                    {
                        //Management.Instance.CollisionTree_2(new Point(bomber.Position.X - 40, bomber.Position.Y), map,bomber,bombs);
                        if (!Management.Instance.IsCollision(new Point(bomber.Position.X-40,bomber.Position.Y), map))
                            bomber.Position= new Point(bomber.Position.X - 8, bomber.Position.Y);
                    }
                    else bomber.Position = new Point(bomber.Position.X - 8, bomber.Position.Y);
                }
                this.Invalidate(new Rectangle(bomber.Position.X-8, bomber.Position.Y-27,100, 100));
                checkMove = false;
            }
            else
            {
                feelTimer.Start();
                checkMove = true;
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
                bomber.BomberRight(iMove++);
                if (bomber.IsRightLimit())
                {
                    if (bomber.Position.X % 40 == 0 && (bomber.Position.Y - 32) % 40 == 0)
                    {
                        //Management.Instance.CollisionTree_2(new Point(bomber.Position.X + 40, bomber.Position.Y), map, bomber,bombs);
                        this.Invalidate(new Rectangle(new Point(bomber.Position.X - 8, bomber.Position.Y - 27), new Size(100, 100)));
                        if (!Management.Instance.IsCollision(new Point(bomber.Position.X + 40, bomber.Position.Y), map))
                            bomber.Position = new Point(bomber.Position.X + 8, bomber.Position.Y);
                    }
                    else bomber.Position = new Point(bomber.Position.X + 8, bomber.Position.Y);
                }
                this.Invalidate(new Rectangle(bomber.Position.X-13, bomber.Position.Y - 27, 100, 100));
                checkMove = false;
            }
            else
            {
                feelTimer.Start();
                checkMove = true;
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
        }

        int iMove = 0;
        private void UpTimer_Tick(object sender, EventArgs e)
        {
            if (iMove < 5)
            {
                bomber.BomberUp(iMove++);
                if (bomber.IsLowerLimit())
                {
                    if (bomber.Position.X % 40 == 0 && (bomber.Position.Y - 32) % 40 == 0)
                    {
                        //Management.Instance.CollisionTree_2(new Point(bomber.Position.X, bomber.Position.Y-40), map, bomber,bombs);
                        if (!Management.Instance.IsCollision(new Point(bomber.Position.X , bomber.Position.Y-40), map))
                            bomber.Position = new Point(bomber.Position.X, bomber.Position.Y-8);
                    }
                    else bomber.Position = new Point(bomber.Position.X, bomber.Position.Y-8);
                }
                this.Invalidate(new Rectangle(bomber.Position.X-13, bomber.Position.Y-27,100, 100));
                checkMove = false;
            }
            else
            {
                feelTimer.Start();
                checkMove = true;
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
        }

        private void DownTimer_Tick(object sender, EventArgs e)
        {
            if(iMove < 5)
            {
                bomber.BomberDown(iMove++);
                if (bomber.IsUpperLimit())
                {
                    if (bomber.Position.X % 40 == 0 && (bomber.Position.Y - 32) % 40 == 0)
                    {
                        //Management.Instance.CollisionTree_2(new Point(bomber.Position.X, bomber.Position.Y + 40), map, bomber,bombs);
                        if (!Management.Instance.IsCollision(new Point(bomber.Position.X, bomber.Position.Y + 40), map))
                            bomber.Position = new Point(bomber.Position.X, bomber.Position.Y + 8);
                    }
                    else bomber.Position = new Point(bomber.Position.X, bomber.Position.Y + 8);
   
                }
                this.Invalidate(new Rectangle(bomber.Position.X-13, bomber.Position.Y -36, 100, 100));
                checkMove = false;
            }
            else
            {
                feelTimer.Start();
                checkMove = true;
                iMove = 0;
                Timer timer = sender as Timer;
                timer.Stop();
                timer.Dispose();
            }
        }
        #endregion
        #region Events
        #region Collect
        private void GCTimer_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }
        #endregion
        #region SystemTimer
        private void SystemTimer_Tick(object sender, EventArgs e)
        {
            Management.Instance.CollisionBomber(Management.Instance.ConvertToPoint(58), bomber.Position, bombs, bomber, this, feelTimer, map.ListMiniBoss, map);
            GetHeartAndScore();
            AddScore();
        }
        #endregion
        #region Paint
        private void fBoom_Paint(object sender, PaintEventArgs e)
        {
            #region map
            if (map.ListBackground != null)
                foreach (Background item in map.ListBackground)
                {
                    item.Draw(e.Graphics);
                }
            #endregion
            if (map.ListItem != null)
            {
                foreach (Item item in map.ListItem)
                {
                    item.Draw(e.Graphics);
                }
            }
            //boss.Draw(e.Graphics);
            foreach (MiniBoss item in map.ListMiniBoss)
            {
                item.Draw(e.Graphics);
            }
            DrawMap1(e.Graphics);
            //DrawMap2(e.Graphics);

        }
        #endregion
        #region Feel
        int iFeel = -15;
        private void FeelTimer_Tick(object sender, EventArgs e)
        {
            if (iFeel < 10)
            {
                iFeel++;
            }
            else
            {
                if (iFeel < 20)
                {
                    bomber.Feel(iFeel % 3);
                    iFeel++;
                }
                else
                {
                    iFeel = -15;
                }
            }
            this.Invalidate(new Rectangle(bomber.Position.X - 8, bomber.Position.Y - 27, 100, 100));

        }
        #endregion
        #region Button_Click
        bool checkPlay = false;
        bool checkBackgroundMusic = true;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            lblHightScore.Visible = Score1.Visible = Score3.Visible = Score2.Visible =false;
            pictureBox.Visible = false;
            pictureBox.SendToBack();
            this.BackgroundImage = game3.Properties.Resources.background_play;
            if (!checkPlay)
            {
                backgroundMusic.PlayGame();

                PlayMiniBoss();
                this.KeyPreview = true;
                btnPlay.Iconimage = game3.Properties.Resources.pause;
                btnPlay.Text = "     Pause";
                checkPlay = !checkPlay;

                //boss.BossMove(map, this);

                foreach (MiniBoss item in map.ListMiniBoss)
                {
                    item.MiniBossMove(map, this);
                }

            }
            else
            {
                if (!checkBackgroundMusic)
                {
                    backgroundMusic.Menu();
                    checkBackgroundMusic = !checkBackgroundMusic;
                }

                StopMiniBoss();
                this.KeyPreview =false;
                btnPlay.Iconimage = game3.Properties.Resources.play;
                btnPlay.Text = "     Play";
                checkPlay = !checkPlay;
            }
            checkBackgroundMusic = false;
        }
        private void btnOption_Click(object sender, EventArgs e)
        {
            if (!checkBackgroundMusic)
            {
                backgroundMusic.Menu();
                checkBackgroundMusic = !checkBackgroundMusic;
            }

            pictureBox.BringToFront();
            pictureBox.Visible = true;
            pictureBox.Image = game3.Properties.Resources.background_option;
            this.KeyPreview = false;

            btnPlay.Iconimage = game3.Properties.Resources.play;
            btnPlay.Text = "     Play";
            checkPlay = !checkPlay;

            lblHightScore.Visible = Score1.Visible = Score3.Visible = Score2.Visible = false;
        }

        private void btnHightScore_Click(object sender, EventArgs e)
        {
            if (!checkBackgroundMusic)
            {
                backgroundMusic.Menu();
                checkBackgroundMusic = !checkBackgroundMusic;
            }

            LoadHightScore();

            pictureBox.BringToFront();
            pictureBox.Visible = true;
            pictureBox.Image = game3.Properties.Resources.background_score;
            this.KeyPreview = false;

            btnPlay.Iconimage = game3.Properties.Resources.play;
            btnPlay.Text = "     Play";
            checkPlay = !checkPlay;

            lblHightScore.Visible = Score1.Visible = Score3.Visible = Score2.Visible = true;
            lblHightScore.BringToFront();
            Score1.BringToFront();
            Score2.BringToFront();
            Score3.BringToFront();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #endregion
    }
}
