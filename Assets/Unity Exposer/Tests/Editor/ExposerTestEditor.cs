using System.Collections.Generic;
using UnityEditorInternal;
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

        private PreviewRenderUtility preview;

        private Mesh sphere;

        private Vector2 previewDirection = new Vector2();

        private Material material;

        static Mesh GetPreviewSphere()
        {
            GameObject gameObject = (GameObject)EditorGUIUtility.LoadRequired("Previews/PreviewMaterials.fbx");

            gameObject.SetActive(false);
            foreach (Transform transform in gameObject.transform)
            {
                if (transform.name == "sphere")
                    return transform.GetComponent<MeshFilter>().sharedMesh;
            }
            return null;
        }

        public void OnEnable()
        {
            preview = new PreviewRenderUtility();
            preview.m_CameraFieldOfView = 30f;

            sphere = GetPreviewSphere();

            //material = new Material(Shader.Find("Mobile/Diffuse"));
            material = EditorGUIUtility.LoadRequired("Previews/Preview3DTextureMaterial.mat") as Material;

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

            //preview.DrawMesh(sphere, Matrix4x4.identity, new Material(Shader.Find("Mobile/Diffuse")), 0);
            OnPreviewGUI(GUILayoutUtility.GetRect(500, 500), GUIStyle.none);
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            //Debug.Log("OnPreviewGUI");

            //preview.BeginPreview(r, background);
            //Bounds bounds = sphere.bounds;
            //float magnitude = bounds.extents.magnitude;
            //float num = 4f * magnitude;
            //preview.m_Camera.transform.position = -Vector3.forward * num;
            //preview.m_Camera.transform.rotation = Quaternion.identity;
            //preview.m_Camera.nearClipPlane = num - magnitude * 1.1f;
            //preview.m_Camera.farClipPlane = num + magnitude * 1.1f;
            //preview.m_Light[0].intensity = 1.4f;
            //preview.m_Light[0].transform.rotation = Quaternion.Euler(40f, 40f, 0.0f);
            //preview.m_Light[1].intensity = 1.4f;
            //Color ambient = new Color(0.1f, 0.1f, 0.1f, 0.0f);
            //InternalEditorUtility.SetCustomLighting(preview.m_Light, ambient);
            ////ModelInspector.RenderMeshPreviewSkipCameraAndLighting(mesh, bounds, previewUtility, litMaterial, wireMaterial, (MaterialPropertyBlock)null, direction, meshSubset);
            //InternalEditorUtility.RemoveCustomLighting();
            //Texture image = preview.EndPreview();
            //GUI.DrawTexture(r, image, ScaleMode.StretchToFill, false);

            previewDirection = PreviewGUI.Drag2D(previewDirection, r);
            if (Event.current.type != EventType.Repaint)
                return;
            material.mainTexture = this.target as Texture;
            preview.BeginPreview(r, background);
            bool fog = RenderSettings.fog;
            Unsupported.SetRenderSettingsUseFogNoDirty(false);
            preview.m_Camera.transform.position = -Vector3.forward * 3f;
            preview.m_Camera.transform.rotation = Quaternion.identity;
            preview.DrawMesh(sphere, Vector3.zero, Quaternion.Euler(previewDirection.y, 0.0f, 0.0f) * Quaternion.Euler(0.0f, previewDirection.x, 0.0f), material, 0);
            preview.m_Camera.Render();
            Unsupported.SetRenderSettingsUseFogNoDirty(fog);
            Texture image = preview.EndPreview();
            GUI.DrawTexture(r, image, ScaleMode.StretchToFill, false);
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