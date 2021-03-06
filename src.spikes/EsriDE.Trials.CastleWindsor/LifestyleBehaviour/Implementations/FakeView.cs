﻿using System;
using EsriDE.Trials.CastleWindsor.LifestyleBehaviour.Contracts;

namespace EsriDE.Trials.CastleWindsor.LifestyleBehaviour.Implementations
{
	public class FakeView : IView
	{
		private Action<bool> _action;

		#region IView Members
		public void ShowView(Action<bool> action)
		{
			Console.WriteLine("FakeView.ShowView");
			_action = action;
		}

		public void CloseView()
		{
			Console.WriteLine("FakeView.CloseView");
		}
		#endregion

		~FakeView()
		{
			Console.WriteLine("~FakeView()");
			_action(true);
		}
	}
}