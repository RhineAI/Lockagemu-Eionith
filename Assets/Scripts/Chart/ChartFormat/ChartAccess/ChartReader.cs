using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eionith.ChartFormat
{
    public class ChartReader : MonoBehaviour
    {
        // public string chartFilePath;
        public List<RawTap> Taps = new List<RawTap>();
        public List<RawHold> Holds = new List<RawHold>();
        public List<RawFlick> Flicks = new List<RawFlick>();
        public List<RawSideFlick> SideFlicks = new List<RawSideFlick>();
        public List<RawSlide> Slides = new List<RawSlide>();
        public List<RawLaneRotation> LaneRotations = new List<RawLaneRotation>();

        void Start()
        {
            // ReadChartFile(chartFilePath);
        }

        public void ReadChartFile(string path)
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { '(', ',', ')' }, System.StringSplitOptions.RemoveEmptyEntries);
                if (parts[0] == "note")
                {
                    RawTap note = new RawTap
                    {
                        StartTiming = int.Parse(parts[1]),
                    };
                    Taps.Add(note);
                }
                else if (parts[0] == "hold")
                {
                    RawHold hold = new RawHold
                    {
                        StartTiming = int.Parse(parts[1]),
                        EndTiming = int.Parse(parts[2]),
                        StartLane = int.Parse(parts[3]),
                        EndLane = int.Parse(parts[4]),
                        Type = parts[5]
                    };
                    Holds.Add(hold);
                }
                else if (parts[0] == "flick")
                {
                    RawFlick flick = new RawFlick
                    {
                        StartTiming = int.Parse(parts[1]),
                        LanePosition = int.Parse(parts[2])
                    };
                    Flicks.Add(flick);
                }
                else if (parts[0] == "sideflick")
                {
                    RawSideFlick sideflick = new RawSideFlick
                    {
                        StartTiming = int.Parse(parts[1]),
                        LanePosition = int.Parse(parts[2]),
                        Type = parts[3]
                    };
                    SideFlicks.Add(sideflick);
                }
                else if (parts[0] == "slide")
                {
                    RawSlide slide = new RawSlide
                    {
                        StartTiming = int.Parse(parts[1]),
                        XPosition = float.Parse(parts[2]),
                    };
                    Slides.Add(slide);
                }
                else if (parts[0] == "lanerotation")
                {
                    RawLaneRotation lanerotation = new RawLaneRotation
                    {
                        StartTiming = int.Parse(parts[1]),
                        ShiftCount = int.Parse(parts[2]),
                        RotationSpeed = float.Parse(parts[3])
                    };
                    LaneRotations.Add(lanerotation);
                }
            }
        }
    }
}