using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.ModelViews.LoginModelView;
using UI.Layouts;

namespace UI.CustomForm
{
    public partial class LoginForm : Form
    {
        private readonly ILoginService _loginService;
        private ErrorProvider _errorProvider = new ErrorProvider();
        public string[] forms;
        public string user;
        public LoginForm(ILoginService loginService)
        {
            this._loginService = loginService;
            forms = [];
            InitializeComponent();
            AlignCenterScreen();
            this.loginBtn.Text = "ĐĂNG NHẬP";
            this.loginBtn.Click += BtnLoginClick;
        }

        /// <summary>
        ///     Căn chỉnh giữa cho form khi display
        /// </summary>
        private void AlignCenterScreen()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnLoginClick(object sender, EventArgs args)
        {
            string userName = this.userName.Text;
            string password = this.password.Text;
            if (string.IsNullOrWhiteSpace(userName))
            {
                _errorProvider.SetError(this.userName, "Nhập mã người dùng");
                return;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                _errorProvider.SetError(this.password, "Nhập password");
                return;
            }
            try
            {
                LoginModel login = new LoginModel(userName, password);
                forms = _loginService.HandleLoginRequest(login);
                this.user = _loginService.GetCurrentuser();
                this.Close();
                
            }
            catch (ErrorException ex)
            {
                MessageBox.Show("ĐĂNG NHẬP THẤT BẠI");
            }
        }

        private void loginBtn_Load(object sender, EventArgs e)
        {

        }
    }
}
