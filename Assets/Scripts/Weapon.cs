using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private GameObject shootEffectPrefab;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shooting();
        }

        //FollowTheCursor();
    }


    private void Shooting()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        Instantiate(shootEffectPrefab, transform.position, transform.rotation);

    }


    // To Make The Fire Point Look At The Mouse Cursor
    //private void FollowTheCursor()
    //{


    //    Vector3 mousePosition = Camera.Main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3 direction = (mousePosition - transform.position);

    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    //}
}
