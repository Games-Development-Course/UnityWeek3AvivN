using UnityEngine;

public class LaserShooter : ClickSpawner
{
    public TurboFire turbo;
    public TripleShot tripleShot;

    [SerializeField]
    private int pointsToAdd = 1;

    [SerializeField]
    private NumberField scoreField;

    protected override GameObject spawnObject()
    {
        if (tripleShot != null && tripleShot.IsActive())
        {
            ShootTriple();
            return null;
        }

        return ShootSingle();
    }

    private GameObject ShootSingle()
    {
        GameObject obj = base.spawnObject();
        RegisterHit(obj);
        return obj;
    }

    private void ShootTriple()
    {
        float centerAngle = transform.eulerAngles.z;
        float leftAngle = centerAngle + 45f;
        float rightAngle = centerAngle - 45f;

        GameObject mid = base.spawnObject();
        SetLaserDirection(mid, centerAngle);
        RegisterHit(mid);

        GameObject left = base.spawnObject();
        SetLaserDirection(left, leftAngle);
        RegisterHit(left);

        GameObject right = base.spawnObject();
        SetLaserDirection(right, rightAngle);
        RegisterHit(right);
    }

    private void SetLaserDirection(GameObject laser, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        Vector3 dir = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * -1f;

        Mover mover = laser.GetComponent<Mover>();
        if (mover != null)
        {
            mover.SetVelocity(dir * 10f);
        }

        laser.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }

    private void RegisterHit(GameObject obj)
    {
        DestroyOnTrigger2D d = obj.GetComponent<DestroyOnTrigger2D>();
        if (d != null)
        {
            d.onHit += AddScore;
        }
    }

    private void AddScore()
    {
        scoreField.AddNumber(pointsToAdd);
        ScoreManager.instance.AddScore(pointsToAdd);

        if (turbo != null)
        {
            turbo.AddPoint();
        }
    }

    public void ManualFire()
    {
        spawnObject();
    }
}
