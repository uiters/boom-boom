namespace game3
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnExit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHightScore = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOption = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPlay = new Bunifu.Framework.UI.BunifuFlatButton();
            this.heart1 = new System.Windows.Forms.PictureBox();
            this.heart2 = new System.Windows.Forms.PictureBox();
            this.heart3 = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblHightScore = new System.Windows.Forms.Label();
            this.Score1 = new System.Windows.Forms.Label();
            this.Score2 = new System.Windows.Forms.Label();
            this.Score3 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse5 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelHeader;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Tomato;
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(603, 32);
            this.panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(583, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(14, 14);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 21;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Boom Boom";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Gainsboro;
            this.panelRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelRight.BackgroundImage")));
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.btnExit);
            this.panelRight.Controls.Add(this.btnHightScore);
            this.panelRight.Controls.Add(this.btnOption);
            this.panelRight.Controls.Add(this.btnPlay);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(440, 32);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(163, 356);
            this.panelRight.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Activecolor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.BorderRadius = 0;
            this.btnExit.ButtonText = "     Exit";
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DisabledColor = System.Drawing.Color.Silver;
            this.btnExit.Iconcolor = System.Drawing.Color.Transparent;
            this.btnExit.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnExit.Iconimage")));
            this.btnExit.Iconimage_right = null;
            this.btnExit.Iconimage_right_Selected = null;
            this.btnExit.Iconimage_Selected = null;
            this.btnExit.IconMarginLeft = 0;
            this.btnExit.IconMarginRight = 0;
            this.btnExit.IconRightVisible = true;
            this.btnExit.IconRightZoom = 0D;
            this.btnExit.IconVisible = true;
            this.btnExit.IconZoom = 32D;
            this.btnExit.IsTab = false;
            this.btnExit.Location = new System.Drawing.Point(8, 247);
            this.btnExit.Name = "btnExit";
            this.btnExit.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.OnHovercolor = System.Drawing.Color.LightGray;
            this.btnExit.OnHoverTextColor = System.Drawing.Color.Tomato;
            this.btnExit.selected = false;
            this.btnExit.Size = new System.Drawing.Size(147, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "     Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Textcolor = System.Drawing.Color.Tomato;
            this.btnExit.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHightScore
            // 
            this.btnHightScore.Activecolor = System.Drawing.Color.WhiteSmoke;
            this.btnHightScore.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHightScore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHightScore.BorderRadius = 0;
            this.btnHightScore.ButtonText = "     Hight Score";
            this.btnHightScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHightScore.DisabledColor = System.Drawing.Color.Silver;
            this.btnHightScore.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHightScore.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnHightScore.Iconimage")));
            this.btnHightScore.Iconimage_right = null;
            this.btnHightScore.Iconimage_right_Selected = null;
            this.btnHightScore.Iconimage_Selected = null;
            this.btnHightScore.IconMarginLeft = 0;
            this.btnHightScore.IconMarginRight = 0;
            this.btnHightScore.IconRightVisible = true;
            this.btnHightScore.IconRightZoom = 0D;
            this.btnHightScore.IconVisible = true;
            this.btnHightScore.IconZoom = 32D;
            this.btnHightScore.IsTab = false;
            this.btnHightScore.Location = new System.Drawing.Point(8, 188);
            this.btnHightScore.Name = "btnHightScore";
            this.btnHightScore.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnHightScore.OnHovercolor = System.Drawing.Color.LightGray;
            this.btnHightScore.OnHoverTextColor = System.Drawing.Color.Tomato;
            this.btnHightScore.selected = false;
            this.btnHightScore.Size = new System.Drawing.Size(147, 40);
            this.btnHightScore.TabIndex = 2;
            this.btnHightScore.Text = "     Hight Score";
            this.btnHightScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHightScore.Textcolor = System.Drawing.Color.Tomato;
            this.btnHightScore.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHightScore.Click += new System.EventHandler(this.btnHightScore_Click);
            // 
            // btnOption
            // 
            this.btnOption.Activecolor = System.Drawing.Color.WhiteSmoke;
            this.btnOption.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOption.BorderRadius = 0;
            this.btnOption.ButtonText = "     Option";
            this.btnOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOption.DisabledColor = System.Drawing.Color.Silver;
            this.btnOption.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOption.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOption.Iconimage")));
            this.btnOption.Iconimage_right = null;
            this.btnOption.Iconimage_right_Selected = null;
            this.btnOption.Iconimage_Selected = null;
            this.btnOption.IconMarginLeft = 0;
            this.btnOption.IconMarginRight = 0;
            this.btnOption.IconRightVisible = true;
            this.btnOption.IconRightZoom = 0D;
            this.btnOption.IconVisible = true;
            this.btnOption.IconZoom = 32D;
            this.btnOption.IsTab = false;
            this.btnOption.Location = new System.Drawing.Point(8, 129);
            this.btnOption.Name = "btnOption";
            this.btnOption.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnOption.OnHovercolor = System.Drawing.Color.LightGray;
            this.btnOption.OnHoverTextColor = System.Drawing.Color.Tomato;
            this.btnOption.selected = false;
            this.btnOption.Size = new System.Drawing.Size(147, 40);
            this.btnOption.TabIndex = 1;
            this.btnOption.Text = "     Option";
            this.btnOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOption.Textcolor = System.Drawing.Color.Tomato;
            this.btnOption.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Activecolor = System.Drawing.Color.WhiteSmoke;
            this.btnPlay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlay.BorderRadius = 0;
            this.btnPlay.ButtonText = "     Play";
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.DisabledColor = System.Drawing.Color.Silver;
            this.btnPlay.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPlay.Iconimage = global::game3.Properties.Resources.play;
            this.btnPlay.Iconimage_right = null;
            this.btnPlay.Iconimage_right_Selected = null;
            this.btnPlay.Iconimage_Selected = null;
            this.btnPlay.IconMarginLeft = 0;
            this.btnPlay.IconMarginRight = 0;
            this.btnPlay.IconRightVisible = true;
            this.btnPlay.IconRightZoom = 0D;
            this.btnPlay.IconVisible = true;
            this.btnPlay.IconZoom = 32D;
            this.btnPlay.IsTab = false;
            this.btnPlay.Location = new System.Drawing.Point(8, 68);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnPlay.OnHovercolor = System.Drawing.Color.LightGray;
            this.btnPlay.OnHoverTextColor = System.Drawing.Color.Tomato;
            this.btnPlay.selected = false;
            this.btnPlay.Size = new System.Drawing.Size(147, 40);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "     Play";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Textcolor = System.Drawing.Color.Tomato;
            this.btnPlay.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // heart1
            // 
            this.heart1.BackColor = System.Drawing.Color.Transparent;
            this.heart1.Image = ((System.Drawing.Image)(resources.GetObject("heart1.Image")));
            this.heart1.Location = new System.Drawing.Point(41, 358);
            this.heart1.Name = "heart1";
            this.heart1.Size = new System.Drawing.Size(24, 24);
            this.heart1.TabIndex = 2;
            this.heart1.TabStop = false;
            // 
            // heart2
            // 
            this.heart2.BackColor = System.Drawing.Color.Transparent;
            this.heart2.Image = ((System.Drawing.Image)(resources.GetObject("heart2.Image")));
            this.heart2.Location = new System.Drawing.Point(68, 358);
            this.heart2.Name = "heart2";
            this.heart2.Size = new System.Drawing.Size(24, 24);
            this.heart2.TabIndex = 3;
            this.heart2.TabStop = false;
            // 
            // heart3
            // 
            this.heart3.BackColor = System.Drawing.Color.Transparent;
            this.heart3.Image = ((System.Drawing.Image)(resources.GetObject("heart3.Image")));
            this.heart3.Location = new System.Drawing.Point(95, 358);
            this.heart3.Name = "heart3";
            this.heart3.Size = new System.Drawing.Size(24, 24);
            this.heart3.TabIndex = 4;
            this.heart3.TabStop = false;
            // 
            // Score
            // 
            this.Score.BackColor = System.Drawing.Color.Transparent;
            this.Score.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Score.Location = new System.Drawing.Point(126, 357);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(85, 23);
            this.Score.TabIndex = 5;
            this.Score.Text = "0";
            this.Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(603, 388);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // lblHightScore
            // 
            this.lblHightScore.AutoSize = true;
            this.lblHightScore.BackColor = System.Drawing.Color.White;
            this.lblHightScore.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHightScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblHightScore.Image = ((System.Drawing.Image)(resources.GetObject("lblHightScore.Image")));
            this.lblHightScore.Location = new System.Drawing.Point(141, 68);
            this.lblHightScore.Name = "lblHightScore";
            this.lblHightScore.Size = new System.Drawing.Size(152, 33);
            this.lblHightScore.TabIndex = 7;
            this.lblHightScore.Text = "Hight Score";
            this.lblHightScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Score1
            // 
            this.Score1.BackColor = System.Drawing.Color.White;
            this.Score1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Score1.Image = ((System.Drawing.Image)(resources.GetObject("Score1.Image")));
            this.Score1.Location = new System.Drawing.Point(67, 130);
            this.Score1.Name = "Score1";
            this.Score1.Size = new System.Drawing.Size(310, 23);
            this.Score1.TabIndex = 8;
            this.Score1.Text = "ndc07: 700";
            this.Score1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Score2
            // 
            this.Score2.BackColor = System.Drawing.Color.White;
            this.Score2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Score2.Image = ((System.Drawing.Image)(resources.GetObject("Score2.Image")));
            this.Score2.Location = new System.Drawing.Point(67, 166);
            this.Score2.Name = "Score2";
            this.Score2.Size = new System.Drawing.Size(310, 23);
            this.Score2.TabIndex = 9;
            this.Score2.Text = "No Name: 500";
            this.Score2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Score3
            // 
            this.Score3.BackColor = System.Drawing.Color.White;
            this.Score3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Score3.Image = ((System.Drawing.Image)(resources.GetObject("Score3.Image")));
            this.Score3.Location = new System.Drawing.Point(67, 201);
            this.Score3.Name = "Score3";
            this.Score3.Size = new System.Drawing.Size(310, 23);
            this.Score3.TabIndex = 10;
            this.Score3.Text = "4 chân: 100";
            this.Score3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this.btnPlay;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 10;
            this.bunifuElipse3.TargetControl = this.btnOption;
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 10;
            this.bunifuElipse4.TargetControl = this.btnHightScore;
            // 
            // bunifuElipse5
            // 
            this.bunifuElipse5.ElipseRadius = 10;
            this.bunifuElipse5.TargetControl = this.btnExit;
            // 
            // fBoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::game3.Properties.Resources.background_play;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(603, 388);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblHightScore);
            this.Controls.Add(this.Score1);
            this.Controls.Add(this.Score2);
            this.Controls.Add(this.Score3);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.heart3);
            this.Controls.Add(this.heart2);
            this.Controls.Add(this.heart1);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fBoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boom Boom";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.fBoom_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fBoom_KeyDown);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panelHeader;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRight;
        private Bunifu.Framework.UI.BunifuFlatButton btnPlay;
        private Bunifu.Framework.UI.BunifuFlatButton btnExit;
        private Bunifu.Framework.UI.BunifuFlatButton btnHightScore;
        private Bunifu.Framework.UI.BunifuFlatButton btnOption;
        private System.Windows.Forms.PictureBox heart1;
        private System.Windows.Forms.PictureBox heart2;
        private System.Windows.Forms.PictureBox heart3;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblHightScore;
        private System.Windows.Forms.Label Score1;
        private System.Windows.Forms.Label Score2;
        private System.Windows.Forms.Label Score3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse5;
    }
}

