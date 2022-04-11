/*
The MIT License (from https://opensource.org/licenses/MIT)
    
Copyright 2022 Ajey Joshi (ajey.joshi@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System.Windows;
using System.Windows.Controls;

/// <References>
/// https://docs.microsoft.com/en-us/dotnet/desktop/wpf/controls/how-to-create-a-custom-panel-element?view=netframeworkdesktop-4.8
/// https://docs.microsoft.com/en-us/dotnet/desktop/wpf/properties/dependency-properties-overview?view=netdesktop-6.0
/// https://docs.microsoft.com/en-us/dotnet/desktop/wpf/properties/attached-properties-overview?view=netdesktop-6.0
/// https://docs.microsoft.com/en-us/dotnet/desktop/wpf/properties/attached-properties-overview?view=netdesktop-6.0
/// </References>

namespace WpfLibrary1427
{
    public class PyramidPanel : Panel
    {
        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register("Rows", typeof(int), typeof(PyramidPanel));

        public int Rows
        {
            get => (int)GetValue(RowsProperty);
            set => SetValue(RowsProperty, value);
        }

        public static readonly DependencyProperty RowProperty =
        DependencyProperty.RegisterAttached("Row", typeof(int), typeof(PyramidPanel),
            new FrameworkPropertyMetadata(defaultValue: 0, flags: FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange));

        public static int GetRow(UIElement target) => (int)target.GetValue(RowProperty);

        public static void SetRow(UIElement target, int value) => target.SetValue(RowProperty, value);



        public static readonly DependencyProperty ColumnProperty =
        DependencyProperty.RegisterAttached("Column", typeof(int), typeof(PyramidPanel),
            new FrameworkPropertyMetadata(defaultValue: 0, flags: FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange));

        public static int GetColumn(UIElement target) => (int)target.GetValue(ColumnProperty);

        public static void SetColumn(UIElement target, int value) => target.SetValue(ColumnProperty, value);


        public PyramidPanel()
            : base()
        {
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
            }

            // Following is done to handle the case when the parent of PyramidPanel is StackPanel or the one which might have
            // either availableSize.Height or Width as double.PositiveInfinity.
            if (availableSize.Height == double.PositiveInfinity)
            {
                availableSize.Height = 0;
                foreach (UIElement child in InternalChildren)
                {
                    availableSize.Height += child.DesiredSize.Height;
                }
            }

            if (availableSize.Width == double.PositiveInfinity)
            {
                availableSize.Width = 0;
                foreach (UIElement child in InternalChildren)
                {
                    availableSize.Width += child.DesiredSize.Width;
                }
            }

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var columnWidth = finalSize.Width / this.Rows;
            var rowHeight = finalSize.Height / this.Rows;

            var width = this.Rows * columnWidth;

            var center = width / 2;

            foreach (UIElement child in InternalChildren)
            {
                var row = PyramidPanel.GetRow(child);
                var column = PyramidPanel.GetColumn(child);

                var rowElementsCount = row + 1;
                var rowStartX = center - (rowElementsCount * columnWidth / 2);
                var x = rowStartX + (column * columnWidth);

                var pt = new Point(x, row * rowHeight);
                var desiredSize = new Size(columnWidth, rowHeight);
                child.Arrange(new Rect(pt, desiredSize));
            }

            return finalSize;
        }
    }
}
