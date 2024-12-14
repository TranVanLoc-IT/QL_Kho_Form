using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.ModelViews.LoginModelView;
using System.Text.RegularExpressions;
using UI.Layouts;

namespace UI.CustomForm
{
    public partial class LoginForm : Form
    {
        private readonly ILoginService _loginService;
        private ErrorProvider _errorProvider = new ErrorProvider();
        public string role;
        public string user;
        public LoginForm(ILoginService loginService)
        {
            this._loginService = loginService;
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

            if (string.IsNullOrWhiteSpace(password))
            {
                _errorProvider.SetError(this.password, "Nhập password");
                return;
            }

            string pattern = @"^(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]:;'""\\|,.<>/?-]).+$";

            if (!Regex.IsMatch(password, pattern))
            {
                _errorProvider.SetError(this.password, "Mật khẩu phải chứa ít nhất một chữ số và một ký tự đặc biệt");
                return;
            }

            try
            {
                LoginModel login = new LoginModel("admin", password);
                role = _loginService.HandleLoginRequest(login);
                if(role == "Admin")
                {
                    this.user = _loginService.GetCurrentuser();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền đăng nhập !");
                }
            }
            catch (ErrorException ex)
            {
                MessageBox.Show("ĐĂNG NHẬP THẤT BẠI");
                this.userName.Text = string.Empty;
                this.password.Text = string.Empty;
            }
        }

        private void loginBtn_Load(object sender, EventArgs e)
        {

        }
    }
}
