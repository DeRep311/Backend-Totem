public class ErrorDataResult<T> : DataResult<T>
{
       public ErrorDataResult(string message, T data) : base(data, false, message)
        {
        }

        public ErrorDataResult() : base(default, false)
        {

        }
     

   
}