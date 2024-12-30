using UnityEngine;
using Eionith.ChartFormat;

namespace Eionith.Ultilities {
    public class SongInfo : MonoBehaviour
    {
        public static SongInfo instance;
        public string SongId;
        public string SongName;
        public string Artist;
        public float bpm = 1;

        void Awake()
        {
            instance = this;
            FileReader.Folder = SongId;
        }
    }  
}
