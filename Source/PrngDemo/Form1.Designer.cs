namespace PrngDemo
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
      protected override void Dispose( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
         this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(38, 37);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(264, 183);
         this.richTextBox1.TabIndex = 0;
         this.richTextBox1.Text = "";
         // 
         // numericUpDown1
         // 
         this.numericUpDown1.Location = new System.Drawing.Point(349, 115);
         this.numericUpDown1.Name = "numericUpDown1";
         this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
         this.numericUpDown1.TabIndex = 5;
         // 
         // numericUpDown2
         // 
         this.numericUpDown2.Location = new System.Drawing.Point(349, 153);
         this.numericUpDown2.Name = "numericUpDown2";
         this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
         this.numericUpDown2.TabIndex = 6;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(482, 117);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(86, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Range of Values";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(485, 153);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(82, 13);
         this.label2.TabIndex = 9;
         this.label2.Text = "Count of Values";
         // 
         // radioButton1
         // 
         this.radioButton1.AutoSize = true;
         this.radioButton1.Location = new System.Drawing.Point(13, 23);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(145, 17);
         this.radioButton1.TabIndex = 1;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "Randomize the Seed Key";
         this.radioButton1.UseVisualStyleBackColor = true;
         // 
         // radioButton2
         // 
         this.radioButton2.AutoSize = true;
         this.radioButton2.Location = new System.Drawing.Point(13, 47);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(133, 17);
         this.radioButton2.TabIndex = 2;
         this.radioButton2.TabStop = true;
         this.radioButton2.Text = "Freeze the Current Key";
         this.radioButton2.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.radioButton2);
         this.groupBox1.Controls.Add(this.radioButton1);
         this.groupBox1.Location = new System.Drawing.Point(349, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(168, 76);
         this.groupBox1.TabIndex = 7;
         this.groupBox1.TabStop = false;
         this.groupBox1.Visible = false;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(627, 261);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.numericUpDown2);
         this.Controls.Add(this.numericUpDown1);
         this.Controls.Add(this.richTextBox1);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RichTextBox richTextBox1;
      private System.Windows.Forms.NumericUpDown numericUpDown1;
      private System.Windows.Forms.NumericUpDown numericUpDown2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.RadioButton radioButton2;
      private System.Windows.Forms.GroupBox groupBox1;
   }
}

