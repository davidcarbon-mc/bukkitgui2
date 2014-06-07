﻿// JsonApiServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/06/07 20:24
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	internal class JsonApiServer : MinecraftServerBase
	{
		public override string Name
		{
			get { return "JsonApi"; }
		}

		public override string Site
		{
			get { return "http://minecraft.net"; }
		}
	}
}