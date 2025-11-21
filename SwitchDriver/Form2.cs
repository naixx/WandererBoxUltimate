// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.Form2
// Assembly: ASCOM.WandererBoxes.Switch, Version=6.6.0.0, Culture=neutral, PublicKeyToken=5a596dde3293c610
// MVID: E3106A5C-05F3-42C7-89F9-2A2C7253BE13
// Assembly location: C:\Program Files (x86)\Wanderer Astro\ASCOM.WandererBoxes.Switch.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ASCOM.WandererBoxes
{
  public class Form2 : Form
  {
    private IContainer components;
    private Label label2;
    private Label label1;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private Label label3;

    public Form2() => this.InitializeComponent();

    private void Form2_Load(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form2));
      this.label2 = new Label();
      this.label1 = new Label();
      this.pictureBox1 = new PictureBox();
      this.pictureBox2 = new PictureBox();
      this.label3 = new Label();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.SuspendLayout();
      this.label2.AutoSize = true;
      this.label2.BackColor = SystemColors.ActiveCaptionText;
      this.label2.Font = new Font("小米兰亭", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(394, 18);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(162, 37);
      this.label2.TabIndex = 5;
      this.label2.Text = "Instruction";
      this.label1.AutoSize = true;
      this.label1.BackColor = SystemColors.ControlDark;
      this.label1.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label1.Location = new Point(2, 80 /*0x50*/);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(0, 28);
      this.label1.TabIndex = 4;
      this.pictureBox1.BackColor = SystemColors.ActiveCaptionText;
      this.pictureBox1.Location = new Point(-52, -4);
      this.pictureBox1.Margin = new Padding(4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(1129, 72);
      this.pictureBox1.TabIndex = 6;
      this.pictureBox1.TabStop = false;
      this.pictureBox2.BackColor = SystemColors.ButtonShadow;
      this.pictureBox2.Location = new Point(-23, 60);
      this.pictureBox2.Margin = new Padding(4);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(1194, 404);
      this.pictureBox2.TabIndex = 7;
      this.pictureBox2.TabStop = false;
      this.label3.AutoSize = true;
      this.label3.BackColor = SystemColors.ControlDark;
      this.label3.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label3.Location = new Point(10, 80 /*0x50*/);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(956, 364);
      this.label3.TabIndex = 8;
      this.label3.Text = componentResourceManager.GetString("label3.Text");
      this.AutoScaleDimensions = new SizeF(168f, 168f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(970, 453);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.pictureBox2);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4);
      this.Name = nameof (Form2);
      this.ShowIcon = false;
      this.Load += new EventHandler(this.Form2_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
