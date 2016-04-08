using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

struct TestStruct {
	public int patate;
}

class TestClass {
	public int patate;
}

public class struct_v_class : MonoBehaviour {
	[SerializeField] Text uiText;

	const int qty = 100000000;
	TestStruct[] structs = new TestStruct[qty];
	TestClass[] classes = new TestClass[qty];

	void Init()
	{
		for (int i = 0; i < qty; ++i) {
			structs[i] = new TestStruct();
		}	
		for (int i = 0; i < qty; ++i) {
			classes[i] = new TestClass();
		}
		uiText.text += Bench.Title("Structs vs class - Linear iteration.");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void DoStruct()
	{
		uiText.text += Bench.Start();
		for (int i = 0; i < qty; ++i) {
			structs[i].patate = 42;
			//structs[i].patate += 42;
		}
		uiText.text += Bench.End("Structs");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void DoClass()
	{
		uiText.text += Bench.Start();
		for (int i = 0; i < qty; ++i) {
			classes[i].patate = 42;
			//classes[i].patate += 42;
		}
		uiText.text += Bench.End("Classes");
	}

	void Awake()
	{
		Init();
	}
	void OnEnable()
	{
		DoStruct();
		DoClass();
	}
}
