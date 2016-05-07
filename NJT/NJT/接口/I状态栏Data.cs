namespace NJT.接口
{
    public interface I状态栏Data<T>
    {
        T 标识 { get; set; }
        dynamic 数据 { get; set; }
    }

    public interface I状态栏Data : I状态栏Data<string>
    {

    }
}
