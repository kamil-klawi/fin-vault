namespace SharedLibrary.Common.Security
{
    public class Permissions
    {
        public class Accounts
        {
            public const string CanAccountsView = "permissions.accounts.view";
            public const string CanAccountsManage = "permissions.accounts.manage";
            public const string CanAccountsCreate = "permissions.accounts.create";
            public const string CanAccountsClose = "permissions.accounts.close";
        }

        public class Transactions
        {

            public const string CanTransactionsView = "permissions.transactions.view";
            public const string CanTransactionsExport = "permissions.transactions.export";
        }

        public class Transfers
        {
            public const string CanTransfersInitiate = "permissions.transfers.initiate";
            public const string CanTransfersApprove = "permissions.transfers.approve";
            public const string CanTransfersCancel = "permissions.transfers.cancel";
        }
    }
}
