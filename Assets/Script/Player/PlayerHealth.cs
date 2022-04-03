using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float health;
    //public GameObject GOplayer;
    SpriteRenderer compRnd;
    public Material matWhite;
    Material matDefault;
    //public GameObject GOfireflyLight;
    public PManagmentHealth HealthManager;
    PlayerAnimation anim;
    public PauseControl PauseControl;
    CharacterSfx sfx;
    public GameObject prefabDeath;

    void Awake()
    {
        compRnd = GetComponent<SpriteRenderer>();
        matDefault = compRnd.material;
        anim = GetComponent<PlayerAnimation>();
        health = maxHealth;
        sfx = GetComponentInChildren<CharacterSfx>();
    }
    private void Start()
    {
        UpdateHealth();
        PauseControl.playerIsDead = false;
    }
    void TakeDamage(int amount)
    {
        //Instantiate(hurtSound, transform.position, Quaternion.identity);
        health -= amount;
        UpdateHealth();
        //StartCoroutine(ExecutePlayerFlash());
        compRnd.material = matWhite;
        anim.Squash();
        sfx.PlayHurt();
        //FindObjectOfType<HitStop>().Stop(0.06f);
        //FindObjectOfType<HitStop>().Stop(0.05f);
        StartCoroutine(WaitForIFrames());

        //UpdateHealthUI(health);
        //hurtAnim.SetTrigger("hurt");
        if (health <= 0)
        {
            Death();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GreenGlow")
        {
            TakeDamage(1);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }
    IEnumerator WaitForIFrames()
    {
        while (Time.timeScale != 1.0f)
            yield return null;//wait for hit stop to end
        compRnd.material = matDefault;
        StartCoroutine(InvFrame());      
        //Instantiate(breakPrefab, transform.position, Quaternion.identity);
    }
    private IEnumerator InvFrame()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        compRnd.color = new Color(1f, 1f, 1f, 0.75f);
        //GOfireflyLight.SetActive(false);

        yield return new WaitForSeconds(0.75f);

        Physics2D.IgnoreLayerCollision(8, 9, false);
        compRnd.color = new Color(1f, 1f, 1f, 1f);
        //GOfireflyLight.SetActive(true);
    }
    void Death()
    {
        Destroy(gameObject);
        PauseControl.playerIsDead = true;
        PauseControl.DeathPanel();
        Instantiate(prefabDeath, transform.position, Quaternion.identity);
    }
    void UpdateHealth()
    {
        HealthManager.UpdateHealthUI(health, maxHealth);
    }
    public void GainHealth()
    {
        health = 10;
        UpdateHealth();
    }
}
