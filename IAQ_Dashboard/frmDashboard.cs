namespace IAQ_Dashboard
{
    public partial class frmDashboard : Form
    {

        BCInterface bcInt;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.bcInt = new BCInterface();

                InitializeTimer();

        }

        private void InitializeTimer()
        {
            // Call this procedure when the application starts.  
            // Set to 10 second.  
            timer1.Interval = 10000;
            timer1.Tick += new EventHandler(DownloadData);

            
        }

        private void DownloadData(object sender, EventArgs e)
        {
            this.bcInt.getContractData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}