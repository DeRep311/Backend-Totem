public class SuccessResult : Result
{
    public SuccessResult(string Mess) : base(true, Mess)
    {
    

    }

    public SuccessResult(): base(true){
        
    }

   
}