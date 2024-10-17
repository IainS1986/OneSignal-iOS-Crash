using Cirrious.FluentLayouts.Touch;
using Core.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

namespace iOS.ViewControllers
{
    [MvxRootPresentation(WrapInNavigationController = true, AnimationDuration = 0.35f, AnimationOptions = UIViewAnimationOptions.TransitionCrossDissolve)]
    public class FirstViewController : BaseViewController<FirstViewModel>
    {
        private UILabel _textLabel;

        protected override void CreateView()
        {
            base.CreateView();

            _textLabel = new UILabel() { TranslatesAutoresizingMaskIntoConstraints = false };
            Add(_textLabel);
        }

        protected override void LayoutView()
        {
            base.LayoutView();

            View.AddConstraints(new List<FluentLayout>()
            {
                _textLabel.WithSameCenterX(View),
                _textLabel.WithSameCenterY(View)
            });
        }

        protected override void BindView()
        {
            base.BindView();

            var set = CreateBindingSet();
            set.Bind(_textLabel).To(vm => vm.Text);
            set.Apply();
        }
    }
}