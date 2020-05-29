
[CreateAssetMenu(fileName = "TargetCard", menuName = "ScriptableObjects/TargetCard", order = 1)]
public class TargetCard : ScriptableObject
{
    public int id;

    [Tooltip("Nome da carta")]
    public string cardName;

    public Sprite img;

    [TextArea(3,10)]
    [Tooltip("Descrição")]
    public string description;

    //private bool completed = false;

    [Tooltip("Recursos necessarios para a conclusão da carta")]
    public ResourceData[] materials;

    [Tooltip("Quanto tempo leva para concluir a carta")]
    public float productionDuration = 10;

    [Tooltip("Quantidade de talento que se recompensa a procução")]
    public int talentReward;

    //Events
    public event Action OnCardCompleted;    // Not Used

    public void CardCompleted() // Not Used
    {
        Debug.LogWarning("Change this later"); // Change Singleton to use this event later

        OnCardCompleted?.Invoke();

        //completed = true;
    }
}
