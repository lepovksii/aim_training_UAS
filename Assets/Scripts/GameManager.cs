using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float sessionDuration = 60f;

    public TargetSpawner targetSpawner;
    public GameObject startMenu;
    public HUDController hud;

    [Header("AI System")]
    public AIAnalyzer analyzer;
    public AIDifficultyManager difficultyManager;
    public AIGrading grading;

    [Header("Audio")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioClip hitClip;

    private float timer;
    private int hits;
    private int shots;
    private bool isPlaying;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StopSession();
    }

    private void Update()
    {
        if (!isPlaying) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            EndSession();
        }

        hud.UpdateHUD(hits, shots, timer);
    }

    public void StartSession()
    {
        isPlaying = true;
        timer = sessionDuration;

        hits = 0;
        shots = 0;

        analyzer?.ResetStats();

        startMenu.SetActive(false);
        targetSpawner.enabled = true;

        if (bgmSource != null)
        {
            bgmSource.loop = true;
            bgmSource.Play();
        }

        hud.UpdateHUD(hits, shots, timer);
    }

    public void EndSession()
    {
        isPlaying = false;
        targetSpawner.enabled = false;

        startMenu.SetActive(true);

        if (grading != null)
            Debug.Log("Final Grade: " + grading.GetFinalGrade());
    }

    public void StopSession()
    {
        isPlaying = false;
        timer = 0;
        targetSpawner.enabled = false;
        startMenu.SetActive(true);

        hud.UpdateHUD(hits, shots, timer);
    }

    public void RegisterShot()
    {
        shots++;
        hud.UpdateHUD(hits, shots, timer);
    }

    public void RegisterHit()
    {
        hits++;
        if (sfxSource != null && hitClip != null)
            sfxSource.PlayOneShot(hitClip);

        hud.UpdateHUD(hits, shots, timer);
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }
}
