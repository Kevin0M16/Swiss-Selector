﻿using System.Collections.Generic;

namespace Swiss_Selector
{
    partial class Form2
    {
        /// <summary>//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label28 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bigModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontOpenInvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIntroOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIntroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontShowIntroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spawnCarOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examinedOnSpawnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notExaminedOnSpawnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label30 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(12, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 441);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 19;
            this.listBox2.Location = new System.Drawing.Point(278, 30);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(158, 232);
            this.listBox2.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(791, 195);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 27);
            this.label28.TabIndex = 23;
            this.label28.Text = "Add XP Amount";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown5.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(708, 195);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(80, 27);
            this.numericUpDown5.TabIndex = 10;
            this.numericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.NumericUpDown5_ValueChanged);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(791, 104);
            this.label27.Margin = new System.Windows.Forms.Padding(0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 27);
            this.label27.TabIndex = 21;
            this.label27.Text = "Cond x 100";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 2;
            this.numericUpDown4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown4.Location = new System.Drawing.Point(708, 104);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(80, 27);
            this.numericUpDown4.TabIndex = 7;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.NumericUpDown4_ValueChanged);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(791, 73);
            this.label26.Margin = new System.Windows.Forms.Padding(0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 27);
            this.label26.TabIndex = 19;
            this.label26.Text = "Mileage";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown3.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown3.Location = new System.Drawing.Point(708, 73);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(80, 27);
            this.numericUpDown3.TabIndex = 6;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.NumericUpDown3_ValueChanged);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(791, 42);
            this.label25.Margin = new System.Windows.Forms.Padding(0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 27);
            this.label25.TabIndex = 17;
            this.label25.Text = "Quality";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(708, 42);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(80, 27);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.NumericUpDown2_ValueChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(791, 138);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 27);
            this.label8.TabIndex = 15;
            this.label8.Text = "Add Money Amount";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(708, 135);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(80, 27);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 19;
            this.listBox3.Location = new System.Drawing.Point(442, 30);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(245, 232);
            this.listBox3.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.preferencesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 27);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bigModeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 23);
            this.toolStripMenuItem1.Text = "File";
            // 
            // bigModeToolStripMenuItem
            // 
            this.bigModeToolStripMenuItem.Name = "bigModeToolStripMenuItem";
            this.bigModeToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.bigModeToolStripMenuItem.Text = "Big Mode";
            this.bigModeToolStripMenuItem.Click += new System.EventHandler(this.BigModeToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyMapToolStripMenuItem,
            this.showIntroOptionsToolStripMenuItem,
            this.spawnCarOptionsToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(98, 23);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // keyMapToolStripMenuItem
            // 
            this.keyMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInvToolStripMenuItem,
            this.dontOpenInvToolStripMenuItem});
            this.keyMapToolStripMenuItem.Name = "keyMapToolStripMenuItem";
            this.keyMapToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.keyMapToolStripMenuItem.Text = "Insert Part Options...";
            // 
            // openInvToolStripMenuItem
            // 
            this.openInvToolStripMenuItem.Name = "openInvToolStripMenuItem";
            this.openInvToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.openInvToolStripMenuItem.Text = "Open Inventory";
            this.openInvToolStripMenuItem.Click += new System.EventHandler(this.OpenInvToolStripMenuItem_Click);
            // 
            // dontOpenInvToolStripMenuItem
            // 
            this.dontOpenInvToolStripMenuItem.Name = "dontOpenInvToolStripMenuItem";
            this.dontOpenInvToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.dontOpenInvToolStripMenuItem.Text = "Don\'t Open Inventory";
            this.dontOpenInvToolStripMenuItem.Click += new System.EventHandler(this.DontOpenInvToolStripMenuItem_Click);
            // 
            // showIntroOptionsToolStripMenuItem
            // 
            this.showIntroOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showIntroToolStripMenuItem,
            this.dontShowIntroToolStripMenuItem});
            this.showIntroOptionsToolStripMenuItem.Name = "showIntroOptionsToolStripMenuItem";
            this.showIntroOptionsToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.showIntroOptionsToolStripMenuItem.Text = "Show Intro Options...";
            // 
            // showIntroToolStripMenuItem
            // 
            this.showIntroToolStripMenuItem.Name = "showIntroToolStripMenuItem";
            this.showIntroToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.showIntroToolStripMenuItem.Text = "Show Intro";
            this.showIntroToolStripMenuItem.Click += new System.EventHandler(this.ShowIntroToolStripMenuItem_Click);
            // 
            // dontShowIntroToolStripMenuItem
            // 
            this.dontShowIntroToolStripMenuItem.Name = "dontShowIntroToolStripMenuItem";
            this.dontShowIntroToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.dontShowIntroToolStripMenuItem.Text = "Don\'t Show Intro";
            this.dontShowIntroToolStripMenuItem.Click += new System.EventHandler(this.DontShowIntroToolStripMenuItem_Click);
            // 
            // spawnCarOptionsToolStripMenuItem
            // 
            this.spawnCarOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examinedOnSpawnToolStripMenuItem,
            this.notExaminedOnSpawnToolStripMenuItem});
            this.spawnCarOptionsToolStripMenuItem.Name = "spawnCarOptionsToolStripMenuItem";
            this.spawnCarOptionsToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.spawnCarOptionsToolStripMenuItem.Text = "Spawn Car Options...";
            // 
            // examinedOnSpawnToolStripMenuItem
            // 
            this.examinedOnSpawnToolStripMenuItem.Name = "examinedOnSpawnToolStripMenuItem";
            this.examinedOnSpawnToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.examinedOnSpawnToolStripMenuItem.Text = "Examined on Spawn";
            this.examinedOnSpawnToolStripMenuItem.Click += new System.EventHandler(this.ExaminedOnSpawnToolStripMenuItem_Click);
            // 
            // notExaminedOnSpawnToolStripMenuItem
            // 
            this.notExaminedOnSpawnToolStripMenuItem.Name = "notExaminedOnSpawnToolStripMenuItem";
            this.notExaminedOnSpawnToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.notExaminedOnSpawnToolStripMenuItem.Text = "Not Examined on Spawn";
            this.notExaminedOnSpawnToolStripMenuItem.Click += new System.EventHandler(this.NotExaminedOnSpawnToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(791, 163);
            this.label30.Margin = new System.Windows.Forms.Padding(0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 27);
            this.label30.TabIndex = 60;
            this.label30.Text = "Set $$$";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown6.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(708, 165);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(80, 27);
            this.numericUpDown6.TabIndex = 9;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.NumericUpDown6_ValueChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(673, 380);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(185, 29);
            this.label31.TabIndex = 62;
            this.label31.Text = "Swiss Selector 1.5";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(278, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 203);
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(693, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 29);
            this.button2.TabIndex = 70;
            this.button2.Text = "Launch CMS 2018";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(693, 236);
            this.textBox2.MaxLength = 9;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 26);
            this.textBox2.TabIndex = 71;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(794, 236);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 26);
            this.button3.TabIndex = 72;
            this.button3.Text = "Set Plate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(615, 268);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(296, 43);
            this.textBox1.TabIndex = 73;
            this.textBox1.WordWrap = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(923, 483);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.numericUpDown6);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Swiss Selector 1.5 - Mini Mode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public string MyProperty { get; set; }
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        public int checker;        
        private string currentKey;
        private string savePath;        
        private string ChosenPath;
        public string dllPath;
        public string keysPath;
        public string swissPath;
        public string carsPath;       
        public string IncreaseConfig;
        public string DecreaseConfig;
        public string RandomChangeCondition;
        public string RandomChangeColor;
        public string ReloadLiveries;
        public string SetMileage;
        public string GenerateJunkyard;
        public string FullyRepairCar;
        public string PhotoMode;
        public string DuplicateEngine;
        public string IncreaseSpeed;
        public string DecreaseSpeed;
        public string AddAllEngineParts;
        public string RepairAllItems;
        public string AddBarn;
        public string AddMoney;
        public string AddXP;
        public string UnlockAllUpgrades;
        public string OpenShop;
        public string AddThisPart;
        public string RotateEngineRight;
        public string RotateEngineLeft;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontOpenInvToolStripMenuItem;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem showIntroOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showIntroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontShowIntroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spawnCarOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examinedOnSpawnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notExaminedOnSpawnToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem bigModeToolStripMenuItem;
    }
}
