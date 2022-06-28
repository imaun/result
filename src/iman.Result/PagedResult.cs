namespace iman.Library.Results
{
    public class PagedResult<T> : Result<T>
    {

        public PagedResult(T value) : base(value)
        {
            
        }
        
        public long PageNumber { get; private set; }
        public long PageSize { get; private set; }

        public long TotalPages => TotalCount / PageSize;
        public long TotalCount { get; private set; }
        

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

        public PagedResult<T> WithTotalCount(long totalRecords)
        {
            TotalCount = totalRecords;
            return this;
        }
        
    }
}