using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LeetCodeCSharp
{
    public class WindowsDllLoader
    {
        public IntPtr LoadDll(string path)
        {
            var ret = LoadLibrary(path);
            if (ret == IntPtr.Zero)
                throw new InvalidOperationException($"Can't load dll. IntPtr of the dll is zero. ErrorCode:{Marshal.GetLastWin32Error()}, Path: {path}");
            return ret;
        }

        public Delegate LoadFunction(IntPtr library, string functionName, Type delType)
        {
            try
            {
                var functionAddress = GetProcAddress(library, functionName);
                return Marshal.GetDelegateForFunctionPointer(functionAddress, delType);
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"Load Cpp function {functionName} failed", ex);
            }
        }

        public TDelegate LoadFunction<TDelegate>(IntPtr library, string functionName) where TDelegate : Delegate
        {
            try
            {
                var functionAddress = GetProcAddress(library, functionName);
                return (TDelegate)Marshal.GetDelegateForFunctionPointer(functionAddress, typeof(TDelegate));
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"Load Cpp function {functionName} failed", ex);
            }
        }

        public IntPtr ToFunctionPointer(Delegate func)
        {
            return Marshal.GetFunctionPointerForDelegate(func);
        }


        [DllImport("Kernel32.dll")]
        public static extern IntPtr LoadLibrary(string path);

        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
    }
}
