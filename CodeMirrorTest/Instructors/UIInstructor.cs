using Blazor.Extensions.Canvas.Canvas2D;
using BlazorCanvasLIB;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CodeMirrorTest
{
    public class UIInstructor
    {
        public Sprite[] Head { get; set; } = new Sprite[4];
        public AnimationSprite[] Body { get; set; } = new AnimationSprite[4];

        private int currentIndex = 0;
        public Rectangle Bounds { get; set; }

        private Vector2 scale;

        private List<AnimationFrame>[] frames;

        TimeSpan minTimeElapsed = TimeSpan.FromMilliseconds(1000);
        Stopwatch runner = new Stopwatch();

        Vector2[] speeds;

        float[] headWidths;
        float[] headHeights;

        private int offSet = 0;
        private int xOffSet = 0;
        public UIInstructor(Vector2 headPosition, float[] headWidth, float[] headHeight, Vector2 scale, OriginType originType, List<AnimationFrame>[] frames, TimeSpan updateTime, ElementReference[] head, ElementReference[] body, Vector2[] speeds, bool isStan = false)
        {
            this.scale = scale;
            this.frames = frames;
            this.speeds = speeds;

            this.headWidths = headWidth;
            this.headHeights = headHeight;

            if (isStan)
            {
                offSet = 10;
                xOffSet = 0;
            }
            else
            {
                offSet = 12;
                xOffSet = 0;
            }

            for (int i = 0; i < frames.Length; i++)
            {
                Head[i] = new Sprite(headPosition, (int)headWidth[i], (int)headHeight[i], scale, Rectangle.Empty, originType)
                {
                    Element = head[i]
                };
                var currHead = Head[i];
                Body[i] = new AnimationSprite(new Vector2(currHead.Position.X + xOffSet, currHead.Position.Y + currHead.ScaledHeight / 2 + frames[i][0].SourceRectangle.Height * scale.Y / 2 - offSet), scale, updateTime, frames[i], originType)
                {
                    Element = body[i]
                };
            }

            runner.Start();
        }

        private int TrueCounters(params bool[] stuffs)
        {
            return stuffs.Where(t => t).Count();
        }

        public async Task Update(Canvas2DContext context)
        {
            await Head[currentIndex].Update(context);
            await Body[currentIndex].Update(context);

            MoveBy(speeds[currentIndex].X, speeds[currentIndex].Y);

            var rightBound = Head[currentIndex].Position.X + Head[currentIndex].ScaledWidth / 2 > Bounds.Width;
            var bottomBound = Body[currentIndex].Position.Y + Body[currentIndex].ScaledHeight / 2 > Bounds.Height;
            var leftBound = Head[currentIndex].Position.X - Head[currentIndex].ScaledWidth / 2 < Bounds.X - 2;
            var topBound = Head[currentIndex].Position.Y - Head[currentIndex].ScaledHeight / 2 < Bounds.Y - 2;

            var count = TrueCounters(leftBound, rightBound, topBound, bottomBound);

            if (count == 1 && runner.ElapsedMilliseconds >= minTimeElapsed.TotalMilliseconds)
            {
                runner.Restart();

                Vector2 oldHeadPosition = Head[currentIndex].Position;

                currentIndex++;
                currentIndex %= Head.Length;

                var currHead = Head[currentIndex];

                if (rightBound)
                {
                    Head[currentIndex].Position = new Vector2(Bounds.Width - (headWidths[currentIndex] / 2) * scale.X, oldHeadPosition.Y);
                }
                else if (bottomBound)
                {
                    var highestHeight = 0;
                    foreach (var frame in frames[currentIndex])
                    {
                        if (frame.SourceRectangle.Height > highestHeight)
                        {
                            highestHeight = frame.SourceRectangle.Height;
                        }
                    }
                    float y = highestHeight * scale.Y - offSet + currHead.ScaledHeight / 2;
                    Head[currentIndex].Position = new Vector2(oldHeadPosition.X, Bounds.Height - y);
                }
                else if (leftBound)
                {
                    var highestHeight = 0;
                    foreach (var frame in frames[currentIndex])
                    {
                        if (frame.SourceRectangle.Height > highestHeight)
                        {
                            highestHeight = frame.SourceRectangle.Height;
                        }
                    }
                    float y = highestHeight * scale.Y - offSet + currHead.ScaledHeight / 2;
                    Head[currentIndex].Position = new Vector2(Bounds.X + headWidths[currentIndex] / 2 * scale.X, oldHeadPosition.Y);
                }
                else if (topBound)
                {
                    Head[currentIndex].Position = new Vector2(oldHeadPosition.X, Bounds.Y + headHeights[currentIndex] / 2 * scale.Y);
                }

                Body[currentIndex].Position = new Vector2(currHead.Position.X + xOffSet, currHead.Position.Y + currHead.ScaledHeight / 2 + frames[currentIndex][0].SourceRectangle.Height * scale.Y / 2 - offSet);
            }
        }
        public void MoveBy(float moveByX, float moveByY)
        {
            Head[currentIndex].Position += new Vector2(moveByX, moveByY);
            Body[currentIndex].Position += new Vector2(moveByX, moveByY);
        }

        public async Task Draw(Canvas2DContext context)
        {
            await Body[currentIndex].Draw(context);
            await Head[currentIndex].Draw(context);

            await context.BeginPathAsync();

            await context.StrokeRectAsync(Head[currentIndex].Position.X - Head[currentIndex].ScaledWidth / 2, Head[currentIndex].Position.Y - Head[currentIndex].ScaledHeight / 2, Head[currentIndex].ScaledWidth, Head[currentIndex].ScaledHeight + Body[currentIndex].SourceRectangle.Height * scale.Y);

            await context.ClosePathAsync();
        }
    }
}
