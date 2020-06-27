﻿using System;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using DeveloperFramework.LibraryModel.CQP;
using DeveloperFramework.Log.CQP;
using DeveloperFramework.Utility;

namespace TestApplication
{
	public class Program
	{
		public static void Main ()
		{
			//Logger.Instance.AddObserver (new Program ());
			EnironmentSetup ();

			Console.ReadLine ();
		}

		public static void EnironmentSetup ()
		{
			string output = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location);
			DirectoryCopy (NestedFoundDirectory ("env"), output);
		}
		private static string NestedFoundDirectory (string directoryName)
		{
			try
			{
				directoryName = directoryName.Insert (0, "../");
				string path = Path.GetFullPath (directoryName);
				if (Directory.Exists (path))
					return path;
				return NestedFoundDirectory (directoryName);
			}
			catch { throw; }
		}
		private static void DirectoryCopy (string sourceDirName, string destDirName)
		{
			DirectoryInfo dir = new DirectoryInfo (sourceDirName);
			DirectoryInfo[] dirs = dir.GetDirectories ();
			if (!Directory.Exists (destDirName))
			{
				Directory.CreateDirectory (destDirName);
			}
			FileInfo[] files = dir.GetFiles ();
			foreach (FileInfo file in files)
			{
				string temppath = Path.Combine (destDirName, file.Name);
				if (!File.Exists (temppath))
					file.CopyTo (temppath, false);
			}
			foreach (DirectoryInfo subdir in dirs)
			{
				string temppath = Path.Combine (destDirName, subdir.Name);
				DirectoryCopy (subdir.FullName, temppath);
			}
		}
	}
}
