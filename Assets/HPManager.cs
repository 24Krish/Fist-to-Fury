using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public float StartingHealth;
    private float CurrentHealth;
    public Image HPImage;
    private CharacterMovement Move;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartingHealth;
        Move = GetComponent <CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float Damage)
    {
        StartCoroutine(DisableMovement());
        CurrentHealth -= Damage;
        HPImage.fillAmount = Mathf.Clamp01(CurrentHealth);
        Debug.Log(CurrentHealth);
    }

    private IEnumerator DisableMovement()
    {
        Move.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Move.enabled = true;
    }
}
