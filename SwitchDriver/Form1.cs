// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.Form1
// Assembly: ASCOM.WandererBoxes.Switch, Version=6.6.0.0, Culture=neutral, PublicKeyToken=5a596dde3293c610
// MVID: E3106A5C-05F3-42C7-89F9-2A2C7253BE13
// Assembly location: C:\Program Files (x86)\Wanderer Astro\ASCOM.WandererBoxes.Switch.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ASCOM.WandererBoxes
{
  public class Form1 : Form
  {
    private IContainer components;
    private Label label1;
    private Label label2;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private Label label3;

    public Form1() => this.InitializeComponent();

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.label1 = new Label();
      this.label2 = new Label();
      this.pictureBox1 = new PictureBox();
      this.pictureBox2 = new PictureBox();
      this.label3 = new Label();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 50);
      this.label1.Name = "label1";
      this.label1.Size = new Size(0, 32 /*0x20*/);
      this.label1.TabIndex = 0;
      this.label2.AutoSize = true;
      this.label2.BackColor = SystemColors.ActiveCaptionText;
      this.label2.Font = new Font("小米兰亭", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(413, 5);
      this.label2.Name = "label2";
      this.label2.Size = new Size(185, 42);
      this.label2.TabIndex = 1;
      this.label2.Text = "Instruction";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.pictureBox1.BackColor = SystemColors.ActiveCaptionText;
      this.pictureBox1.Location = new Point(-26, -8);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(1112, 55);
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      this.pictureBox2.Location = new Point(-5, 42);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(853, 522);
      this.pictureBox2.TabIndex = 3;
      this.pictureBox2.TabStop = false;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(2, 50);
      this.label3.Name = "label3";
      this.label3.Size = new Size(1084, 320);
      this.label3.TabIndex = 4;
      this.label3.Text = componentResourceManager.GetString("label3.Text");
      this.AutoScaleDimensions = new SizeF(15f, 32f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoValidate = AutoValidate.EnableAllowFocusChange;
      this.BackColor = SystemColors.AppWorkspace;
      this.ClientSize = new Size(1087, 373);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.pictureBox2);
      this.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Margin = new Padding(3, 4, 3, 4);
      this.Name = nameof (Form1);
      this.Load += new EventHandler(this.Form1_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
