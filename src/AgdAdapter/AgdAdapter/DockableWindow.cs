﻿using System;
using System.Windows.Forms;

namespace EsriDE.Samples.ContentFinder.AgdAdapter
{
	/// <summary>
	/// Designer class of the dockable window add-in. It contains user interfaces that
	/// make up the dockable window.
	/// </summary>
	public partial class DockableWindow : UserControl
	{
		public DockableWindow(object hook)
		{
			InitializeComponent();
			this.Hook = hook;
		}

		/// <summary>
		/// Host object of the dockable window
		/// </summary>
		private object Hook
		{
			get;
			set;
		}

		/// <summary>
		/// Implementation class of the dockable window add-in. It is responsible for 
		/// creating and disposing the user interface class of the dockable window.
		/// </summary>
		public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
		{
			private DockableWindow m_windowUI;

			public AddinImpl()
			{
			}

			protected override IntPtr OnCreateChild()
			{
				m_windowUI = new DockableWindow(this.Hook);
				return m_windowUI.Handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (m_windowUI != null)
					m_windowUI.Dispose(disposing);

				base.Dispose(disposing);
			}

		}
	}
}
