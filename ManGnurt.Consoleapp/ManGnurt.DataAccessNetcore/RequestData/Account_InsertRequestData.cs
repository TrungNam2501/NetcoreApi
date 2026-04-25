namespace ManGnurt.DataAccessNetcore.RequestData
{
    public class Account_GetListRequestData
    {
        public int? AccountID { get; set; }
        public string? UserName { get; set; }
    }

    public class Account_InsertRequestData
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
    }

    public class Account_UpdateRequestData : Account_InsertRequestData
    {
        public int AccountID { get; set; }
    }

    public class Account_DeleteRequestData
    {
        public int AccountID { get; set; }
    }
}
