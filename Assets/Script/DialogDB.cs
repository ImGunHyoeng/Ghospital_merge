using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class DialogDB : ScriptableObject
{
	public List<DialogDBEntity> Sheet1; // Replace 'EntityType' to an actual type that is serializable.
	//이름은 엑셀의 시트 명과 동일하게 설정되어있음
}
