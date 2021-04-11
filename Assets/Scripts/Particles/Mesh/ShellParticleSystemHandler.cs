using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellParticleSystemHandler : MonoBehaviour
{
    public static ShellParticleSystemHandler Instance { get; private set; }

    private MeshParticleSystem meshParticleSystem;
    private List<Single> singleList;

    private void Awake()
    {
        Instance = this;
        meshParticleSystem = GetComponent<MeshParticleSystem>();
        singleList = new List<Single>();
    }

    private void Update()
    {
        for (int i=0; i<singleList.Count; i++)
        {
            Single single = singleList[i];
            single.Update();

            if(single.IsMovementComplete())
            {
                singleList.RemoveAt(i);
                i--;
            }
        }
    }

    public void SpawnShell (Vector3 position, Vector3 direction)
    {
        singleList.Add(new Single(position, direction, meshParticleSystem));
    }

    /*
     * *Represents a single dirt particle
     * **/
    private class Single
    {
        private MeshParticleSystem meshParticleSystem;
        private Vector3 position;
        private Vector3 direction;
        private int quadIndex;
        private Vector3 quadSize;
        private float moveSpeed;
        private float rotation;


        public Single(Vector3 position, Vector3 direction, MeshParticleSystem meshParticleSystem)
        {
            this.position = position;
            this.direction = direction;
            this.meshParticleSystem = meshParticleSystem;

            quadSize = new Vector3(0.05f, 0.1f);
            moveSpeed = Random.Range(3f, 9f);
            rotation = Random.Range(0, 360f);


            quadIndex = meshParticleSystem.AddQuad(position, rotation, quadSize, true, 0);
        }

        public void Update()
        {
            position += direction * moveSpeed * Time.deltaTime;
            rotation += 360f * (moveSpeed / 10f) * Time.deltaTime;


            meshParticleSystem.UpdateQuad(quadIndex, position, rotation, quadSize, true, 0);

            float slowDownFactor = 3.5f;
            moveSpeed -= moveSpeed * slowDownFactor * Time.deltaTime;
        }

        public bool IsMovementComplete ()
        {
            return moveSpeed < 0.1f;
        }
    }
}
