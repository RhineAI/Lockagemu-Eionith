using System.Collections.Generic;
using UnityEngine;

namespace Eionith.ChartFormat
{
    public class ChartLoader : MonoBehaviour
    {
        public TextAsset chartFile; 
        public static ChartLoader instance; 
        public string folder; // From id (like arcaea)

        private void Awake() 
        {
            instance = this;
        }

        public void Start()
        {
            // Load the Chart File (.txt)
            chartFile = Resources.Load<TextAsset>(folder + "/easy");
            if (chartFile != null)
            {
                // Debug log untuk memeriksa isi dari chartFile.text
                Debug.Log("Chart file loaded successfully!");
                Debug.Log("Chart file content: " + chartFile.text); // Menampilkan isi file

                ChartReader chartReader = new ChartReader();
                // Mengirim konten file ke ChartReader
                List<IChartElement> chartElements = chartReader.ParseChartFile(chartFile.text);
                Debug.Log("Parsed chart elements: " + chartElements.Count); // Menampilkan jumlah elemen yang diparsing

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

