public class Father : MonoBehaviour
{
    protected virtual void Start()
    {
        stats.StartValues();
        
        animController = GetComponent<GenericAnim>();
    }
}


public class Son : Father
{
    protected override void Start()
    {
        base.Start();

        currentPos = GetComponentInParent<Area>().numArea;
    }
}
