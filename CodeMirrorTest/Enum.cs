using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeMirrorTest
{
    public enum TraversalType
    { 
        RFLA,
        FLAR,
        LARF,
        ARFL,
        LFRA
    }
    public enum FrameType
    {
        StanForward = 0,
        StanBackward = 1,
        StanLeft = 2,
        StanRight = 3,
        GeneralForward = 4,
        GeneralBackward = 5,
        GeneralLeft = 6,
        GeneralRight = 7,
    }
    public enum Direction
    { 
        F = 70,
        R = 82,
        L = 76,
        A = 65
    }
}
