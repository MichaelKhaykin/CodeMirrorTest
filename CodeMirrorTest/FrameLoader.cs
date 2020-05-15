using BlazorCanvasLIB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CodeMirrorTest
{
    public static class FrameLoader
    {
        public static List<AnimationFrame> Load(FrameType type, Vector2 scale)
        {
            switch (type)
            {
                case FrameType.StanForward:
                    return CreateStanForwardWalkingRect(scale);
                case FrameType.StanBackward:
                    return CreateStanBackWalkingRect(scale);
                case FrameType.StanLeft:
                    return CreateStanLeftWalkingRect(scale);
                case FrameType.StanRight:
                    return CreateStanRightWalkingRect(scale);
                case FrameType.GeneralForward:
                    return CreateGenericBodyForwardWalkingRect(scale);
                case FrameType.GeneralBackward:
                    return CreateGenericBodyBackWalkingRect(scale);
                case FrameType.GeneralRight:
                    return CreateGenericBodyRightWalkingRect(scale);
                case FrameType.GeneralLeft:
                    return CreateGenericBodyLeftWalkingRect(scale);
            }

            return null;
        }

        private static List<AnimationFrame> CreateGenericBodyRightWalkingRect(Vector2 scale)
        {
            List<AnimationFrame> rect = new List<AnimationFrame>();

            var data = System.IO.File.ReadAllText(@"C:\Users\Michael Khaykin\source\repos\CodeMirrorTest\CodeMirrorTest\JSONData\WalkBodyRight.json");
            var list = JsonConvert.DeserializeObject<List<Data>>(data);

            foreach (var item in list)
            {
                rect.Add(new AnimationFrame(item.Rectangle, scale, item.Origin, false));
            }

            return rect;
        }
        private static List<AnimationFrame> CreateGenericBodyForwardWalkingRect(Vector2 scale)
        {
            List<AnimationFrame> rect = new List<AnimationFrame>();

            var data = System.IO.File.ReadAllText(@"C:\Users\Michael Khaykin\source\repos\CodeMirrorTest\CodeMirrorTest\JSONData\WalkBodyToward.json");
            var list = JsonConvert.DeserializeObject<List<Data>>(data);

            foreach (var item in list)
            {
                rect.Add(new AnimationFrame(item.Rectangle, scale, item.Origin, false));
            }

            return rect;
        }
        private static List<AnimationFrame> CreateGenericBodyLeftWalkingRect(Vector2 scale)
        {
            List<AnimationFrame> rect = new List<AnimationFrame>();

            var data = System.IO.File.ReadAllText(@"C:\Users\Michael Khaykin\source\repos\CodeMirrorTest\CodeMirrorTest\JSONData\WalkBodyLeft.json");
            var list = JsonConvert.DeserializeObject<List<Data>>(data);

            foreach (var item in list)
            {
                rect.Add(new AnimationFrame(item.Rectangle, scale, item.Origin, false));
            }

            return rect;
        }
        private static List<AnimationFrame> CreateGenericBodyBackWalkingRect(Vector2 scale)
        {
            List<AnimationFrame> rect = new List<AnimationFrame>();

            var data = System.IO.File.ReadAllText(@"C:\Users\Michael Khaykin\source\repos\CodeMirrorTest\CodeMirrorTest\JSONData\WalkBodyAway.json");
            var list = JsonConvert.DeserializeObject<List<Data>>(data);

            foreach (var item in list)
            {
                rect.Add(new AnimationFrame(item.Rectangle, scale, item.Origin, false));
            }
            return rect;
        }
        private static List<AnimationFrame> CreateStanRightWalkingRect(Vector2 scale)
        {
            List<AnimationFrame> rects = new List<AnimationFrame>();

            //FIRST LINE
            rects.Add(new AnimationFrame(new Rectangle(144, 162, 74, 132), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(324, 162, 71, 132), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(504, 162, 71, 131), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(684, 162, 71, 129), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(864, 162, 75, 129), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(1044, 162, 80, 129), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(1224, 162, 86, 132), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(1404, 162, 89, 133), scale, Vector2.Zero, true));

            //SECOND LINE
            rects.Add(new AnimationFrame(new Rectangle(144, 372, 91, 133), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(324, 372, 89, 133), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(504, 372, 86, 132), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(684, 372, 80, 132), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(864, 372, 75, 129), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(864, 372, 71, 129), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(1044, 372, 71, 131), scale, Vector2.Zero, true));
            rects.Add(new AnimationFrame(new Rectangle(1404, 372, 71, 132), scale, Vector2.Zero, true));

            return rects;
        }
        private static List<AnimationFrame> CreateStanForwardWalkingRect(Vector2 scale)
        {
            List<AnimationFrame> rect = new List<AnimationFrame>();

            rect.Add(new AnimationFrame(new Rectangle(144, 162, 110, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(324, 162, 112, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(504, 162, 118, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(684, 162, 121, 129), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(864, 162, 123, 130), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1044, 162, 123, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1224, 162, 118, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1404, 162, 113, 133), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(144, 372, 112, 135), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(324, 372, 113, 133), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(504, 372, 118, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(684, 372, 123, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(864, 372, 123, 130), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1044, 372, 121, 129), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1224, 372, 118, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1404, 372, 112, 131), scale, Vector2.Zero, true));

            return rect;
        }
        private static List<AnimationFrame> CreateStanLeftWalkingRect(Vector2 scale)
        {
            List<AnimationFrame> rect = new List<AnimationFrame>();

            //FIRST LINE
            rect.Add(new AnimationFrame(new Rectangle(144, 162, 73, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(324, 162, 72, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(504, 162, 71, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(684, 162, 71, 129), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(864, 162, 74, 129), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1044, 162, 80, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1224, 162, 86, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1404, 162, 89, 133), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(144, 372, 92, 133), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(324, 372, 89, 133), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(504, 372, 86, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(684, 372, 80, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(864, 372, 74, 129), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1044, 372, 71, 129), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1224, 372, 71, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1404, 372, 72, 132), scale, Vector2.Zero, true));

            return rect;
        }
        private static List<AnimationFrame> CreateStanBackWalkingRect(Vector2 scale)
        {
            List<AnimationFrame> rect = new List<AnimationFrame>();

            //FIRST LINE
            rect.Add(new AnimationFrame(new Rectangle(144, 162, 111, 133), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(324, 162, 112, 132), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(504, 162, 118, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(684, 162, 122, 128), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(864, 162, 123, 126), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1044, 162, 122, 128), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1224, 162, 118, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1404, 162, 113, 133), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(144, 372, 113, 134), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(324, 372, 113, 133), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(504, 372, 118, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(684, 372, 122, 128), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(864, 372, 123, 126), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1044, 372, 122, 128), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1224, 372, 118, 131), scale, Vector2.Zero, true));
            rect.Add(new AnimationFrame(new Rectangle(1404, 372, 112, 132), scale, Vector2.Zero, true));

            return rect;
        }
    }
}
