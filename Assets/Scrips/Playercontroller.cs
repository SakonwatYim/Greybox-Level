using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    PlayerSpeed playerSpeed;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float fireRate = 0.2f;

    float nextFireTime = 0f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = GetComponent<PlayerSpeed>();
    }

    void Update()
    {
        Move();
        LookAtMouse();
        Shoot();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        rb.linearVelocity = new Vector3(move.x * playerSpeed.moveSpeed, rb.linearVelocity.y, move.z * playerSpeed.moveSpeed);
    }

    void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);

        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 mouseWorld = ray.GetPoint(distance);

            Vector3 dir = mouseWorld - transform.position;
            dir.y = 0;

            transform.forward = dir;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);

            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.linearVelocity = transform.forward * bulletSpeed;

            Debug.DrawRay(firePoint.position, transform.forward * 5f, Color.red, 1f);
        }
    }
}