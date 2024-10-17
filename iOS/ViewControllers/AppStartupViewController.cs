using Cirrious.FluentLayouts.Touch;
using Core.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

namespace iOS.ViewControllers
{
    [MvxRootPresentation(WrapInNavigationController = true, AnimationDuration = 0.35f, AnimationOptions = UIViewAnimationOptions.TransitionCrossDissolve)]
    public class AppStartupViewController : BaseViewController<AppStartupViewModel>
    {
        private UIActivityIndicatorView _spinner;
        
        protected override void CreateView()
        {
            _spinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Large) { TranslatesAutoresizingMaskIntoConstraints = false };
            _spinner.OverrideUserInterfaceStyle = UIUserInterfaceStyle.Light;
            _spinner.StartAnimating();
            Add(_spinner);
        }

        protected override void LayoutView()
        {
            base.LayoutView();

            View.AddConstraints(new List<FluentLayout>()
            {
                _spinner.WithSameCenterX(View),
                _spinner.WithSameCenterY(View)
            });
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.HidesBackButton = true;
            ViewModel?.StartupCommand?.Execute();
        }
    }
}

