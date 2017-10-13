using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFun
{
    public partial class Form1 : Form
    {
        private ImageWorker FImageWorker;

        private bool FOperating;
        private bool Operating
        {
            get => FOperating;
            set
            {
                if (value)
                {
                    nudIterations.ReadOnly = true;
                    nudEllipseX.ReadOnly = true;
                    nudEllipseY.ReadOnly = true;
                    txtFile.ReadOnly = true;
                    btnSearchImage.Enabled = false;
                    chkFast.Enabled = false;
                    chkFaster.Enabled = false;

                    Image LOriginalImage = Image.FromFile(txtFile.Text);

                    picOriginal.BackgroundImage = LOriginalImage;

                    int LQtdTotalIterations = Convert.ToInt32(nudIterations.Value);
                    int LEllipseX = Convert.ToInt32(nudEllipseX.Value);
                    int LEllipseY = Convert.ToInt32(nudEllipseY.Value);

                    FImageWorker?.Dispose();
                    FImageWorker = new ImageWorker((Bitmap)LOriginalImage, LQtdTotalIterations, LEllipseX, LEllipseY);
                    if (!chkFaster.Checked) FImageWorker.ProgressChanged += OnProgressChanged;
                    FImageWorker.Done += OnDone;

                    lblIterations.Text = $"0 / {LQtdTotalIterations}";
                    prgIterations.Maximum = LQtdTotalIterations;
                    prgIterations.Value = 0;

                    prgIterations.Visible = true;

                    FImageWorker.Start();

                    btnStart.Text = "STOP";
                }
                else
                {
                    FImageWorker.Stop();

                    nudIterations.ReadOnly = false;
                    nudEllipseX.ReadOnly = false;
                    nudEllipseY.ReadOnly = false;
                    txtFile.ReadOnly = false;
                    btnSearchImage.Enabled = true;

                    prgIterations.Visible = false;

                    chkFast.Enabled = true;
                    chkFaster.Enabled = true;

                    btnStart.Text = "START";
                }

                FOperating = value;
            }
        }

        private void OnDone(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                picCreated.BackgroundImage = FImageWorker.NewBitmap;
                lblIterations.Text = $"Took {FImageWorker.TimeElapsed:hh\\:mm\\:ss\\.fff}";
                Operating = false;
            }));
        }

        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblIterations.Text = $"{e.IterationsDone} / {e.TotalIterations}";
                prgIterations.Value = e.IterationsDone;
                if (!chkFast.Checked) picCreated.BackgroundImage = FImageWorker.NewBitmap;

                if (e.IterationsDone == e.TotalIterations)
                {
                    Operating = false;
                    picCreated.BackgroundImage = FImageWorker.NewBitmap;
                }

                if (!chkFast.Checked) Application.DoEvents();
            }));
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
                picOriginal.BackgroundImage = Image.FromFile(txtFile.Text);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Operating = !Operating;
        }
    }
}
