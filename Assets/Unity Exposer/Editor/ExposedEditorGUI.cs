namespace UnityEditor.Exposer
{
    using UnityEngine;
    using System;
    using System.Reflection;

    public class ExposedEditorGUI
    {
        //private object Instance { get; set; }

        private static Type ActualType { get; set; }

        static ExposedEditorGUI()
        {
            ActualType = Type.GetType("UnityEditor.EditorGUI, UnityEditor", true);
        }

        public static bool ButtonMouseDown(Rect position, GUIContent content, FocusType focusType, GUIStyle style)
        {
            MethodInfo methodInfo = ActualType.GetMethod("ButtonMouseDown", BindingFlags.NonPublic | BindingFlags.Static, new[] { typeof(Rect), typeof(GUIContent), typeof(FocusType), typeof(GUIStyle) });
            return methodInfo.Invoke<bool>(new object[] { position, content, focusType, style });
        }
    }
}