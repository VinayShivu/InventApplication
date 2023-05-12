namespace InventApplication.Domain.Helpers
{
    public static class Messages
    {
        #region Vendor
        public const string VendorRegisterSuccess = "Vendor added successfully";
        public const string VendorUpdateSuccess = "Vendor update successfully";
        public const string VendorDeleteSuccess = "Vendor delete successfully";
        public const string VendorRegisterError = "Error in adding Vendor";
        public const string VendorDeleteError = "Error in deleting Vendor";
        public const string VendorUpdateError = "Error in update Vendor";
        public const string VendorExists = "Vendor by this name already exists";
        public const string VendorNotExists = "Vendor does not exists";
        public const string InvalidVendorId = "Vendor by this Id not exists";
        public const string InvalidVendor = "Invalid Vendor";
        public const string CompanyNameRequired = "Company Name Required";
        public const string VendorGSTRequired = "Vendor GST% Required";
        public const string VendorPhoneRequired = "Vendor Phone Number Required";
        public const string VendorAddressRequired = "Vendor Address Required";
        public const string VendorPrimaryContactNameRequired = "Vendor Primary Contact Name Required";
        #endregion

        #region Buyer
        public const string BuyerRegisterSuccess = "Buyer added successfully";
        public const string BuyerUpdateSuccess = "Buyer update successfully";
        public const string BuyerDeleteSuccess = "Buyer delete successfully";
        public const string BuyerRegisterError = "Error in adding Buyer";
        public const string BuyerDeleteError = "Error in deleting Buyer";
        public const string BuyerUpdateError = "Error in update Buyer";
        public const string BuyerExists = "Buyer by this name already exists";
        public const string BuyerNotExists = "Buyer does not exists";
        public const string InvalidBuyerId = "Buyer by this Id not exists";
        public const string InvalidBuyer = "Invalid Buyer";
        #endregion

        #region User
        public const string NoData = "No Data Found";
        public const string UserExists = "User by this username already exists";
        public const string InvalidUsername = "Invalid username";
        public const string InvalidPassword = "Invalid password";
        public const string UserNameRequired = "User Name is required";
        public const string UserRoleRequired = "User Role is required";
        #endregion

        #region Items
        public const string ItemsRegisterSuccess = "Items added successfully";
        public const string ItemsUpdateSuccess = "Items update successfully";
        public const string ItemsDeleteSuccess = "Items delete successfully";
        public const string ItemsRegisterError = "Error in adding Items";
        public const string ItemsDeleteError = "Error in deleting Items";
        public const string ItemsUpdateError = "Error in update Items";
        public const string ItemsExists = "Items by this name already exists";
        public const string ItemsNotExists = "Items does not exists";
        public const string InvalidItemsId = "Items by this Id not exists";
        public const string InvalidItems = "Invalid Items";
        #endregion

        #region Token
        public const string InvalidToken = "Invalid refresh token";
        public const string InvalidUserClaimName = "Invalid User Claim Name";
        public const string TokenExpired = "Refresh token expired";
        public const string UserNotAuthorized = "User not Authorized";
        #endregion

        #region Validation
        public const string Min6Max150 = "Minimum of 6 and maximum of 150 characters allowed";
        public const string Min3Max150 = "Minimum of 3 and maximum of 150 characters allowed";
        public const string Min1Max150 = "Minimum of 1 and maximum of 150 characters allowed";
        public const string Min1Max64 = "Minimum of 1 and maximum of 64 characters allowed";
        public const string Min4Max360 = "Minimum of 4 and maximum of 360 characters allowed";
        public const string Min2Max32 = "Minimum of 2 and maximum of 32 characters allowed";
        public const string Max128 = "Maximum of 128 characters allowed";
        public const string PasswordRequired = "Password is required";
        public const string CurrentPasswordRequired = "Current password is required";
        public const string NewPasswordRequired = " New password is required";
        public const string ResetTokenRequired = "Reset Token is required";
        public const string InvalidEmail = "Invalid email address format";
        public const string InvalidPhoneNumber = "Invalid Phone Number";
        #endregion
    }
}
