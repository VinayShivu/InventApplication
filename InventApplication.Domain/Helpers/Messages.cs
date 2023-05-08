namespace InventApplication.Domain.Helpers
{
    public static class Messages
    {
        #region Supplier
        public const string SupplierRegisterSuccess = "Supplier added successfully";
        public const string SupplierUpdateSuccess = "Supplier update successfully";
        public const string SupplierDeleteSuccess = "Supplier delete successfully";
        public const string SupplierRegisterError = "Error in adding Supplier";
        public const string SupplierDeleteError = "Error in deleting Supplier";
        public const string SupplierUpdateError = "Error in update Supplier";
        public const string SupplierExists = "Supplier by this name already exists";
        public const string SupplierNotExists = "Supplier does not exists";
        public const string InvalidSupplierId = "Supplier by this Id not exists";
        public const string InvalidSupplier = "Invalid Supplier";
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
    }
}
