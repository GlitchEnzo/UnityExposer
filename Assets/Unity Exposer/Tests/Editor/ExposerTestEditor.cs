using System.Collections.Generic;
using UnityEngine;

namespace UnityExposer.Tests
{
    using UnityEditor;
    using UnityEditor.Exposer;

    [CustomEditor(typeof(ExposerTest))]
    [CanEditMultipleObjects]
    public class ExposerTestEditor : Editor
    {
        private List<GameObject> gameObjects;

        public void OnEnable()
        {
            gameObjects = new List<GameObject>();
            foreach (var unityObject in targets)
            {
                gameObjects.Add(((ExposerTest)unityObject).gameObject);
            }
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            AddComponentButton();
        }

        private void AddComponentButton()
        {
            EditorGUILayout.BeginHorizontal();

            GUIContent content = new GUIContent("Add Component");

            Rect rect = GUILayoutUtility.GetRect(content, "LargeButton", null);
            rect.y += 10f;
            rect.x += (float)((rect.width - 230.0) / 2.0);
            rect.width = 230f;

            //if (Event.current.type == EventType.Repaint)
            //    this.DrawSplitLine(rect.y - 11f);

            Event current = Event.current;
            bool flag = false;
            if (current.type == EventType.ExecuteCommand && current.commandName == "OpenAddComponentDropdown")
            {
                flag = true;
                current.Use();
            }

            if ((ExposedEditorGUI.ButtonMouseDown(rect, content, FocusType.Passive, "LargeButton") || flag) && AddComponentWindow.Show(rect, gameObjects.ToArray()))
            //if ((GUI.Button(rect, content, "LargeButton") || flag) && AddComponentWindow.Show(rect, gameObjects.ToArray()))
                GUIUtility.ExitGUI();

            EditorGUILayout.EndHorizontal();

            // we need a little more space
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }
    }
}