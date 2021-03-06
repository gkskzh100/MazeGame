﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoint : MonoBehaviour {

	public Transform[] points;
	public GameObject monster;
	public float createTime = 5.0f;
	private int[] pointIndex = new int[10] {0,0,0,0,0,0,0,0,0,0};

	// Use this for initialization
	void Start () {
		points = GameObject.Find("MonsterPoint").GetComponentsInChildren<Transform>();
		StartCoroutine(CreateMonster());
	}
	
	IEnumerator CreateMonster() {
		for(int i = 0; i <10; i++) {
			int index = Random.Range(1,points.Length);
			pointIndex[i] = index;

			for(int j = 0; j<i; j++) {
				if(index == pointIndex[j]) {
					while (true)
					{
						index = Random.Range(1,points.Length);
						pointIndex[i] = index;
						if(index != pointIndex[j]) break;
					}
				}
			}
			
			Instantiate(monster,points[index].position,Quaternion.Euler(0,-180,0));

			yield return new WaitForSeconds(createTime);
		}
	}
}