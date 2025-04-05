using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            ActivatePowerup(player);
        }
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

            Destroy(gameObject);
            StartCoroutine(PowerupTimer(player));
        }
    }
    IEnumerator PowerupTimer(PlayerMoveSystem playerScript)
    {
        yield return new WaitForSeconds(2f);

        playerScript.powerUpActive = false;

        // announce enemies that powerup stops
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.OnPowerupEnd();
        }
    }
}
