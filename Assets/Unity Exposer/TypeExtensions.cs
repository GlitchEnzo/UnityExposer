// These extensions are placed in the global namespace to allow everything to access them.

using System;
using System.Reflection;

public static class TypeExtensions
{
    /// <summary>
    /// Searches for the specified method whose parameters match the specified argument types and modifiers, using the specified binding constraints.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name">The string containing the name of the method to get.</param>
    /// <param name="bindingAttr">A bitmask comprised of one or more BindingFlags that specify how the search is conducted.</param>
    /// <param name="types">An array of Type objects representing the number, order, and type of the parameters for the method to get. Use Type.EmptyTypes for no parameters.</param>
    /// <returns>An object representing the method that matches the specified requirements, if found; otherwise, null.</returns>
    public static MethodInfo GetMethod(this Type type, string name, BindingFlags bindingAttr, Type[] types)
    {
        return type.GetMethod(name, bindingAttr, null, types, null);
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