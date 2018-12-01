using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaChanger : MonoBehaviour
{
	public float speed;
	public Color start, end;

	private Text named;
	private Color target;
	
	void Start ()
	{
		named = GetComponent<Text>();
		target = start;
	}
	
	void Update ()
	{
		named.color = Vector4.MoveTowards(named.color, target, Time.deltaTime * speed);		
	}

	public void FromHeightToLow()
	{
		target = end;
	}
	
	public void FromLowToHeight()
	{
		target = start;
	}
}
