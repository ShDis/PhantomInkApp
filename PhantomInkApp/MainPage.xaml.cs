namespace PhantomInkApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_PlayAsMedium_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MediumPage());
        }

        private async void Button_PlayAsSpirit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SpiritPage());
        }
    }

}
