using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class TypeAttribute : Attribute
{
    private Type _type;

    public TypeAttribute(Type type)
    {
        this._type = type;
    }
    public Type Type
    {
        get
        {
            return this._type;
        }
    }
}

public static class EnumUtility
{
    public static Type GetStringType(Enum value)
    {
        Type result = null;
        Type type = value.GetType();
        if (type != null)
        {
            FieldInfo field = type.GetField(value.ToString());
            if (field != null)
            {
                TypeAttribute[] array = field.GetCustomAttributes(typeof(TypeAttribute), false) as TypeAttribute[];
                if (array != null)
                {
                    if (array.Length > 0)
                    {
                        result = array[0].Type;
                    }
                }

            }

        }

        return result;
    }

    public static T GetEnumType<T>(string code, T defaultVaule)
    {
        T result;
        try
        {
            result = (T)((object)Enum.Parse(typeof(T), code));
        }
        catch (Exception)
        {
            result = defaultVaule;
        }
        return result;
    }

    public static T GetEnumType<T>(int code, T defaultVaule)
    {
        T result;
        try
        {
            result = (T)((object)Enum.ToObject(typeof(T), code));
        }
        catch (Exception)
        {
            result = defaultVaule;
        }
        return result;
    }
}

