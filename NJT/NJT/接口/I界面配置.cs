namespace NJT.接口
{
    public interface I界面配置
    {
        string 标题 { get; set; }
        int 字体大小 { get; set; }
        string 主题 { get; set; }
    }


    public class 界面配置 : I界面配置
    {
        public string 标题 { get; set; }
        public int 字体大小 { get; set; }
        public string 主题 { get; set; }
    }
}