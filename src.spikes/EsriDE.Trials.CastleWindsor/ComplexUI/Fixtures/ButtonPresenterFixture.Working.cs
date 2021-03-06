﻿using EsriDE.Trials.CastleWindsor.ComplexUI.AA;
using EsriDE.Trials.CastleWindsor.ComplexUI.Contracts.Buttons;
using EsriDE.Trials.CastleWindsor.ComplexUI.Contracts.DomainModel;
using EsriDE.Trials.CastleWindsor.ComplexUI.Fixtures.WidgetFakes;
using EsriDE.Trials.CastleWindsor.ComplexUI.Implementations.Buttons;
using Moq;
using NUnit.Framework;
using Rhino.Mocks;
using MockRepository = Rhino.Mocks.MockRepository;

namespace EsriDE.Trials.CastleWindsor.ComplexUI.Fixtures
{
	[TestFixture]
	public partial class ButtonPresenterFixture
	{
		//[Test]
		//public void DoClassic()
		//{
		//    var mockRepository = new MockRepository();
		//    var view = mockRepository.StrictMock<IButtonView>();
		//    var model = mockRepository.Stub<IToggleModel>();

		//    var presenter = new ButtonPresenterForTest(model);
		//    presenter.ConnectView(view);

		//    mockRepository.Playback();

		//    Expect.Call(() => view.SetCheckedState(CheckedState.Checked)).IgnoreArguments();

		//    mockRepository.ReplayAll();

		//    presenter.EmulateEventing(VisibilityState.Visible);

		//    mockRepository.VerifyAll();
		//}

		//[Test]
		//public void DoFluent()
		//{
		//    var mockRepository = new MockRepository();
		//    var view = mockRepository.StrictMock<IButtonView>();
		//    var model = mockRepository.Stub<IToggleModel>();

		//    var presenter = new ButtonPresenterForTest(model);

		//    With.Mocks(mockRepository)
		//        .Expecting(delegate
		//                    {
		//                        Expect.Call(() => view.Clicked += null).IgnoreArguments();
		//                        Expect.Call(() => view.SetCheckedState(CheckedState.Checked)).IgnoreArguments();
		//                    })
		//        .Verify(delegate
		//                    {
		//                        presenter.ConnectView(view);
		//                        presenter.EmulateEventing(VisibilityState.Visible);
		//                    });
		//}

		//[Test]
		//public void DoUsing()
		//{
		//    var mockRepository = new MockRepository();
		//    var view = mockRepository.StrictMock<IButtonView>();
		//    var model = mockRepository.Stub<IToggleModel>();

		//    var presenter = new ButtonPresenterForTest(model);

		//    using (mockRepository.Record())
		//    {
		//        Expect.Call(() => view.Clicked += null).IgnoreArguments();
		//        Expect.Call(() => view.SetCheckedState(CheckedState.Checked)).IgnoreArguments();
		//    }

		//    using (mockRepository.Playback())
		//    {
		//        presenter.ConnectView(view);
		//        presenter.EmulateEventing(VisibilityState.Visible);
		//    }
		//}

		[Test]
		public void RoundtripViewToModelToView_Hiding()
		{
			var view = new Mock<IButtonView>(MockBehavior.Strict);
			var model = new Mock<IToggleModel>(MockBehavior.Strict);

			var presenter = new ButtonPresenter(model.Object);
			presenter.ConnectView(view.Object);

			// Erwartungen definieren
			// User-Interaktion im View -> Änderung im Model muss erfolgen
			model.Setup(m => m.ToggleVisibility());
			// Model-Änderungs-Event -> View muss aktualisiert werden
			view.Setup(v => v.SetCheckedState(CheckedState.Unchecked));

			// Events auslösen
			view.Raise(m => m.Clicked += null);
			model.Raise(m => m.VisibilityStateChanged += null, VisibilityState.Invisible);

			// Erwartungen verifizieren
			model.VerifyAll();
			view.VerifyAll();
		}

		[Test]
		public void RoundtripViewToModelToView_Showing()
		{
			var view = new Mock<IButtonView>(MockBehavior.Strict);
			var model = new Mock<IToggleModel>(MockBehavior.Strict);

			var presenter = new ButtonPresenter(model.Object);
			presenter.ConnectView(view.Object);

			// Erwartungen definieren
			// User-Interaktion im View -> Änderung im Model muss erfolgen
			model.Setup(m => m.ToggleVisibility());
			// Model-Änderungs-Event -> View muss aktualisiert werden
			view.Setup(v => v.SetCheckedState(CheckedState.Checked));

			// Events auslösen
			view.Raise(m => m.Clicked += null);
			model.Raise(m => m.VisibilityStateChanged += null, VisibilityState.Visible);

			// Erwartungen verifizieren
			model.VerifyAll();
			view.VerifyAll();
		}
	}
}