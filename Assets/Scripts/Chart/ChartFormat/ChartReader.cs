using System;
using System.Collections.Generic;
using UnityEngine;

namespace Eionith.ChartFormat
{
    public interface IChartElement {}
    public class ChartReader : MonoBehaviour
    {
        public List<IChartElement> ParseChartFile(string fileContent)
        {
            List<IChartElement> chartElements = new List<IChartElement>();
            string[] lines = fileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var originalLine in lines)
            {
                string line = originalLine.Trim();

                // if (line.StartsWith("LaneRotation"))
                // {
                //     IChartElement laneRotation = ParseLaneRotation(line);
                //     if (laneRotation != null)
                //     {
                //         chartElements.Add(laneRotation);
                //     }
                // }
                // else if (line.StartsWith("Hold"))
                // {
                //     IChartElement hold = ParseHold(line);
                //     if (hold != null)
                //     {
                //         chartElements.Add(hold);
                //     }
                // }
                // else if (line.StartsWith("Slide"))
                // {
                //     IChartElement slide = ParseSlide(line);
                //     if (slide != null)
                //     {
                //         chartElements.Add(slide);
                //     }
                // }
                // else if (line.StartsWith("Note"))
                // {
                //     IChartElement note = ParseNote(line);
                //     if (note != null)
                //     {
                //         chartElements.Add(note);
                //     }
                // }
                // else if (line.StartsWith("Flick"))
                // {
                //     IChartElement flick = ParseFlick(line);
                //     if (flick != null)
                //     {
                //         chartElements.Add(flick);
                //     }
                // }
                // else if (line.StartsWith("FlickDirection"))
                // {
                //     IChartElement directionalFlick = ParseDirectionalFlick(line);
                //     if (directionalFlick != null)
                //     {
                //         chartElements.Add(directionalFlick);
                //     }
                // }
            }

            return chartElements;
        }
    }
}