namespace Eionith.ChartFormat
{
    public class RawLaneRotation : RawEvents
    {
        /* 
            #Extended Class from RawEvents
                Examples : LaneRotation((StartTiming), (ShiftCount), (RotationSpeed));
                           LaneRotation(71524, 1-12, 0.00-60.00);
        */
        public int ShiftCount { get; set; }
        public float RotationSpeed { get; set; }
    }
}