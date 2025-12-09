using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    public float sessionDuration = 60f;

    [Header("References")]
    public TargetSpawner targetSpawner;
    public GameObject startMenu;        // prefab StartMenu di scene
    public HUDController hud;           // script HUD yang akan kita buat di bawah

    [Header("Audio")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioClip hitClip;

    private float timeRemaining;
    private int hits;
    private int shots;
    private bool isPlaying;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // Jika mau GameManager tidak hancur ketika ganti scene:
        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StopSession();
    }

    void Update()
    {
        if (!isPlaying) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0f)
        {
            timeRemaining = 0f;
            EndSession();
        }

        if (hud != null)
        {
            hud.UpdateHUD(hits, shots, timeRemaining);
        }
    }

    public void StartSession()
    {
        hits = 0;
        shots = 0;
        timeRemaining = sessionDuration;
        isPlaying = true;

        if (startMenu != null) startMenu.SetActive(false);
        if (targetSpawner != null) targetSpawner.enabled = true;

        if (bgmSource != null && !bgmSource.isPlaying)
        {
            bgmSource.loop = true;
            bgmSource.Play();
        }

        if (hud != null)
        {
            hud.UpdateHUD(hits, shots, timeRemaining);
        }
    }

    public void EndSession()
    {
        isPlaying = false;

        if (targetSpawner != null) targetSpawner.enabled = false;

        if (startMenu != null)
        {
            startMenu.SetActive(true);
        }
    }

    public void StopSession()
    {
        isPlaying = false;
        timeRemaining = 0f;

        if (targetSpawner != null) targetSpawner.enabled = false;
        if (startMenu != null) startMenu.SetActive(true);

        if (hud != null)
        {
            hud.UpdateHUD(hits, shots, timeRemaining);
        }
    }

    public void RegisterShot()
    {
        shots++;
        if (hud != null)
        {
            hud.UpdateHUD(hits, shots, timeRemaining);
        }
    }

    public void RegisterHit()
    {
        hits++;

        if (sfxSource != null && hitClip != null)
        {
            sfxSource.PlayOneShot(hitClip);
        }

        if (hud != null)
        {
            hud.UpdateHUD(hits, shots, timeRemaining);
        }
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }
}
