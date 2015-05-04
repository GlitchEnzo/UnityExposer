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
                PropertyInfo propertyInfo = ActualType.GetPropertyAll("className");
                return propertyInfo.GetGetMethod().Invoke<string>();
            }
            set
            {
                PropertyInfo propertyInfo = ActualType.GetPropertyAll("className");
                propertyInfo.GetSetMethod().Invoke(new object[] { value });
            }
        }

        public static GameObject[] gameObjects
        {
            get
            {
                PropertyInfo propertyInfo = ActualType.GetPropertyAll("gameObjects");
                return propertyInfo.GetGetMethod().Invoke<GameObject[]>();
            }
            set
            {
                PropertyInfo propertyInfo = ActualType.GetPropertyAll("gameObjects");
                propertyInfo.GetSetMethod().Invoke(new object[] { value });
            }
        }

        static AddComponentWindow()
        {
            ActualType = Type.GetType("UnityEditor.AddComponentWindow, UnityEditor", true);
        }

        public static void ExecuteAddComponentMenuItem()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("ExecuteAddComponentMenuItem");
            methodInfo.Invoke();
        }

        public static bool Show(Rect rect, GameObject[] gos)
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("Show");
            return methodInfo.Invoke<bool>(new object[] { rect, gos });
        }

        public static bool ValidateAddComponentMenuItem()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("ValidateAddComponentMenuItem");
            return methodInfo.Invoke<bool>();
        }

        //public void OnGUI()
        //{
        //    MethodInfo methodInfo = ActualType.GetMethodAll("OnGUI");
        //    methodInfo.Invoke(Instance);
        //}
    }
}