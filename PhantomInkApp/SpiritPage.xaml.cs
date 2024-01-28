namespace PhantomInkApp;

public partial class SpiritPage : ContentPage
{
	public SpiritPage()
	{
		InitializeComponent();

		SpiritCard card = SpiritCardLibrary.Instance.RandomCard;

		Label_1.Text = card.Things[0];
        Label_2.Text = card.Things[1];
        Label_3.Text = card.Things[2];
        Label_4.Text = card.Things[3];
        Label_5.Text = card.Things[4];
        Label_6.Text = card.Things[5];
    }
}