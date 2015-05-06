namespace UnityEditor.Exposer
{
    using UnityEngine;
    using System;
    using System.Reflection;

    public class LogEntries
    {
        private static Type ActualType { get; set; }

        static LogEntries()
        {
            ActualType = Type.GetType("UnityEditorInternal.LogEntries, UnityEditor", true);
        }

        public static int consoleFlags 
        {
            get
            {
                PropertyInfo propertyInfo = ActualType.GetPropertyAll("consoleFlags");
                return propertyInfo.GetGetMethod().Invoke<int>();
            }
            set
            {
                PropertyInfo propertyInfo = ActualType.GetPropertyAll("consoleFlags");
                propertyInfo.GetSetMethod().Invoke(new object[] { value });
            }
        }

        public static void RowGotDoubleClicked(int index)
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("RowGotDoubleClicked");
            methodInfo.Invoke(new object[] { index });
        }

        public static string GetStatusText()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("GetStatusText");
            return methodInfo.Invoke<string>();
        }

        public static int GetStatusMask()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("GetStatusMask");
            return methodInfo.Invoke<int>();
        }

        public static int StartGettingEntries()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("StartGettingEntries");
            return methodInfo.Invoke<int>();
        }

        public static void SetConsoleFlag(int bit, bool value)
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("SetConsoleFlag");
            methodInfo.Invoke(new object[] { bit, value });
        }

        public static void EndGettingEntries()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("EndGettingEntries");
            methodInfo.Invoke();
        }

        public static int GetCount()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("GetCount");
            return methodInfo.Invoke<int>();
        }

        public static void GetCountsByType(ref int errorCount, ref int warningCount, ref int logCount)
        {
            object[] parameters = {errorCount, warningCount, logCount};

            MethodInfo methodInfo = ActualType.GetMethodAll("GetCountsByType");
            methodInfo.Invoke(parameters);

            errorCount = (int)parameters[0];
            warningCount = (int)parameters[1];
            logCount = (int)parameters[2];
        }

        public static void GetFirstTwoLinesEntryTextAndModeInternal(int row, ref int mask, ref string outString)
        {
            object[] parameters = { row, mask, outString };

            MethodInfo methodInfo = ActualType.GetMethodAll("GetFirstTwoLinesEntryTextAndModeInternal");
            methodInfo.Invoke(parameters);

            mask = (int)parameters[1];
            outString = (string)parameters[2];
        }

        public static bool GetEntryInternal(int row, LogEntry outputEntry)
        {
            object[] parameters = { row, outputEntry };

            MethodInfo methodInfo = ActualType.GetMethodAll("GetEntryInternal");
            bool result = methodInfo.Invoke<bool>(parameters);

            outputEntry = (LogEntry)parameters[1];

            return result;
        }

        public static int GetEntryCount(int row)
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("GetEntryCount");
            return methodInfo.Invoke<int>(new object[] { row });
        }

        public static void Clear()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("Clear");
            methodInfo.Invoke();
        }

        public static int GetStatusViewErrorIndex()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("GetStatusViewErrorIndex");
            return methodInfo.Invoke<int>();
        }

        public static void ClickStatusBar(int count)
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("ClickStatusBar");
            methodInfo.Invoke(new object[] { count });
        }
    }
}