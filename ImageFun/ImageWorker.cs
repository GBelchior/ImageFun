using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace ImageFun
{
    public class ImageWorker : IDisposable
    {
        private Task FBitmapProcessor;

        private CancellationTokenSource FCancellationTokenSource;
        private CancellationToken FCancellationToken;

        private List<Color> FImageColors;
        private DirectBitmap FBitmap1;
        private DirectBitmap FBitmap2;
        private int FIterationsDone;
        private int FTotalIterations;
        private Random FRandomSource;

        private int FBoundingRectangleWidth;
        private int FBoundingRectangleHeight;

        private DateTime FStartProcess;
        private DateTime FEndProcess;

        public TimeSpan TimeElapsed { get => FEndProcess - FStartProcess; }

        public DirectBitmap OriginalBitmap { get; }
        public Bitmap NewBitmap { get => (Bitmap)FBitmap1.Bitmap.Clone(); }

        public event ProgressChangedEventHandler ProgressChanged;
        public event EventHandler Done;

        public ImageWorker(Bitmap AOriginalBitmap, int ANumberOfIterations, int ABoundingRectangleWidth, int ABoundingRectangleHeight)
        {
            FCancellationTokenSource = new CancellationTokenSource();
            FCancellationToken = FCancellationTokenSource.Token;
            FImageColors = new List<Color>();
            FRandomSource = new Random();

            OriginalBitmap = new DirectBitmap(AOriginalBitmap.Width, AOriginalBitmap.Height);

            using (Graphics g = Graphics.FromImage(OriginalBitmap.Bitmap))
            {
                g.DrawImage(AOriginalBitmap, 0, 0);
            }

            FIterationsDone = 0;
            FTotalIterations = ANumberOfIterations;

            FBoundingRectangleWidth = ABoundingRectangleWidth;
            FBoundingRectangleHeight = ABoundingRectangleHeight;
        }

        public void Start()
        {
            FStartProcess = DateTime.Now;

            FBitmapProcessor = Task.Factory.StartNew(() =>
            {
                Initialize();

                try
                {
                    for (FIterationsDone = 0; FIterationsDone < FTotalIterations; ++FIterationsDone)
                    {
                        FCancellationToken.ThrowIfCancellationRequested();

                        DrawRandomEllipse();

                        ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(FIterationsDone + 1, FTotalIterations));
                    }

                    FEndProcess = DateTime.Now;
                    Done?.Invoke(this, new EventArgs());
                }
                catch (OperationCanceledException)
                {
                    FEndProcess = DateTime.Now;
                    Done?.Invoke(this, new EventArgs());
                    return;
                }

                FEndProcess = DateTime.Now;
            }, FCancellationToken);
        }

        public void Stop()
        {
            FCancellationTokenSource.Cancel();
        }

        private void Initialize()
        {
            // Pego todas as cores da imagem original
            for (int x = 0; x < OriginalBitmap.Width; x++)
            {
                for (int y = 0; y < OriginalBitmap.Height; y++)
                {
                    FImageColors.Add(OriginalBitmap.GetPixel(x, y));
                }
            }

            // Inicializo minhas 2 imagens temporárias
            FBitmap1 = new DirectBitmap(OriginalBitmap.Width, OriginalBitmap.Height);
            FBitmap2 = new DirectBitmap(OriginalBitmap.Width, OriginalBitmap.Height);

            // Preencho as 2 imagens temporárias de branco
            using (Graphics g1 = Graphics.FromImage(FBitmap1.Bitmap))
            using (Graphics g2 = Graphics.FromImage(FBitmap2.Bitmap))
            {
                g1.FillRectangle(Brushes.White, 0, 0, OriginalBitmap.Width, OriginalBitmap.Height);
                g2.FillRectangle(Brushes.White, 0, 0, OriginalBitmap.Width, OriginalBitmap.Height);
            }

            Rectangle imageRect = new Rectangle(0, 0, OriginalBitmap.Width, OriginalBitmap.Height);
        }
        private void DrawRandomEllipse()
        {
            // Pego posições x e y aleatórias para desenhar na imagem
            int x = FRandomSource.Next(0, OriginalBitmap.Width - 1);
            int y = FRandomSource.Next(0, OriginalBitmap.Height - 1);

            int x2 = x + 80 >= OriginalBitmap.Width ? OriginalBitmap.Width - 1 : x + 80;
            int y2 = y - 40 < 0 ? 0 : y - 40;

            // Pego uma cor aleatória da imagem
            Color color = FImageColors[FRandomSource.Next(0, FImageColors.Count)];

            // Desenho uma elipse na imagem
            using (Graphics g = Graphics.FromImage(FBitmap1.Bitmap))
            using (SolidBrush b = new SolidBrush(color))
            {
                g.FillEllipse(b, x, y, FBoundingRectangleWidth, FBoundingRectangleHeight);
            }

            // Comparo os resultados
            CompareImages(
                x - FBoundingRectangleWidth / 2,
                y - FBoundingRectangleHeight / 2,
                FBoundingRectangleWidth,
                FBoundingRectangleHeight
            );
        }

        private void CompareImages(int AX, int AY, int AWidth, int AHeight)
        {
            double sumEuclideanDist1 = 0;
            double sumEuclideanDist2 = 0;
            int numPixels = AWidth * AHeight;

            if (AX < 0) AX = 0;
            if (AY < 0) AY = 0;

            for (int x = 0; x < AWidth; x++)
            {
                for (int y = 0; y < AHeight; y++)
                {
                    if (AX + x >= FBitmap1.Width ||
                        AY + y >= FBitmap1.Height) continue;

                    Color c1 = FBitmap1.GetPixel(AX + x, AY + y);
                    Color c2 = FBitmap2.GetPixel(AX + x, AY + y);
                    Color cOrig = OriginalBitmap.GetPixel(AX + x, AY + y);

                    double redsqr1 = Math.Pow(c1.R - cOrig.R, 2);
                    double gresqr1 = Math.Pow(c1.G - cOrig.G, 2);
                    double blusqr1 = Math.Pow(c1.B - cOrig.B, 2);

                    double redsqr2 = Math.Pow(c2.R - cOrig.R, 2);
                    double gresqr2 = Math.Pow(c2.G - cOrig.G, 2);
                    double blusqr2 = Math.Pow(c2.B - cOrig.B, 2);

                    //Calculo a distância euclidiana entre a cor da imagem 1 e da imagem original
                    sumEuclideanDist1 += Math.Sqrt(redsqr1 + gresqr1 + blusqr1);

                    //Calculo a distância euclidiana entre a cor da imagem 2 e da imagem original
                    sumEuclideanDist2 += Math.Sqrt(redsqr2 + gresqr2 + blusqr2);
                }
            }

            // Faço a média das distâncias
            sumEuclideanDist1 /= numPixels;
            sumEuclideanDist2 /= numPixels;

            Rectangle r = new Rectangle(AX, AY, AWidth, AHeight);

            // Se a imagem 1 é mais parecida com a original, eu copio a imagem 1 para a imagem 2
            if (sumEuclideanDist1 < sumEuclideanDist2)
            {
                using (Graphics g = Graphics.FromImage(FBitmap2.Bitmap))
                using (GraphicsPath p = new GraphicsPath())
                {
                    p.AddEllipse(r);
                    g.SetClip(p);
                    g.DrawImage(FBitmap1.Bitmap, r, r, GraphicsUnit.Pixel);
                }
            }
            // Senão, copio a imagem 2 para a imagem 1
            else
            {
                using (Graphics g = Graphics.FromImage(FBitmap1.Bitmap))
                using (GraphicsPath p = new GraphicsPath())
                {
                    p.AddEllipse(r);
                    g.SetClip(p);
                    g.DrawImage(FBitmap2.Bitmap, r, r, GraphicsUnit.Pixel);
                }
            }
        }

        public void Dispose()
        {
            OriginalBitmap.Dispose();
            NewBitmap.Dispose();
            FCancellationTokenSource.Cancel();
            FCancellationTokenSource.Dispose();
            FBitmapProcessor.Dispose();
        }
    }

    public class ProgressChangedEventArgs : EventArgs
    {
        public int IterationsDone { get; set; }
        public int TotalIterations { get; set; }

        public ProgressChangedEventArgs(int AIterationsDone, int ATotalIterations)
        {
            IterationsDone = AIterationsDone;
            TotalIterations = ATotalIterations;
        }
    }

    public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);
}
