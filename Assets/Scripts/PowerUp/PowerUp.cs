using UnityEngine;

public class PowerUp: MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);   // מוחק אחרי 3 שניות
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            TripleShot triple = col.GetComponent<TripleShot>();
            if (triple != null)
                triple.ActivateTripleShot();

            Destroy(gameObject);
        }
    }

}
