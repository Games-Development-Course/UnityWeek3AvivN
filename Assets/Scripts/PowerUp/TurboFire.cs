using UnityEngine;
using TMPro;

public class TurboFire : MonoBehaviour
{
    [Header("Settings")]
    public int pointsRequired = 5;
    public float turboDuration = 5f;
    public float turboFireRate = 0.15f; // ירי מהיר יותר

    [Header("References")]
    public LaserShooter laserShooter;
    public TextMeshProUGUI turboText;

    private int currentPoints = 0;
    private bool turboActive = false;
    private float turboTimer = 0f;
    private float lastShotTime = 0f;

    private void Start()
    {
        turboText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (turboActive)
        {
            turboTimer -= Time.deltaTime;

            if (Input.GetKey(KeyCode.Space) && Time.time > lastShotTime + turboFireRate)
            {
                laserShooter.ManualFire();
                lastShotTime = Time.time;
            }

            if (turboTimer <= 0f)
            {
                turboActive = false;
                currentPoints = 0;
                turboText.gameObject.SetActive(false);
            }
        }
    }

    public void AddPoint()
    {
        if (turboActive)
        {
            return;
        }

        currentPoints++;

        if (currentPoints >= pointsRequired)
        {
            ActivateTurbo();
        }
    }

    private void ActivateTurbo()
    {
        turboActive = true;
        turboTimer = turboDuration;
        turboText.gameObject.SetActive(true);
        turboText.text = "Turbo mode available! Hold SPACE for automatic fire!";
    }
}
