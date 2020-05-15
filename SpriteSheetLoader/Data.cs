﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetLoader
{
    public class Data
    {
        public Rectangle Rectangle { get; set; }
        public Vector2 Origin { get; set; }

        public Data(Rectangle rect, Vector2 origin)
        {
            Rectangle = rect;
            Origin = origin;
        }
    }
}
