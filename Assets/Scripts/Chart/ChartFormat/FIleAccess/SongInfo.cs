using UnityEngine;
using Eionith.ChartFormat;
// {
    public class SongInfo : MonoBehaviour
    {
        public static SongInfo instance;
        public string SongId;
        public string SongName;
        public string Artist;
        public int BPM;

        void Awake()
        {
            instance = this;
            FileReader.Folder = SongId;
        }
    }  
// }
    
