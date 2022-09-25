using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Utils
{
    class GuiUtils
    {

        public class CenteredEditorStyles : IDisposable
        {
            public CenteredEditorStyles()
            {
                EditorStyles.textField.alignment = TextAnchor.MiddleCenter;
                EditorStyles.numberField.alignment = TextAnchor.MiddleCenter;
            }

            public void Dispose()
            {
                EditorStyles.textField.alignment = TextAnchor.UpperLeft;
                EditorStyles.numberField.alignment = TextAnchor.UpperLeft;
            }
        }

        public class EditorLabelWidth : IDisposable
        {
            private float width;

            public EditorLabelWidth(float width = 10)
            {
                this.width = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = width;
            }

            public void Dispose()
            {
                EditorGUIUtility.labelWidth = width;
            }
        }

        public class EditorFieldMinWidth : IDisposable
        {
            private float oldWidth;

            public EditorFieldMinWidth(Rect pos, float width = 10)
            {
                this.oldWidth = EditorGUIUtility.labelWidth;
                if (pos.width - EditorGUIUtility.labelWidth < width)
                    EditorGUIUtility.labelWidth = pos.width - width;
            }

            public void Dispose()
            {
                EditorGUIUtility.labelWidth = oldWidth;
            }
        }

        public class GuiColor : IDisposable
        {
            private Color oldCol;

            public GuiColor(Color color)
            {
                oldCol = GUI.color;
                GUI.color = color;
            }

            public void Dispose() => GUI.color = oldCol;
        }

        public class GuiBackgroundColor : IDisposable
        {
            private Color oldCol;

            public GuiBackgroundColor(Color color)
            {
                oldCol = GUI.backgroundColor;
                GUI.backgroundColor = color;
            }

            public void Dispose() => GUI.backgroundColor = oldCol;
        }

        public class GuiForceActive : IDisposable
        {
            private bool wasEnabled;

            public GuiForceActive()
            {
                wasEnabled = GUI.enabled;
                GUI.enabled = true;
            }

            public void Dispose() => GUI.enabled = wasEnabled;
        }
    }
}