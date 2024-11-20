using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eionith.ChartFormat
{
    public interface IChartElement {}
    public class ChartReader : MonoBehaviour
    {
        public List<IChartElement> ParseChartFile(string filePath)
        {
            List<IChartElement> chartElements = new List<IChartElement>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();

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
                        // if (line.StartsWith("Note"))
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
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error parsing chart file: {ex.Message}");
            }

            return chartElements;
        }
    }
}