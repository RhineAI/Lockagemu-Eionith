namespace Eionith.ChartFormat
{
    public class RawFlick : RawEvents
    {
        /* 
            #Extended Class from RawEvents
                Examples : Flick((StartTiming), (LanePosition));
                           Flick(71524, 1-12(Default is 1-4));
        */
        public float LanePosition { get; set; }
    }
}