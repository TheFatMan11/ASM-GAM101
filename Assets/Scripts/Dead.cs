using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject DeathScene;
   private Vector3 RespawnPoint;
    public static int ran;
    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = transform.position;
        ran = 0;
    }

    private void Update()
    {




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moster") || collision.CompareTag("bay")||collision.CompareTag("fire"))
        {
            if (animator.GetBool("runDead"))
            {
                animator.SetBool("runDead", false);
            }
            UI_Mananger.mang_--;
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("isDead");
        }
        else if (collision.CompareTag("dauQuaiVat"))
        {
            Destroy(collision.transform.parent.gameObject);
            AudioManager.instance.PlaySFX("hit");
            UI_Mananger.diem_ += 300;
            ran++;
            Debug.Log("Ddang chay");
        }

    }

    public void reSpawn()
    {
        if (UI_Mananger.mang_ <= 0)
        {
            DeathScene.SetActive(true);
            Time.timeScale = 0f;
            UI_Mananger.mang_ = 3;
            UI_Mananger.diem_ = 0;
        }
        else
        {
            transform.position = RespawnPoint;
            rb.bodyType = RigidbodyType2D.Dynamic;
            AudioManager.instance.StopSound();
           
        }
        animator.SetBool("runDead", true);
        Debug.Log("ddang cnau");
    }
    public void soundDead()
    {
        if (!animator.GetBool("runDead"))
        {
            AudioManager.instance.PlaySFX("dead");
        }

    }


}
