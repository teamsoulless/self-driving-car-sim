using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using SocketIO;
using UnityStandardAssets.Vehicles.Car;
using System;
using System.Security.AccessControl;

public class CommandServer : MonoBehaviour
{
    public const int k_OutputImageWidth = 1920;
    public const int k_OutputImageHeight = 1200;

    public CarRemoteControl CarRemoteControl;
	public Camera FrontFacingCamera;
	private SocketIOComponent _socket;
	private CarController _carController;

	// Use this for initialization
	void Start ()
	{
		_socket = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		_socket.On ("open", OnOpen);
		_socket.On ("steer", OnSteer);
		_socket.On ("manual", onManual);
		_carController = CarRemoteControl.GetComponent<CarController> ();
        if (MenuOptions.resolution == 1)
        {
            FrontFacingCamera.targetTexture = new RenderTexture(k_OutputImageWidth, k_OutputImageHeight, 24);
        } else {
            FrontFacingCamera.targetTexture = new RenderTexture(320, 160, 24);
        }
    }

    // Update is called once per frame
    void Update ()
	{
	}

	void OnOpen (SocketIOEvent obj)
	{
		Debug.Log ("Connection Open");
		EmitTelemetry (obj);
	}

	//
	void onManual (SocketIOEvent obj)
	{
		EmitTelemetry (obj);
	}

	void OnSteer (SocketIOEvent obj)
	{
		JSONObject jsonObject = obj.data;
		//    print(float.Parse(jsonObject.GetField("steering_angle").str));
		CarRemoteControl.SteeringAngle = float.Parse (jsonObject.GetField ("steering_angle").str);
		CarRemoteControl.Acceleration = float.Parse (jsonObject.GetField ("throttle").str);
		EmitTelemetry (obj);
	}

	void EmitTelemetry (SocketIOEvent obj)
	{
		UnityMainThreadDispatcher.Instance ().Enqueue (() => {
			print ("Attempting to Send...");
			// send only if it's not being manually driven
			if ((Input.GetKey (KeyCode.W)) || (Input.GetKey (KeyCode.S))) {
				_socket.Emit ("telemetry", new JSONObject ());
			} else {
				// Collect Data from the Car
				Dictionary<string, string> data = new Dictionary<string, string> ();
				data ["steering_angle"] = _carController.CurrentSteerAngle.ToString ("N4");
				data ["throttle"] = _carController.AccelInput.ToString ("N4");
				data ["speed"] = _carController.CurrentSpeed.ToString ("N4");
				data ["image"] = Convert.ToBase64String (CameraHelper.CaptureFrame (FrontFacingCamera));


				var positionStr = string.Format ("{0}:{1}:{2}",
					                             _carController.transform.position.x,
					                             _carController.transform.position.z,
					                             _carController.transform.position.y);
					
				var rotationStr = string.Format ("{0}:{1}:{2}",
					                              _carController.transform.rotation.eulerAngles.x,
					                              _carController.transform.rotation.eulerAngles.y,
					                              _carController.transform.rotation.eulerAngles.z);
					
				data ["position"] = positionStr;
				data ["rotation"] = rotationStr;


				_socket.Emit ("telemetry", new JSONObject (data));
			}
		});

		//    UnityMainThreadDispatcher.Instance().Enqueue(() =>
		//    {
		//      	
		//      
		//
		//		// send only if it's not being manually driven
		//		if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))) {
		//			_socket.Emit("telemetry", new JSONObject());
		//		}
		//		else {
		//			// Collect Data from the Car
		//			Dictionary<string, string> data = new Dictionary<string, string>();
		//			data["steering_angle"] = _carController.CurrentSteerAngle.ToString("N4");
		//			data["throttle"] = _carController.AccelInput.ToString("N4");
		//			data["speed"] = _carController.CurrentSpeed.ToString("N4");
		//			data["image"] = Convert.ToBase64String(CameraHelper.CaptureFrame(FrontFacingCamera));
		//			_socket.Emit("telemetry", new JSONObject(data));
		//		}
		//      
		////      
		//    });
	}
}