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
        private sbyte _lightX, _lightY, _lightZ;
        private Point lastpoint;
        public sbyte LightX {
            get => _lightX;
            set
            {
                _lightX = Math.Max(Math.Min(value, (sbyte) 127), (sbyte) -128);
                Refresh();
            }
        }

        public sbyte LightY {
            get => _lightY;
            set
            {
                _lightY = Math.Max(Math.Min(value, (sbyte)127), (sbyte)-128);
                Refresh();
            }
        }

        public sbyte LightZ {
            get => _lightZ;
            set
            {
                _lightZ = Math.Max(Math.Min(value, (sbyte)127), (sbyte)-128);
                Refresh();
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

        public override void Refresh() {
            base.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float fov = 0.5f;
            Graphics gfx = e.Graphics;
                gfx.Clear(BackColor);
            gfx.DrawString(lastpoint.ToString(), Font, _sunBrush, 0, 0);
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

            DrawSun(gfx, fov);

            // Face at z = 1.1
            gfx.DrawPolygon(_boundingBoxPen, rectFace);

            

            
        }

        private void DrawSun(Graphics gfx, float fov) {
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

            sunPoint += new Size(Bounds.Size.Width/2, Bounds.Size.Height/2);

            gfx.FillEllipse(_sunBrush, sunPoint.X - (SUN_RADIUS / sunRadiusMult), sunPoint.Y - (SUN_RADIUS / sunRadiusMult),
                (SUN_RADIUS / sunRadiusMult)*2, (SUN_RADIUS / sunRadiusMult)*2);
            gfx.FillRectangle(_sunBrush, sunPoint.X, sunPoint.Y,
                (SUN_RADIUS / sunRadiusMult) * 2, (SUN_RADIUS / sunRadiusMult) * 2);
        }

        private void LightDirectionPanel_MouseMove(object sender, MouseEventArgs e) {
            Point mousePt = e.Location;
            lastpoint = e.Location;
            mousePt.X -= Width/2;
            mousePt.Y -= Height/2;



            _lightX = (sbyte)Math.Max(Math.Min((mousePt.X / (Width / 2f)) * 127, 127), -128);
            _lightY = (sbyte)Math.Max(Math.Min((mousePt.Y / (Width / 2f)) * 127, 127), -128);
            _lightZ = -128;
            Refresh();
        }
    }
}
