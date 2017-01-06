using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameConcepts;

namespace SharpGameEngine
{
    public partial class GameFrame : Form
    {
        private readonly BufferedGraphicsContext context;
        private BufferedGraphics _grafx;
        private readonly Timer _drawTimer;
        public event DrawSceneHandler DrawScene;
        public event KeyPressedHandler KeyPressed;

        public GameFrame()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Resize += new EventHandler(this.OnResize);
            _drawTimer = new Timer();
            _drawTimer.Interval = 200; // set timer to 200 ms (8-bit style)
            _drawTimer.Tick += new EventHandler(this.OnTimer);

            // Retrieves the BufferedGraphicsContext for the 
            // current application domain.
            context = BufferedGraphicsManager.Current;

            // Sets the maximum size for the primary graphics buffer
            // of the buffered graphics context for the application
            // domain.  Any allocation requests for a buffer larger 
            // than this will create a temporary buffered graphics 
            // context to host the graphics buffer.
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);

            // Allocates a graphics buffer the size of this form
            // using the pixel format of the Graphics created by 
            // the Form.CreateGraphics() method, which returns a 
            // Graphics object that matches the pixel format of the form.
            _grafx = context.Allocate(this.CreateGraphics(),
                 new Rectangle(0, 0, this.Width, this.Height));

            // Draw the first frame to the buffer.
            DrawToBuffer(_grafx.Graphics);

            _drawTimer.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            // Draw randomly positioned ellipses to the buffer.
            DrawToBuffer(_grafx.Graphics);

            this.Refresh();
        }

        private void OnResize(object sender, EventArgs e)
        {
            // Re-create the graphics buffer for a new window size.
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            if (_grafx != null)
            {
                _grafx.Dispose();
                _grafx = null;
            }
            _grafx = context.Allocate(this.CreateGraphics(),
                new Rectangle(0, 0, this.Width, this.Height));

            // Cause the background to be cleared and redraw.
            DrawToBuffer(_grafx.Graphics);
            this.Refresh();
        }

        private void DrawToBuffer(Graphics graphics)
        {
            // Clear the graphics buffer every five updates.
           _grafx.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);

            if (DrawScene != null)
                DrawScene(graphics);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _grafx.Render(e.Graphics);
        }

        private void GameFrame_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyPressed != null)
                KeyPressed(e);
        }
    }
}
