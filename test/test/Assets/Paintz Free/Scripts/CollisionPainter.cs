using UnityEngine;

public class CollisionPainter : MonoBehaviour
{
    public Brush brush;
    public bool RandomChannel = false;

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject abc;
        HandleCollision(collision);
        if(collision.gameObject.tag == "wall")
        {
            
            collision.transform.GetComponent<Cube>().Explosion();
            
            //GameObject deb = collision.transform.GetComponentInChildren<Cube>().gameObject;
            //Destroy(deb, 3f);
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        HandleCollision(collision);
    }

    private void HandleCollision(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            PaintTarget paintTarget = contact.otherCollider.GetComponent<PaintTarget>();
            if (paintTarget != null)
            {
                if (RandomChannel) brush.splatChannel = Random.Range(0, 4);
                PaintTarget.PaintObject(paintTarget, contact.point, contact.normal, brush);
            }
        }
    }
}