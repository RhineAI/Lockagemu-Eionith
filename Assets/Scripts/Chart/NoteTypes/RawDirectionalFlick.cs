namespace Eionith.ChartFormat
{
    public class DirectionalFlick : RawEvents
    {
        /* 
            #Extended Class from RawEvents
                Examples : DirectionalFlick((StartTiming), (LanePosition), (Type));
                           DirectionalFlick(71524, 1-12(Default is 1-4), Left/Right);
        */
        public int LanePosition { get; set; }
        public string Type { get; set; }
    }
}