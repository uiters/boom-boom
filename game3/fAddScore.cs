using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game3
{
    public partial class fAddScore : Form
    {
        #region Fields
        Sound gameMusic;
        #endregion
        #region Struct
        struct HightScore
        {
            public string Name;
            public int Score;
        };
        #endregion
        #region Methods
        public fAddScore(int _score)
        {
            InitializeComponent();
            Score.Text = _score.ToString();
            gameMusic= new Sound();
            gameMusic.Win();
        }
        void SaveHightScore(HightScore hightScore)
        {
            HightScore[] hightScores = new HightScore[4];
            hightScores[0] = hightScore;
            hightScores[1] = new HightScore() { Name = game3.Properties.Settings.Default.Name1, Score = game3.Properties.Settings.Default.Score1 };
            hightScores[2] = new HightScore() { Name = game3.Properties.Settings.Default.Name2, Score = game3.Properties.Settings.Default.Score2 };
            hightScores[3] = new HightScore() { Name = game3.Properties.Settings.Default.Name3, Score = game3.Properties.Settings.Default.Score3 };
            Array.Sort<HightScore>(hightScores, (x, y) => x.Score.CompareTo(y.Score));
            Array.Reverse(hightScores);

            game3.Properties.Settings.Default.Score1 = hightScores[0].Score;
            game3.Properties.Settings.Default.Name1 = hightScores[0].Name;
            game3.Properties.Settings.Default.Score2 = hightScores[1].Score;
            game3.Properties.Settings.Default.Name2 = hightScores[1].Name;
            game3.Properties.Settings.Default.Score3 = hightScores[2].Score;
            game3.Properties.Settings.Default.Name3 = hightScores[2].Name;
            game3.Properties.Settings.Default.Save();
        }
        #endregion
        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //txbYourName.Text = string.Empty;
            //txbYourName.Focus();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name;
            if (txbYourName.Text == string.Empty)
                name = "No Name";
            else name = txbYourName.Text;
            SaveHightScore(new HightScore() { Name = name, Score = int.Parse(Score.Text) });
            MetroFramework.MetroMessageBox.Show(this, "Add success score", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        #endregion
    }
}
