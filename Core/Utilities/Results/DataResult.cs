public class DataResult<T>: Result, IDataResult<T>{

    public DataResult(T data, bool status, String Mess ): base(status, Mess){

        Data= data;
    }

    public DataResult(T data, bool status): base(status){

        Data=data;

    }

    public T Data { get; }

}

    