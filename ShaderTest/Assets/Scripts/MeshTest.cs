using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  

//最经典的Mesh 简单用法
public class MeshTest : MonoBehaviour {  
	//用于存储绘制三角形的顶点坐标  
	private Vector3[] vertices;  
	//用于记录绘制三角形所需要的顶点ID顺序  
	private int[] triangles;  
	//记录顶点数  
	private int count=0;  
	//定义Mesh  
	private Mesh mesh;  
	//定义一个链表用于记录所有点的坐标  
	private List<Vector3> list;  

	private MeshFilter mMeshFilter = null;
	private MeshRenderer mMeshRenderer = null;
	public GameObject obj = null;

	void Start ()
	{  
		mMeshFilter = obj.GetComponent<MeshFilter> ();  
		mMeshRenderer = obj.GetComponent<MeshRenderer> ();  

		list = new List<Vector3> ();  
		mesh = mMeshFilter.mesh;  
		mesh.Clear ();

		mMeshRenderer.material.color = Color.green;    
		mMeshRenderer.material.shader = Shader.Find ("Standard");          
	}

	void Update () 
	{  
		//点击鼠标左键  
		if (Input.GetMouseButton(0))  
		{      
			//顶点数+1  
			count++;  
			Vector3 screenPos = Input.mousePosition;
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			Debug.Log (pos);
			//将获得的鼠标坐标转换为世界坐标，然后添加到list链表中。  
			list.Add(pos);  
		}

		//如果顶点数>=3，那么就开始渲染Mesh  
		if (count >= 3)  
		{  
			//三角形个数  
			int triangles_count = count - 2;
			//根据顶点数来计算绘制出三角形的所以顶点数  
			triangles = new int[3 * triangles_count];  
			//根据顶点数来创建记录顶点坐标  
			vertices = new Vector3[count];  
			//将链表中的顶点坐标赋值给vertices  
			for (int i = 0; i < count; i++)  
			{  
				vertices[i] = list[i];
			}  
				 
			//根据三角形的个数，来计算绘制三角形的顶点顺序（索引）  
			for (int i = 0; i < triangles_count; i++)  
			{  
				//这个算法好好琢磨一下吧~  
				triangles[3 * i] = 0;  
				triangles[3 * i + 1] = i + 1;  
				triangles[3 * i + 2] = i + 2;  
			}  
			//设置顶点坐标  
			mesh.vertices = vertices;  
			//设置顶点索引  
			mesh.triangles = triangles;  
		}
	}  
}  