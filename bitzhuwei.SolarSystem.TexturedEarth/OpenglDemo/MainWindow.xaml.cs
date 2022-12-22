using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenglDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
            //int width = bmp.Width;
            //int height = bmp.Height;
            //openGL.ReadPixels(0, 0, width, height, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, bmdat.Scan0);
        }

        private byte[] Getpix(Bitmap bmp) {
            BitmapData bmdat = bmp.LockBits(new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size),
            ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);  // 锁定位图
            byte[] buffer = new byte[bmdat.Stride * bmdat.Height];  //缓冲区，用来装载位图数据
            Marshal.Copy(bmdat.Scan0, buffer, 0, buffer.Length);    //复制位图数据
            bmp.UnlockBits(bmdat);  // 解除锁定
            return buffer;
        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.WPF.OpenGLRoutedEventArgs args) {
            //OpenGL gl = args.OpenGL;
            //gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //gl.LoadIdentity();
            //gl.Color(1.0f, 1.0f, 1.0f, 1.0f);
            //gl.Begin(OpenGL.GL_TRIANGLES);
            //gl.TexCoord(0, 1.0f);
            //gl.Vertex(0.0f, 0.0f);
            //gl.TexCoord(1.0f, 0f);
            //gl.Vertex(1.0f, 0f);
            //gl.TexCoord(1.0f, 1.0f);
            //gl.Vertex(1.0f, 1.0f);
            //gl.End();

            //  Get the OpenGL object.
            OpenGL gl = args.OpenGL;
            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Load the identity matrix.
            gl.LoadIdentity();

            if (!TexturesInitialised) {
                InitialiseTexture(ref gl);//贴图片纹理
            }

            gl.Enable(OpenGL.GL_TEXTURE_2D);//开启2D纹理
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, gtexture[0]);//绑定
            gl.Color(1.0f, 1.0f, 1.0f, 0.1f);
            gl.Begin(OpenGL.GL_QUADS);//四边形

            gl.TexCoord(1.0f, 1.0f);
            gl.Vertex(gImage1.Width, gImage1.Height, 1.0f);

            gl.TexCoord(0.0f, 1.0f);
            gl.Vertex(0.0f, gImage1.Height, 1.0f);

            gl.TexCoord(0.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 1.0f);

            gl.TexCoord(1.0f, 0.0f);
            gl.Vertex(gImage1.Width, 0.0f, 1.0f);

            gl.End();
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Ortho(0.0, (double)gImage1.Width, (double)gImage1.Height, 0.0, -1.0, 1.0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.Disable(OpenGL.GL_DEPTH_TEST);
        }

        private bool TexturesInitialised = false;
        private Bitmap gImage1;
        private System.Drawing.Imaging.BitmapData gbitmapdata;
        private uint[] gtexture = new uint[1];

        private void InitialiseTexture(ref OpenGL gl) {
            gImage1 = new Bitmap(System.Drawing.Image.FromFile("A.bmp"));
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, gImage1.Width, gImage1.Height);
            gbitmapdata = gImage1.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            gImage1.UnlockBits(gbitmapdata);
            gl.GenTextures(1, gtexture);//创建纹理
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, gtexture[0]);//绑定纹理
            //一定注意OpenGL.GL_BGRA这个格式 和bmp图片一致的
            gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA, gImage1.Width, gImage1.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, gbitmapdata.Scan0);
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);

            TexturesInitialised = true;
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.WPF.OpenGLRoutedEventArgs args) {
            //var openGL = args.OpenGL;
            //Bitmap bmp = new Bitmap(System.Drawing.Image.FromFile("A.bmp"));  // 加载图像 
            //uint[] texture = new uint[1];
            //System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            //BitmapData gbitmapdata = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //bmp.UnlockBits(gbitmapdata);
            //openGL.GenTextures(1, texture);
            //openGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA, bmp.Width, bmp.Height, 0, OpenGL.GL_RGBA, OpenGL.GL_BYTE, gbitmapdata.Scan0);
            //openGL.BindTexture(OpenGL.GL_TEXTURE_2D, texture[0]);
            //openGL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);

            //Random rnd = new Random();
            //OpenGL gl = args.OpenGL;
            //gl.ClearColor(0, 0, 0, 0);

            //gl.Enable(OpenGL.GL_TEXTURE_2D);

            //byte[] colors = new byte[256 * 256 * 4];

            //for (int i = 0; i < 256 * 256 * 4; i++) {
            //    colors[i] = (byte)rnd.Next(256);
            //}

            //uint[] textureID = new uint[1];
            //gl.GenTextures(1, textureID);
            //gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA, 256, 256, 0, OpenGL.GL_RGBA, OpenGL.GL_BYTE, colors);
            //gl.BindTexture(OpenGL.GL_TEXTURE_2D, textureID[0]);
            //uint[] array = new uint[] { OpenGL.GL_NEAREST };
            //gl.TexParameterI(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, array);
            //gl.TexParameterI(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, array);
            //gl.Enable(OpenGL.GL_TEXTURE_2D);

            //  Get the OpenGL object.
            OpenGL gl = args.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
        }
    }
}
