using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    private BanditController _banditController;
    // Start is called before the first frame update
    void Start()
    {
        _banditController = FindObjectOfType<BanditController>();
        StartCoroutine(BombCoroutine(5f));
    }
    
    
    private IEnumerator BombCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Explode();
        _banditController.CantPlantBomb = false;
        Destroy(gameObject);
    }

    private void Explode()
    {
        var colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one, 1f);
        foreach (var cldr in colliders)
        {
            if (cldr.gameObject.layer == 6)
            {
                Destroy(cldr.gameObject);
            }

            if (cldr.gameObject.layer == 3)
            {
                SceneManager.LoadScene("Scenes/SampleScene");
            }
        }
    }
}
