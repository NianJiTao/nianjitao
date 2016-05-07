namespace NJT.接口
{
    public interface I位置
    {
        /// <summary>
        ///     摘要:
        ///     获取或设置窗口左边缘相对于桌面的位置。
        ///     返回结果:
        ///     以逻辑单位（1/96 英寸）表示的窗口左边缘位置。
        /// </summary>
        /// <value>The 左.</value>
        double 左 { get; set; }

        /// <summary>
        ///     摘要:
        ///     获取或设置窗口上边缘相对于桌面的位置。
        ///     返回结果:
        ///     以逻辑单位（1/96 英寸）表示的窗口上边缘位置。
        /// </summary>
        /// <value>The 上.</value>
        double 上 { get; set; }

        /// <summary>
        ///     摘要:
        ///     获取或设置元素的建议宽度。
        ///     返回结果:
        ///     元素的宽度（采用与设备无关的单位（每个单位 1/96 英寸））。 默认值为 System.Double.NaN。 此值必须大于等于 0.0。 有关上限信息，请参见“备注”。
        /// </summary>
        /// <value>The 宽.</value>
        double 宽 { get; set; }

        /// <summary>
        ///     摘要:
        ///     获取或设置元素的建议高度。
        ///     返回结果:
        ///     元素的高度（采用与设备无关的单位（每个单位 1/96 英寸））。 默认值为 System.Double.NaN。 此值必须大于等于 0.0。 有关上限信息，请参见“备注”。
        /// </summary>
        /// <value>The 高.</value>
        double 高 { get; set; }
    }

    public class 位置1 : I位置
    {
        public double 左 { get; set; }
        public double 上 { get; set; }
        public double 宽 { get; set; }
        public double 高 { get; set; }
    }
}