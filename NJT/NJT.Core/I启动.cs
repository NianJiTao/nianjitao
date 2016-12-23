namespace NJT.Core

{
    public interface I启动
    {
        bool Is启动 { get; }
        void 启动();
        void 停止();
    }

    public class 启动1 : I启动
    {
        public bool Is启动 { get; private set; }


        public void 启动()
        {
            if (Is启动) return;
            Is启动 = true;
        }


        public void 停止()
        {
            Is启动 = false;
        }
    }
}