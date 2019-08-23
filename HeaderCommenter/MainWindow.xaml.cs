using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace HeaderCommenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> fileExtensions;
        private List<string> filePaths;
        private FolderBrowserDialog folderBrowserDialog;
        private List<SourceFile> sourceFiles;
        private string folderName;
        private string fileExtension;
        
            
        public MainWindow()
        {
            //contains extensions for combo box
            fileExtensions = new List<string>() {".cs", ".java", ".py", ".cpp"};
            //contains the filepaths for the list view
            filePaths = new List<string>();
            //contains list of source files to be commented
            sourceFiles = new List<SourceFile>();

            InitializeComponent();
            cbxFileExtensions.ItemsSource = fileExtensions;
            cbxFileExtensions.SelectedIndex = 0;

            folderBrowserDialog = new FolderBrowserDialog();

            lvFiles.DataContext = filePaths;
        }


        private void btnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            //clear our filePaths List first so we don't have duplicated
            filePaths.Clear();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                folderName = new DirectoryInfo(folderBrowserDialog.SelectedPath).FullName;
                //set label to folder name that was chosen from file browser dialog
                lblFolderName.Content = $"Folder: {folderName}";
                DirectoryInfo directoryInfo = new DirectoryInfo(folderName);
                //search pattern for file extension chosen from combo box
                fileExtension = "*" + (string) cbxFileExtensions.SelectedItem;
                FileInfo[] files = directoryInfo.GetFiles(fileExtension);
                
                foreach (var file in files)
                {
                    filePaths.Add(file.FullName);
                }

                //update items source for ListView so that files are shown on form
                lvFiles.ItemsSource = filePaths;
            }

        }

        private void btnAddHeaderComments_Click(object sender, RoutedEventArgs e)
        {
            foreach (var sourceFile in sourceFiles)
            {
                //TODO add exception handling
                sourceFile.ReadFile();
                sourceFile.WriteFile();
            }
        }

        private void btnSetFilesForComments_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string program = txtProgram.Text;
            string date = txtDate.Text;
            Comment comment = new Comment(name, email, date, program, "");


            foreach (var file in filePaths)
            {
                //split up filename so comment doesn't have full path
                int start = file.LastIndexOf("\\") + 1;
                comment.Filename = file.Substring(start);
                sourceFiles.Add(new SourceFile(file, comment)); 
            }
            
        }
    }
}
