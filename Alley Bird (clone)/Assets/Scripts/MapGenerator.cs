/*
*	TickLuck
*	All rights reserved
*/
using UnityEngine;

/// <summary>
/// Generation works by Devide and Conquere idea,
/// generator instantiates obj and child it,
/// when the game just begins there is only one generator
/// but later num of generators changes and generation happens as a
/// recursion proccess via all child generators
/// </summary>
public class MapGenerator : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private readonly float TEMPLATE_HIGHT = 24.42f;
    [HideInInspector] public bool _isOnCreate = false;
    [HideInInspector] public bool _isOnDestroy = false;
    private GameObject cityInstance = null;
    private static bool _firstIteration = false;
    #endregion

    #region UnityMethods

    private void Start()
    {
        if (!_firstIteration)
        {
            ClearCity();
            GenerateCity();
        }

        // set to null so when generator is just instantiated
        // nothing to destroy and ClearCity() terminates
        //cityInstance = null;
    }

    #endregion

    public void GenerateCity()
    {
        int rand = Random.Range(0, objectsToSpawn.Length);
        cityInstance = Instantiate(objectsToSpawn[rand], transform.position, Quaternion.identity);
        cityInstance.transform.parent = gameObject.transform;
    }

    public void ClearCity()
    {
        _firstIteration = false;

        if (cityInstance != null)
        {
            Debug.Log("Cleared");
            Destroy(cityInstance);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + TEMPLATE_HIGHT / 2), new Vector3(1f, TEMPLATE_HIGHT));
    }
}
