using aplimat_labs.Utilities;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
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


namespace aplimat_labs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private CubeMesh lightCube = new CubeMesh()
        {
            Position = new Vector3(-25, 0, 0)
        };

        private CubeMesh heavyCube = new CubeMesh()
        {
            Position = new Vector3(-25, -5, 0),
            Mass = 3
        };
        private CubeMesh leadCube = new CubeMesh()
        {
            Position = new Vector3(-25, 5, 0),
            Mass = 10
        };

        private Vector3 gravity = new Vector3(0, -0.05f, 0);
        private Vector3 wind = new Vector3(0.05f, 0, 0);

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
#region UpdateStart
            OpenGL gl = args.OpenGL;

            // Clear The Screen And The Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Move Left And Into The Screen
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -40.0f);
            #endregion
            //Draw and Color
            gl.Color(1.0, 0.0, 0.0);
            lightCube.Draw(gl);
            gl.Color(0.0, 1.0, 0.0);
            heavyCube.Draw(gl);
            gl.Color(0.0, 0.0, 1.0);
            leadCube.Draw(gl);

            //Apply Gravity
            lightCube.ApplyForce(gravity);
            heavyCube.ApplyForce(gravity);
            leadCube.ApplyForce(gravity);

            //Apply Wind
            lightCube.ApplyForce(wind);
            heavyCube.ApplyForce(wind);
            leadCube.ApplyForce(wind);

            //LightCube Border Checks
            if (lightCube.Position.x >= 25)
            {
                lightCube.BounceX();
            }
            if (lightCube.Position.y <= -15)
            {
                lightCube.BounceY();
            }
            //HeavyCube Border Checks
            if (heavyCube.Position.x >= 25)
            {
                heavyCube.BounceX();
            }
            if (heavyCube.Position.y <= -15)
            {
                heavyCube.BounceY();
            }
            //Lead Cube Border Checks
            if (leadCube.Position.x >= 25)
            {
                leadCube.BounceX();
            }
            if (leadCube.Position.y <= -15)
            {
                leadCube.BounceY();
            }
        }
#region OpenGLInit

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_LIGHT0);

            gl.ShadeModel(OpenGL.GL_SMOOTH);
        }
        #endregion

#region MouseControl
        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {           
        }
        #endregion
    }
}
