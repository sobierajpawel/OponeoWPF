using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace Oponeo.WMS.WPFClient.Behavior
{
    internal class LoadOnFocusBehavior : Behavior<FrameworkElement>
    {

        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }


        protected override void OnDetaching()
        {
           this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Focus();
        }

    }
}
