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
        public const string InvalidCompanyName = "Invalid Company Name";
        public const string CompanyNameRequired = "Company Name Required";
        public const string VendorGSTRequired = "Vendor GST% Required";
        public const string VendorPhoneRequired = "Vendor Phone Number Required";
        public const string VendorAddressRequired = "Vendor Address Required";
        public const string VendorPrimaryContactNameRequired = "Vendor Primary Contact Name Required";
        #endregion

        #region Customer
        public const string CustomerRegisterSuccess = "Customer added successfully";
        public const string CustomerUpdateSuccess = "Customer update successfully";
        public const string CustomerDeleteSuccess = "Customer delete successfully";
        public const string CustomerRegisterError = "Error in adding Customer";
        public const string CustomerDeleteError = "Error in deleting Customer";
        public const string CustomerUpdateError = "Error in update Customer";
        public const string CustomerExists = "Customer by this name already exists";
        public const string CustomerNotExists = "Customer does not exists";
        public const string InvalidCustomerId = "Customer by this Id not exists";
        public const string InvalidCustomer = "Invalid Customer";
        public const string CustomerGSTRequired = "Customer GST% Required";
        public const string CustomerPhoneRequired = "Customer Phone Number Required";
        public const string CustomerAddressRequired = "Customer Address Required";
        public const string CustomerPrimaryContactNameRequired = "Customer Primary Contact Name Required";

        #endregion

        #region User
        public const string UserRegisterSuccess = "User added successfully";
        public const string UserRegisterError = "Error in adding User";
        public const string NoData = "No Data Found";
        public const string UserExists = "User by this username already exists";
        public const string InvalidUsername = "Invalid username";
        public const string InvalidPassword = "Invalid password";
        public const string InvalidEmail = "Invalid Email";
        public const string InvalidUserId = "Invalid User Id";
        public const string UserNameRequired = "User Name is required";
        public const string UserIdRequired = "User Id is required";
        public const string UserRoleRequired = "User Role is required";
        public const string UserNotFound = "User Not Found";
        public const string EmailSent = "Sent Reset Password Link to Email";
        public const string UserResetPasswordUpdateSuccess = "User Reset Password updated successfully";
        public const string UserResetPasswordUpdateError = "Error in resetting user password";
        public const string FailedPasswordResetEmail = "Failed to send password reset email";
        public const string UserChangePasswordSuccess = "User Changed Password successfully";
        public const string UserChangePasswordError = "Error in changeing user password";

        #endregion

        #region Items
        public const string ItemRegisterSuccess = "Item added successfully";
        public const string ItemUpdateSuccess = "Item updated successfully";
        public const string ItemDeleteSuccess = "Item deleted successfully";
        public const string ItemRegisterError = "Error in adding Item";
        public const string ItemDeleteError = "Error in deleting Item";
        public const string ItemUpdateError = "Error in update Item";
        public const string ItemInActivedSuccess = "Item InActivated successfully";
        public const string ItemInActivedError = " Error in InActivating Item";
        public const string ItemActivedSuccess = "Item Activated successfully";
        public const string ItemActivedError = " Error in Activating Item";
        public const string ItemExists = "Item by this name already exists";
        public const string ItemNotExists = "Item does not exists";
        public const string InvalidItemId = "Item by this Id not exists";
        public const string InvalidItemName = "Invalid Item Name";
        public const string ItemNameRequired = "Item Name Required";
        public const string UnitRequired = "Item Unit Required";
        public const string HSNRequired = "Item HSN Code Required";
        public const string SellingPriceRequired = "Item Selling Price Required";
        public const string SqlConnectionError = "Sql Connection Error";

        #endregion

        #region Token
        public const string InvalidToken = "Invalid refresh token";
        public const string InvalidUserClaimName = "Invalid User Claim Name";
        public const string TokenExpired = "Refresh token expired";
        public const string PasswordResetTokenExpired = "Invalid or Password Reset Token expired";
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
        public const string AccessTokenRequired = "Access Token is required";
        public const string RefreshTokenRequired = "Refresh Token is required";
        public const string InvalidEmailFormat = "Invalid email address format";
        public const string InvalidPhoneNumber = "Invalid Phone Number";
        #endregion
    }
}
