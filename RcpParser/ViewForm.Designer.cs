namespace RcpParser
{
   partial class ViewForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
         this.load_file_ctrl = new System.Windows.Forms.Button();
         this.result_view_ctrl = new System.Windows.Forms.RichTextBox();
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.SuspendLayout();
         // 
         // load_file_ctrl
         // 
         this.load_file_ctrl.Location = new System.Drawing.Point(12, 12);
         this.load_file_ctrl.Name = "load_file_ctrl";
         this.load_file_ctrl.Size = new System.Drawing.Size(144, 40);
         this.load_file_ctrl.TabIndex = 0;
         this.load_file_ctrl.Text = "Load report file";
         this.load_file_ctrl.UseVisualStyleBackColor = true;
         this.load_file_ctrl.Click += new System.EventHandler(this.button1_Click);
         // 
         // result_view_ctrl
         // 
         this.result_view_ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.result_view_ctrl.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.result_view_ctrl.Location = new System.Drawing.Point(12, 58);
         this.result_view_ctrl.Name = "result_view_ctrl";
         this.result_view_ctrl.ReadOnly = true;
         this.result_view_ctrl.Size = new System.Drawing.Size(750, 391);
         this.result_view_ctrl.TabIndex = 1;
         this.result_view_ctrl.Text = "";
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.FileName = "openFileDialog1";
         // 
         // ViewForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 461);
         this.Controls.Add(this.result_view_ctrl);
         this.Controls.Add(this.load_file_ctrl);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximumSize = new System.Drawing.Size(800, 500);
         this.MinimumSize = new System.Drawing.Size(800, 500);
         this.Name = "ViewForm";
         this.Text = "RCP Analyzer 1.02";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button load_file_ctrl;
      private System.Windows.Forms.RichTextBox result_view_ctrl;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
   }
}