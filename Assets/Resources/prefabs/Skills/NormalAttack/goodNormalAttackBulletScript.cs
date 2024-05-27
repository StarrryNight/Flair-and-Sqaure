using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodNormalAttackBulletScript : MonoBehaviour
{
    public int damage;
    Animation anim;
    public int velocity;
    public Quaternion dir;
    damageManager damageManager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        //anim.Play("goodNormalAttackAnimation");
        dir = transform.rotation;
        StartCoroutine(wait());
        damageManager = GameObject.Find("damage manager").GetComponent<damageManager>();
        damage = damageManager.normalDamage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * velocity * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hitted");
        Destroy(this.gameObject);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }
}
