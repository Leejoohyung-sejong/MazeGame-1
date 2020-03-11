using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offset = Vector3.zero;
    GameObject t_clone;
    Rigidbody[] t_rigids;

    public void Explosion()
    {
        t_clone = Instantiate(m_goPrefab, transform.position, Quaternion.identity);
        t_rigids = t_clone.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < t_rigids.Length; i++)
        {
            t_rigids[i].AddExplosionForce(m_force, transform.position + m_offset, 10f);
            Invoke("TriggerOn", 3f);
            InvokeRepeating("fadeDebris", 3f, 0.2f);
        }
        gameObject.SetActive(false);
        
        
        //Destroy(t_clone, 5f);
    }
    void TriggerOn()
    {
        for(int i=0; i<t_rigids.Length;i++)
            t_rigids[i].GetComponent<BoxCollider>().isTrigger = true;
    }
    void fadeDebris()
    {

        t_clone.transform.position -= Vector3.up * 0.3f * Time.deltaTime;
        //for (int i = 0; i < 10; i++)
        //{
        //    transform.Translate(transform.up * -2f * Time.deltaTime);
        //}
    }
}
