using System;
using GTA;
using GTA.Native;

namespace Metadata
{
	class Scripts : Script
	{
		public Scripts()
		{
			Tick += OnTick;
		}

		public void OnTick(object sender, EventArgs e)
		{
			if (NewFunc.HideHud)
			{
				Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME);
			}
		}
	}
}
