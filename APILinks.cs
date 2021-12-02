namespace GameHeaven
{
    public static class APILinks
    {
        public const string API_URL = "https://localhost:5001/";
        public const string CPU_URL = API_URL + "admin/CPU";
        public const string GPU_URL = API_URL + "admin/GPU";
        public const string PLATFORM_URL = API_URL + "admin/Platform";
        public const string DIRECTX_URL = API_URL + "admin/DirectX";
        public const string GENRE_URL = API_URL + "admin/Genre";
        public const string OS_URL = API_URL + "admin/Os";
        public const string DEVELOPER_URL = API_URL + "admin/Developer";
        public const string GAME_URL = API_URL + "admin/Game";
        public const string PUBLISHER_URL = API_URL + "admin/Publisher";
        public const string USERS_URL = API_URL + "admin/UserSetup";
        public const string STATUS_URL = API_URL + "admin/Status";
        public const string FRANCHISE_URL = API_URL + "admin/Franchise";
        public const string LOGIN_URL = API_URL + "AuthManagement/Login";
        public const string REGISTER_URL = API_URL + "AuthManagement/Register";
        public const string RESET_PASSWORD = API_URL + "AuthManagement/Reset-Password";
        public const string CONFIRM_EMAIL = API_URL + "AuthManagement/Confirm-Email";
        public const string FORGOT_PASSWORD = API_URL + "AuthManagement/Forgot-Password";
    }
}
