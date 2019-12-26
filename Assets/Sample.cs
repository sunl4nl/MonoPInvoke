using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using AOT;

public class Sample : MonoBehaviour 
{
    private void Start()
    {
#if UNITY_IOS
        ResultHandler handler = new ResultHandler(resultHandler);
        IntPtr fp = Marshal.GetFunctionPointerForDelegate(handler);

        outputAppendString("AAA", "BBB");
        outputAppendString2("hello", "world", fp);
#endif
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ResultHandler(string str);


    [MonoPInvokeCallback(typeof(ResultHandler))]
    static void resultHandler(string str)
    {
        Debug.Log("Unity resultHandler-- " +str);
    }

#if UNITY_IOS
    [DllImport("__Internal")]
    static extern void outputAppendString(string str1, string str2);
    [DllImport("__Internal")]
    static extern void outputAppendString2(string str1, string str2, IntPtr resultHandler);
#endif
}
