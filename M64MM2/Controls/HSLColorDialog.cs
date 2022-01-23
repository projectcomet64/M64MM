using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static M64MM.Utils.ColorSpace;

namespace M64MM2.Controls
{
    public partial class HSLColorDialog : Form
    {
        private List<Color> _colorGrad = new List<Color>();
        private List<PointF> _circlee = new List<PointF>();
        public HSLColorDialog()
        {
            InitializeComponent();
            HSV genesis = HSV.Identity;
            for (int i = 0; i < 360; i += 5)
            {
                double angle = Math.PI * i / 180;
                _circlee.Add(new PointF((float)pnlColorWheel.Width / 2 + (float)Math.Cos(angle) * pnlColorWheel.Width / 2, 
                    (float)pnlColorWheel.Height / 2 + (float)Math.Sin(angle) * pnlColorWheel.Height / 2));
            }
        }
    }
}
