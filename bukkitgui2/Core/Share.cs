﻿// Share.cs in bukkitgui2/bukkitgui2
// Created 2014/01/18
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Reflection;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Filesystem;
using Net.Bertware.Bukkitgui2.Core.Filesystem.Local;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.Core
{
	internal static class Share
	{
		public static IFilesystem ServerFileSystem = null;
		public static IntPtr MainFormHandle;

		public static readonly string AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
		public static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
		public static readonly string AssemblyFullName = Assembly.GetExecutingAssembly().GetName().FullName;
		public static readonly string AssemblyLocation = new FileInfo(AssemblyFullName).DirectoryName;

		public static void Initialize()
		{
			DefaultFileLocation.Initialize();
			Logger.Initialize();

			Config.Initialize();

			Locale.Initialize();


			//The filesystem to use (Only for server actions! e.g. logging and config are handled through the normal filesystem
			//This can be changed later on
			//e.g. when FTP connection settings are read from config or user presses connect button
			ServerFileSystem = new LocalFileSystem();
		}
	}
}