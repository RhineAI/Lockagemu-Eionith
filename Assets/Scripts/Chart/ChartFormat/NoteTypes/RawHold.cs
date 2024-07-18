namespace Eionith.ChartFormat
{
    public class RawHold : RawEvents
    {
        /* 
            #Extended Class from RawEvents
                Examples : Hold((StartTiming), (EndTiming), (StartLane), (EndLane), (Type));
                           Hold(0, 1000, 1-12(Default is 1-4), 1-12(Default is 1-4), [Ease-in, Ease-out, Ease-in-out, Linear]);
        */
        public int EndTiming { get; set; }
        public int StartLane { get; set; }
        public int EndLane { get; set; }
        public string Type { get; set; }
    }
}