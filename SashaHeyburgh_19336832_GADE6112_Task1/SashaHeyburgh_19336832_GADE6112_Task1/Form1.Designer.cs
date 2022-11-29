namespace SashaHeyburgh_19336832_GADE6112_Task1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblMap = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.txtMinWidth = new System.Windows.Forms.TextBox();
            this.txtMaxWidth = new System.Windows.Forms.TextBox();
            this.lblMinWidth = new System.Windows.Forms.Label();
            this.lblMaxWidth = new System.Windows.Forms.Label();
            this.txtMinHeight = new System.Windows.Forms.TextBox();
            this.txtMaxHeight = new System.Windows.Forms.TextBox();
            this.lblMinHeight = new System.Windows.Forms.Label();
            this.lblMaxHeight = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.btnAttack = new System.Windows.Forms.Button();
            this.richShowAttack = new System.Windows.Forms.RichTextBox();
            listEnemies = new System.Windows.Forms.ListBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            btnShopW1 = new System.Windows.Forms.Button();
            btnShopW2 = new System.Windows.Forms.Button();
            btnShopW3 = new System.Windows.Forms.Button();
            this.lblShop = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblBegin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.ForeColor = System.Drawing.Color.Lime;
            this.lblMap.Location = new System.Drawing.Point(380, 374);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(0, 21);
            this.lblMap.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnUp.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUp.Location = new System.Drawing.Point(109, 398);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(66, 69);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnLeft.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLeft.Location = new System.Drawing.Point(37, 475);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(66, 67);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "←";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnRight.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRight.Location = new System.Drawing.Point(181, 473);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(66, 69);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnDown.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDown.Location = new System.Drawing.Point(109, 548);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(66, 69);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnMap
            // 
            this.btnMap.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnMap.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMap.Location = new System.Drawing.Point(37, 166);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(216, 35);
            this.btnMap.TabIndex = 5;
            this.btnMap.Text = "START - Generate Map";
            this.btnMap.UseVisualStyleBackColor = false;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // txtMinWidth
            // 
            this.txtMinWidth.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtMinWidth.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinWidth.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtMinWidth.Location = new System.Drawing.Point(37, 134);
            this.txtMinWidth.Name = "txtMinWidth";
            this.txtMinWidth.Size = new System.Drawing.Size(104, 26);
            this.txtMinWidth.TabIndex = 6;
            // 
            // txtMaxWidth
            // 
            this.txtMaxWidth.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtMaxWidth.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxWidth.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtMaxWidth.Location = new System.Drawing.Point(147, 134);
            this.txtMaxWidth.Name = "txtMaxWidth";
            this.txtMaxWidth.Size = new System.Drawing.Size(106, 26);
            this.txtMaxWidth.TabIndex = 7;
            // 
            // lblMinWidth
            // 
            this.lblMinWidth.AutoSize = true;
            this.lblMinWidth.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinWidth.Location = new System.Drawing.Point(39, 104);
            this.lblMinWidth.Name = "lblMinWidth";
            this.lblMinWidth.Size = new System.Drawing.Size(96, 25);
            this.lblMinWidth.TabIndex = 8;
            this.lblMinWidth.Text = "Min Width:";
            // 
            // lblMaxWidth
            // 
            this.lblMaxWidth.AutoSize = true;
            this.lblMaxWidth.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxWidth.Location = new System.Drawing.Point(147, 104);
            this.lblMaxWidth.Name = "lblMaxWidth";
            this.lblMaxWidth.Size = new System.Drawing.Size(100, 25);
            this.lblMaxWidth.TabIndex = 9;
            this.lblMaxWidth.Text = "Max Width:";
            // 
            // txtMinHeight
            // 
            this.txtMinHeight.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtMinHeight.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinHeight.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtMinHeight.Location = new System.Drawing.Point(37, 75);
            this.txtMinHeight.Name = "txtMinHeight";
            this.txtMinHeight.Size = new System.Drawing.Size(104, 26);
            this.txtMinHeight.TabIndex = 10;
            // 
            // txtMaxHeight
            // 
            this.txtMaxHeight.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtMaxHeight.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxHeight.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtMaxHeight.Location = new System.Drawing.Point(147, 75);
            this.txtMaxHeight.Name = "txtMaxHeight";
            this.txtMaxHeight.Size = new System.Drawing.Size(106, 26);
            this.txtMaxHeight.TabIndex = 11;
            // 
            // lblMinHeight
            // 
            this.lblMinHeight.AutoSize = true;
            this.lblMinHeight.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinHeight.Location = new System.Drawing.Point(39, 47);
            this.lblMinHeight.Name = "lblMinHeight";
            this.lblMinHeight.Size = new System.Drawing.Size(102, 25);
            this.lblMinHeight.TabIndex = 12;
            this.lblMinHeight.Text = "Min Height:";
            // 
            // lblMaxHeight
            // 
            this.lblMaxHeight.AutoSize = true;
            this.lblMaxHeight.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxHeight.Location = new System.Drawing.Point(147, 47);
            this.lblMaxHeight.Name = "lblMaxHeight";
            this.lblMaxHeight.Size = new System.Drawing.Size(106, 25);
            this.lblMaxHeight.TabIndex = 13;
            this.lblMaxHeight.Text = "Max Height:";
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Bernard MT Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStats.Location = new System.Drawing.Point(685, 241);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(112, 22);
            this.lblStats.TabIndex = 14;
            this.lblStats.Text = "Player\'s Stats:";
            this.lblStats.Click += new System.EventHandler(this.lblStats_Click);
            // 
            // btnAttack
            // 
            this.btnAttack.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnAttack.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttack.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAttack.Location = new System.Drawing.Point(287, 110);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(352, 35);
            this.btnAttack.TabIndex = 15;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = false;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // richShowAttack
            // 
            this.richShowAttack.BackColor = System.Drawing.SystemColors.MenuText;
            this.richShowAttack.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richShowAttack.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.richShowAttack.Location = new System.Drawing.Point(287, 155);
            this.richShowAttack.Name = "richShowAttack";
            this.richShowAttack.Size = new System.Drawing.Size(352, 74);
            this.richShowAttack.TabIndex = 16;
            this.richShowAttack.Text = "";
            // 
            // listEnemies
            // 
            listEnemies.BackColor = System.Drawing.SystemColors.MenuText;
            listEnemies.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listEnemies.ForeColor = System.Drawing.SystemColors.MenuBar;
            listEnemies.FormattingEnabled = true;
            listEnemies.HorizontalScrollbar = true;
            listEnemies.ItemHeight = 19;
            listEnemies.Location = new System.Drawing.Point(287, 43);
            listEnemies.Name = "listEnemies";
            listEnemies.Size = new System.Drawing.Size(352, 61);
            listEnemies.TabIndex = 18;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.Location = new System.Drawing.Point(350, 15);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(216, 25);
            this.lblSelect.TabIndex = 19;
            this.lblSelect.Text = "Select an Enemy to Attack";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnSave.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(109, 473);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnLoad.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLoad.Location = new System.Drawing.Point(109, 507);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(66, 35);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnShopW1
            // 
            btnShopW1.BackColor = System.Drawing.SystemColors.MenuText;
            btnShopW1.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnShopW1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnShopW1.Location = new System.Drawing.Point(670, 43);
            btnShopW1.Name = "btnShopW1";
            btnShopW1.Size = new System.Drawing.Size(230, 35);
            btnShopW1.TabIndex = 22;
            btnShopW1.Text = "Shop";
            btnShopW1.UseVisualStyleBackColor = false;
            btnShopW1.Click += new System.EventHandler(this.btnShopW1_Click);
            // 
            // btnShopW2
            // 
            btnShopW2.BackColor = System.Drawing.SystemColors.MenuText;
            btnShopW2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnShopW2.Location = new System.Drawing.Point(670, 84);
            btnShopW2.Name = "btnShopW2";
            btnShopW2.Size = new System.Drawing.Size(230, 35);
            btnShopW2.TabIndex = 23;
            btnShopW2.Text = "Shop";
            btnShopW2.UseVisualStyleBackColor = false;
            btnShopW2.Click += new System.EventHandler(this.btnShopW2_Click);
            // 
            // btnShopW3
            // 
            btnShopW3.BackColor = System.Drawing.SystemColors.MenuText;
            btnShopW3.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnShopW3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnShopW3.Location = new System.Drawing.Point(670, 125);
            btnShopW3.Name = "btnShopW3";
            btnShopW3.Size = new System.Drawing.Size(230, 35);
            btnShopW3.TabIndex = 24;
            btnShopW3.Text = "Shop";
            btnShopW3.UseVisualStyleBackColor = false;
            btnShopW3.Click += new System.EventHandler(this.btnShopW3_Click);
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShop.Location = new System.Drawing.Point(684, 15);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(202, 25);
            this.lblShop.TabIndex = 25;
            this.lblShop.Text = "Shop - Click to Purchase";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(61, 214);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(166, 171);
            this.lblKey.TabIndex = 26;
            this.lblKey.Text = "H = Hero\r\nG = Goblin (Enemy)\r\nM = Mage (Enemy)\r\nL = Leader (Enemy)\r\nD = Dagger (W" +
    "eapon)\r\nS = Longsword (Weapon)\r\nB = Longbow (Weapon)\r\nR = Rifle (Weapon)\r\n© = Go" +
    "ld";
            // 
            // lblBegin
            // 
            this.lblBegin.AutoSize = true;
            this.lblBegin.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBegin.Location = new System.Drawing.Point(17, 15);
            this.lblBegin.Name = "lblBegin";
            this.lblBegin.Size = new System.Drawing.Size(267, 25);
            this.lblBegin.TabIndex = 27;
            this.lblBegin.Text = "Enter Height and Width to Begin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(930, 624);
            this.Controls.Add(this.lblBegin);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(btnShopW3);
            this.Controls.Add(btnShopW2);
            this.Controls.Add(btnShopW1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(listEnemies);
            this.Controls.Add(this.richShowAttack);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.lblMaxHeight);
            this.Controls.Add(this.lblMinHeight);
            this.Controls.Add(this.txtMaxHeight);
            this.Controls.Add(this.txtMinHeight);
            this.Controls.Add(this.lblMaxWidth);
            this.Controls.Add(this.lblMinWidth);
            this.Controls.Add(this.txtMaxWidth);
            this.Controls.Add(this.txtMinWidth);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblMap);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Form1";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.TextBox txtMinWidth;
        private System.Windows.Forms.TextBox txtMaxWidth;
        private System.Windows.Forms.Label lblMinWidth;
        private System.Windows.Forms.Label lblMaxWidth;
        private System.Windows.Forms.TextBox txtMinHeight;
        private System.Windows.Forms.TextBox txtMaxHeight;
        private System.Windows.Forms.Label lblMinHeight;
        private System.Windows.Forms.Label lblMaxHeight;
        public System.Windows.Forms.Label lblMap;
        public System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.RichTextBox richShowAttack;
        public System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.Label lblShop;
        public System.Windows.Forms.Label lblKey;
        public System.Windows.Forms.Label lblBegin;
        private static System.Windows.Forms.Button btnShopW1;
        private static System.Windows.Forms.Button btnShopW2;
        private static System.Windows.Forms.Button btnShopW3;
        public static System.Windows.Forms.ListBox listEnemies;
    }
}

