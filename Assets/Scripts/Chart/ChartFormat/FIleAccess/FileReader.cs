using System.IO;
using UnityEngine;
using System.Collections.Generic;
using Eionith.Ultilities;

namespace Eionith.ChartFormat
{
    public class FileReader : MonoBehaviour
    {
        public static FileReader instance;
        public static string Folder;
        private string chartText;
        private AudioClip song;
        private Texture2D thumb;
        // public ChartReader chartReader;
         public List<RawTap> Taps = new List<RawTap>();
        public List<RawHold> Holds = new List<RawHold>();
        public List<RawFlick> Flicks = new List<RawFlick>();
        public List<RawSideFlick> SideFlicks = new List<RawSideFlick>();
        public List<RawSlide> Slides = new List<RawSlide>();
        public List<RawLaneRotation> LaneRotations = new List<RawLaneRotation>();

        void Awake()
        {
            instance = this;
        }
        void Start()
        {
            string Folder = SongInfo.instance.SongId;
            string FolderPath = Path.Combine(Application.dataPath, "Songs" , Folder); 
            // Debug.Log($"Folder : {Folder}");
            // Debug.Log($"Folder Path : {FolderPath}");
            ChartFiles(FolderPath);
            ReadSongFile(FolderPath);
            ReadThumbFile(FolderPath);
        }

        public void ChartFiles(string folderPath)
        {
            string easyPath = Path.Combine(folderPath, "easy.txt");
            string normalPath = Path.Combine(folderPath, "normal.txt");
            string expertPath = Path.Combine(folderPath, "expert.txt");
            
            // Debug.Log(easyPath);
            if(File.Exists(easyPath)) {
                ReadChartFile(easyPath);
            }
            else {
                Debug.Log("File not found");
            }
            if(File.Exists(normalPath)) {
                ReadChartFile(normalPath);
            }
            else {
                Debug.Log("File not found");
            }
            if(File.Exists(expertPath)) {
                ReadChartFile(expertPath);
            }
            else {
                Debug.Log("File not found");
            }
        }

        public void ReadChartFile(string path)
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { '(', ',', ')' }, System.StringSplitOptions.RemoveEmptyEntries);
                if (parts[0] == "tap")
                {
                    RawTap tap = new RawTap
                    {
                        StartTiming = int.Parse(parts[1]),
                    };
                    Taps.Add(tap);
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

        void ReadSongFile(string folderPath)
        {
            string wav = Path.Combine(folderPath, "song.wav");
            string ogg = Path.Combine(folderPath, "song.ogg");
            if (File.Exists(wav))
            {
                // StartCoroutine(LoadAudioClip(songFilePath));
            }
            else
            {
                Debug.LogError("song.wav file not found at path: " + wav);
            }
            
            if (File.Exists(ogg))
            {
                // StartCoroutine(LoadAudioClip(songFilePath));
            }
            else
            {
                Debug.LogError("song.ogg file not found at path: " + ogg);
            }
        }

        void ReadThumbFile(string folderPath)
        {
            string thumbFilePath = Path.Combine(folderPath, "thumb.jpg");
            if (File.Exists(thumbFilePath))
            {
                byte[] thumbData = File.ReadAllBytes(thumbFilePath);
                thumb = new Texture2D(2, 2);
                thumb.LoadImage(thumbData);
                Debug.Log("Thumb file loaded with size: " + thumb.width + "x" + thumb.height);
            }
            else
            {
                Debug.LogError("thumb.jpg file not found at path: " + thumbFilePath);
            }
        }

        // private IEnumerator LoadAudioClip(string path)
        // {
        //     using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + path, AudioType.WAV))
        //     {
        //         yield return www.SendWebRequest();

        //         if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        //         {
        //             Debug.LogError(www.error);
        //         }
        //         else
        //         {
        //             song = DownloadHandlerAudioClip.GetContent(www);
        //             Debug.Log("Song file loaded with length: " + song.length + " seconds");
        //         }
        //     }
        // }
    }
}