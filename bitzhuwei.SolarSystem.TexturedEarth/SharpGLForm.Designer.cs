namespace bitzhuwei.SolarSystem.TexturedEarth
{
    partial class SharpGLForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpGLForm));
            this.openGLControl = new SharpGL.OpenGLControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFilename = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTextureImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.openTextureImage = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.AllowDrop = true;
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.BitDepth = 24;
            this.openGLControl.DrawFPS = true;
            this.openGLControl.FrameRate = 20;
            this.openGLControl.Location = new System.Drawing.Point(0, 0);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.FBO;
            this.openGLControl.Size = new System.Drawing.Size(624, 336);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Load += new System.EventHandler(this.openGLControl_Load);
            this.openGLControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.openGLControl_DragDrop);
            this.openGLControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.openGLControl_DragEnter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFilename,
            this.lblTextureImage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFilename
            // 
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(44, 17);
            this.lblFilename.Text = "文件：";
            this.lblFilename.Click += new System.EventHandler(this.lblTextureImage_Click);
            // 
            // lblTextureImage
            // 
            this.lblTextureImage.Name = "lblTextureImage";
            this.lblTextureImage.Size = new System.Drawing.Size(68, 17);
            this.lblTextureImage.Text = "earth.bmp";
            this.lblTextureImage.Click += new System.EventHandler(this.lblTextureImage_Click);
            // 
            // SharpGLForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.openGLControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SharpGLForm";
            this.Text = "纹理星球";
            this.Load += new System.EventHandler(this.SharpGLForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTextureImage;
        private System.Windows.Forms.OpenFileDialog openTextureImage;
        private System.Windows.Forms.ToolStripStatusLabel lblFilename;
    }
}

