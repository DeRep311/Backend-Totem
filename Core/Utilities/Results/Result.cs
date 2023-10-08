public class Result : IResult
{


    public Result( bool status, String Mess){

        Message= Mess;
        Success= status;

    }
    public Result(bool success)
        {
            Success = success;
           
        }


    public bool Success{get;}
    public string Message{get;} 
}