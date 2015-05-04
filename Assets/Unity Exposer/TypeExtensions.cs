// These extensions are placed in the global namespace to allow everything to access them.

using System;
using System.Reflection;

public static class TypeExtensions
{
    private const BindingFlags BindAll = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    /// <summary>
    /// Searches for the method with the given name whose parameters match the specified argument types, searching ALL access types (public, non-public, static, and instance).
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name">The string containing the name of the method to get.</param>
    /// <param name="types">An array of Type objects representing the number, order, and type of the parameters for the method to get. Use Type.EmptyTypes for no parameters.</param>
    /// <returns>An object representing the method that matches the specified requirements, if found; otherwise, null.</returns>
    public static MethodInfo GetMethodAll(this Type type, string name, Type[] types)
    {
        return type.GetMethod(name, BindAll, null, types, null);
    }

    /// <summary>
    /// Searches for a method with the given name, searching ALL access types (public, non-public, static, and instance).
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name">The name of the method to search for.</param>
    /// <returns></returns>
    public static MethodInfo GetMethodAll(this Type type, string name)
    {
        return type.GetMethod(name, BindAll);
    }

    /// <summary>
    /// Searches for a property with the given name, searching ALL access types (public, non-public, static, and instance).
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name">The name of the property to search for.</param>
    /// <returns></returns>
    public static PropertyInfo GetPropertyAll(this Type type, string name)
    {
        return type.GetProperty(name, BindAll);
    }

    /// <summary>
    /// Invokes a static method with no parameters and no return type.
    /// </summary>
    /// <param name="methodInfo"></param>
    public static void Invoke(this MethodInfo methodInfo)
    {
        methodInfo.Invoke(null, null);
    }

    /// <summary>
    /// Invokes a static method with the given parameters and no return type.
    /// </summary>
    /// <param name="methodInfo"></param>
    /// <param name="parameters"></param>
    public static void Invoke(this MethodInfo methodInfo, object[] parameters)
    {
        methodInfo.Invoke(null, parameters);
    }

    //public static void Invoke(this MethodInfo methodInfo, object instance, object[] parameters)
    //{
    //    methodInfo.Invoke(instance, parameters);
    //}

    /// <summary>
    /// Invokes an instance method with no parameters and no return type.
    /// </summary>
    /// <param name="methodInfo"></param>
    /// <param name="instance">The current instance to call the method on.</param>
    public static void Invoke(this MethodInfo methodInfo, object instance)
    {
        methodInfo.Invoke(instance, null);
    }

    /// <summary>
    /// Invokes a static method with no parameters and the given return type.
    /// </summary>
    /// <typeparam name="T">The return type of the method.</typeparam>
    /// <param name="methodInfo"></param>
    /// <returns></returns>
    public static T Invoke<T>(this MethodInfo methodInfo)
    {
        return (T)methodInfo.Invoke(null, null);
    }

    /// <summary>
    /// Invokes a static method with the given parameters and the given return type.
    /// </summary>
    /// <typeparam name="T">The return type of the method.</typeparam>
    /// <param name="methodInfo"></param>
    /// <param name="parameters">The parameters to pass into the method.</param>
    /// <returns></returns>
    public static T Invoke<T>(this MethodInfo methodInfo, object[] parameters)
    {
        return (T)methodInfo.Invoke(null, parameters);
    }

    /// <summary>
    /// Invokes an instance method with the given parameters and the given return type.
    /// </summary>
    /// <typeparam name="T">The return type of the method.</typeparam>
    /// <param name="methodInfo"></param>
    /// <param name="instance">The current instance to call the method on.</param>
    /// <param name="parameters">The parameters to pass into the method.</param>
    /// <returns></returns>
    public static T Invoke<T>(this MethodInfo methodInfo, object instance, object[] parameters)
    {
        return (T)methodInfo.Invoke(instance, parameters);
    }

    /// <summary>
    /// Invokes an instance method with no parameters and the given return type.
    /// </summary>
    /// <typeparam name="T">The return type of the method.</typeparam>
    /// <param name="methodInfo"></param>
    /// <param name="instance">The current instance to call the method on.</param>
    /// <returns></returns>
    public static T Invoke<T>(this MethodInfo methodInfo, object instance)
    {
        return (T)methodInfo.Invoke(instance, null);
    }
}