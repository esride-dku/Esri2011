﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EsriDE.Trials.TrioBagatelli
{
	public class ButtonTrioBagatelli : ESRI.ArcGIS.Desktop.AddIns.Button
	{
		public ButtonTrioBagatelli()
		{
		}

		protected override void OnClick()
		{
			//
			//  TODO: Sample code showing how to access button host
			//
			ArcMap.Application.CurrentTool = null;
		}
		protected override void OnUpdate()
		{
			Enabled = ArcMap.Application != null;
		}
	}

}
