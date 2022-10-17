using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Helper
{
    public class EMAILTEMPLATE_CONSTANT
    {
        public const string USER_PASSWORD_RESET_EMAIL = "Email thông báo khôi phục mật khẩu người dùng";
        public const string NEW_USER_CREATION_EMAIL = "Email thông báo tạo mới tài khoản người dùng";
        public const string USER_PASSWORD_CHANGE_EMAIL = "Email thông báo thay đổi mật khẩu người dùng";
        public const string EMAIL_FORGOT_PASSWORD = "Emai thông báo quên mật khẩu";
        public const string RESET_PASSWORD_MOBILE = "ResetPasswordMobile";

        public const string QUOTATIONEMPLOYEESENDTOMANAGER = "QuotationEmployeeSendToManager";
        public const string QUOTATION_MANAGER_REJECT_EMAIL = "QuotationManagerRejectEmail";
        public const string QUOTATION_MANAGER_RECALL_EMAIL = "QuotationManagerRecallEmail";
        public const string QUOTATION_EMAIL_RECALL_EMAIL = "QuotationEmailTemplate";
        public const string QUOTATION_EMAIL_TEMPLATE = "QuotationEmailTemplate";
        public const string INVENTORYNOTE_EMAIL_TEMPLATE = "TLTInventory";
    }
}
