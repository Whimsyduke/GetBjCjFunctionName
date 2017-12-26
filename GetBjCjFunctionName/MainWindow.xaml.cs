using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetBjCjFunctionName
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Regex RegexCJ = new Regex(@"(?<=native\s+)[_a-zA-Z]\w*(?=\s+takes\s+[\s\S]*?\s+returns)");
        Regex RegexBJ = new Regex(@"(?<=function\s+)[_a-zA-Z]\w*(?=\s+takes\s+[\s\S]*?\s+returns)");

        private void Common_TextChanged(object sender, EventArgs e)
        {
            TextEditor_FuncList.Text = null;
            MatchCollection matchs;
            int index = 0;
            if (CheckBox_OutputCJ.IsChecked == true)
            {
                matchs = RegexCJ.Matches(TextEditor_BjCj.Text);
                foreach (Match select in matchs)
                {
                    index++;
                    TextEditor_FuncList.Text +=
                        TextBox_CjPrefixBeforeIndex.Text +
                        (CheckBox_CjPrefixIndex.IsChecked == true ? index.ToString() : "") +
                        TextBox_CjPrefixAfterIndex.Text +
                        select.Value +
                        TextBox_CjSuffixBeforeIndex.Text +
                        (CheckBox_CjSuffixIndex.IsChecked == true ? index.ToString() : "") +
                        TextBox_CjSuffixAfterIndex.Text + "\n";
                }
            }
            if (CheckBox_Separator.IsChecked == true)
            {
                TextEditor_FuncList.Text += TextBox_Separator.Text + "\n";
            }
                if (CheckBox_OutputBJ.IsChecked == true)
            {
                matchs = RegexBJ.Matches(TextEditor_BjCj.Text);
                foreach (Match select in matchs)
                {
                    TextEditor_FuncList.Text +=
                        TextBox_BjPrefixBeforeIndex.Text +
                        (CheckBox_BjPrefixIndex.IsChecked == true ? index.ToString() : "") +
                        TextBox_BjPrefixAfterIndex.Text +
                        select.Value +
                        TextBox_BjSuffixBeforeIndex.Text +
                        (CheckBox_BjSuffixIndex.IsChecked == true ? index.ToString() : "") +
                        TextBox_BjSuffixAfterIndex.Text + "\n";
                }
            }
        }
    }
}
