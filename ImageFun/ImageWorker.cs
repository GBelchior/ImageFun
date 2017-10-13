using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private Bitmap FBitmap1;
        private Bitmap FBitmap2;
        private int FIterationsDone;
        private int FTotalIterations;
        private Random FRandomSource;

        private int FBoundingRectangleWidth;
        private int FBoundingRectangleHeight;

        public Bitmap OriginalBitmap { get; }
        public Bitmap NewBitmap { get => (Bitmap)FBitmap1.Clone(); }

        public event ProgressChangedEventHandler ProgressChanged;
        public event EventHandler Done;

        public ImageWorker(Bitmap AOriginalBitmap, int ANumberOfIterations, int ABoundingRectangleWidth, int ABoundingRectangleHeight)
        {
            FCancellationTokenSource = new CancellationTokenSource();
            FCancellationToken = FCancellationTokenSource.Token;
            FImageColors = new List<Color>();
            FRandomSource = new Random();

            OriginalBitmap = new Bitmap(AOriginalBitmap);

            FIterationsDone = 0;
            FTotalIterations = ANumberOfIterations;

            FBoundingRectangleWidth = ABoundingRectangleWidth;
            FBoundingRectangleHeight = ABoundingRectangleHeight;
        }

        public void Start()
        {
            FBitmapProcessor = Task.Factory.StartNew(() =>
            {
                Initialize();

                try
                {
                    for (FIterationsDone = 0; FIterationsDone < FTotalIterations; ++FIterationsDone)
                    {
                        FCancellationToken.ThrowIfCancellationRequested();

                        DrawRandomCircle();

                        ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(FIterationsDone + 1, FTotalIterations));
                    }

                    Done?.Invoke(this, new EventArgs());
                }
                catch (OperationCanceledException)
                {
                    return;
                }
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
            FBitmap1 = new Bitmap(OriginalBitmap.Width, OriginalBitmap.Height, OriginalBitmap.PixelFormat);
            FBitmap2 = new Bitmap(OriginalBitmap.Width, OriginalBitmap.Height, OriginalBitmap.PixelFormat);

            // Preencho as 2 imagens temporárias de branco
            using (Graphics g1 = Graphics.FromImage(FBitmap1))
            using (Graphics g2 = Graphics.FromImage(FBitmap2))
            {
                g1.FillRectangle(Brushes.White, 0, 0, OriginalBitmap.Width, OriginalBitmap.Height);
                g2.FillRectangle(Brushes.White, 0, 0, OriginalBitmap.Width, OriginalBitmap.Height);
            }
        }
        private void DrawRandomCircle()
        {
            // Pego posições x e y aleatórias para desenhar na imagem
            int x = FRandomSource.Next(0, OriginalBitmap.Width);
            int y = FRandomSource.Next(0, OriginalBitmap.Height);

            // Pego uma cor aleatória da imagem
            Color color = FImageColors[FRandomSource.Next(0, FImageColors.Count)];

            // Desenho uma elipse na imagem
            using (Graphics g = Graphics.FromImage(FBitmap1))
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
            int points1 = 0;
            int points2 = 0;

            for (int x = 0; x < AWidth; x++)
            {
                for (int y = 0; y < AHeight; y++)
                {
                    if (AX + x < 0 ||
                        AX + x >= FBitmap1.Width ||
                        AY + y < 0 ||
                        AY + y >= FBitmap1.Height) continue;

                    Color c1 = FBitmap1.GetPixel(AX + x, AY + y);
                    Color c2 = FBitmap2.GetPixel(AX + x, AY + y);
                    Color cOrig = OriginalBitmap.GetPixel(AX + x, AY + y);

                    float hue1 = c1.GetHue();
                    float sat1 = c1.GetSaturation();
                    float bri1 = c1.GetBrightness();

                    float hue2 = c2.GetHue();
                    float sat2 = c2.GetSaturation();
                    float bri2 = c2.GetBrightness();

                    float hueorig = cOrig.GetHue();
                    float satorig = cOrig.GetSaturation();
                    float briorig = cOrig.GetBrightness();

                    double huesqr1 = Math.Pow(hue1 - hueorig, 2);
                    double satsqr1 = Math.Pow(sat1 - satorig, 2);
                    double brisqr1 = Math.Pow(bri1 - briorig, 2);

                    double huesqr2 = Math.Pow(hue2 - hueorig, 2);
                    double satsqr2 = Math.Pow(sat2 - satorig, 2);
                    double brisqr2 = Math.Pow(bri2 - briorig, 2);

                    // Calculo a distância euclidiana entre a cor da imagem 1 e da imagem original
                    double euclideanDistance1 = Math.Sqrt(huesqr1 + satsqr1 + brisqr1);

                    // Calculo a distância euclidiana entre a cor da imagem 2 e da imagem original
                    double euclideanDistance2 = Math.Sqrt(huesqr2 + satsqr2 + brisqr2);

                    // Se a distância das cores da imagem 1 for menor do que a da imagem 2,
                    // quer dizer que a imagem 1 tem uma cor mais similar a da original
                    if (euclideanDistance1 < euclideanDistance2) points1++;
                    else if (euclideanDistance2 < euclideanDistance1) points2++;
                }
            }

            Rectangle r = new Rectangle(AX, AY, AWidth, AHeight);

            // Se a imagem 1 é mais parecida com a original, eu copio a imagem 1 para a imagem 2
            if (points1 > points2)
            {
                using (Graphics g = Graphics.FromImage(FBitmap2))
                {
                    g.DrawImage(FBitmap1, r, r, GraphicsUnit.Pixel);
                }
            }
            // Senão, copio a imagem 2 para a imagem 1
            else if (points2 > points1)
            {
                using (Graphics g = Graphics.FromImage(FBitmap1))
                {
                    g.DrawImage(FBitmap2, r, r, GraphicsUnit.Pixel);
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
