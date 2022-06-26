namespace iman.Result
{
    public class PagedResult<T> : Result<T>
    {

        public PagedResult(T value) : base(value)
        {
            
        }
        
        public long PageNumber { get; private set; }
        public long PageSize { get; private set; }

        public long TotalPages => TotalRecords / PageSize;
        public long TotalRecords { get; private set; }
        

        public PagedResult<T> WithPageSize(long pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public PagedResult<T> WithPageNumber(long pageNumber)
        {
            PageNumber = pageNumber;
            return this;
        }

        public PagedResult<T> WithTotalRecords(long totalRecords)
        {
            TotalRecords = totalRecords;
            return this;
        }
        
    }
}