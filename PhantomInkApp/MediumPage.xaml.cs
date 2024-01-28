namespace PhantomInkApp;

public partial class MediumPage : ContentPage
{
	public MediumPage()
	{
		InitializeComponent();
	}

    private void Button_RandomCode_Clicked(object sender, EventArgs e)
    {
        Random rand = new Random(DateTime.Now.Millisecond);
        Entry_Code.Text = rand.Next(1000).ToString();
    }

    private async void Button_Start_Clicked(object sender, EventArgs e)
    {
        Entry_Code.IsEnabled = false;
        Button_RandomCode.IsEnabled = false;
        Picker_Command.IsEnabled = false;
        MediumCardLibrary.Instance.Init(Int32.Parse(Entry_Code.Text));
        MediumCardLibrary.Instance.SunOrMoonCommand = Picker_Command.SelectedIndex == 0 ? true : false;
        await Navigation.PushModalAsync(new MediumFrom7ChooserPage(true));
    }

    private void Entry_Code_TextChanged(object sender, TextChangedEventArgs e)
    {
        CheckStartAllowed();
    }

    private void Picker_Command_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckStartAllowed();
    }

    private void CheckStartAllowed()
    {
        int testInt = -1;
        Int32.TryParse(Entry_Code.Text, out testInt);
        int selected = Picker_Command.SelectedIndex;
        if (testInt >= 0 && selected != -1 && Entry_Code.Text != "")
        {
            Button_Start.IsEnabled = true;
        }
        else
        {
            Button_Start.IsEnabled = false;
        }
    }
}