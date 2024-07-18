using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace Eionith.ChartFormat
{
    public class FileReader : MonoBehaviour
    {
        public static FileReader instance;
        public static string Folder;
        private string chartText;
        private AudioClip song;
        private Texture2D thumb;
        public ChartReader chartReader;

        void Awake()
        {
            instance = this;
        }
        void Start()
        {
            string Folder = SongInfo.instance.SongId;
            string folderPath = Path.Combine(Application.dataPath, "Songs" , Folder); 
            Debug.Log($"Folder : {Folder}");
            Debug.Log($"FolderPath : {folderPath}");
            ChartFiles(folderPath);
            ReadSongFile(folderPath);
            ReadThumbFile(folderPath);
        }

        public void ChartFiles(string folderPath)
        {
            string easyPath = Path.Combine(folderPath, "easy.txt");
            string normalPath = Path.Combine(folderPath, "normal.txt");
            string expertPath = Path.Combine(folderPath, "expert.txt");

            if (File.Exists(easyPath))
            {
                chartReader.ReadChartFile(easyPath);
            }
            else
            {
                Debug.LogWarning("Easy chart file not found: " + easyPath);
            }

            if (File.Exists(normalPath))
            {
                chartReader.ReadChartFile(normalPath);
            }
            else
            {
                Debug.LogWarning("Normal chart file not found: " + normalPath);
            }

            if (File.Exists(expertPath))
            {
                chartReader.ReadChartFile(expertPath);
            }
            else
            {
                Debug.LogWarning("Expert chart file not found: " + expertPath);
            }
        }

        void ReadSongFile(string folderPath)
        {
            string songFilePath = Path.Combine(folderPath, Folder.ToLower() + ".wav");
            if (File.Exists(songFilePath))
            {
                // StartCoroutine(LoadAudioClip(songFilePath));
            }
            else
            {
                Debug.LogError("song.wav file not found at path: " + songFilePath);
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