﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EsriDE.Samples.ContentFinder.AgdAdapter;

namespace EsriDE.Trials.ArcMapAddin
{
	public class TrialAddinButton : ShifterAddinButton //ESRI.ArcGIS.Desktop.AddIns.Button
	{
		public TrialAddinButton()
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
