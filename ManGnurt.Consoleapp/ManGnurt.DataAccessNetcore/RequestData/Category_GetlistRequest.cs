namespace ManGnurt.DataAccessNetcore.RequestData
{
    public class Category_GetlistRequest
    {
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }

    public class Category_InsertRequestData
    {
        public string? CategoryName { get; set; }
    }

    public class Category_UpdateRequestData : Category_InsertRequestData
    {
        public int CategoryID { get; set; }
    }

    public class Category_DeleteRequestData
    {
        public int CategoryID { get; set; }
    }
}
