using System.Collections;
using UnityEngine;

public class SpawnerRandom : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array objek yang akan di-spawn.
    public float minY = 0.0f; // Batas bawah posisi Y spawn.
    public float maxY = 5.0f; // Batas atas posisi Y spawn.
    public int numberOfObjectsToSpawn = 10;
    public float minSpawnDelay = 1.0f;
    public float maxSpawnDelay = 3.0f;

    // Probabilitas munculnya objek 0, objek 1, dan objek 2.
    public float[] probabilities = { 0.4f, 0.3f, 0.3f };

    // Kecepatan masing-masing objek.
    public float[] objectSpeeds = { 2.0f, 3.0f, 4.0f };

    void Start()
    {
        StartCoroutine(SpawnObjectsCoroutine());
    }

    IEnumerator SpawnObjectsCoroutine()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

            GameObject objectToInstantiate = null;

            // Pilih objek dengan probabilitas yang sesuai.
            float randomValue = Random.value;
            float cumulativeProbability = 0;
            int chosenIndex = -1;

            for (int j = 0; j < probabilities.Length; j++)
            {
                cumulativeProbability += probabilities[j];
                if (randomValue <= cumulativeProbability)
                {
                    chosenIndex = j;
                    break;
                }
            }

            if (chosenIndex != -1)
            {
                objectToInstantiate = objectsToSpawn[chosenIndex];
                GameObject spawnedObject = Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);

                Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
                if (rb == null)
                {
                    rb = spawnedObject.AddComponent<Rigidbody2D>();
                }

                rb.gravityScale = 0f;

                // Set kecepatan objek sesuai dengan indeks objek yang di-spawn.
                if (chosenIndex < objectSpeeds.Length)
                {
                    rb.velocity = new Vector2(objectSpeeds[chosenIndex], 0f);
                }
                else
                {
                    // Jika Anda kehabisan kecepatan dalam array, Anda dapat melakukan sesuatu yang sesuai, misalnya, menggunakan kecepatan default.
                    rb.velocity = new Vector2(2.0f, 0f);
                }
            }

            float nextSpawnTime = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(nextSpawnTime);
        }
    }
}