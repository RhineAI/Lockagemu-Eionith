using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface IChartElement 
{
    public int StartTiming { get; set; }
    public int EndTiming { get; set; }
}
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

                    if (line.StartsWith("LaneRotation"))
                    {
                        // IChartElement laneRotation = ParseLaneRotation(line);
                        // if (laneRotation != null)
                        // {
                        //     chartElements.Add(laneRotation);
                        // }
                    }
                    // else if (line.StartsWith("Hold"))
                    // {
                    //     IChartElement hold = ParseHold(line);
                    //     if (hold != null)
                    //     {
                    //         chartElements.Add(hold);
                    //     }
                    // }
                    // else if (line.StartsWith("Catch"))
                    // {
                    //     IChartElement catch = ParseCatch(line);
                    //     if (catch != null)
                    //     {
                    //         chartElements.Add(catch);
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
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error parsing chart file: {ex.Message}");
        }

        return chartElements;
    }

    // private LaneRotation ParseLaneRotation(string line)
    // {
    //     try
    //     {
    //         string trimmedLine = line.Substring("LaneRotation(".Length);
    //         trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);

    //         string[] parts = trimmedLine.Split(',');

    //         if (parts.Length == 4)
    //         {
    //             int startTiming = int.Parse(parts[0].Trim());
    //             int endTiming = int.Parse(parts[1].Trim());
    //             int shiftAmount = int.Parse(parts[2].Trim());
    //             float rotationSpeed = float.Parse(parts[3].Trim());

    //             return new LaneRotation(startTiming, endTiming, shiftAmount, rotationSpeed);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Debug.LogError($"Error parsing Rotation '{line}': {ex.Message}");
    //     }

    //     return null;
    // }

    // private Hold ParseHold(string line)
    // {
    //     try
    //     {
    //         string trimmedLine = line.Substring("Hold(".Length);
    //         trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);

    //         string[] parts = trimmedLine.Split(',');

    //         if (parts.Length == 5)
    //         {
    //             int startTiming = int.Parse(parts[0].Trim());
    //             int endTiming = int.Parse(parts[1].Trim());
    //             int startLanePosition = int.Parse(parts[2].Trim());
    //             int endLanePosition = int.Parse(parts[3].Trim());
    //             string type = parts[4].Trim(); // (ease-in, ease-out, ease-in-out, linear)

    //             return new Hold(startTiming, endTiming, startLanePosition, endLanePosition);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Debug.LogError($"Error parsing Hold '{line}': {ex.Message}");
    //     }

    //     return null;
    // }

    // private Catch ParseCatch(string line)
    // {
    //     try
    //     {
    //         string trimmedLine = line.Substring("Catch(".Length);
    //         trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);

    //         string[] parts = trimmedLine.Split(',');

    //         if (parts.Length == 5)
    //         {
    //             int startTiming = int.Parse(parts[0].Trim());
    //             int position = int.Parse(parts[1].Trim());  // Z location (Free spawn, Y must be 0, Max Z is between -60f to 60f)

    //             return new Catch(startTiming, endTiming, startLanePosition, endLanePosition);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Debug.LogError($"Error parsing Catch '{line}': {ex.Message}");
    //     }

    //     return null;
    // }

    // private Note ParseNote(string line)
    // {
    //     try
    //     {
    //         string trimmedLine = line.Substring("Note(".Length);
    //         trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);

    //         string[] parts = trimmedLine.Split(',');

    //         if (parts.Length == 2)
    //         {
    //             int startTiming = int.Parse(parts[0].Trim());
    //             int lanePosition = int.Parse(parts[1].Trim());

    //             return new Note(startTiming, lanePosition);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Debug.LogError($"Error parsing Note '{line}': {ex.Message}");
    //     }

    //     return null;
    // }

    // private Flick ParseFlick(string line)
    // {
    //     try
    //     {
    //         string trimmedLine = line.Substring("Flick(".Length);
    //         trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);

    //         string[] parts = trimmedLine.Split(',');

    //         if (parts.Length == 2)
    //         {
    //             int startTiming = int.Parse(parts[0].Trim());
    //             int lanePosition = int.Parse(parts[1].Trim());

    //             return new Flick(startTiming, lanePosition);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Debug.LogError($"Error parsing Flick '{line}': {ex.Message}");
    //     }

    //     return null;
    // }

    // private DirectionalFlick ParseDirectionalFlick(string line)
    // {
    //     try
    //     {
    //         string trimmedLine = line.Substring("FlickDirection(".Length);
    //         trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);

    //         string[] parts = trimmedLine.Split(',');

    //         if (parts.Length == 2)
    //         {
    //             int startTiming = int.Parse(parts[0].Trim());
    //             int lanePosition = int.Parse(parts[1].Trim());
    //             string type = parts[2].Trim(); // (Left/Right)

    //             return new DirectionalFlick(startTiming, lanePosition);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Debug.LogError($"Error parsing Flick '{line}': {ex.Message}");
    //     }

    //     return null;
    // }
}
