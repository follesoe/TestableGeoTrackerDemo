namespace TestableGeoTrackerDemo.Test
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += (o, e) => this.StartTestRunner();
        }
    }
}