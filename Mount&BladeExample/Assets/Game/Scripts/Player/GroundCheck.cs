using UnityEngine;


public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private LayerMask groundLayer;

    public enum CurrentTerrain { GroundGrass, GroundMud, GroundSnow, GroundStones }
    public CurrentTerrain currentTerrain;

    private void Update()
    {
        CheckGroundLayer();
        RaycastHit[] hits = Physics.RaycastAll(this.transform.position, Vector3.down, 1f);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
            {
                currentTerrain = CurrentTerrain.GroundGrass;
            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Mud"))
            {
                currentTerrain = CurrentTerrain.GroundMud;
            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Snow"))
            {
                currentTerrain = CurrentTerrain.GroundSnow;
            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Rocks"))
            {
                currentTerrain = CurrentTerrain.GroundStones;
            }
        }

    }

    private void CheckGroundLayer()
    {
        isGrounded = Physics.CheckSphere(this.transform.position, 1f, groundLayer);

       
    }
}


