namespace Eionith.ChartFormat
{
    public class RawTap : RawEvents
    {
        /* 
            #Extended Class from RawEvents
                Examples : Note((StartTiming), (LanePosition));
                           Note(71524, 1-12(Default is 1-4));
        */
        public int LanePosition { get; set; }
    }
}