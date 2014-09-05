﻿// QuickButtons.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.Controls.QuickButtons
{
	public partial class QuickButtons : MetroUserControl
	{
		public QuickButtons()
		{
			InitializeComponent();
			ProcessHandler.ServerStatusChanged += HandleServerStatusChange;
		}

		public event EventHandler TaskButtonPressed;

		protected virtual void OnTaskButtonPressed()
		{
			EventHandler handler = TaskButtonPressed;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		private void HandleServerStatusChange(ServerState currentState)
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => HandleServerStatusChange(currentState)));
			}
			else
			{
				switch (currentState)
				{
					case ServerState.Starting:
						btnStartStop.Enabled = false;
						btnRestart.Enabled = false;
						btnStartStop.Text = Locale.Tr("Starting...");
						metroToolTip.SetToolTip(btnStartStop, "Stop the server");
						break;
					case ServerState.Running:
						btnStartStop.Enabled = true;
						btnRestart.Enabled = true;
						btnStartStop.Text = Locale.Tr("Stop");
						break;
					case ServerState.Stopping:
						btnStartStop.Enabled = false;
						btnRestart.Enabled = false;
						btnStartStop.Text = Locale.Tr("Stopping...");
						metroToolTip.SetToolTip(btnStartStop, "Start the server");
						break;
					case ServerState.Stopped:
						btnStartStop.Enabled = true;
						btnRestart.Enabled = false;
						btnStartStop.Text = Locale.Tr("Start");
						break;
				}
			}
		}

		private void BtnStartStopClick(object sender, EventArgs e)
		{
			//suport for calls from other threads
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => BtnStartStopClick(sender, e)));
			}
			else
			{
				if (ProcessHandler.IsRunning)
				{
					ProcessHandler.StopServer(); // stop running server
				}
				else
				{
					Starter.StartServer(); // Launch with tab settings
				}
			}
		}

		private void btnCustom_Click(object sender, EventArgs e)
		{
			OnTaskButtonPressed();
		}
	}
}