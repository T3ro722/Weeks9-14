using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public TextMeshProUGUI powerupText;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMoveSystem player = FindObjectOfType<PlayerMoveSystem>();
        if (player == null) return;

        float dx = transform.position.x - player.transform.position.x;
        float dy = transform.position.y - player.transform.position.y;
        float dist = Mathf.Sqrt(dx * dx + dy * dy);

        if (dist < 1.0f)
        {
            Debug.Log("Touched player. Powerup status: " + player.powerUpActive);
            ActivatePowerup(player);
        }
    }

    public void ResetPowerup()
    {
        transform.position = originalPosition;
        gameObject.SetActive(true);
    }

    void ActivatePowerup(PlayerMoveSystem player)
    {
        if (!player.powerUpActive)
        {
            player.powerUpActive = true;

            // find all enemies and add powerup listener
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.OnPowerupStart();
            }

            StartCoroutine(PowerupTimer(player));
        }
    }
    IEnumerator PowerupTimer(PlayerMoveSystem playerScript)
    {
        powerupText.gameObject.SetActive(true);

        float countdown = 2f;
        while (countdown > 0)
        {
            powerupText.text = "Powerup: " + countdown.ToString("F1") + "s";
            yield return new WaitForSeconds(0.1f);
            countdown -= 0.1f;
        }

        powerupText.gameObject.SetActive(false);
        playerScript.powerUpActive = false;

        // announce to enemy that powerup ended
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.OnPowerupEnd();
        }

        gameObject.SetActive(false); // turn off powerup
    }
}
