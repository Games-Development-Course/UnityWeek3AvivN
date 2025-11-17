using UnityEngine;

public class LaserShooter : ClickSpawner
{
    public TurboFire turbo;
    public TripleShot tripleShot;

    [SerializeField] int pointsToAdd = 1;
    [SerializeField] private NumberField scoreField;

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
        Vector3 pos = transform.position;

        // זוויות
        float centerAngle = transform.eulerAngles.z;        // באמצע
        float leftAngle = centerAngle + 45f;              // שמאל
        float rightAngle = centerAngle - 45f;              // ימין

        // --- אמצעי ---
        GameObject mid = base.spawnObject();
        SetLaserDirection(mid, centerAngle);
        RegisterHit(mid);


        // --- שמאל ---
        GameObject left = base.spawnObject();
        SetLaserDirection(left, leftAngle);
        RegisterHit(left);


        // --- ימין ---
        GameObject right = base.spawnObject();
        SetLaserDirection(right, rightAngle);
        RegisterHit(right);

    }

    private void SetLaserDirection(GameObject laser, float angle)
    {
        // הפיכת זווית לרדיאנים
        float rad = angle * Mathf.Deg2Rad;

        // בניית וקטור תנועה
        Vector3 dir = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * -1f;
        // הגדרת מהירות
        Mover mover = laser.GetComponent<Mover>();
        mover.SetVelocity(dir * 10f);   // 10f = מהירות, תשנה למה שבא לך

        // בונוס: לסובב ויזואלית
        laser.transform.rotation = Quaternion.Euler(0, 0, angle);
    }



    private void RegisterHit(GameObject obj)
    {
        DestroyOnTrigger2D d = obj.GetComponent<DestroyOnTrigger2D>();
        if (d)
            d.onHit += AddScore;
    }


    private void AddScore()
    {
        scoreField.AddNumber(pointsToAdd);
        ScoreManager.instance.AddScore(pointsToAdd);

        if (turbo != null)
            turbo.AddPoint();
    }

    public void ManualFire()
    {
        spawnObject();
    }
}
