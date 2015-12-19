var theRotor : Transform;
private var RotorActive : boolean = true;
yield rotateMillRotor();

function Start () {
	theRotor = transform.Find("mill/head/rotor");
}

function rotateMillRotor () {
	while (RotorActive) {
		yield WaitForSeconds (0);
		theRotor.Rotate(Time.deltaTime*-8, 0, 0);
	}
}
