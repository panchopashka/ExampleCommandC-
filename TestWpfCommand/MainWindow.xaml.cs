using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace TestWpfCommand
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        private bool isDirty =  false;
        SaveFileDialog saveDialog = new SaveFileDialog();
        OpenFileDialog openDialog = new OpenFileDialog();

        private static RoutedUICommand cleanCommand;

        public static RoutedUICommand CleanCommand
        {
            get { return cleanCommand; }
        }

        static MainWindow()
        {
            cleanCommand = new RoutedUICommand("Clean Command", "CleanCommand", typeof(MainWindow));
        }

        public MainWindow()
        {
            InitializeComponent();

            saveDialog.FileName = "Document"; // Default file name
            saveDialog.DefaultExt = ".txt"; // Default file extension
            saveDialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            CommandBinding binding;
            binding = new CommandBinding(ApplicationCommands.New);
            binding.Executed += NewCommand;
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Open);
            binding.Executed += OpenCommand;
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Save);
            binding.Executed += SaveCommand;
            binding.CanExecute += SaveCommand_CanExecute;
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Close);
            binding.Executed += ExitCommand;
            this.CommandBindings.Add(binding);
        }

        private void ExitCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AskAndSaveChanges();
            this.Close();
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void SaveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AskAndSaveChanges();
        }

        private void OpenCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AskAndSaveChanges();
            openDialog.Filter = "Text documents (.txt)|*.txt";
            openDialog.CheckFileExists = true;

            if (openDialog.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(openDialog.FileName);
                Text.Text = reader.ReadToEnd();
                reader.Close();

                isDirty = false;
            }
           
        }

        private void NewCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AskAndSaveChanges();
            Text.Text = "";
        }

        private void AskAndSaveChanges()
        {
            if (isDirty == true)
            {
                if (MessageBox.Show("Сохранить изменения в текущем файле?", "Сохранить?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    // Process save file dialog box results
                    if (saveDialog.ShowDialog() == true)
                    {
                        // Save document
                        string filename = saveDialog.FileName;

                        StreamWriter writer = new StreamWriter(filename);
                        writer.WriteLine(Text.Text);
                        writer.Close();
                    }
                }
                isDirty = false;
            }
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDirty = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Text.Text = "";
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Text.Text != "";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            AskAndSaveChanges();
            base.OnClosing(e);
        }
    }
}
