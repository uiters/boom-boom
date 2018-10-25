using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game3
{
    class Barrier:Object
    {
        #region Methods
        public Barrier(Point position) : base(position) { }
        public void Tree1()
        {
            Image =game3.Properties.Resources.tree_1;
            Image.Tag = "tree_1";
        }
        public void Tree2(int index)
        {
            switch(index)
            {
                case 0:
                    {
                        Image =game3.Properties.Resources.tree_21;
                        Image.Tag = "tree_21";
                        break;
                    }
                case 1:
                    {
                        Image =game3.Properties.Resources.tree_22;
                        Image.Tag = "tree_22";
                        break;
                    }
                case 2:
                    {
                        Image =game3.Properties.Resources.tree_23;
                        Image.Tag = "tree_23";
                        break;
                    }
                case 3:
                    {
                        Image =game3.Properties.Resources.tree_24;
                        Image.Tag = "tree_24";
                        break;
                    }
                case 4:
                    {
                        Image =game3.Properties.Resources.tree_25;
                        Image.Tag = "tree_25";
                        break;
                    }
            }
            
        }
        public void Tree3()
        {
            Image =game3.Properties.Resources.tree_4;
            Image.Tag = "tree_4";
        }
        public void Tree4()
        {
            Image = game3.Properties.Resources.tree_5;
            Image.Tag = "tree_5";
        }
        public void House()
        {
            Random random = new Random();
            int index = random.Next(0,2);
            switch(index)
            {
                case 0:
                    {
                        Image = new Bitmap(game3.Properties.Resources.house_3);
                        Image.Tag = "house_3";
                        break;
                    }
                case 1:
                    {
                        Image = new Bitmap(game3.Properties.Resources.house_2);
                        Image.Tag = "house_2";
                        break;
                    }
                case 2:
                    {
                        Image = new Bitmap(game3.Properties.Resources.house_1);
                        Image.Tag = "house_1";
                        break;
                    }
            }
        }
        public void Barrier1()
        {
            Image =game3.Properties.Resources.barrier_1;
            Image.Tag = "barrier_1";
        }
        public void Barrier2()
        {
            Image =game3.Properties.Resources.barrier_2;
            Image.Tag = "barrier_2";
        }
        public void Barrier3()
        {
            Image =game3.Properties.Resources.barrier_3;
            Image.Tag = "barrier_3";
        }
        #endregion
    }
}
