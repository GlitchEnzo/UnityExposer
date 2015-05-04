namespace UnityEditor.Exposer
{
    using UnityEngine;
    using System;
    using System.Reflection;

    public class AddComponentWindow
    {
        private static Type ActualType { get; set; }

        public static string className
        {
            get
            {
                PropertyInfo propertyInfo = ActualType.GetProperty("className", BindingFlags.NonPublic | BindingFlags.Static);
                return propertyInfo.GetGetMethod().Invoke<string>();
            }
            set
            {
                PropertyInfo propertyInfo = ActualType.GetProperty("className", BindingFlags.NonPublic | BindingFlags.Static);
                propertyInfo.GetSetMethod().Invoke(new object[] { value });
            }
        }

        public static GameObject[] gameObjects
        {
            get
            {
                PropertyInfo propertyInfo = ActualType.GetProperty("gameObjects", BindingFlags.NonPublic | BindingFlags.Static);
                return propertyInfo.GetGetMethod().Invoke<GameObject[]>();
            }
            set
            {
                PropertyInfo propertyInfo = ActualType.GetProperty("gameObjects", BindingFlags.NonPublic | BindingFlags.Static);
                propertyInfo.GetSetMethod().Invoke(new object[] { value });
            }
        }

        static AddComponentWindow()
        {
            ActualType = Type.GetType("UnityEditor.AddComponentWindow, UnityEditor", true);
        }

        public static void ExecuteAddComponentMenuItem()
        {
            MethodInfo methodInfo = ActualType.GetMethod("ExecuteAddComponentMenuItem", BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo.Invoke();
        }

        public static bool Show(Rect rect, GameObject[] gos)
        {
            MethodInfo methodInfo = ActualType.GetMethod("Show", BindingFlags.NonPublic | BindingFlags.Static);
            return methodInfo.Invoke<bool>(new object[] { rect, gos });
        }

        public static bool ValidateAddComponentMenuItem()
        {
            MethodInfo methodInfo = ActualType.GetMethod("ValidateAddComponentMenuItem", BindingFlags.NonPublic | BindingFlags.Static);
            return methodInfo.Invoke<bool>();
        }

        //public void OnGUI()
        //{
        //    MethodInfo methodInfo = ActualType.GetMethod("OnGUI", BindingFlags.NonPublic | BindingFlags.Instance);
        //    methodInfo.Invoke(Instance);
        //}
    }
}