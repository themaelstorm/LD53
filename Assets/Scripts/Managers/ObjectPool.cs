using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    public IObjectPool<BulletAgent> BulletPool;
    public BulletAgent BulletPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        BulletPool = new ObjectPool<BulletAgent>(CreateBullet, GetBullet, ReleaseBullet, DestroyBullet);
    }


    private BulletAgent CreateBullet()
    {
        BulletAgent bullet = Instantiate(BulletPrefab);
        bullet.transform.SetParent(this.transform);

        return bullet;
    }

    private void DestroyBullet(BulletAgent obj)
    {
        Destroy(obj.gameObject);
    }

    private void ReleaseBullet(BulletAgent obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void GetBullet(BulletAgent obj)
    {
        obj.gameObject.SetActive(true);
    }

}