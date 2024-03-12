namespace nodes;

public partial class notePage : ContentPage
{
    string _filepath = Path.Combine(FileSystem.AppDataDirectory, "note.txt");
    
    public notePage()
	{
		InitializeComponent();
        if (File.Exists(_filepath)) { 
            TextEditor.Text = File.ReadAllText(_filepath);
        }

	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_filepath, TextEditor.Text);
        await DisplayAlert("Salvo", "Arquivo criado com susseso", "OK");
    }
    private async void deleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_filepath))
        {
            File.Delete(_filepath);
            await DisplayAlert("Deletado", "Arquivo deletado com susseso", "OK");
            TextEditor.Text = "";
        }
        else
        {
            await DisplayAlert("Nop", "Arquivo não foi deletado com susseso", "OK");
        }
        
    }
}