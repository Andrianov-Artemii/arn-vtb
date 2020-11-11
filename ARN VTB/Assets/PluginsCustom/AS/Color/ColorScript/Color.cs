using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AS
{
    public class ASColor
    {

        const float maxRGB = 255f;

        public static Color black { get { return Color.black; } }
        public static Color Blue { get { return new Color(0 / maxRGB, 122 / maxRGB, 255 / maxRGB); } }
        public static Color Green { get { return new Color(52 / maxRGB, 199 / maxRGB, 89 / maxRGB); } }
        public static Color Indigo { get { return new Color(88 / maxRGB, 86 / maxRGB, 214 / maxRGB); } }
        public static Color Orange { get { return new Color(255 / maxRGB, 149 / maxRGB, 0 / maxRGB); } }
        public static Color Pink { get { return new Color(255 / maxRGB, 45 / maxRGB, 85 / maxRGB); } }
        public static Color Purple { get { return new Color(175 / maxRGB, 82 / maxRGB, 222 / maxRGB); } }
        public static Color Red { get { return new Color(255 / maxRGB, 59 / maxRGB, 48 / maxRGB); } }
        public static Color Teal { get { return new Color(90 / maxRGB, 200 / maxRGB, 250 / maxRGB); } }
        public static Color Yellow { get { return new Color(255 / maxRGB, 204 / maxRGB, 0 / maxRGB); } }
    }
}
