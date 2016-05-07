namespace NJT.接口
{
    public interface I名称
    {
        string 名称 { get; set; }
    }

    public class 名称1 : I名称
    {
        public string 名称 { get; set; }

        public 名称1()
        {
        }
        public 名称1(string 名称cs)
        {
            this.名称 = 名称cs;
        }
    }
}