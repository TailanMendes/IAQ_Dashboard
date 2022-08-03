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

            //bcInt.getContractData();

            InitializeTimer();

        }

        private void InitializeTimer()
        {
            // Call this procedure when the application starts.  
            // Set to 5 second.  
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(DownloadData);

            
        }

        private void DownloadData(object sender, EventArgs e)
        {
            this.bcInt.getContractData();
            //label1.Text = DateTime.Now.ToString();
        }
    }
}