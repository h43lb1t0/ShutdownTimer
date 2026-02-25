using System;
using System.Windows.Forms;

namespace ShutdownTimer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.timeLabel = new System.Windows.Forms.ToolStripLabel();
            this.resetTimerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.min15Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.min30Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.min60Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.min90Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.min120Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.customDuratationBox = new System.Windows.Forms.ToolStripTextBox();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.hourBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.dayBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.trayMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ShutdownTimer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitBtn,
            this.timeLabel,
            this.resetTimerBtn,
            this.addToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.customDuratationBox,
            this.unitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(248, 281);
            this.trayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.trayMenu_Opening);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(247, 38);
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(187, 32);
            this.timeLabel.Text = "Time remaining:";
            this.timeLabel.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // resetTimerBtn
            // 
            this.resetTimerBtn.Name = "resetTimerBtn";
            this.resetTimerBtn.Size = new System.Drawing.Size(247, 38);
            this.resetTimerBtn.Text = "Reset timer";
            this.resetTimerBtn.Click += new System.EventHandler(this.ResetTimerBtn_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.min15Btn,
            this.min30Btn,
            this.min60Btn,
            this.min90Btn,
            this.min120Btn});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // min15Btn
            // 
            this.min15Btn.Name = "min15Btn";
            this.min15Btn.Size = new System.Drawing.Size(221, 44);
            this.min15Btn.Tag = "15";
            this.min15Btn.Text = "15 min";
            this.min15Btn.Click += new System.EventHandler(this.AddTime_Click);
            // 
            // min30Btn
            // 
            this.min30Btn.MergeIndex = 0;
            this.min30Btn.Name = "min30Btn";
            this.min30Btn.Size = new System.Drawing.Size(221, 44);
            this.min30Btn.Tag = "30";
            this.min30Btn.Text = "30 min";
            this.min30Btn.Click += new System.EventHandler(this.AddTime_Click);
            // 
            // min60Btn
            // 
            this.min60Btn.Name = "min60Btn";
            this.min60Btn.Size = new System.Drawing.Size(221, 44);
            this.min60Btn.Tag = "60";
            this.min60Btn.Text = "60 min";
            this.min60Btn.Click += new System.EventHandler(this.AddTime_Click);
            // 
            // min90Btn
            // 
            this.min90Btn.Name = "min90Btn";
            this.min90Btn.Size = new System.Drawing.Size(221, 44);
            this.min90Btn.Tag = "90";
            this.min90Btn.Text = "1.5 h";
            this.min90Btn.Click += new System.EventHandler(this.AddTime_Click);
            // 
            // min120Btn
            // 
            this.min120Btn.Name = "min120Btn";
            this.min120Btn.Size = new System.Drawing.Size(221, 44);
            this.min120Btn.Tag = "120";
            this.min120Btn.Text = "2 h";
            this.min120Btn.Click += new System.EventHandler(this.AddTime_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(132, 32);
            this.toolStripLabel2.Text = "Duratation:";
            // 
            // customDuratationBox
            // 
            this.customDuratationBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.customDuratationBox.Name = "customDuratationBox";
            this.customDuratationBox.Size = new System.Drawing.Size(100, 39);
            this.customDuratationBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomDurationBox_keyPress);
            // 
            // unitToolStripMenuItem
            // 
            this.unitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minBtn,
            this.hourBtn,
            this.dayBtn});
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.unitToolStripMenuItem.Text = "In (time unit)";
            // 
            // minBtn
            // 
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(197, 44);
            this.minBtn.Tag = "m";
            this.minBtn.Text = "min";
            this.minBtn.Click += new System.EventHandler(this.SetTime_Click);
            // 
            // hourBtn
            // 
            this.hourBtn.Name = "hourBtn";
            this.hourBtn.Size = new System.Drawing.Size(197, 44);
            this.hourBtn.Tag = "h";
            this.hourBtn.Text = "hour";
            this.hourBtn.Click += new System.EventHandler(this.SetTime_Click);
            // 
            // dayBtn
            // 
            this.dayBtn.Name = "dayBtn";
            this.dayBtn.Size = new System.Drawing.Size(197, 44);
            this.dayBtn.Tag = "d";
            this.dayBtn.Text = "days";
            this.dayBtn.Click += new System.EventHandler(this.SetTime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.trayMenu.ResumeLayout(false);
            this.trayMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem resetTimerBtn;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem min15Btn;
        private System.Windows.Forms.ToolStripMenuItem min30Btn;
        private System.Windows.Forms.ToolStripMenuItem min60Btn;
        private System.Windows.Forms.ToolStripMenuItem min90Btn;
        private System.Windows.Forms.ToolStripMenuItem min120Btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel timeLabel;
        private System.Windows.Forms.ToolStripTextBox customDuratationBox;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minBtn;
        private System.Windows.Forms.ToolStripMenuItem hourBtn;
        private System.Windows.Forms.ToolStripMenuItem dayBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;

    }
}

