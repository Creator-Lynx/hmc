using System.Collections;
using UnityEngine;

public class OldShoot : IShootable
{
    GameObject _bulletPrefab;
    Transform _transform, player;
    Enemy myEnemy;
    bool alreadyShoot = false, isFirst = true;
    float firstDelay, coolDown;
    public OldShoot(Transform transform, GameObject bullet, float FirstShootDelay = 0.5f, float CoolDown = 0.5f)
    {
        _transform = transform;
        _bulletPrefab = bullet;
        myEnemy = _transform.GetComponent<Enemy>();
        firstDelay = FirstShootDelay;
        coolDown = CoolDown;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Shoot()
    {
        if (alreadyShoot) return;
        alreadyShoot = true;
        if (isFirst)
        {
            myEnemy.StartCoroutine(FirstShootDelay());
        }
        else
        {
            myEnemy.StartCoroutine(CoolDownDelay());
        }

    }

    IEnumerator FirstShootDelay()
    {
        yield return new WaitForSeconds(firstDelay);
        if (player)
            CreateBullet((player.transform.position - _transform.position).normalized);
        alreadyShoot = false;
        isFirst = false;
    }
    IEnumerator CoolDownDelay()
    {
        yield return new WaitForSeconds(coolDown);
        if (player)
            CreateBullet((player.transform.position - _transform.position).normalized);
        alreadyShoot = false;
    }

    void CreateBullet(Vector2 direction)
    {
        MonoBehaviour.Instantiate(_bulletPrefab, _transform.position + (Vector3)direction, Quaternion.identity).
        GetComponent<BulletBehavior>().SetDirection(direction, DamageTaker.Type.player);

    }
}
