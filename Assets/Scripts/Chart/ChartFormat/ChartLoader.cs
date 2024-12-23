using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eionith.ChartFormat
{
    public class ChartLoader : MonoBehaviour
    {
        public string folder; // From id (like arcaea)

        private void Start()
        {
            // Load the Chart File (.txt)
            TextAsset chartFile = Resources.Load<TextAsset>(folder + "/expert");

            if (chartFile != null)
            {
                ChartReader chartReader = new ChartReader();
                List<IChartElement> chartElements = chartReader.ParseChartFile(chartFile.text);

                foreach (var element in chartElements)
                {
                    Debug.Log(element.ToString());
                }
            }
            else
            {
                Debug.LogError("Chart file not found!");
            }
        }
    }
}

