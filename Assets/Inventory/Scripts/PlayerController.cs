using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private Transform _gun;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnSpeed = 10f;
    public List<BulletType> bulletTypes = new List<BulletType>();
    private int currentBulletIndex = 0; 



    private Rigidbody _rbBullet;
    private Rigidbody _rbPlayer;

    void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Shoot();
        SwitchBullet();
    }

    void SwitchBullet()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentBulletIndex++;
            if (currentBulletIndex >= bulletTypes.Count)
            {
                currentBulletIndex = 0;
            }
        }
      
    }
    private void  Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * _moveSpeed * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            _rbPlayer.MovePosition(_rbPlayer.position + movement);
            // –ассчитывает и устанавливает новую ротацию
            Quaternion newRotation = Quaternion.LookRotation(movement);
            _rbPlayer.MoveRotation(Quaternion.Slerp(_rbPlayer.rotation, newRotation, _turnSpeed * Time.deltaTime));
        }
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentBullet = Instantiate(bulletTypes[currentBulletIndex].bulletPrefab, _gun.position, _gun.rotation);
            _rbBullet = currentBullet.GetComponent<Rigidbody>();
            _rbBullet.AddForce(_gun.right * _bulletSpeed, ForceMode.Impulse);
            Destroy(currentBullet, 2);
        }
    }
}
