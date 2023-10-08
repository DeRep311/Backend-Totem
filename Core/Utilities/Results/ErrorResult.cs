class ErrorResult : Result
{
    public ErrorResult( string Mess) : base(false, Mess)
    {

    }

    public ErrorResult() : base(false)
    {

    }
}