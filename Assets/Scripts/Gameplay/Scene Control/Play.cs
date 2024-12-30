using UnityEngine;
using Eionith.ChartFormat;
using Eionith.Ultilities;

public class Play : MonoBehaviour
{
    public static Play instance;
    public GameObject beatline;
    public bool play;

    [SerializeField]
    [Range(1.0f, 7.0f)]
    public float speed;

    private float spawnInterval;
    private float timer;
    // private GameObject beatObjectPrefab; 

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        float bpm = SongInfo.instance.bpm;
        speed = Mathf.Min(speed, 7);
        Debug.Log($"Bpm : {bpm}");
        spawnInterval = 60f / bpm;

        timer = spawnInterval;
    }

    void Update()
    {
        if (!play)
        {
            // Start spawning beatlines based on BPM
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnBeatline();
                timer -= spawnInterval;
            }
        }
        else
        {
            float moveDistance = speed * Time.deltaTime;
            transform.position -= new Vector3(0f, 0f, moveDistance);

            // If beatline is a child object and should move with transform
            if (beatline != null)
            {
                beatline.transform.position -= new Vector3(0f, 0f, moveDistance);
            }        
        }
    }

    void SpawnBeatline()
    {
        Instantiate(beatline, transform.position + new Vector3(0f, 0f, timer), Quaternion.identity);
    }
}
