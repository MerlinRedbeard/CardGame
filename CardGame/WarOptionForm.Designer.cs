﻿namespace CardGame
{
    partial class WarOptionForm
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
            this.aceLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.aceLow = new System.Windows.Forms.RadioButton();
            this.aceHigh = new System.Windows.Forms.RadioButton();
            this.OKbutton = new System.Windows.Forms.Button();
            this.aceLayoutPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aceLayoutPanel
            // 
            this.aceLayoutPanel.ColumnCount = 1;
            this.aceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.aceLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.aceLayoutPanel.Controls.Add(this.groupBox1, 0, 0);
            this.aceLayoutPanel.Controls.Add(this.OKbutton, 0, 1);
            this.aceLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.aceLayoutPanel.Name = "aceLayoutPanel";
            this.aceLayoutPanel.RowCount = 2;
            this.aceLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.aceLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.aceLayoutPanel.Size = new System.Drawing.Size(200, 100);
            this.aceLayoutPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.aceLow);
            this.groupBox1.Controls.Add(this.aceHigh);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // aceLow
            // 
            this.aceLow.AutoSize = true;
            this.aceLow.Location = new System.Drawing.Point(7, 26);
            this.aceLow.Name = "aceLow";
            this.aceLow.Size = new System.Drawing.Size(72, 17);
            this.aceLow.TabIndex = 1;
            this.aceLow.Text = "Aces Low";
            this.aceLow.UseVisualStyleBackColor = true;
            this.aceLow.CheckedChanged += new System.EventHandler(this.aceLow_CheckedChanged);
            // 
            // aceHigh
            // 
            this.aceHigh.AutoSize = true;
            this.aceHigh.Checked = true;
            this.aceHigh.Location = new System.Drawing.Point(7, 7);
            this.aceHigh.Name = "aceHigh";
            this.aceHigh.Size = new System.Drawing.Size(74, 17);
            this.aceHigh.TabIndex = 0;
            this.aceHigh.TabStop = true;
            this.aceHigh.Text = "Aces High";
            this.aceHigh.UseVisualStyleBackColor = true;
            this.aceHigh.CheckedChanged += new System.EventHandler(this.aceHigh_CheckedChanged);
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(3, 53);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 2;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // WarOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 354);
            this.Controls.Add(this.aceLayoutPanel);
            this.Name = "WarOptionForm";
            this.Text = "War Options";
            this.aceLayoutPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel aceLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton aceLow;
        private System.Windows.Forms.RadioButton aceHigh;
        private System.Windows.Forms.Button OKbutton;
    }
}