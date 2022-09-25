using System.Collections.Generic;
using UnityEngine;

namespace Editor.Utils
{
    public class DynamicStyles
    {
        private static Dictionary<GUIStyle, GUIStyle> _cachedRichTextStyles = new Dictionary<GUIStyle, GUIStyle>();
        
        public static GUIStyle RichTextOf(GUIStyle copyStyle)
        {
            if (_cachedRichTextStyles.ContainsKey(copyStyle))
            {
                return _cachedRichTextStyles[copyStyle];
            }
            
            _cachedRichTextStyles[copyStyle] = new GUIStyle(copyStyle)
            {
                richText = true
            };
            return _cachedRichTextStyles[copyStyle];
        }

        private static Dictionary<GUIStyle, GUIStyle> _cachedWordWrapStyles = new Dictionary<GUIStyle, GUIStyle>();
        public static GUIStyle WordWrapOf(GUIStyle copyStyle)
        {
            if (_cachedWordWrapStyles.ContainsKey(copyStyle))
            {
                return _cachedWordWrapStyles[copyStyle];
            }
            
            _cachedWordWrapStyles[copyStyle] = new GUIStyle(copyStyle)
            {
                wordWrap = true
            };
            return _cachedWordWrapStyles[copyStyle];
        }

        private static Dictionary<GUIStyle, GUIStyle> _cachedLeftAlignedStyles = new Dictionary<GUIStyle, GUIStyle>();
        public static GUIStyle LeftAlignedOf(GUIStyle copyStyle)
        {
            if (_cachedLeftAlignedStyles.ContainsKey(copyStyle))
            {
                return _cachedLeftAlignedStyles[copyStyle];
            }
            
            _cachedLeftAlignedStyles[copyStyle] = new GUIStyle(copyStyle)
            {
                alignment = TextAnchor.MiddleLeft
            };
            return _cachedLeftAlignedStyles[copyStyle];
        }
        
    }
}