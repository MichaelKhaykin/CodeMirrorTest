using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeMirrorTest
{
    public static class StaticStuff
    {
        public static int CanvasWidth = 1526;

        public static int CanvasHeight = 730;

        #region LightBodySprites
        public static ElementReference WalkBodyAwayLight;
        public static ElementReference WalkBodyTowardLight;
        public static ElementReference WalkBodyRightLight;
        public static ElementReference WalkBodyLeftLight;
        #endregion

        #region MediumBodySprites
        public static ElementReference WalkBodyAwayMedium;
        public static ElementReference WalkBodyLeftMedium;
        public static ElementReference WalkBodyRightMedium;
        public static ElementReference WalkBodyTowardMedium;
        #endregion

        #region DarkBodySprites
        public static ElementReference WalkBodyAwayDark;
        public static ElementReference WalkBodyRightDark;
        public static ElementReference WalkBodyLeftDark;
        public static ElementReference WalkBodyTowardDark;
        #endregion
    }
}
