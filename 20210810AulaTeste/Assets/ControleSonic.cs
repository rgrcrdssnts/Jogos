using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSonic : MonoBehaviour
{
    //variáveis criadas no escopo da classe, são chamadas de campos(fields)
    public LayerMask layerMascara;//para quais layer eu vou verificar a colisao
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");

        if (horz != 0)
        {
            GetComponent<Animator>().SetBool("CORRENDO", true);
            transform.Translate(0.75f * Time.deltaTime * horz, 0, 0);//faz o personagem andar
            if (horz < 0)
                transform.localScale = new Vector3(-1, 1, 1);//vira a sprite
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GetComponent<Animator>().SetBool("CORRENDO", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
            GetComponent<Animator>().SetTrigger("PULAR");
            GetComponent<Animator>().SetBool("NOCHAO", false);
        }


    }

    private void FixedUpdate()
    {

        // if (GetComponent<Animator>().GetBool("NOCHAO") == false)
        {
            Collider2D[] colisoes = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.09f, 0), 0.05f, layerMascara);
            Debug.Log(colisoes.Length);
            if (colisoes.Length > 0)
                GetComponent<Animator>().SetBool("NOCHAO", true);
            else
                GetComponent<Animator>().SetBool("NOCHAO", false);

        }
        //
    }
    //Isso aqui é só para debug!!!!
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, 0.09f, 0), 0.05f);
    }

    //tosquera: Vamos acertar isso na segunda parte da aula
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     GetComponent<Animator>().SetBool("NOCHAO", true);
    // }


}
