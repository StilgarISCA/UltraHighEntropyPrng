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
         this.rtbSeedKey = new System.Windows.Forms.RichTextBox();
         this.numRange = new System.Windows.Forms.NumericUpDown();
         this.numCount = new System.Windows.Forms.NumericUpDown();
         this.lblRange = new System.Windows.Forms.Label();
         this.lblCount = new System.Windows.Forms.Label();
         this.rtbRandom = new System.Windows.Forms.RichTextBox();
         this.btnGenerate = new System.Windows.Forms.Button();
         this.lblStatus = new System.Windows.Forms.Label();
         this.rdoRandomize = new System.Windows.Forms.RadioButton();
         this.rdoFreeze = new System.Windows.Forms.RadioButton();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.btnReset = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         ( (System.ComponentModel.ISupportInitialize) ( this.numRange ) ).BeginInit();
         ( (System.ComponentModel.ISupportInitialize) ( this.numCount ) ).BeginInit();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // rtbSeedKey
         // 
         this.rtbSeedKey.Location = new System.Drawing.Point( 13, 31 );
         this.rtbSeedKey.Name = "rtbSeedKey";
         this.rtbSeedKey.ReadOnly = true;
         this.rtbSeedKey.Size = new System.Drawing.Size( 295, 163 );
         this.rtbSeedKey.TabIndex = 0;
         this.rtbSeedKey.Text = "";
         // 
         // numRange
         // 
         this.numRange.Location = new System.Drawing.Point( 331, 92 );
         this.numRange.Maximum = new decimal( new int[] {
            2147483647,
            0,
            0,
            0} );
         this.numRange.Minimum = new decimal( new int[] {
            2,
            0,
            0,
            0} );
         this.numRange.Name = "numRange";
         this.numRange.Size = new System.Drawing.Size( 103, 20 );
         this.numRange.TabIndex = 5;
         this.numRange.ThousandsSeparator = true;
         this.numRange.Value = new decimal( new int[] {
            10000,
            0,
            0,
            0} );
         // 
         // numCount
         // 
         this.numCount.Location = new System.Drawing.Point( 331, 125 );
         this.numCount.Maximum = new decimal( new int[] {
            2147483647,
            0,
            0,
            0} );
         this.numCount.Name = "numCount";
         this.numCount.Size = new System.Drawing.Size( 103, 20 );
         this.numCount.TabIndex = 6;
         this.numCount.ThousandsSeparator = true;
         this.numCount.Value = new decimal( new int[] {
            10000,
            0,
            0,
            0} );
         // 
         // lblRange
         // 
         this.lblRange.AutoSize = true;
         this.lblRange.Location = new System.Drawing.Point( 446, 94 );
         this.lblRange.Name = "lblRange";
         this.lblRange.Size = new System.Drawing.Size( 86, 13 );
         this.lblRange.TabIndex = 8;
         this.lblRange.Text = "Range of Values";
         // 
         // lblCount
         // 
         this.lblCount.AutoSize = true;
         this.lblCount.Location = new System.Drawing.Point( 446, 127 );
         this.lblCount.Name = "lblCount";
         this.lblCount.Size = new System.Drawing.Size( 82, 13 );
         this.lblCount.TabIndex = 9;
         this.lblCount.Text = "Count of Values";
         // 
         // rtbRandom
         // 
         this.rtbRandom.Location = new System.Drawing.Point( 13, 229 );
         this.rtbRandom.Name = "rtbRandom";
         this.rtbRandom.ReadOnly = true;
         this.rtbRandom.Size = new System.Drawing.Size( 534, 186 );
         this.rtbRandom.TabIndex = 10;
         this.rtbRandom.Text = "";
         // 
         // btnGenerate
         // 
         this.btnGenerate.Location = new System.Drawing.Point( 331, 156 );
         this.btnGenerate.Name = "btnGenerate";
         this.btnGenerate.Size = new System.Drawing.Size( 93, 38 );
         this.btnGenerate.TabIndex = 11;
         this.btnGenerate.Text = "Generate";
         this.btnGenerate.UseVisualStyleBackColor = true;
         this.btnGenerate.Click += new System.EventHandler( this.btnGenerate_Click );
         // 
         // lblStatus
         // 
         this.lblStatus.AutoSize = true;
         this.lblStatus.Location = new System.Drawing.Point( 12, 402 );
         this.lblStatus.Name = "lblStatus";
         this.lblStatus.Size = new System.Drawing.Size( 0, 13 );
         this.lblStatus.TabIndex = 12;
         // 
         // rdoRandomize
         // 
         this.rdoRandomize.AutoSize = true;
         this.rdoRandomize.Checked = true;
         this.rdoRandomize.Location = new System.Drawing.Point( 12, 19 );
         this.rdoRandomize.Name = "rdoRandomize";
         this.rdoRandomize.Size = new System.Drawing.Size( 145, 17 );
         this.rdoRandomize.TabIndex = 1;
         this.rdoRandomize.TabStop = true;
         this.rdoRandomize.Text = "Randomize the Seed Key";
         this.rdoRandomize.UseVisualStyleBackColor = true;
         // 
         // rdoFreeze
         // 
         this.rdoFreeze.AutoSize = true;
         this.rdoFreeze.Location = new System.Drawing.Point( 12, 42 );
         this.rdoFreeze.Name = "rdoFreeze";
         this.rdoFreeze.Size = new System.Drawing.Size( 133, 17 );
         this.rdoFreeze.TabIndex = 2;
         this.rdoFreeze.Text = "Freeze the Current Key";
         this.rdoFreeze.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add( this.rdoFreeze );
         this.groupBox1.Controls.Add( this.rdoRandomize );
         this.groupBox1.Location = new System.Drawing.Point( 331, 12 );
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size( 201, 71 );
         this.groupBox1.TabIndex = 13;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Seed Control";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point( 13, 210 );
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size( 39, 13 );
         this.label2.TabIndex = 15;
         this.label2.Text = "Output";
         // 
         // btnReset
         // 
         this.btnReset.Location = new System.Drawing.Point( 439, 156 );
         this.btnReset.Name = "btnReset";
         this.btnReset.Size = new System.Drawing.Size( 93, 38 );
         this.btnReset.TabIndex = 16;
         this.btnReset.Text = "Reset";
         this.btnReset.UseVisualStyleBackColor = true;
         this.btnReset.Click += new System.EventHandler( this.btnReset_Click );
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point( 15, 12 );
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size( 32, 13 );
         this.label1.TabIndex = 14;
         this.label1.Text = "Seed";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size( 559, 438 );
         this.Controls.Add( this.btnReset );
         this.Controls.Add( this.label2 );
         this.Controls.Add( this.label1 );
         this.Controls.Add( this.lblStatus );
         this.Controls.Add( this.btnGenerate );
         this.Controls.Add( this.rtbRandom );
         this.Controls.Add( this.lblCount );
         this.Controls.Add( this.lblRange );
         this.Controls.Add( this.numCount );
         this.Controls.Add( this.numRange );
         this.Controls.Add( this.rtbSeedKey );
         this.Controls.Add( this.groupBox1 );
         this.Name = "Form1";
         this.Text = "Form1";
         ( (System.ComponentModel.ISupportInitialize) ( this.numRange ) ).EndInit();
         ( (System.ComponentModel.ISupportInitialize) ( this.numCount ) ).EndInit();
         this.groupBox1.ResumeLayout( false );
         this.groupBox1.PerformLayout();
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RichTextBox rtbSeedKey;
      private System.Windows.Forms.NumericUpDown numRange;
      private System.Windows.Forms.NumericUpDown numCount;
      private System.Windows.Forms.Label lblRange;
      private System.Windows.Forms.Label lblCount;
      private System.Windows.Forms.RichTextBox rtbRandom;
      private System.Windows.Forms.Button btnGenerate;
      private System.Windows.Forms.Label lblStatus;
      private System.Windows.Forms.RadioButton rdoRandomize;
      private System.Windows.Forms.RadioButton rdoFreeze;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button btnReset;
      private System.Windows.Forms.Label label1;
   }
}

