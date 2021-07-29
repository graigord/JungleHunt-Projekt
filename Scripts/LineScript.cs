using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public Transform ropePrefab;
    private float lastRopeX = 5.0f;
    private float levelEndLength = 0.0f;

    private const float ropeJointXOffset = 1.2f;
    private const float ropeJointYOffset = 1.0f;

    const float ropeY = 1.0f;
    private int ropeMinDistance;
    private int ropeMaxDistance;
    private int numberOfRopes;
    private const int ropeMinSpeed = 1;
    private const int ropeMaxSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        ropeMinDistance = 2;
        ropeMaxDistance = 3;
        numberOfRopes = 10;
        GenerateRopes();
    }
void GenerateRopes()
    {
        lastRopeX = ropeJointXOffset;
        var ropeDistance = 0;
        for (int n = 0; n < numberOfRopes; n++)
        {
            var rope = Instantiate(ropePrefab, new Vector3(lastRopeX + ropeDistance, ropeY, 27), Quaternion.identity);

            // We also need to move the connected anchor of the first element's hinge joint to the correct place
            var firstElement = rope.Find("rope_1");
            firstElement.gameObject.GetComponent<HingeJoint2D>().connectedAnchor
                = new Vector2(lastRopeX + ropeDistance - ropeJointXOffset, ropeY + ropeJointYOffset);

            // Set a random speed (gravity scale) for each rope
            var ropeSpeed = Random.Range(ropeMinSpeed, ropeMaxSpeed);
            for (int i = 0; i < rope.childCount; i++)
            {
                var ropeElement = rope.GetChild(i);
                ropeElement.gameObject.GetComponent<Rigidbody2D>().gravityScale = ropeSpeed;
            }

            lastRopeX += ropeDistance;
            ropeDistance = Random.Range(ropeMinDistance, ropeMaxDistance);
        }
    }
}
