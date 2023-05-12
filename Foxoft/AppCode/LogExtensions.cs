using Foxoft.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Foxoft
{
   public static class LogExtensions
   {
      static string path = Path.Combine(AppContext.BaseDirectory, "Log");
      public static void GetPropertyDisplayName(string fileName)
      {
         if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

         string fullName = Path.Combine(path, DateTime.Now.ToShortDateString() + " - " + Process.GetCurrentProcess().Id.ToString() + " - " + fileName);
         if (!File.Exists(fullName))
         {
            Stream myFile = File.Create(fullName);
            /* Create a new text writer using the output stream, and add it to the trace listeners. */
            TextWriterTraceListener myTextListener = new(myFile);
            Trace.Listeners.Add(myTextListener);
         }

      }

   }
}
