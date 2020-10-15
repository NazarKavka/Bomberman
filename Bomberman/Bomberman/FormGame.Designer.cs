namespace Bomberman
{
    partial class FormGame
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаГраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проГруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelScore = new System.Windows.Forms.Label();
            this.timerFireClear = new System.Windows.Forms.Timer(this.components);
            this.timerGameOver = new System.Windows.Forms.Timer(this.components);
            this.рівеньСкладностіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.простийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.середнійToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.важкийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.довідкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаГраToolStripMenuItem,
            this.рівеньСкладностіToolStripMenuItem,
            this.toolStripSeparator1,
            this.вихідToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.fileToolStripMenuItem.Text = "Меню";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // новаГраToolStripMenuItem
            // 
            this.новаГраToolStripMenuItem.Name = "новаГраToolStripMenuItem";
            this.новаГраToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.новаГраToolStripMenuItem.Text = "Нова гра";
            this.новаГраToolStripMenuItem.Click += new System.EventHandler(this.новаГраToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // довідкаToolStripMenuItem
            // 
            this.довідкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проГруToolStripMenuItem});
            this.довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            this.довідкаToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.довідкаToolStripMenuItem.Text = "Довідка";
            // 
            // проГруToolStripMenuItem
            // 
            this.проГруToolStripMenuItem.Name = "проГруToolStripMenuItem";
            this.проГруToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.проГруToolStripMenuItem.Text = "Про гру";
            this.проГруToolStripMenuItem.Click += new System.EventHandler(this.проГруToolStripMenuItem_Click_1);
            // 
            // panelGame
            // 
            this.panelGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGame.Location = new System.Drawing.Point(0, 56);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1052, 805);
            this.panelGame.TabIndex = 1;
            // 
            // labelScore
            // 
            this.labelScore.Location = new System.Drawing.Point(0, 29);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(1212, 27);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "New game";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelScore.Click += new System.EventHandler(this.label1_Click);
            // 
            // timerFireClear
            // 
            this.timerFireClear.Interval = 1000;
            this.timerFireClear.Tick += new System.EventHandler(this.timerFireClear_Tick);
            // 
            // timerGameOver
            // 
            this.timerGameOver.Tick += new System.EventHandler(this.timerGameOver_Tick);
            // 
            // рівеньСкладностіToolStripMenuItem
            // 
            this.рівеньСкладностіToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.простийToolStripMenuItem,
            this.середнійToolStripMenuItem,
            this.важкийToolStripMenuItem});
            this.рівеньСкладностіToolStripMenuItem.Name = "рівеньСкладностіToolStripMenuItem";
            this.рівеньСкладностіToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.рівеньСкладностіToolStripMenuItem.Text = "Рівень складності";
            // 
            // простийToolStripMenuItem
            // 
            this.простийToolStripMenuItem.Name = "простийToolStripMenuItem";
            this.простийToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.простийToolStripMenuItem.Text = "Простий";
            this.простийToolStripMenuItem.Click += new System.EventHandler(this.простийToolStripMenuItem_Click);
            // 
            // середнійToolStripMenuItem
            // 
            this.середнійToolStripMenuItem.Name = "середнійToolStripMenuItem";
            this.середнійToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.середнійToolStripMenuItem.Text = "Середній";
            this.середнійToolStripMenuItem.Click += new System.EventHandler(this.середнійToolStripMenuItem_Click);
            // 
            // важкийToolStripMenuItem
            // 
            this.важкийToolStripMenuItem.Name = "важкийToolStripMenuItem";
            this.важкийToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.важкийToolStripMenuItem.Text = "Важкий";
            this.важкийToolStripMenuItem.Click += new System.EventHandler(this.важкийToolStripMenuItem_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1034, 778);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bomberman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаГраToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.ToolStripMenuItem довідкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проГруToolStripMenuItem;
        private System.Windows.Forms.Timer timerFireClear;
        private System.Windows.Forms.Timer timerGameOver;
        private System.Windows.Forms.ToolStripMenuItem рівеньСкладностіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem простийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem середнійToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem важкийToolStripMenuItem;
    }
}

