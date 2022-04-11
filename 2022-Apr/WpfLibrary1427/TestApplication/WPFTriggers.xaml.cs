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
using System.Collections.ObjectModel;
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
    class PersonData
    {
        public string? Name { get; set; }
        public string? State { get; set; }

        public bool? IsFromNorthEast { get; set; }
    }

    /// <summary>
    /// Interaction logic for WPFConcepts.xaml
    /// </summary>
    public partial class WPFTriggers : Window
    {
        ObservableCollection<PersonData> persons = new ObservableCollection<PersonData>();


        public WPFTriggers()
        {
            InitializeComponent(); this.DataContext = persons;

            persons.Add(new PersonData() { Name = "Kumar", State = "Bihar", IsFromNorthEast = false });
            persons.Add(new PersonData() { Name = "Shiv Kumar", State = "Assam", IsFromNorthEast = false });
            persons.Add(new PersonData() { Name = "Shiv Kumar", State = "Manipur", IsFromNorthEast = true });
            persons.Add(new PersonData() { Name = "Pratap Kumar", State = "Madya Pradesh", IsFromNorthEast = false });
            persons.Add(new PersonData() { Name = "Kumar Rawat", State = "Himachal Pradesh", IsFromNorthEast = false });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Btn clicked");
        }
    }
}
