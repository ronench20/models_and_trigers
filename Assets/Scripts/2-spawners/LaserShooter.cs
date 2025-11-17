using UnityEngine;
using UnityEngine.UI;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter: ClickSpawner {
    [SerializeField]
    [Tooltip("How many points to add to the shooter, if the laser hits its target")]
    int pointsToAdd = 1;
    [SerializeField] Text ammoText;
    [SerializeField] int ammo;
    [SerializeField] float cooldown = 0.5f;

    // A reference to the field that holds the score that has to be updated when the laser hits its target.
    private NumberField scoreField;  

    private void Start() {
        scoreField = GetComponentInChildren<NumberField>();
        if (!scoreField)
            Debug.LogError($"No child of {gameObject.name} has a NumberField component!");
    }

    private void AddScore()
    {
        scoreField.AddNumber(pointsToAdd);
    }

    protected override GameObject spawnObject() {
        
        if (timer < cooldown)
        {
            return null;
        }
        timer = 0f;
        
        if (ammo > 0)
        {
            ammo--;
            ammoText.text = ammo.ToString();
        }
        else
        {
            return null;
        }

        
        GameObject newObject = base.spawnObject();  // base = super
        DestroyOnTrigger2D newObjectDestroyer = newObject.GetComponent<DestroyOnTrigger2D>();
        if (newObjectDestroyer)
            newObjectDestroyer.onHit += AddScore;
        return newObject;
    }
}
