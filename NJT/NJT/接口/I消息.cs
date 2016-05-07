namespace NJT.接口
{
    public interface I消息
    {
        string 显示文字 { get; set; }
        int 显示毫秒 { get; set; }

    }


    public class 消息1 : I消息
    {
        public 消息1()
        {
            显示文字 = "成功";
            显示毫秒 = 500;
        }
       
        public string 显示文字 { get; set; }
        public int 显示毫秒 { get; set; }
    }

}
