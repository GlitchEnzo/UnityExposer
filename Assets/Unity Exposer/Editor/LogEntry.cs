namespace UnityEditor.Exposer
{
    using System;
    using System.Reflection;

    public class LogEntry
    {
        private static Type ActualType { get; set; }

        private static object Instance { get; set; }

        public LogEntry()
        {
            ActualType = Type.GetType("UnityEditorInternal.LogEntry, UnityEditor", true);

            var constructorInfo = ActualType.GetConstructor(Type.EmptyTypes);

            Instance = constructorInfo.Invoke(null);
        }

        public LogEntry(object instance)
        {
            ActualType = Type.GetType("UnityEditorInternal.LogEntry, UnityEditor", true);

            Instance = instance;
        }

        public string condition
        {
            get
            {
                FieldInfo fieldInfo = ActualType.GetField("condition");
                return (string)fieldInfo.GetValue(Instance);
            }
            set
            {
                FieldInfo fieldInfo = ActualType.GetField("condition");
                fieldInfo.SetValue(Instance, value);
            }
        }

        public int errorNum
        {
            get
            {
                FieldInfo fieldInfo = ActualType.GetField("errorNum");
                return (int)fieldInfo.GetValue(Instance);
            }
            set
            {
                FieldInfo fieldInfo = ActualType.GetField("errorNum");
                fieldInfo.SetValue(Instance, value);
            }
        }

        public string file
        {
            get
            {
                FieldInfo fieldInfo = ActualType.GetField("file");
                return (string)fieldInfo.GetValue(Instance);
            }
            set
            {
                FieldInfo fieldInfo = ActualType.GetField("file");
                fieldInfo.SetValue(Instance, value);
            }
        }

        public int line
        {
            get
            {
                FieldInfo fieldInfo = ActualType.GetField("line");
                return (int)fieldInfo.GetValue(Instance);
            }
            set
            {
                FieldInfo fieldInfo = ActualType.GetField("line");
                fieldInfo.SetValue(Instance, value);
            }
        }

        public int mode
        {
            get
            {
                FieldInfo fieldInfo = ActualType.GetField("mode");
                return (int)fieldInfo.GetValue(Instance);
            }
            set
            {
                FieldInfo fieldInfo = ActualType.GetField("mode");
                fieldInfo.SetValue(Instance, value);
            }
        }

        public int instanceID
        {
            get
            {
                FieldInfo fieldInfo = ActualType.GetField("instanceID");
                return (int)fieldInfo.GetValue(Instance);
            }
            set
            {
                FieldInfo fieldInfo = ActualType.GetField("instanceID");
                fieldInfo.SetValue(Instance, value);
            }
        }

        public int identifier
        {
            get
            {
                FieldInfo fieldInfo = ActualType.GetField("identifier");
                return (int)fieldInfo.GetValue(Instance);
            }
            set
            {
                FieldInfo fieldInfo = ActualType.GetField("identifier");
                fieldInfo.SetValue(Instance, value);
            }
        }

        public int isWorldPlaying
        {
            get
            {
                FieldInfo fieldInfo = ActualType.GetField("isWorldPlaying");
                return (int)fieldInfo.GetValue(Instance);
            }
            set
            {
                FieldInfo fieldInfo = ActualType.GetField("isWorldPlaying");
                fieldInfo.SetValue(Instance, value);
            }
        }
    }
}