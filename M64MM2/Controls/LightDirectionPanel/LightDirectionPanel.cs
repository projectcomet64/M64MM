using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using M64MM2.Helpers;
using Newtonsoft.Json.Linq;

namespace M64MM2.Controls.LightDirectionPanel
{
    public partial class LightDirectionPanel : UserControl
    {
        private Pen _boundingBoxPen = new Pen(Color.Black, 2f);
        private Brush _sunBrush = new SolidBrush(Color.Orange);
        private Brush _sunShadow = new SolidBrush(Color.DarkOrange);
        private Brush _objectSilhouette = new SolidBrush(Color.DarkSlateGray);
        private sbyte _lightX, _lightY, _lightZ;
        private bool _mouseHeld;

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public event EventHandler UserValueChange;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public event EventHandler ValueChange;

        public sbyte LightX
        {
            get => _lightX;
            set
            {
                _lightX = Math.Max(Math.Min(value, (sbyte)127), (sbyte)-128);
                Refresh();
                ValueChange?.Invoke(this, EventArgs.Empty);
            }
        }

        public sbyte LightY
        {
            get => _lightY;
            set
            {
                _lightY = Math.Max(Math.Min(value, (sbyte)127), (sbyte)-128);
                Refresh();
                ValueChange?.Invoke(this, EventArgs.Empty);
            }
        }

        public sbyte LightZ
        {
            get => _lightZ;
            set
            {
                _lightZ = Math.Max(Math.Min(value, (sbyte)127), (sbyte)-128);
                Refresh();
                ValueChange?.Invoke(this, EventArgs.Empty);
            }
        }

        public LightDirectionPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        public void SetLightDirection(sbyte x, sbyte y, sbyte z)
        {
            _lightX = x;
            _lightY = y;
            _lightZ = z;
            Refresh();
            ValueChange?.Invoke(this, EventArgs.Empty);
        }

