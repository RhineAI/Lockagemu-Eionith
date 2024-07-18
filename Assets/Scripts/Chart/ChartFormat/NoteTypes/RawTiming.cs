namespace Eionith.ChartFormat
{
    public class RawTiming : RawEvents
    {
        /* 
            #Extended Class from RawEvents
                Examples : Timing((StartTiming), (BPM));
                           Timing(0, 200.00);
        */
        public float BPM { get; set; }
    }
}