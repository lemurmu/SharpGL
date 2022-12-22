using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.IO;

namespace bitzhuwei.SolarSystem.TexturedEarth
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, PaintEventArgs e)
        {
            if (this.texture != null)
            {
                OpenGL gl = openGLControl.OpenGL;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                
                gl.LoadIdentity();
                gl.Scale(3.6, 3.6, 3.6);//放大到3.6倍
                gl.Rotate(90, 1.0f, 0, 0);//绕X轴旋转90度
                gl.Rotate(-rotation, 0.0f, 0.0f, 1.0f);//饶Z轴旋转
                gl.Sphere(ptrBall, 1.0f, 100, 100);//绘制星球

                rotation += 3.0f;
            }
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;

            gl.ClearColor(0, 0, 0, 0);
            gl.ShadeModel(OpenGL.GL_SMOOTH);
            //初始化材质
            var mat_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            var mat_ambient = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            var mat_diffuse = new float[] { 2.0f, 2.0f, 2.0f, 0.1f };
            var mat_shininess = new float[] { 100.0f };
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SPECULAR, mat_specular);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_AMBIENT, mat_ambient);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, mat_diffuse);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, mat_shininess);
            //初始化光照
            var ambientLight = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            var diffuseLight = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };	
            var posLight0 = new float[] { 2.0f, 0.1f, 0.0f, 0.0f };
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, ambientLight);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, diffuseLight); 
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, posLight0);
            //初始化纹理
            texture = new SharpGL.SceneGraph.Assets.Texture();
            texture.Create(gl, "Data/earth.bmp");
            //初始化星球
            ptrBall = gl.NewQuadric();					
            gl.QuadricNormals(ptrBall, OpenGL.GL_SMOOTH);
            gl.QuadricTexture(ptrBall, (int)(OpenGL.GL_TRUE));

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_LIGHT1);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }

        /// <summary>
        /// The current rotation.
        /// </summary>
        private float rotation = 0.0f;
        private SharpGLController.ViewController viewController;
        private SharpGL.SceneGraph.Assets.Texture texture;
        private IntPtr ptrBall;

        private void SharpGLForm_Load(object sender, EventArgs e)
        {
            this.Text = "纹理星球 @ http://www.cnblogs.com/bitzhuwei";
            this.viewController = new SharpGLController.ViewController(this.openGLControl);
            this.viewController.Start();
        }

                            
        private void lblTextureImage_Click(object sender, EventArgs e)
        {
            if (openTextureImage.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                UpdateTextureImage(openTextureImage.FileName);
            }
        }

        private void UpdateTextureImage(string filename)
        {
            var gl = this.openGLControl.OpenGL;
            if (this.texture != null)
            {
                this.texture.Destroy(gl);
                this.texture.Create(gl, filename);
                this.lblTextureImage.Text = (new FileInfo(filename)).Name;
            }
        }

        private void openGLControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void openGLControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var item = (string[])e.Data.GetData(DataFormats.FileDrop);
                UpdateTextureImage(item[0]);
            }
        }

        private void openGLControl_Load(object sender, EventArgs e)
        {

        }
    }
}
