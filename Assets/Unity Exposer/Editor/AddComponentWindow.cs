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
                return (string)propertyInfo.GetGetMethod().Invoke(null, null);
            }
            set
            {
                PropertyInfo propertyInfo = ActualType.GetProperty("className", BindingFlags.NonPublic | BindingFlags.Static);
                propertyInfo.GetSetMethod().Invoke(null, new object[] { value });
            }
        }

        public static GameObject[] gameObjects
        {
            get
            {
                PropertyInfo propertyInfo = ActualType.GetProperty("gameObjects", BindingFlags.NonPublic | BindingFlags.Static);
                return (GameObject[])propertyInfo.GetGetMethod().Invoke(null, null);
            }
            set
            {
                PropertyInfo propertyInfo = ActualType.GetProperty("gameObjects", BindingFlags.NonPublic | BindingFlags.Static);
                propertyInfo.GetSetMethod().Invoke(null, new object[] { value });
            }
        }

        static AddComponentWindow()
        {
            ActualType = Type.GetType("UnityEditor.AddComponentWindow, UnityEditor", true);
        }

        public static void ExecuteAddComponentMenuItem()
        {
            MethodInfo methodInfo = ActualType.GetMethod("ExecuteAddComponentMenuItem", BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo.Invoke(null, null);
        }

        public static bool Show(Rect rect, GameObject[] gos)
        {
            MethodInfo methodInfo = ActualType.GetMethod("Show", BindingFlags.NonPublic | BindingFlags.Static);
            return (bool)methodInfo.Invoke(null, new object[] { rect, gos });
        }

        public static bool ValidateAddComponentMenuItem()
        {
            MethodInfo methodInfo = ActualType.GetMethod("ValidateAddComponentMenuItem", BindingFlags.NonPublic | BindingFlags.Static);
            return (bool)methodInfo.Invoke(null, null);
        }

        //public void OnGUI()
        //{
        //    MethodInfo methodInfo = ActualType.GetMethod("OnGUI", BindingFlags.NonPublic | BindingFlags.Instance);
        //    methodInfo.Invoke(null, null);
        //}
    }
}