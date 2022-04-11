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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for TestPyramidPanel.xaml
    /// </summary>
    public partial class TestPyramidPanel : Window
    {
        public TestPyramidPanel()
        {
            InitializeComponent();
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBlock? selectedTextBlock = null;
                var comboBoxSelectedTextBlock = (string)((System.Windows.Controls.ContentControl)cBoxTextBox.SelectedItem).Content;
                if (comboBoxSelectedTextBlock != null)
                {
                    switch(comboBoxSelectedTextBlock)
                    {
                        case "tBox_00":
                            selectedTextBlock = this.tBox_00;
                            break;

                        case "tBox_10":
                            selectedTextBlock = this.tBox_10;
                            break;

                        case "tBox_11":
                            selectedTextBlock = this.tBox_11;
                            break;
                        case "tBox_20":
                            selectedTextBlock = this.tBox_20;
                            break;
                        case "tBox_21":
                            selectedTextBlock = this.tBox_21;
                            break;
                        case "tBox_22":
                            selectedTextBlock = this.tBox_22;
                            break;

                        case "tBox_30":
                            selectedTextBlock = this.tBox_30;
                            break;

                        case "tBox_31":
                            selectedTextBlock = this.tBox_31;
                            break;

                        case "tBox_32":
                            selectedTextBlock = this.tBox_32;
                            break;

                        case "tBox_33":
                            selectedTextBlock = this.tBox_33;
                            break;
                    }
                }
                
                if (selectedTextBlock != null)
                {
                    var row = -1;
                    var column = -1;

                    Int32.TryParse(txtRow.Text, out row);
                    Int32.TryParse(txtCol.Text, out column);

                    if (row > -1 && column > -1)
                    {
                        WpfLibrary1427.PyramidPanel.SetRow(selectedTextBlock, row);
                        WpfLibrary1427.PyramidPanel.SetColumn(selectedTextBlock, column);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            
        }
    }
}
