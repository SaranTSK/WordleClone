using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Wordle
{
    public static class WordleConstant
    {
        public static class Color
        {
            public static UnityEngine.Color darkGrey
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return new UnityEngine.Color(0.3f, 0.3f, 0.3f, 1f);
                }
            }

            public static UnityEngine.Color lightGrey
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return new UnityEngine.Color(0.7f, 0.7f, 0.7f, 1f);
                }
            }
        }
    }
}
