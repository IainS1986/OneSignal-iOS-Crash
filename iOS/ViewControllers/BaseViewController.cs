using Core.ViewModels;
using MvvmCross.Platforms.Ios.Views;

namespace iOS.ViewControllers
{
    public class BaseViewController<TViewModel> : MvxViewController<TViewModel>
        where TViewModel : BaseViewModel
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Disable Drag to dismiss (messes with MvvmCross, TODO - Come back to this later)
            if (OperatingSystem.IsIOSVersionAtLeast(13))
                ModalInPresentation = true;

            View.BackgroundColor = UIColor.White;

            CreateView();

            LayoutView();

            BindView();
        }

        protected virtual void CreateView()
        {
        }

        protected virtual void BindView()
        {
        }

        protected virtual void LayoutView()
        {
        }
    }
}