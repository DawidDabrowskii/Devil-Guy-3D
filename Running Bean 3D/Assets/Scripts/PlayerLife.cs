using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    [SerializeField] AudioSource deathSound;

    // Gdy gracz upadnie z platformy, tj. pozycja bedzie ponizej -15.5 uruchomic metode 'die'
    private void Update()

        // poprzez '&& !dead' w tym miejscu sprawiamy, ze gracz 'umiera' raz, a nie co klatke przez czas opisany ponizej
    {
        if (transform.position.y < -14.2f && !dead)
        {
            Die();
        }
    }
    // smierc gracza poprzez kolizje z tag. "EnemyBody".
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyBody"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    // Nie robimy zwyklego 'destroy', poniewaz bedziemy ladowac script ponownie. Invoke powoduje reset sceny w z delay'em
    private void Die()
    {
        Invoke(nameof(ReloadLevel), 1f);
        dead = true;
        deathSound.Play();
    }

    // Ponownie zaladowanie sceny 
    private void ReloadLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
