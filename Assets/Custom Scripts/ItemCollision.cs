using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemCollision : MonoBehaviour
{
    public GameObject spawnThis;
    bool pulloLevyllä;
    ParticleSystem luigit;

    private void Start()
    {
        luigit = spawnThis.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.name == "PoleCollider" && collision.gameObject.name == "PolettiIcon")
        {
            InteractionSuccess();

            print("Ole hyvä :)");
            Destroy(gameObject);

        }

        if (gameObject.name == "ChemCollider" && collision.gameObject.name == "LasipulloIcon")
        {
            InteractionSuccess();

            print("Jee pullo");
            pulloLevyllä = true;

        }

        void InteractionSuccess()
        {
            spawnThis.SetActive(true);
            collision.gameObject.SetActive(false);
        }

        if (pulloLevyllä == true)
        {
            Mixology();
        }

        void Mixology()
        {
            if (gameObject.name == "ChemCollider" && collision.gameObject.name == "LimuIcon")
            {
                collision.gameObject.SetActive(false);
                luigit.Play(true);
                print("Limu miksattu");
            }
        }
    }
}
