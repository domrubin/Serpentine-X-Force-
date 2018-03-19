using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	/*public float m_DampTime = 0.2f;                 
	public float m_ScreenEdgeBuffer = 4f;           
	public float m_MinSize = 6.5f;                  
	public GameObject P1;
	public GameObject P2;


	/*[HideInInspector]*/ /*public Transform[] m_Targets; 
	
	
	private Camera m_Camera;                        
	private float m_ZoomSpeed;                      
	private Vector3 m_MoveVelocity;                 
	private Vector3 m_DesiredPosition;              
	

	private void Awake()
	{
		m_Camera = GetComponent<Camera>();
	}
	
	
	private void FixedUpdate()
	{
		Move();
		Zoom();
	}
	
	
	private void Move()
	{
		FindAveragePosition();
		
		transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
	}
	
	
	private void FindAveragePosition()
	{
		Vector3 averagePos = new Vector3((P1.transform.position.x + P2.transform.position.x)/2, (P1.transform.position.y + P2.transform.position.y)/2, 0);
		int numTargets = 0;
	
		
		averagePos = transform.position;
		
		m_DesiredPosition = averagePos;
	}
	
	
	private void Zoom()
	{
		float requiredSize = FindRequiredSize();
		m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
	}
	
	
	private float FindRequiredSize()
	{
		Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);
		
		float size = 0f;
			
	
			
			Vector3 desiredPosToTarget = averagepos - desiredLocalPos;
			
			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));
			
			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
		
		size += m_ScreenEdgeBuffer;
		
		size = Mathf.Max(size, m_MinSize);
		
		return size;
	}
	
	
	public void SetStartPositionAndSize()
	{
		FindAveragePosition();
		
		transform.position = m_DesiredPosition;
		
		m_Camera.orthographicSize = FindRequiredSize();
	}
*/
}
