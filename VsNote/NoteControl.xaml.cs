namespace VsNote
{
    using Microsoft.VisualStudio.Shell;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for NoteControl.
    /// </summary>
    /// 
    public partial class NoteControl : UserControl
    {
        private ObservableCollection<NoteItem> timeStepDataCollection;
        public ObservableCollection<NoteItem> TimeStepDataCollection
        {
            get
            {
                if (timeStepDataCollection == null)
                {
                    timeStepDataCollection = new ObservableCollection<NoteItem>();
                    timeStepDataCollection.Add(new NoteItem() { Title = "test", brush = Brushes.White });
                }
                return timeStepDataCollection;
            }
            set
            {
                timeStepDataCollection = value;
            }
        }

        public NoteControl()
        {
            this.InitializeComponent();
        }

        public class NoteItem
        {
            public string Title { get; set; }
            public Brush brush { set; get; }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            noteList.Items.Add(textBox.Text);
        }

        private void noteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (noteList.SelectedIndex != -1)
            {
                Clipboard.SetText(noteList.SelectedValue.ToString());
                textBox.Text = noteList.SelectedValue.ToString();
                noteList.SelectedIndex = -1;
            }
        }

        private void textBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                noteList.Items.Add(textBox.Text);
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in noteList.Items)
            {
                if (i.ToString() == textBox.Text)
                {
                    noteList.Items.Remove(i);
                    break;
                }
            }
        }
    }
}