using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;
using Newtonsoft.Json;

namespace SpriteSheetLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop, false));
            var img = new Bitmap(Image.FromFile(files[0]));
            var pixelFormat = img.PixelFormat;
            int startX = 144;
            int startY = 162;

            int xIncrement = 180;
            int yIncrement = 210;

            List<Data> datas = new List<Data>();
            while (startY <= 372)
            {
                datas.Add(GetFrame(img, startX, startY, startX + (int)(xIncrement * (0.72)), startY + (int)(yIncrement * (0.72))));
                startX += xIncrement;
                if(startX > 1404)
                {
                    startX = 144;
                    startY += yIncrement;
                }
            }

            var str = JsonConvert.SerializeObject(datas);
            System.IO.File.WriteAllText(@"C:\Users\Michael Khaykin\source\repos\CodeMirrorTest\CodeMirrorTest\JSONData\WalkBodyAway.json", str);
            ;
        }

        private Data GetFrame(Bitmap img, int startX, int startY, int maxWidth, int maxHeight)
        {
            float xOrigin = 0;
            float yOrigin;
            int calculatedWidth = 0;
            int calculatedHeight = 0;

            for (int j = startY; j < maxHeight; j++)
            {
                int amountOfPixelsInThisLine = 0;
                int firstIndexOfPixelInLine = 0;
                bool didIncrementHeight = false;

                for (int i = startX; i < maxWidth; i++)
                {
                    var color = img.GetPixel(i, j);
                    if(color != Color.FromArgb(0, 0, 0, 0))
                    {
                        if(i >= calculatedWidth)
                        {
                            calculatedWidth = i + 1;
                        }

                        if(amountOfPixelsInThisLine == 0)
                        {
                            firstIndexOfPixelInLine = i;
                        }
                        amountOfPixelsInThisLine++;

                        if (!didIncrementHeight)
                        {
                            calculatedHeight++;
                            didIncrementHeight = true;
                        }
                    }
                }

                if(j == startY)
                {
                    xOrigin = firstIndexOfPixelInLine + (float)amountOfPixelsInThisLine / 2;
                }
            }

            xOrigin -= startX;
            calculatedWidth -= startX;
            yOrigin = calculatedHeight / 2;

            return new Data(new Rectangle(startX, startY, calculatedWidth, calculatedHeight), new Vector2(xOrigin, yOrigin));
        }
    }
}