        public void SetLightDirection(int x, int y, int z)
        {
            SetLightDirection((sbyte)Math.Max(Math.Min(x, (sbyte)127), (sbyte)-128),
                (sbyte)Math.Max(Math.Min(y, (sbyte)127), (sbyte)-128),
                (sbyte)Math.Max(Math.Min(z, (sbyte)127), (sbyte)-128));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction">Normalized Vector3 that points to where the light source is</param>
        public void SetLightDirection(Vector3 direction) {
            Vector3 dirNormal = Vector3.Normalize(direction);
            SetLightDirection(Math.Max((int) Math.Round(Math.Min(dirNormal.X * 128, (sbyte) 127)), (sbyte) -128),
                Math.Max((int) Math.Round(Math.Min(dirNormal.Y * 128, (sbyte) 127)), (sbyte) -128),
                Math.Max((int) Math.Round(Math.Min(dirNormal.Z * 128, (sbyte) 127)), (sbyte) -128));
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float fov = 0.5f;
            Graphics gfx = e.Graphics;
            gfx.Clear(BackColor);
            Vector3 tl = new Vector3(-Bounds.Width, -Bounds.Height, 1f);
            Vector3 br = new Vector3(Bounds.Width, Bounds.Height, 1f);
            Vector3 tr = new Vector3(br.X, tl.Y, 1f);
            Vector3 bl = new Vector3(tl.X, br.Y, 1f);

            PointF[] rectFace = new PointF[] {
                    VectorHelpers.WeakPerspective(tl, fov).ToPointF() +
                    new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2),
                    VectorHelpers.WeakPerspective(tr, fov).ToPointF() +
                    new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2),
                    VectorHelpers.WeakPerspective(br, fov).ToPointF() +
                    new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2),
                    VectorHelpers.WeakPerspective(bl, fov).ToPointF() +
                    new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2)
                };

            PointF[] backFace = new PointF[] {
                    VectorHelpers.WeakPerspective(tl + Vector3.UnitZ * 0.5f, fov).ToPointF() +
                    new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2),
                    VectorHelpers.WeakPerspective(tr + Vector3.UnitZ * 0.5f, fov).ToPointF() +
                    new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2),
                    VectorHelpers.WeakPerspective(br + Vector3.UnitZ * 0.5f, fov).ToPointF() +
                    new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2),
                    VectorHelpers.WeakPerspective(bl + Vector3.UnitZ * 0.5f, fov).ToPointF() +
                    new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2)
                };

            // Face at z = 1.5
            gfx.DrawPolygon(_boundingBoxPen, backFace);

            // Box projecting edges
            gfx.DrawLine(_boundingBoxPen, rectFace[0], backFace[0]);
            gfx.DrawLine(_boundingBoxPen, rectFace[1], backFace[1]);
            gfx.DrawLine(_boundingBoxPen, rectFace[2], backFace[2]);
            gfx.DrawLine(_boundingBoxPen, rectFace[3], backFace[3]);

            if (_lightZ < 0) {
                DrawSubject(gfx, fov);
                DrawSun(gfx, fov);
            }
            else {
                DrawSun(gfx, fov);
                DrawSubject(gfx, fov);
            }

            // Face at z = 1.1
            gfx.DrawPolygon(_boundingBoxPen, rectFace);
        }

        private void LightDirectionPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseHeld = true;
        }

        private void LightDirectionPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseHeld = false;
        }

        private void DrawSubject(Graphics gfx, float fov) {
            float subjectRadiusMult = ((128) / 255f) + 0.5f;

            PointF subjectPoint = VectorHelpers.WeakPerspective(new Vector3(0, 0, .25f), fov)
                .ToPointF();

            subjectPoint += new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2);

            gfx.FillEllipse(_objectSilhouette, subjectPoint.X - (15 / subjectRadiusMult), subjectPoint.Y - (15 / subjectRadiusMult),
                (15 / subjectRadiusMult) * 2, (15 / subjectRadiusMult) * 2);
        }

        private void DrawSun(Graphics gfx, float fov)
        {
            // Z = 0 == radius = 1x
            // Z = -128 == radius = 0.5x;
            // Z = 127 == radius = around 1.5x;
            float sunRadiusMult = ((_lightZ + 128) / 255f) + 0.5f;

            // Sun's radius in pixels (oh mama hi-dpi)
            const float SUN_RADIUS = 12;

            float responsiveX = ((_lightX / 128f) * (Bounds.Width));
            float responsiveY = ((_lightY / 128f) * (Bounds.Height));
            float responsiveZ = (((_lightZ + 128) / 256f) * (0.5f)) + 1f;
            PointF sunPoint = VectorHelpers.WeakPerspective(new Vector3(responsiveX, responsiveY, responsiveZ), fov)
                .ToPointF();

            PointF sunBottomPoint = VectorHelpers.WeakPerspective(new Vector3(responsiveX, Bounds.Height, responsiveZ), fov)
                .ToPointF();

            sunPoint += new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2);

            sunBottomPoint += new Size(Bounds.Size.Width / 2, Bounds.Size.Height / 2);

            gfx.FillEllipse(_sunBrush, sunPoint.X - (SUN_RADIUS / sunRadiusMult), sunPoint.Y - (SUN_RADIUS / sunRadiusMult),
                (SUN_RADIUS / sunRadiusMult) * 2, (SUN_RADIUS / sunRadiusMult) * 2);

            gfx.FillEllipse(_sunShadow, sunBottomPoint.X - (SUN_RADIUS / sunRadiusMult), sunBottomPoint.Y - (SUN_RADIUS / sunRadiusMult) * 0.25f,
                (SUN_RADIUS / sunRadiusMult) * 2, (SUN_RADIUS / sunRadiusMult) * 0.25f);

        }

        private void LightDirectionPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseHeld)
            {
                Point mousePt = e.Location;
                mousePt.X -= Width / 2;
                mousePt.Y -= Height / 2;
                Console.WriteLine(e.Location);
                _lightX = (sbyte)Math.Max(Math.Min((mousePt.X / (Width / 2f)) * 128, 127), -128);
                _lightY = (sbyte)Math.Max(Math.Min((mousePt.Y / (Height / 2f)) * 128, 127), -128);

                Refresh();
                ValueChange?.Invoke(this, EventArgs.Empty);
                UserValueChange?.Invoke(this, EventArgs.Empty);
            }

        }
    }
}
