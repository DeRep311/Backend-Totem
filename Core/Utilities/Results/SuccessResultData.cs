public class SuccessResultData<T> : DataResult<T>
{
    public SuccessResultData(T data, string Mess) : base(data, true, Mess)
    {




    }

     public SuccessResultData(T data) : base(data, true)
    {




    }
}