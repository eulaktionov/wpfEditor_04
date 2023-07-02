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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

using Microsoft.Win32;

//using static System.Net.WebRequestMethods;

namespace wpfEditor_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void closeApp(object sender, ExecutedRoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            Close();
        }

        void openFile(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string fileContent = File.ReadAllText(filePath);

                    TextEditor.Document.Blocks.Clear();
                    TextEditor.Document.Blocks.Add(new Paragraph(new Run(fileContent)));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
                }
            }
        }
    }
    //public class TextCommands
    //{
    //    public static RoutedCommand Open { get; set; }
    //    static TextCommands()
    //    {
    //        Open = new RoutedCommand("Open", typeof(RichTextBox));
    //    }
    //}
}

/*
 * Да, конечно! Вот пример кода команды "Copy" в C# для WPF:

```csharp
private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
{
    // Выполнение операций копирования

    // Получение объекта, откуда нужно скопировать данные
    var source = e.Source as FrameworkElement;

    // Проверка, поддерживает ли источник операцию копирования
    if (source != null && source is ICopyable)
    {
        // Вызов метода копирования объекта
        var copyable = (ICopyable)source;
        copyable.Copy();
    }
}

private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
{
    // Устанавливаем значение true, если команда Copy может быть выполнена
    e.CanExecute = (e.Source as FrameworkElement) is ICopyable;
}
```

В этом примере предполагается, что у ваших элементов управления в WPF есть интерфейс `ICopyable`, 
который определяет метод `Copy()` для выполнения копирования. 
Вы можете настроить этот интерфейс и реализовать метод `Copy()` в соответствии с вашими потребностями.

Кроме того, в XAML-разметке вам нужно будет связать команду с элементами управления. 
Вот пример, как это можно сделать:

```xaml
<Window x:Class="YourNamespace.YourWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:YourNamespace"
        Title="Your Window" Width="800" Height="600">
    <Window.CommandBindings>
        <CommandBinding Command="ApplicationCommands.Copy" 
                        Executed="CopyCommand_Executed" 
                        CanExecute="CopyCommand_CanExecute" />
    </Window.CommandBindings>
    
    <!-- Ваша разметка окна -->
    
</Window>
```

Здесь `CopyCommand_Executed` и `CopyCommand_CanExecute` - это обработчики событий, 
которые были определены в C#-коде. 
Команда `ApplicationCommands.Copy` связывается с этими обработчиками событий 
с помощью `CommandBinding`.
 */
/*
 * private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
{
    OpenFileDialog openFileDialog = new OpenFileDialog();

    if (openFileDialog.ShowDialog() == true)
    {
        string filePath = openFileDialog.FileName;

        try
        {
            // Чтение содержимого файла
            string fileContent = File.ReadAllText(filePath);

            // Отображение содержимого в RichTextBox
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(fileContent)));
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
        }
    }
}

private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
{
    e.CanExecute = true; // Команда всегда доступна для выполнения
}

<Window x:Class="YourNamespace.YourWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:YourNamespace"
        Title="Your Window" Width="800" Height="600">
    <Window.CommandBindings>
        <CommandBinding Command="ApplicationCommands.Open" 
                        Executed="OpenCommand_Executed" 
                        CanExecute="OpenCommand_CanExecute" />
    </Window.CommandBindings>
    
    <!-- Ваша разметка окна -->
    
</Window>

 */
/*
 * using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
{
    OpenFileDialog openFileDialog = new OpenFileDialog();

    if (openFileDialog.ShowDialog() == true)
    {
        string filePath = openFileDialog.FileName;

        try
        {
            // Открытие файла DOCX
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                // Извлечение текстового содержимого
                string fileContent = string.Empty;
                Body body = wordDoc.MainDocumentPart.Document.Body;
                if (body != null)
                {
                    fileContent = body.InnerText;
                }

                // Отображение содержимого в RichTextBox
                richTextBox.Document.Blocks.Clear();
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(fileContent)));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
        }
    }
}

private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
{
    e.CanExecute = true; // Команда всегда доступна для выполнения
}

 * 
 */