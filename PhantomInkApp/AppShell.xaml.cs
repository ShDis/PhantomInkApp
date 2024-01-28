namespace PhantomInkApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            SetTabBarBackgroundColor(this, Colors.Black);
            SetBackgroundColor(this, Colors.Black);
        }
    }
}
