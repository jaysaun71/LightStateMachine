namespace Core.Lightfsm
{
    using Lightfsm.Wpfexmpl.Classes.DataContext;
    using System.Windows;
    using System.Windows.Controls;

    public class ViewDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the location data template.
        /// </summary>
        public DataTemplate SecondDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the removable data template.
        /// </summary>
        public DataTemplate ThirdDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the default data template.
        /// </summary>
        public DataTemplate DefaultDataTemplate { get; set; }

        /// <summary>
        /// The select template.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The <see cref="DataTemplate"/>.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DefaultContext)
            {
                return this.DefaultDataTemplate;
            }
            else if (item is SecondContext)
            {
                return this.SecondDataTemplate;
            }
            else if (item is ThirdContext)
            {
                return this.ThirdDataTemplate;
            }

            return this.DefaultDataTemplate;
        }
    }
}