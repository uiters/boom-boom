using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game3
{
    class Map
    {
        #region Fields
        private List<Barrier> listBarrier;
        private List<Background> listBackground;
        private List<Box> listBox;
        private List<MiniBoss> listMiniBoss;
        private List<Item> listItem;
        #endregion
        #region Properties
        internal List<Barrier> ListBarrier
        {
            get
            {
                return listBarrier;
            }

            set
            {
                listBarrier = value;
            }
        }
        internal List<Background> ListBackground
        {
            get
            {
                return listBackground;
            }

            set
            {
                listBackground = value;
            }
        }
        internal List<Box> ListBox
        {
            get
            {
                return listBox;
            }

            set
            {
                listBox = value;
            }
        }
        internal List<MiniBoss> ListMiniBoss { get => listMiniBoss; set => listMiniBoss = value; }
        internal List<Item> ListItem { get => listItem; set => listItem = value; }
        #endregion
        #region Methods
        public Map()
        {
            ListBarrier = new List<Barrier>();
            ListBackground = new List<Background>();
            ListBox = new List<Box>();
            ListMiniBoss = new List<MiniBoss>();
            ListItem = new List<Item>();
        }
        #region Create maps
        public void CreateMap1()
        {
            #region background
            for (int i = 0; i < 63; i++)
            {
                Background background = new Background(Management.Instance.ConvertToPoint(i));
                background.Background2();
                ListBackground.Add(background);
            }
            #endregion
            #region barrier
            int[] indexBarrier1 = { 6, 20, 56, 60 };
            for (int i = 0; i < indexBarrier1.Count(); i++)
            {
                Barrier barrier1 = new Barrier(new Point(Management.Instance.ConvertToPoint(indexBarrier1[i]).X, Management.Instance.ConvertToPoint(indexBarrier1[i]).Y - 7));
                barrier1.Barrier1();
                ListBarrier.Add(barrier1);
            }
            int[] indexBarrier2 = { 0, 36 };
            for (int i = 0; i < indexBarrier2.Count(); i++)
            {
                Barrier barrier2 = new Barrier(new Point(Management.Instance.ConvertToPoint(indexBarrier2[i]).X, Management.Instance.ConvertToPoint(indexBarrier2[i]).Y - 23));
                barrier2.Barrier2();
                ListBarrier.Add(barrier2);
            }
            int[] indexBarrier3 = { 2, 26 };
            for (int i = 0; i < indexBarrier3.Count(); i++)
            {
                Barrier barrier3 = new Barrier(new Point(Management.Instance.ConvertToPoint(indexBarrier3[i]).X, Management.Instance.ConvertToPoint(indexBarrier3[i]).Y - 23));
                barrier3.Barrier3();
                ListBarrier.Add(barrier3);
            }
            #endregion
            #region tree

            int[] indexTree4 = {13,24,31,38,44};
            for (int i = 0; i < indexTree4.Count(); i++)
            {
                Barrier barrier = new Barrier(new Point(Management.Instance.ConvertToPoint(indexTree4[i]).X+1, Management.Instance.ConvertToPoint(indexTree4[i]).Y - 15));
                barrier.Tree3();
                ListBarrier.Add(barrier);
            }
            int[] indexTree5 = {8,18,42,54,49,62 };
            for (int i = 0; i < indexTree5.Count(); i++)
            {
                Barrier barrier = new Barrier(new Point(Management.Instance.ConvertToPoint(indexTree5[i]).X + 1, Management.Instance.ConvertToPoint(indexTree5[i]).Y - 19));
                barrier.Tree4();
                ListBarrier.Add(barrier);
            }
            #endregion
            #region box
            int[] indexBox = {12, 14, 28, 30, 32, 34,48, 50};
            for (int i = 0; i < indexBox.Length; i++)
            {
                Box box = new Box(new Point(Management.Instance.ConvertToPoint(indexBox[i]).X, Management.Instance.ConvertToPoint(indexBox[i]).Y - 4));
                box.Box_4();
                ListBox.Add(box);
            }
            #endregion
            #region miniBoss
            int[] indexMiniBoss = { 4, 10, 16, 22,40, 46, 52 };
            for (int i = 0; i < indexMiniBoss.Length; i++)
            {
                MiniBoss miniBoss = new MiniBoss(new Point(Management.Instance.ConvertToPoint(indexMiniBoss[i]).X, Management.Instance.ConvertToPoint(indexMiniBoss[i]).Y - 4));
                ListMiniBoss.Add(miniBoss);
            }
            #endregion
        }
        public void CreateMap2()
        {
            #region background
            int[] indexBackground = { 0, 1, 2, 6, 7, 8, 9, 10, 11, 15, 17, 19, 20, 24, 25, 26, 27, 28, 29, 33, 34, 35, 36, 37, 38, 42, 43, 45, 47, 51, 52, 53, 54, 55, 56, 60, 61, 62 };
            for (int i = 0; i < indexBackground.Count(); i++)
            {
                Background background = new Background(Management.Instance.ConvertToPoint(indexBackground[i]));
                background.Background1();
                listBackground.Add(background);
            }
            #endregion
            #region house
            int[] indexHouse = { 16, 18, 44, 46 };
            for (int i = 0; i < indexHouse.Count(); i++)
            {
                Barrier barrier = new Barrier(new Point(Management.Instance.ConvertToPoint(indexHouse[i]).X, Management.Instance.ConvertToPoint(indexHouse[i]).Y - 17));
                barrier.House();
                ListBarrier.Add(barrier);
            }
            #endregion
            #region tree
            int[] indexTree1 = { 2, 6, 20, 28, 34, 42, 56, 60 };
            for (int i = 0; i < indexTree1.Count(); i++)
            {
                Barrier barrier = new Barrier(new Point(Management.Instance.ConvertToPoint(indexTree1[i]).X, Management.Instance.ConvertToPoint(indexTree1[i]).Y - 30));
                barrier.Tree1();
                ListBarrier.Add(barrier);
            }
            int[] indexTree2 = { 11, 15, 27, 29, 33, 35, 47, 51 };
            for (int i = 0; i < indexTree2.Count(); i++)
            {
                Barrier barrier = new Barrier(new Point(Management.Instance.ConvertToPoint(indexTree2[i]).X - 4, Management.Instance.ConvertToPoint(indexTree2[i]).Y - 25));
                barrier.Tree2(4);
                ListBarrier.Add(barrier);
            }
            #endregion
            #region street
            int[] street_1 = { 12, 14, 21, 23, 30, 32, 39, 41, 48, 50 };
            for (int i = 0; i < street_1.Count(); i++)
            {
                Background background = new Background(Management.Instance.ConvertToPoint(street_1[i]));
                background.Street_1();
                listBackground.Add(background);
            }
            int[] street_2 = { 3, 4, 5, 57, 58, 59 };
            for (int i = 0; i < street_2.Count(); i++)
            {
                Background background = new Background(Management.Instance.ConvertToPoint(street_2[i]));
                background.Street_2();
                listBackground.Add(background);
            }
            int[] street_3 = { 13, 22, 31, 40, 49 };
            for (int i = 0; i < street_3.Count(); i++)
            {
                Background background = new Background(Management.Instance.ConvertToPoint(street_3[i]));
                background.Street_3();
                listBackground.Add(background);
            }
            #endregion
            #region box
            int[] box1 = { 3, 14, 17, 21, 22, 32, 39, 45, 49, 50, 57 };
            for (int i = 0; i < box1.Count(); i++)
            {
                Box box = new Box(new Point(Management.Instance.ConvertToPoint(box1[i]).X, Management.Instance.ConvertToPoint(box1[i]).Y - 4));
                box.Box_1();
                ListBox.Add(box);
            }
            int[] box2 = { 7, 19, 26, 36, 52, 55 };
            for (int i = 0; i < box2.Count(); i++)
            {
                Box box = new Box(new Point(Management.Instance.ConvertToPoint(box2[i]).X, Management.Instance.ConvertToPoint(box2[i]).Y - 4));
                box.Box_2();
                ListBox.Add(box);
            }
            int[] box3 = { 8, 10, 25, 37, 43, 54 };
            for (int i = 0; i < box3.Count(); i++)
            {
                Box box = new Box(new Point(Management.Instance.ConvertToPoint(box3[i]).X, Management.Instance.ConvertToPoint(box3[i]).Y - 4));
                box.Box_3();
                ListBox.Add(box);
            }
            #endregion
        }
        #endregion
        #endregion
    }
}

