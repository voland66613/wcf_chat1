using System.Threading.Tasks;
using System.Windows;


namespace MyChatClient
{
    /// <summary>
    /// Interaction logic for PrivateMassage.xaml 
    /// </summary>
    public partial class PrivateMessage : Window
    {
        private int pmID=0;
        private string _sender;
        private string _adressee;
        IServiceManager _serviceManager;

        public PrivateMessage()
        {
            InitializeComponent();
        }

         public PrivateMessage(string sender, string adressee, IServiceManager serviceManager)
        {
            InitializeComponent();
            _sender = sender;
            _adressee = adressee;
            _serviceManager = serviceManager;
            _serviceManager.onPrivateConnected += OnPrivateConnected;
            _serviceManager.onPrivateMessageReceived_v2 += OnPrivateMessageReceived_v2;   //Max

        }

        public PrivateMessage(string sender, string adressee, IServiceManager serviceManager, string message)
        {
            InitializeComponent();
            _sender = sender;
            _adressee = adressee;
            _serviceManager = serviceManager;
            _serviceManager.onPrivateConnected += OnPrivateConnected;
            _serviceManager.onPrivateMessageReceived_v2 += OnPrivateMessageReceived_v2;   //Max

            OnMessageReceived(message);
            
        }




        async public Task Init()
        {
            pmID = await _serviceManager.PrivateMessagesServiceClient.CreatePrivateMessageAsync(_sender, _adressee);
        }



        public string SetGetSender
        {
            set { _sender = value; }
            get { return _sender; }
        }


        public string SetGetAdressee
        {
            set { _adressee = value; }
            get { return _adressee; }
        }


        public int SetGetpmID
        {
            set { pmID = value; }
            get { return pmID; }
        }

               
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void SendButtonClick(object sender, RoutedEventArgs e)     //Max
        {
            if (_serviceManager.PrivateMessagesServiceClient != null)
            {
                string msg = textBoxPrivateMsgWrite.Text;
                _serviceManager.PrivateMessagesServiceClient.SendPrivateMsg(_sender, _adressee, msg);
                textBoxPrivateMsgWrite.Text = string.Empty;

                listBoxPrivateMsgList.Items.Add(msg);
                listBoxPrivateMsgList.ScrollIntoView(listBoxPrivateMsgList.Items[listBoxPrivateMsgList.Items.Count - 1]);

                //MessageBox.Show("SendButtonClicked!");
            }




            //MessageBox.Show(_sender);
            //MessageBox.Show(_adressee);
        }

        public void OnPrivateConnected(object sender, string msg)
        {
            listBoxPrivateMsgList.Items.Add(msg);
            listBoxPrivateMsgList.ScrollIntoView(listBoxPrivateMsgList.Items[listBoxPrivateMsgList.Items.Count - 1]);
        }

        public void OnMessageReceived(string msg)
        {
            listBoxPrivateMsgList.Items.Add(msg);
            listBoxPrivateMsgList.ScrollIntoView(listBoxPrivateMsgList.Items[listBoxPrivateMsgList.Items.Count - 1]);
        }
        private void OnPrivateMessageReceived_v2(object sender, MessageEventArgs e)               ///Max
        {
            if (_adressee == e._sendername)
            {
                listBoxPrivateMsgList.Items.Add(e._message);
                listBoxPrivateMsgList.ScrollIntoView(listBoxPrivateMsgList.Items[listBoxPrivateMsgList.Items.Count - 1]);
            }
        }

    }
}
