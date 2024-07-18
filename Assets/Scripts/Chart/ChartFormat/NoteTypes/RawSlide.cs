namespace Eionith.ChartFormat
{
    public class RawSlide : RawEvents
    {
        // NOT PRETTY SURE
        /* 
            #Extended Class from RawEvents
                Examples : Slide((StartTiming), (XPosition));
                           Slide(71524, );
        */
        public float XPosition { get; set; }
    }
}