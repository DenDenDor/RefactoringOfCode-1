using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    [SerializeField] private int _spawnRadius;
    [SerializeField] private float _spawnColdownMaximum = 2f;
    [SerializeField] GameObject[] _monster;

    private float _spawnColdown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnColdown > 0)
        _spawnColdown -= Time.deltaTime;
        if (_spawnColdown <= 0)
            SpawnMinions();
    }

    private void SpawnMinions() {
        _spawnColdown = _spawnColdownMaximum;

        Vector3 currentPosition = transform.position;
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-_spawnRadius, _spawnRadius), 5, Random.Range(-_spawnRadius, _spawnRadius));
        GameObject randomMonster = _monster[Random.Range(0, _monster.Length)];

        var enemy = Instantiate(randomMonster, randomSpawnPosition + currentPosition, randomMonster.transform.rotation);
    }
}
